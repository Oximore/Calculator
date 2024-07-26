using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string operand1 = "", operand2 = "";
        private string @operator = ""; // @ car operator mot-clef c#

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DigitButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button)
                return;

            if (button.Content is not string digit)
                return;

            if (!string.IsNullOrEmpty(@operator) &&
                string.IsNullOrEmpty(operand2))
                resultText.Text = "";

            if (string.IsNullOrEmpty(@operator))
                operand1 += digit;
            else
                operand2 += digit;

            resultText.Text += digit;
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button)
                return;

            if (button.Content is not string @operator)
                return;

            this.@operator = @operator;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(operand1, out double value1))
                return;

            if (!double.TryParse(operand2, out double value2))
                return;

            double result;

            switch (@operator)
            {
                case "+": result = value1 + value2; break;
                case "−": result = value1 - value2; break;
                case "×": result = value1 * value2; break;
                case "÷": result = value1 / value2; break;
                default: return;
            }

            resultText.Text = result.ToString("0.#########");

            // Reset
            operand1 = operand2 = @operator = "";
        }
    }
}