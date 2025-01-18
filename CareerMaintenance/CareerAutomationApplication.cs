using CareerAutomationElementExtensions;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace CareerAutomation
{
    public class CareerAutomationApplication
    {

        private AutomationElement mApplicationAutomationElement = null;
        private Process mApplicationProcess = null;

        //Constructor
        private CareerAutomationApplication(Process iApplicationProcess, AutomationElement iApplicationAutomationElement)
        {
            mApplicationProcess = iApplicationProcess;
            mApplicationAutomationElement = iApplicationAutomationElement;
        }

        public static CareerAutomationApplication AttachToProcess(Process iProcess)
        {
            if (null == iProcess)
            {
                return null;
            }
            if (null == iProcess.MainWindowTitle)
            {
                return null;
            }

            Thread.Sleep(500); //Give a Bit time for Application to start

            if (0 >= iProcess.MainWindowTitle.Length)
            {
                //WindowName can still be empty thats allowed
                //return null;
            }

            //GetDesktop
            AutomationElement vRootDesktopElement = AutomationElement.RootElement;
            if (null == vRootDesktopElement)
            {
                return null;
            }

            int cMaxAttempts = 20;
            int vAttemptCounter = 0;
            AutomationElement vAppAutomationElement = null;
            do
            {
                vAttemptCounter++;
                Thread.Sleep(500);
                //Condition vSearchCondition1 = new PropertyCondition(AutomationElement.NameProperty, iProcess.ProcessName); //they write "Please wait while the application opens" in the iProcess.MainWindowTitle till the window is open . So we can't use iProcess.MainWindowTitle
                Condition vSearchCondition1 = new PropertyCondition(AutomationElement.NameProperty, iProcess.MainWindowTitle);
                Condition vSearchCondition2 = new PropertyCondition(AutomationElement.ProcessIdProperty, iProcess.Id);
                Condition vSearchConditionCombi = new AndCondition(vSearchCondition1, vSearchCondition2);
                //vAppAutomationElement = vRootDesktopElement.FindFirst(TreeScope.Children, vSearchCondition1);
                //vAppAutomationElement = vRootDesktopElement.FindFirst(TreeScope.Children, vSearchCondition2);
                vAppAutomationElement = vRootDesktopElement.FindFirst(TreeScope.Children, vSearchConditionCombi);
            } while ((null == vAppAutomationElement) && (vAttemptCounter < cMaxAttempts));


            if ((null == vAppAutomationElement) && (vAttemptCounter >= cMaxAttempts))
            {
                //Application not found Check Process and WindowsName Error
                return null;
            }

            Thread.Sleep(250);
            vAppAutomationElement.WaitForIdle();
            Thread.Sleep(250);

            //Seesm we have to get the Process again. The iProcess is outdated (MainWindowTitle is not set..any shutdown like Process.CloseMainWindow()  event is not handled without this !?
            //Process vNewProcess = ProcessHelper.GetProcess(iProcess.ProcessName); //In case of multiple instances this can happen to return the wrong one therefore we have to get the one with the same id again.
            Process vNewProcess = GetSpecificProcessAgain(iProcess.ProcessName, iProcess.Id);

            CareerAutomationApplication vAutomation = new CareerAutomationApplication(vNewProcess, vAppAutomationElement);
            return vAutomation;
        }

        public static Process GetSpecificProcessAgain(string iProcessName, int iProcessId)
        {
            if (string.IsNullOrEmpty(iProcessName))
            {
                return null;
            }

            //Search for the running Processes
            Process vFoundProcess = null;
            Process[] vProcessArray = Process.GetProcesses(".");
            if (null != vProcessArray)
            {
                foreach (Process vProcess in vProcessArray)
                {
                    if ((null != vProcess) && (null != vProcess.ProcessName))
                    {
                        if (vProcess.ProcessName.Length > 0)
                        {
                            if (string.Equals(iProcessName, vProcess.ProcessName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                if (vProcess.Id == iProcessId)
                                {
                                    vFoundProcess = vProcess;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return vFoundProcess;
        }

        public void WaitForIdle()
        {
            mApplicationAutomationElement.WaitForIdle();
            Thread.Sleep(10);
        }

        public void Focus()
        {
            try
            {
                mApplicationAutomationElement.SetFocus();
                //mApplicationAutomationElement.FindFirst(TreeScope.Subtree,Condition.TrueCondition).SetFocus();
            }
            catch { }
            Thread.Sleep(50);
        }

        public void Screenshot()
        {
            DoScreenShot("Screenshot.bmp");
        }

        public void GetWindowBorders(out int oTopLeftX, out int oTopLeftY, out int oWidth, out int oHight)
        {
            System.Windows.Rect vBounding = mApplicationAutomationElement.Current.BoundingRectangle;
            oTopLeftX = (int)Math.Round(vBounding.TopLeft.X);
            oTopLeftY = (int)Math.Round(vBounding.TopLeft.Y);
            oWidth = (int)Math.Round(vBounding.Width);
            oHight =(int)Math.Round(vBounding.Height);
        }

        public void FullWindowScreenshot()
        {
            System.Windows.Rect vBounding = mApplicationAutomationElement.Current.BoundingRectangle;
            DoScreenShotRegion("Screenshot.bmp", (int)vBounding.TopLeft.X, (int)vBounding.TopLeft.Y, (int)vBounding.Width, (int)vBounding.Height);
        }

        public Bitmap PartialScreenshot(int iTopX, int iTopY, int iWidth, int iHeight)
        {
            //System.Windows.Rect vBounding = mApplicationAutomationElement.Current.BoundingRectangle;
            return DoPartialScreenShot(iTopX, iTopY, iWidth, iHeight);

        }

        public static void DoScreenShot(string iFileName)
        {
            //Save a Screenshot
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                   Screen.PrimaryScreen.Bounds.Height,
                                   PixelFormat.Format32bppArgb);

            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);

            // Save the screenshot to the specified path that the user has chosen.
            bmpScreenshot.Save(iFileName, ImageFormat.Bmp);
        }

        public static void DoScreenShotRegion(string iFileName, int iTopLeftX, int iTopLeftY, int iSizeX, int iSizeY)
        {
            //Save a Screenshot
            Bitmap bmpScreenshot = new Bitmap(iSizeX,
                                   iSizeY,
                                   PixelFormat.Format32bppArgb);

            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(iTopLeftX,
                                        iTopLeftY,
                                        0,
                                        0,
                                        new Size(iSizeX, iSizeY),
                                        CopyPixelOperation.SourceCopy);

            // Save the screenshot to the specified path that the user has chosen.
            bmpScreenshot.Save(iFileName, ImageFormat.Bmp);
        }


        public static Bitmap DoPartialScreenShot(int iTopLeftX, int iTopLeftY, int iSizeX, int iSizeY)
        {
            //Save a Screenshot
            Bitmap bmpScreenshot = new Bitmap(iSizeX,
                                   iSizeY,
                                   PixelFormat.Format32bppArgb);

            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(iTopLeftX,
                                        iTopLeftY,
                                        0,
                                        0,
                                        new Size(iSizeX, iSizeY),
                                        CopyPixelOperation.SourceCopy);

            // Save the screenshot to the specified path that the user has chosen.
            return bmpScreenshot;
        }
    }
}
