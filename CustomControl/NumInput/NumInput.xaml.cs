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
        private bool canDrag = false;
        Point lastPoint;

        float offset = 0;

        public NumInput()
        {
            InitializeComponent();
            ValueChanged();
        }

        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);

            InputControl.IsHitTestVisible = true;
        }

        private void InputControlLeftMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            DLog.Log(e.ClickCount + "");
            if (e.ClickCount == 1)
            {
                canDrag = true;
                lastPoint = e.GetPosition(null);

                InputControl.CaptureMouse();
            }

            if (e.ClickCount == 2)
            {
                canDrag = false;

                InputControl.IsHitTestVisible = false;
                valueInput.Focus();
            }
        }

        private void InputControlLeftMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            canDrag = false;
            offset = 0;

            InputControl.ReleaseMouseCapture();
        }

        private void InputControlPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (!canDrag)
                return;

            Point point = e.GetPosition(null);

            float delta = (float)(point.X - lastPoint.X);

            float interval = Keyboard.IsKeyDown(Key.LeftShift) ? 10 : 1;

            if (MathF.Abs(delta) >= interval)
            {
                offset += 1 * delta.Signum();
                lastPoint = point;
            }

            DLog.Log(offset + "");
        }

        private void ValueChanged()
        {
            RaiseEvent(new RoutedEventArgs(OnValueChangedEvent));
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

            ValueChanged();
        }

        private void OnTextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            bool cancelCommand = false;

            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));

                if (!IsNumericString(text))
                    cancelCommand = true;
            }
            else
                cancelCommand = true;

            if (cancelCommand)
                e.CancelCommand();
            else
                ValueChanged();
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

        public static readonly RoutedEvent OnValueChangedEvent =
         EventManager.RegisterRoutedEvent(nameof(OnValueChanged), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumInput));

        public event RoutedEventHandler OnValueChanged
        {
            add { AddHandler(OnValueChangedEvent, value); }
            remove { RemoveHandler(OnValueChangedEvent, value); }
        }
    }
}
