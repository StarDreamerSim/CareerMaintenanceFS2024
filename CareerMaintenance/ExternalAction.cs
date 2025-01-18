using System;
using System.Runtime.InteropServices;
using System.Windows;



namespace CareerNamespace
{
    /// <summary>
    /// Click the element by simulating mouse.
    /// </summary>
    public static class ExternalAction
    {

        #region Windows

        //[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        //public static extern IntPtr SetFocus(HandleRef hWnd);

        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT oRect);

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hwnd, out RECT oRect);

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref System.Drawing.Point oPoint);


        // [DllImport("User32")]
        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        //[DllImportAttribute("User32.DLL")]
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOW = 5;
        private const int SW_MINIMIZE = 6;
        private const int SW_RESTORE = 9;


        public static void SetTheForegroundWindow(IntPtr hwnd)
        {
            //ShowWindow(hwnd, SW_SHOW);
            SetForegroundWindow(hwnd);
            //SetFocus(hwnd);
           // SetActiveWindow(handle);
            //SwitchToThisWindow(handle, true);
        }

        public static void GetWindowsRectangles(IntPtr hwnd, out Rect oWindowsRect, out Rect oClientRect)
        {
            RECT vWindowsRect;
            RECT vClientRect;
            System.Drawing.Point vClientPositionToScreen = new System.Drawing.Point();
            GetWindowRect(hwnd, out vWindowsRect);
            GetClientRect(hwnd, out vClientRect);
            ClientToScreen(hwnd, ref vClientPositionToScreen);
            oWindowsRect = new Rect(vWindowsRect.Left, vWindowsRect.Top, vWindowsRect.Right - vWindowsRect.Left, vWindowsRect.Bottom - vWindowsRect.Top);
            oClientRect = new Rect(vClientPositionToScreen.X, vClientPositionToScreen.Y, vClientRect.Right - vClientRect.Left, vClientRect.Bottom - vClientRect.Top);
        }

        #endregion

        #region Mouse

        /// <summary>
        /// Moves the Mouse to the given Position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private extern static bool SetCursorPos(int x, int y);


        /// <summary>
        /// Mouse click event
        /// </summary>
        /// <param name="dataFlags"></param>
        /// <param name="dataX"></param>
        /// <param name="dataY"></param>
        /// <param name="data"></param>
        /// <param name="dataExtraInfo"></param>
        /// <returns></returns>
        [DllImport("user32")]
        private static extern int mouse_event(UInt32 dataFlags, UInt32 dataX, UInt32 dataY, UInt32 data, IntPtr dataExtraInfo);


        /// <summary>
        /// Drag and Drop Mouse Event
        /// </summary>
        /// <param name="a">MouseEventFlag </param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        [DllImport("user32.dll")]
        private extern static void mouse_event(int a, int x, int y, int d, int e);



        //Thte Mouse Flag Constants
        const int cMOUSEEVENTF_MOVE = 0x0001;
        const int cMOUSEEVENTF_LEFTDOWN = 0x0002;
        const int cMOUSEEVENTF_LEFTUP = 0x0004;
        const int cMOUSEEVENTF_RIGHTDOWN = 0x0008;
        const int cMOUSEEVENTF_RIGHTUP = 0x0010;
        const int cMOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const int cMOUSEEVENTF_MIDDLEUP = 0x0040;
        const int cMOUSEEVENTF_ABSOLUTE = 0x8000;



        /// <summary>
        /// Moves(Sets) the cursor to the give postion.
        /// </summary>
        /// <param name="offsetX">Relative offset X</param>
        /// <param name="offsetY">Relative offset Y</param>
        public static void MoveToPosition(int offsetX, int offsetY)
        {
            SetCursorPos(offsetX, offsetY);
        }


        /// <summary>
        /// MouseEvent LEFTDOWN | LEFTUP
        /// </summary>
        public static void ClickLeft()
        {
            mouse_event(cMOUSEEVENTF_MOVE, 0, 0, 0, IntPtr.Zero);
            mouse_event(cMOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            mouse_event(cMOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
        }

        /// <summary>
        /// MouseEvent RIGHTDOWN | RIGHTUP
        /// </summary>
        public static void ClickRight()
        {
            mouse_event(cMOUSEEVENTF_MOVE, 0, 0, 0, IntPtr.Zero);
            mouse_event(cMOUSEEVENTF_RIGHTDOWN, 0, 0, 0, IntPtr.Zero);
            mouse_event(cMOUSEEVENTF_RIGHTUP, 0, 0, 0, IntPtr.Zero);
        }



        /// <summary>
        /// Drag and Drop
        /// </summary>
        /// <param name="iDragX"></param>
        /// <param name="iDragY"></param>
        /// <param name="iDropX"></param>
        /// <param name="iDropY"></param>
        public static void DragAndDrop(int iDragX, int iDragY, int iDropX, int iDropY)
        {

            //Make the cursor position to the element.
            SetCursorPos(iDragX, iDragY);
            //mouse_event(cMOUSEEVENTF_MOVE ,iDragX,iDragY,0,0);
            mouse_event(cMOUSEEVENTF_LEFTDOWN, iDragX, iDragY, 0, 0);

            SetCursorPos(iDropX, iDropY);
            mouse_event(cMOUSEEVENTF_ABSOLUTE, iDropX, iDropY, 0, 0);

            mouse_event(cMOUSEEVENTF_LEFTDOWN, iDropX, iDropY, 0, 0);
            mouse_event(cMOUSEEVENTF_LEFTUP, iDropX, iDropY, 0, 0);
        }

        #endregion
    }
}
