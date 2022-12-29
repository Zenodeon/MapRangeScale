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

namespace MapRangeScale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DLog.Instantiate();

            InitializeComponent();
            TitleBar.parentWindow= this;
        }

        private void UpdateRange(object sender, RoutedEventArgs e)
        {
            DLog.Log("Value Changed");
        }

        private void Background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.LoseFocus();
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
