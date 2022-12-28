using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MapRangeScale.CustomControl
{
    /// <summary>
    /// Interaction logic for NumInput.xaml
    /// </summary>
    public partial class NumInput : UserControl
    {
        public NumInput()
        {
            InitializeComponent();
        }

        #region TextInput Filtering

        private readonly Regex allowedSecNumericRegex = new Regex("[^0-9.]+");

        private bool IsNumericString(string text)
        {
            return allowedSecNumericRegex.IsMatch(text);
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsNumericString(e.Text);
        }

        private void OnTextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsNumericString(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }
        #endregion

        public string DirName
        {
            get { return (string)GetValue(DirNameProperty); }
            set { SetValue(DirNameProperty, value); }
        }

        public static readonly DependencyProperty DirNameProperty =
            DependencyProperty.Register("DirName", typeof(string), typeof(NumInput), new PropertyMetadata("DIR"));

        public string InputValue
        {
            get { return (string)GetValue(InputValueProperty); }
            set { SetValue(InputValueProperty, value); }
        }

        public static readonly DependencyProperty InputValueProperty =
            DependencyProperty.Register("InputValue", typeof(string), typeof(NumInput), new PropertyMetadata("0"));

        public string InputName
        {
            get { return (string)GetValue(InputNameProperty); }
            set { SetValue(InputNameProperty, value); }
        }

        public static readonly DependencyProperty InputNameProperty =
            DependencyProperty.Register("InputName", typeof(string), typeof(NumInput), new PropertyMetadata("INPUT"));
    }
}
