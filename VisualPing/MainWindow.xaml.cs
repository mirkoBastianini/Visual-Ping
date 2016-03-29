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
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;

namespace VisualPing
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
 string hostName = Dns.GetHostName(); 
            Console.WriteLine(hostName);
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            listBox.Items.Add("----------\n");
            listBox.Items.Add("Hostname: "+ hostName +"\n");
            listBox.Items.Add("IP: "+ myIP + "\n");
            listBox.Items.Add("----------");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
        
            for (int i=0; i < 4; i++)
            {
                using(Ping p = new Ping())
                {
                    PingReply reply = p.Send(textBox.Text, 1000);
                    listBox.Items.Add("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
        }

        

        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
