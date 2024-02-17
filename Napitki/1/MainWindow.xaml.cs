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
using System.Windows.Threading;

namespace _1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int balance = 0;
        public string napitok;
        public int saxar = 0;
        public int milk = 0;
        public bool load = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        void vvod_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Select coin denomination");
            _1.Visibility = Visibility.Visible;
            _2.Visibility = Visibility.Visible;
            _5.Visibility = Visibility.Visible;
            _10.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            napitok = "Drink not selected";
            _1.Visibility = Visibility.Hidden;
            _2.Visibility = Visibility.Hidden;
            _5.Visibility = Visibility.Hidden;
            _10.Visibility = Visibility.Hidden;
            //timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            Button B = sender as Button;
            /*Balance.Content*/
            balance +=Convert.ToInt32(B.Content);
            //MessageBox.Show("Вы вытащили монету из кошелька и попытались вставить её в монитор, а потом перестав прикалываться, пополнили баланс на целых " + B.Content + " денег");
            _1.Visibility = Visibility.Hidden;
            _2.Visibility = Visibility.Hidden;
            _5.Visibility = Visibility.Hidden;
            _10.Visibility = Visibility.Hidden;
        }
        /*public static int bucks(string sas)
        {
            return Convert.ToInt32(sas);
        }*/
        //string[] sas;
        public int i = 0;
        public int d = 1000;
        private void timer_Tick(object sender, EventArgs e)
        {
            //
            // код здесь
            if (load)
            {
                if (i > 7) { load = !load; }
                i += 1;

                Balance.Content = /*"please stand by"*/Convert.ToString(d)+"-7";
                d-= 7;
            }
            else
            {
                if (i < 3) { i += 1; } else { i = 0;/* Balance.Content = "Выдаёtся сдача"; milk = 0; saxar = 0; napitok = "Напиток не выбран";*/ }
                string[] sas = new string[4] { Convert.ToString(balance) + " coins", napitok, "Sugar " + Convert.ToString(saxar), "Milk " + Convert.ToString(milk) };
                Balance.Content = sas[i];
                
            }
        }

        /*private void rus_Click(object sender, RoutedEventArgs e)
        {
            napitok = "Руссиано";
        }

        private void cap_Click(object sender, RoutedEventArgs e)
        {
            napitok = "Капучино";
        }

        private void ex_Click(object sender, RoutedEventArgs e)
        {
            napitok = "Экспрессо";
        }

        private void cac_Click(object sender, RoutedEventArgs e)
        {
            napitok = "Какао";
        }*/

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            switch (napitok) {
                case "Руссиано": if (balance > 48) { balance = 0;/*balance -= 49;*/load = true; Balance.Content = "Выдаёtся сдача"; milk = 0; saxar = 0; napitok = "Напиток не выбран"; } else Balance.Content="Недостаточно денег" ; break;
                case "Капучино": if (balance > 51) { balance = 0;/*balance -= 52;*/ load = true; Balance.Content = "Выдаёtся сдача"; milk = 0; saxar = 0; napitok = "Напиток не выбран"; } else Balance.Content = "Недостаточно денег"; break;
                case "Экспрессо": if (balance > 45) { balance = 0;/* balance -= 46;*/ load = true; Balance.Content = "Выдаёtся сдача"; milk = 0; saxar = 0; napitok = "Напиток не выбран"; } else Balance.Content = "Недостаточно денег"; break;
                case "Какао": if (balance > 40) { balance = 0;/*balance -= 41;*/ load = true; Balance.Content = "Выдаёtся сдача"; milk = 0; saxar = 0; napitok = "Напиток не выбран"; } else Balance.Content = "Недостаточно денег"; break;
                default:MessageBox.Show("Program is broken!"); break;
            }
        }

        private void sp__Click(object sender, RoutedEventArgs e)
        {
            if (saxar < 4)
            {
                saxar += 1;
            }
        }

        private void sm_Click(object sender, RoutedEventArgs e)
        {
            if (saxar > 0)
            {
                saxar -= 1;
            }
        }

        private void mp_Click(object sender, RoutedEventArgs e)
        {
            if (milk < 3)
            {
                milk += 1;
            }
        }

        private void mm_Click(object sender, RoutedEventArgs e)
        {
            if (milk > 0)
            {
                milk -= 1;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            napitok = "Какао";
        }

        private void Exp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            napitok = "Экспрессо";
        }

        private void Rus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            napitok = "Руссиано";
        }

        private void Cap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            napitok = "Капучино";
        }
        /*public void loading()
{
timer.
}*/
    }
}
