using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapRangeScale.View
{
    /// <summary>
    /// Interaction logic for TopNav.xaml
    /// </summary>
    public partial class TitleBar : UserControl
    {
        public Window parentWindow { get; set; }

        public TitleBar()
        {
            InitializeComponent();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                parentWindow.DragMove();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            parentWindow.Close();
        }

        private void MinWindow(object sender, RoutedEventArgs e)
        {
            parentWindow.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.FadeProperty(HeightProperty, 20);
            TitleBarHandle.FadeProperty(WidthProperty, 100);

            ControlsGrid.FadeProperty(HeightProperty, 20);
        }

        private void TitleBar_MouseLeave(object sender, MouseEventArgs e)
        {
            this.FadeProperty(HeightProperty, 10);
            TitleBarHandle.FadeProperty(WidthProperty, 50);

            ControlsGrid.FadeProperty(HeightProperty, 0);
        }
    }
}
