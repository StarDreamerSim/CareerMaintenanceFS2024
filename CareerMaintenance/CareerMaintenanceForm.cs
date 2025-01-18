using CareerAutomationTests;
using System;
using System.Windows.Forms;

namespace CareerMaintenance
{
    public partial class CareerMaintenanceForm : Form
    {

        Timer mGUITimer = null;
        string mLastStatusMessage = string.Empty;
        string mLastProgressLabelMessage = "Ready";

        public CareerMaintenanceForm()
        {
            InitializeComponent();
        }


        private void ExecuteMaintenanceButton_Click(object sender, EventArgs e)
        {
            if (CareerMaintenanceScript.IsScriptRunning())
            {
                return;
            }

            CareerMaintenanceScript.StartScript();
        }

        private void ScreenShotButton_Click(object sender, EventArgs e)
        {
            if (CareerMaintenanceScript.IsScriptRunning())
            {
                return;
            }
            CareerNamespace.CareerAutomation vCareer = null;
            vCareer = CareerNamespace.CareerAutomation.AttachToRunningCareer();
            if (null == vCareer)
            {
                StatusTextBox.Text = "No running FS2024 found";
                return;
            }

            vCareer.FullWindowScreenshot();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            CareerMaintenanceScript.Stop();
        }


        private void CareerMaintenanceForm_Shown(object sender, EventArgs e)
        {
            InitializeData();
        }
        private void InitializeData()
        {

            if (null == mGUITimer)
            {
                mGUITimer = new Timer();
                mGUITimer.Interval = 50;
                mGUITimer.Tick += new EventHandler(TimerEvent);
                mGUITimer.Start();
            }
        }
        private void TimerEvent(object sender, System.EventArgs e)
        {
            //if (CareerMaintenanceScript.IsScriptRunning())
            {
                string vLatestStatus = CareerMaintenanceScript.GetStatus();
                if (!string.Equals(mLastStatusMessage, vLatestStatus))
                {
                    mLastStatusMessage = vLatestStatus;
                    StatusTextBox.Text = vLatestStatus;
                }
                string vProgressLabelStatus = CareerMaintenanceScript.GetProgressLabelStatus();
                if (!string.Equals(mLastProgressLabelMessage, vProgressLabelStatus))
                {
                    mLastProgressLabelMessage = vProgressLabelStatus;
                    ProgressLabel.Text = vProgressLabelStatus;
                }
            }
        }

        private void CareerMaintenanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CareerMaintenanceScript.KillTask();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            CareerMaintenanceScript.Reset();
        }
    }
}
