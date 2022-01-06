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
using Lab_20__wpf__Finished_Module_Ex.Models;

namespace Lab_20__wpf__Finished_Module_Ex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ariph cal = new Ariph();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumOpButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            textLabel.Text += button.Content.ToString();
        }

        private void FuncButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == clearButton)
            {
                textLabel.Text = "";
            }
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ariph();
            }
            catch (Exception ex)
            {
                textLabel.Text = "Error";
            }
        }

        private void Ariph()
        {
            int opPos = 0;
            double value1 = 0;
            double value2 = 0;
            double result = 0;
            string op = "";

            if (textLabel.Text.Contains("*"))
            {
                opPos = textLabel.Text.IndexOf("*");
            }
            else if (textLabel.Text.Contains("/"))
            {
                opPos = textLabel.Text.IndexOf("/");
            }
            else if (textLabel.Text.Contains("+"))
            {
                opPos = textLabel.Text.IndexOf("+");
            }
            else if (textLabel.Text.Contains("-"))
            {
                opPos = textLabel.Text.IndexOf("-");
            }

            value1 = Double.Parse(textLabel.Text.Substring(0, opPos));
            op = textLabel.Text.Substring(opPos, 1);
            value2 = Double.Parse(textLabel.Text.Substring(opPos + 1, textLabel.Text.Length - opPos - 1));
            if (op == "*")
            {
                result = cal.Multiply(value1, value2);
                textLabel.Text += "= " + result.ToString();
            }
            else if (op == "/")
            {
                if (value2 == 0)
                {
                    textLabel.Text = "Нельзя делить на ноль";
                }
                else
                {
                    result = cal.Divide(value1, value2);
                    textLabel.Text += "= " + result.ToString();
                }
            }
            else if (op == "+")
            {
                result = cal.Add(value1, value2);
                textLabel.Text += "= " + result.ToString();
            }
            else if (op == "-")
            {
                result = cal.Subtract(value1, value2);
                textLabel.Text += "= " + result.ToString();
            }
        }
    }
}