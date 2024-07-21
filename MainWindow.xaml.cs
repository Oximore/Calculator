using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            labelOperation.Content = " ";
            labelResult.Content = " ";
        }

        private enum Operator
        { Plus, Minus, Multiply, Divide }

        private class Operation
        {
            public List<double> Numbers = new List<double>();
            public List<Operator> Operators = new List<Operator>();

            public bool Computable => (Numbers.Count == Operators.Count + 1);
            public bool Computed = false;

            public double Current = 0;
            public double? Result = null;


            public void Clear()
            {
                Numbers.Clear(); Operators.Clear();
                Computed = false;
                Current = 0;
                Result = null;
            }

            public void ValidateCurrent()
            {
                Numbers.Add(Current);
                Current = 0;
            }

            public void AddToCurrent(int i)
            {
                if (Computed)
                    Clear();

                Current = Current * 10 + i;
                //TODO comma
            }

            public void AddOperator(Operator op)
            {
                if (Computed)
                    return; // error

                ValidateCurrent();
                Operators.Add(op);
            }

            public double Compute()
            {
                if (Computed && Result != null)
                    return (double) Result;

                ValidateCurrent();

                double result = 0;
                if (Computable)
                {
                    result = Numbers.ElementAt(0);
                    for (int i = 0; i < Numbers.Count-1; i++)
                    {
                        double value = Numbers[i+1];
                        
                        switch (Operators[i])
                        {
                            case Operator.Plus:
                                result = result + value;
                                break;
                            case Operator.Minus:
                                result = result - value;
                                break;
                            case Operator.Multiply:
                                result = result * value;
                                break;
                            case Operator.Divide:
                                result = result / value;
                                break;
                            default:
                                break;
                        }
                    }

                    Result = result;
                    Computed = true;
                }
                else
                {
                    Debug.WriteLine($" *********** ERROR in file *******");
                }
                return result;
            }

            public override string ToString()
            {
                string sResult = "";
                for (int i = 0; i < Numbers.Count; i++)
                {
                    sResult += " " + Numbers[i];
                    if (Operators.Count > i)
                    {
                        var op = Operators[i] switch
                        {
                            Operator.Plus => '+',
                            Operator.Minus => '-',
                            Operator.Multiply => '*',
                            Operator.Divide => '/',
                            _ => '?',
                        };
                        sResult += $" {op}";
                    }
                }

                if (Computed)
                {
                    sResult += $" = {Result}";
                }
                return sResult;
            }

            internal void AddComma()
            {
                throw new NotImplementedException();
            }
        }

        private Operation CurrentOp = new Operation();


        private void RefreshCalc(Operation op)
        {
            labelOperation.Content = CurrentOp.ToString();
            if (CurrentOp.Computed)
                labelResult.Content = CurrentOp.Result;
            else
                labelResult.Content = CurrentOp.Current;
        }


        private void DisplayOperation()
        {
            Debug.WriteLine(CurrentOp.ToString() + "*******");
            labelOperation.Content = CurrentOp.ToString();
        }

        private void DisplayResult()
        {
            if (CurrentOp.Computed)
                labelResult.Content = CurrentOp.Result;
        }

        private void DebugButton(int index)
        {
            Debug.WriteLine($" --- Boutton {index} clicked");
            Debug.WriteLine($" --- curent op: {CurrentOp.ToString()}");
            Debug.WriteLine($" --- curent nb: {CurrentOp.Current}");

        }

        private void DebugButton(string msg)
        {
            Debug.WriteLine($" --- Boutton {msg} clicked");
            Debug.WriteLine($" --- curent op: {CurrentOp.ToString()}");
            Debug.WriteLine($" --- curent nb: {CurrentOp.Current}");
        }

        private void Click_0(object sender, RoutedEventArgs e)
        {
            TypeNumber(0);
        }

        private void Click_1(object sender, RoutedEventArgs e)
        {
            TypeNumber(1);
        }

        private void Click_2(object sender, RoutedEventArgs e)
        {
            TypeNumber(2);
        }

        private void Click_3(object sender, RoutedEventArgs e)
        {
            TypeNumber(3);
        }

        private void Click_4(object sender, RoutedEventArgs e)
        {
            TypeNumber(4);
        }

        private void Click_5(object sender, RoutedEventArgs e)
        {
            TypeNumber(5);
        }

        private void Click_6(object sender, RoutedEventArgs e)
        {
            TypeNumber(6);
        }

        private void Click_7(object sender, RoutedEventArgs e)
        {
            TypeNumber(7);
        }

        private void Click_8(object sender, RoutedEventArgs e)
        {
            TypeNumber(8);
        }

        private void Click_9(object sender, RoutedEventArgs e)
        {
            TypeNumber(9);
        }

        private void Click_Plus(object sender, RoutedEventArgs e)
        {
            TypePlus();
        }

        private void Click_Minus(object sender, RoutedEventArgs e)
        {
            TypeMinus();
        }

        private void Click_Multiply(object sender, RoutedEventArgs e)
        {
            TypeMultiply();
        }

        private void Click_Divide(object sender, RoutedEventArgs e)
        {
            TypeDivide();
        }

        private void Click_Equal(object sender, RoutedEventArgs e)
        {
            TypeEqual();
        }

        private void Click_Comma(object sender, RoutedEventArgs e)
        {
            TypeComma();
        }


        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                    TypeNumber(0);
                    break;
                case Key.NumPad1:
                    TypeNumber(1);
                    break;
                case Key.NumPad2:
                    TypeNumber(2);
                    break;
                case Key.NumPad3:
                    TypeNumber(3);
                    break;
                case Key.NumPad4:
                    TypeNumber(4);
                    break;
                case Key.NumPad5:
                    TypeNumber(5);
                    break;
                case Key.NumPad6:
                    TypeNumber(6);
                    break;
                case Key.NumPad7:
                    TypeNumber(7);
                    break;
                case Key.NumPad8:
                    TypeNumber(8);
                    break;
                case Key.NumPad9:
                    TypeNumber(9);
                    break;
                case Key.Enter:
                    TypeEqual();
                    break;

                case Key.Add:
                    TypePlus();
                    break;
                case Key.Subtract:
                    TypeMinus();
                    break;
                case Key.Multiply:
                    TypeMultiply();
                    break;
                case Key.Divide:
                    TypeDivide();
                    break;
                case Key.OemComma: // TODO check
                    TypeComma();
                    break;
                default:
                    break;
            }
        }


        private void TypeNumber(int i)
        {
            DebugButton(i);
            if (CurrentOp.Computed)
            {
                CurrentOp.Clear();
            }

            CurrentOp.AddToCurrent(i);
            RefreshCalc(CurrentOp);
        }

        private void TypePlus()
        {
            DebugButton("plus");
            CurrentOp.AddOperator(Operator.Plus);
            RefreshCalc(CurrentOp);
        }

        private void TypeMinus()
        {
            DebugButton("minus");
            CurrentOp.AddOperator(Operator.Minus);
            RefreshCalc(CurrentOp);
        }

        private void TypeMultiply()
        {
            DebugButton("multiply");
            CurrentOp.AddOperator(Operator.Multiply);
            RefreshCalc(CurrentOp);
        }

        private void TypeDivide()
        {
            DebugButton("divide");
            CurrentOp.AddOperator(Operator.Divide);
            RefreshCalc(CurrentOp);
        }

        private void TypeComma()
        {
            DebugButton("comma");
            CurrentOp.AddComma();
            RefreshCalc(CurrentOp);
        }

        private void TypeEqual()
        {
            DebugButton("equal");
            CurrentOp.Compute();
            //double result = CurrentOp.Result;
            RefreshCalc(CurrentOp);
        }
    }
}