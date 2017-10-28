using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Audivel
{
    public partial class MainWindow : Form
    {
        private List<IAudioSessionControl2> sessionList;
        private IAudioSessionControl2 primarySourceSession = null;
        private IAudioSessionControl2 secondarySourceSession = null;
        private GlobalKeyboardHook _globalKeyboardHook;
        private bool queue = true;
        private int deltaMS;
        private DateTime lastKeyTime = DateTime.UtcNow;
        private List<int> pressedKeys = new List<int>(); 



        public MainWindow()
        {
            InitializeComponent();

            //This is basically a keylogger, but I swear it won't save shit.
            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            lastKeyTime = DateTime.UtcNow;
            Debug.WriteLine(lastKeyTime);
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown && !pressedKeys.Contains(e.KeyboardData.VirtualCode))
            {
                pressedKeys.Add(e.KeyboardData.VirtualCode);
            } else if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
            {
                pressedKeys.Remove(e.KeyboardData.VirtualCode);
            }
        }

        public void Dispose()
        {
            _globalKeyboardHook?.Dispose();
        }

        private void audioChannelLeveler_DoWork(object sender, DoWorkEventArgs e)
        {
            if (primarySourceSession == null)
            {
                return;
            }
            Guid guid = Guid.Empty;
            ISimpleAudioVolume primaryControl = primarySourceSession as ISimpleAudioVolume;
            float highVolumeLevel;
            primaryControl.GetMasterVolume(out highVolumeLevel);
            Console.WriteLine(highVolumeLevel);
            float lowVolumeLevel = highVolumeLevel * (float)(reductionBox.Value / 100);
            float volumeStep = (highVolumeLevel - lowVolumeLevel) * (50f/(float)reductionTimeBox.Value);
            int maxTics = (int)reductionTimeBox.Value / 50;
            int curTics = 0;
            
            while (queue)
            {
                TimeSpan span = DateTime.UtcNow - lastKeyTime;
                deltaMS = (int)span.TotalMilliseconds;

                if (deltaMS > changeDelayBox.Value && pressedKeys.Count == 0) {   
                    if (curTics < maxTics)
                        curTics++;
                } else {
                    if (curTics > 0)
                        curTics--;
                }

                primaryControl.SetMasterVolume(highVolumeLevel - (volumeStep * curTics), ref guid);
                Thread.Sleep(50);
            }
            primaryControl.SetMasterVolume(highVolumeLevel, ref guid);
        }

        private string formatSessionIdentifier(string ident)
        {
            if (ident.IndexOf(".exe") != -1)
            {
                ident = ident.Remove(ident.IndexOf(".exe"));
            }
            if (ident.IndexOf("%b") != -1)
            {
                ident = ident.Remove(ident.IndexOf("%b"));
            }
            if (ident.LastIndexOf('|') != -1)
            {
                ident = ident.Remove(0, ident.LastIndexOf('|') + 1);
            }
            if (ident.LastIndexOf('\\') != -1)
            {
                ident = ident.Remove(0, ident.LastIndexOf('\\') + 1);
            }

            return ident;
        }

        private void updateSessionList(object sender, EventArgs e)
        {
            primarySource.Items.Clear();
            secondarySource.Items.Clear();
            sessionList = VolumeMixer.GetVolumeSessionList();

            foreach (IAudioSessionControl2 session in sessionList)
            {
                if (session.IsSystemSoundsSession() == 0)
                {
                    continue;
                }
                string sessionName;
                session.GetSessionIdentifier(out sessionName);
                sessionName = formatSessionIdentifier(sessionName);
                primarySource.Items.Add(sessionName);
                secondarySource.Items.Add(sessionName);
            }
        }

        private void primarySource_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (IAudioSessionControl2 session in sessionList)
            {
                string sessionName;
                session.GetSessionIdentifier(out sessionName);
                sessionName = formatSessionIdentifier(sessionName);
                if (sessionName.Equals(primarySource.SelectedItem))
                {
                    primarySourceSession = session;
                    Debug.WriteLine(session);
                    break;
                }
            }
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = true;
            startButton.Enabled = false;
            primarySource.Enabled = false;
            changeDelayBox.Enabled = false;
            reductionBox.Enabled = false;
            reductionTimeBox.Enabled = false;

            if (!audioChannelLeveler.IsBusy)
            {
                queue = true;

                audioChannelLeveler.RunWorkerAsync();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            startButton.Enabled = true;
            primarySource.Enabled = true;
            changeDelayBox.Enabled = true;
            reductionBox.Enabled = true;
            reductionTimeBox.Enabled = true;

            if (audioChannelLeveler.IsBusy)
            {
                queue = false;
            }
        }

    }
}
