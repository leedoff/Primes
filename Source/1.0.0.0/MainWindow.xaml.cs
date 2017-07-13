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

namespace Primes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //nothing, can not be removed :/
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //nothing, can not be removed :/
        }

        public long numA, numB, i, number, number1, number2, start, stop;
        public List<long> ListOfPrimes = new List<long>();
        public List<long> Range = new List<long>();

        private bool isPrime(long number)
        {
            if (number == 2)
            { 
                return true;
            }
            for (i = 2; i < (Math.Sqrt(number))+1; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private List<long> findPrimes(long number1, long number2)
        {

            if (number1 == number2)
            {
                InfoBox.Text = "ERROR: Values A and B can not be equal";
                return new List<long>();
            }
            if (number1 > number2)
            {
                stop = number1;
                start = number2;
            }
            else
            {
                stop = number2;
                start = number1;
            }
            for (i = start; i < stop+1; i++)
            {
                Range.Add(i);
            }
            foreach (long iter in Range)
            {
                if (isPrime(iter))
                {
                    ListOfPrimes.Add(iter);
                }
            }
            //ListOfPrimes.TrimExcess();
            return ListOfPrimes;
        }

        private string amountOfPrimes(long number1, long number2)
        {
            if (number1 == number2)
            {
                InfoBox.Text = "ERROR: Values A and B can not be equal";
            }
            if (number1 > number2)
            {
                stop = number1;
                start = number2;
            }
            else
            {
                stop = number2;
                start = number1;
            }
            for (i = start; i < stop+1; i++)
            {
                Range.Add(i);
            }
            foreach (long iter in Range)
            {
                if (isPrime(iter))
                {
                    ListOfPrimes.Add(iter);
                }
            }
            int rangelen = (int)Range.Count();
            int primelen = (int)ListOfPrimes.Count();
            string tempStr = rangelen + " Natural Numbers\n\n" + 
                primelen + " Prime Numbers\n\n" + 
                Math.Round(((float)primelen / (float)rangelen), 6)*100 + " % of Naturals on the interval are Prime\n\n" ;
            return tempStr;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox3.Clear();
            ListOfPrimes.Clear();
            Range.Clear();
            switch (ComboBox.SelectedIndex)
            {
                case 0:
                    try
                    {
                        numA = Convert.ToInt64(TextBox1.Text);
                    }
                    catch
                    {
                        InfoBox.Text = "ERROR: Conversion Error";
                        return;
                    }
                    TextBox3.Text = Convert.ToString(isPrime(numA));
                    break;
                case 1:
                    try
                    {
                        numA = Convert.ToInt64(TextBox1.Text);
                        numB = Convert.ToInt64(TextBox2.Text);
                    }
                    catch
                    {
                        InfoBox.Text = "ERROR: Conversion Error";
                        return;
                    }
                    string tempString = string.Join(", ", findPrimes(numA, numB));
                    TextBox3.Text = tempString;
                    break;
                case 2:
                    try
                    {
                        numA = Convert.ToInt64(TextBox1.Text);
                        numB = Convert.ToInt64(TextBox2.Text);
                    }
                    catch
                    {
                        InfoBox.Text = "ERROR: Conversion Error";
                        return;
                    };
                    TextBox3.Text = amountOfPrimes(numA, numB);
                    break;
            }
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            string tempStr = "- Primality Test A : Checks if A is prime, returns 'True' or 'False'\n\n" +
                "- Find Primes [A;B] : Finds all primes between A and B, inclusive (and outputs them)\n\n" +
                "- Amount of Primes [A;B] : Finds all primes between A and B and outputs how many " +
                "there are and what percentage of the interval they occupy\n\n";
            MessageBox.Show(tempStr);
            TextBox3.Text = tempStr;
            InfoBox.Text = "Help: This is the status box";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //nothing, can not be removed :/
        }
    }
}
