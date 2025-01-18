using CareerNamespace;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace CareerAutomationElementExtensions
{

    public static class AutomationElementExtensions
    {

        public static void LeftMouseClick(this AutomationElement iAutomationElement, double iClickPosFactorX, double iClickPosFactorY)
        {
            System.Windows.Point vPointToClick;
            //if (!iAutomationElement.TryGetClickablePoint(out vPointToClick))
            {
                System.Windows.Rect vBounding = iAutomationElement.Current.BoundingRectangle;
                vPointToClick = new System.Windows.Point(vBounding.TopLeft.X + iClickPosFactorX * (vBounding.BottomRight.X - vBounding.TopLeft.X), vBounding.TopLeft.Y + iClickPosFactorY * (vBounding.BottomRight.Y - vBounding.TopLeft.Y));
            }
            ExternalAction.MoveToPosition((int)vPointToClick.X, (int)vPointToClick.Y);
            ExternalAction.ClickLeft();
        }

        public static void WaitForIdle(this AutomationElement iAutomationElement)
        {
            int vProcessID = 0;
            int vAttempts = 0;
            bool vValidProcessID = false;

            //For long commandos iAutomationElement.Current.ProcessId  ends up into COM Exception Operation timed out HRESULT 0x80131505
            do
            {
                vAttempts++;
                try
                {
                    vProcessID = iAutomationElement.Current.ProcessId;
                    vValidProcessID = true;
                }
                catch
                {
                    Thread.Sleep(50);
                }
            } while ((!vValidProcessID) && (10 > vAttempts));

            Process vProcess = Process.GetProcessById(vProcessID);
            bool vWaitTillIdle = vProcess.WaitForInputIdle();
        }

    }

}
