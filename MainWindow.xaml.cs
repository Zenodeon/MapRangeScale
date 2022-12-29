using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace MapRangeScale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //DLog.Instantiate();

            InitializeComponent();
            TitleBar.parentWindow= this;

            UpdateRange();
        }

        private void UpdateRange(object sender, RoutedEventArgs e)
        {
            UpdateRange();
        }

        private void UpdateRange()
        {
            OR.inputValue = UUtility.RangedMapClamp(IV, IMN, IMX, OMN, OMX);
            ShowRange();
        }

        private void UpdateRangeInverse(object sender, RoutedEventArgs e)
        {
            IV.inputValue = UUtility.RangedMapClamp(OR, OMN, OMX, IMN, IMX);
        }

        private void ShowRange()
        {
            IMR.Text = "- " + MathF.Abs(IMX - IMN) + " -";
            OMR.Text = "- " + MathF.Abs(OMX - OMN) + " -";
        }

        private void Background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.LoseFocus();
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
