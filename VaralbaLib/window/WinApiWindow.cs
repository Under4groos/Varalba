using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace VaralbaLib
{

    // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowpos
    public enum SWP : int
    {
        NOSIZE = 0x0001,
        NOMOVE = 0x0002,
        NOZORDER = 0x0004,
        NOREDRAW = 0x0008,
        NOACTIVATE = 0x0010,
        DRAWFRAME = 0x0020,
        FRAMECHANGED = 0x0020,
        SHOWWINDOW = 0x0040,
        HIDEWINDOW = 0x0080,
        NOCOPYBITS = 0x0100,
        NOOWNERZORDER = 0x0200,
        NOREPOSITION = 0x0200,
        NOSENDCHANGING = 0x0400,
        DEFERERASE = 0x2000,
        ASYNCWINDOWPOS = 0x4000,
    }
    public enum HWND
    {
        HWND_TOPMOST = -1,
        HWND_NOTOPMOST = -2,
        HWND_TOP = 0,
        HWND_BOTTOM = 1,
    }
    public class WinApiWindow
    {
        public IntPtr win_IntPtr = IntPtr.Zero;
        private Window WPF_WINDOW;
        #region dllimport   
        
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hwnd, int index);
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            int uFlags
        );
        #endregion


        
      
        public void Set(Window wpfwindow)
        {
            WPF_WINDOW = wpfwindow;
            win_IntPtr = new System.Windows.Interop.WindowInteropHelper(WPF_WINDOW).Handle;
        }
        public void MakeTransparent()
        {
            int windowLong = GetWindowLong(win_IntPtr, -20);
            SetWindowLong(win_IntPtr, -20, windowLong | 0x20);
        }
        public void HideWin_Tab()
        {
            int WS_EX_TOOLWINDOW = 0x00000080;
            int GWL_EXSTYLE = (-20);
            int exStyle = GetWindowLong(win_IntPtr, GWL_EXSTYLE);
            exStyle |= WS_EX_TOOLWINDOW;
            SetWindowLong(win_IntPtr, GWL_EXSTYLE, exStyle);
        }

        public void MakeNormal()
        {
            int windowLong = GetWindowLong(win_IntPtr, -20);
            SetWindowLong(win_IntPtr, -20, windowLong & -33);
        }
        public void SetMostTop(bool b)
        {
            if (win_IntPtr != IntPtr.Zero)
                switch (b)
                {
                    case true:
                        SetWindowPos(
                            win_IntPtr, (IntPtr)HWND.HWND_TOPMOST,
                            (int)WPF_WINDOW.Left, (int)WPF_WINDOW.Top,
                            (int)WPF_WINDOW.Width, (int)WPF_WINDOW.Height,
                            (int)SWP.DRAWFRAME | (int)SWP.NOSIZE | (int)SWP.NOMOVE
                            );
                        break;
                    case false:
                        SetWindowPos(
                            win_IntPtr, (IntPtr)HWND.HWND_BOTTOM,
                            (int)WPF_WINDOW.Left, (int)WPF_WINDOW.Top,
                            (int)WPF_WINDOW.Width, (int)WPF_WINDOW.Height,
                            (int)SWP.DRAWFRAME | (int)SWP.NOSIZE | (int)SWP.NOMOVE
                            );
                        break;
                    default:
                        break;
                }
        }
    }


}