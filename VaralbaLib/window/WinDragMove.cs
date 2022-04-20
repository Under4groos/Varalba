using System;
using System.Windows;


namespace VaralbaLib
{
    public class WinDragMove
    {


        public double TopDown
        {
            get; set;
        } = 35;
        public double LeftDown
        {
            get; set;
        } = 0;

        public WinDragMove(Window win_, FrameworkElement ee)
        {
            ee.MouseLeftButtonDown += (sender, e) =>
            {

                if (e.GetPosition(win_).Y < TopDown && e.LeftButton == System.Windows.Input.MouseButtonState.Pressed && (win_.Width - e.GetPosition(win_).X) > LeftDown)
                    win_.DragMove();


            };
        }
    }
}

