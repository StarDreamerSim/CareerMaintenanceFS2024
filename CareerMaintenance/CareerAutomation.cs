using CareerAutomation;
using System;
using System.Drawing;
using System.Threading;
using System.Windows;

namespace CareerNamespace
{
    public class CareerAutomation
    {

        CareerAutomationApplication mAutoCareer;

        private CareerAutomation(CareerAutomationApplication iAutomationApplication)
        {
            mAutoCareer = iAutomationApplication;
        }

        public void Focus()
        {
            mAutoCareer.Focus();
        }
        public void Screenshot()
        {
            mAutoCareer.Screenshot();
        }

        public void FullWindowScreenshot()
        {
            mAutoCareer.FullWindowScreenshot();
        }

        public void GetWindowBorders(out int oTopLeftX, out int oTopLeftY, out int oWidth, out int oHight)
        {
            mAutoCareer.GetWindowBorders(out oTopLeftX, out oTopLeftY, out  oWidth, out oHight);
        }


        public Bitmap PartialScreenshot(int iTopX, int iTopY, int iWidth, int iHeight)
        {
            return mAutoCareer.PartialScreenshot(iTopX, iTopY, iWidth, iHeight);
        }


        public void SendKey(string iKey)
        {
            //Press Button
            mAutoCareer.Focus();

            //If no TextToType then we are finish
            if (string.IsNullOrEmpty(iKey))
            {
                return;
            }

            //Put Text into Keyboard buffer
            //It's no problem if we start normal standalone test but the Regression test (unitTest) says:
            //System.InvalidOperationException : SendKeys cannot run inside this application because the application is not handling Windows messages. Either change the application to handle messages, or use the SendKeys.SendWait method.
            //System.Windows.Forms.SendKeys.Send(iTextToType + "{ENTER}");
            System.Windows.Forms.SendKeys.SendWait(iKey);
            Thread.Sleep(50);
            mAutoCareer.WaitForIdle();

            return;


        }


        //static methods


        public static CareerAutomation AttachToRunningCareer()
        {
            System.Diagnostics.Process[] vProcess = System.Diagnostics.Process.GetProcessesByName("FlightSimulator2024");
            if (vProcess != null && vProcess.Length > 0)
            {
                CareerAutomationApplication vCareer = CareerAutomationApplication.AttachToProcess(vProcess[0]);
                if (null != vCareer)
                {
                    ExternalAction.SetTheForegroundWindow(vProcess[0].MainWindowHandle);
                    return new CareerAutomation(vCareer);
                }
            }
            return null;
        }

        public static void GetWindowsClient(out int vWindowsClientTopLeftX,
                                            out int vWindowsClientTopLeftY,
                                            out int vWindowsClientWidth,
                                            out int vWindowsClientHeight)
        {
            vWindowsClientTopLeftX = 0;
            vWindowsClientTopLeftY = 0;
            vWindowsClientWidth = 0;
            vWindowsClientHeight = 0;

            System.Diagnostics.Process[] vProcess = System.Diagnostics.Process.GetProcessesByName("FlightSimulator2024");
            if (vProcess != null && vProcess.Length > 0)
            {
                Rect oRectWindow;
                Rect oRectClient;
                ExternalAction.GetWindowsRectangles(vProcess[0].MainWindowHandle, out oRectWindow, out oRectClient);
                if (oRectWindow!=null)
                {
                    vWindowsClientTopLeftX = (int)Math.Round(oRectClient.TopLeft.X);
                    vWindowsClientTopLeftY = (int)Math.Round(oRectClient.TopLeft.Y);
                    vWindowsClientWidth = (int)Math.Round(oRectClient.Width);
                    vWindowsClientHeight = (int)Math.Round(oRectClient.Height);
                }
            }
        }

    }
}
