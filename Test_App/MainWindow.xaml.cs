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
using MahApps.Metro.Controls;

namespace Test_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
      

        private static string userLogin;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnPreviousTab_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tcSample.SelectedIndex - 1;
            if (newIndex < 0)
                newIndex = tcSample.Items.Count - 1;
            tcSample.SelectedIndex = newIndex;
        }

        private void btnNextTab_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tcSample.SelectedIndex + 1;
            if (newIndex >= tcSample.Items.Count)
                newIndex = 0;
            tcSample.SelectedIndex = newIndex;
        }

        private void btnSelectedTab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Selected tab: " + (tcSample.SelectedItem as TabItem).Header);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            userLogin = LoginName.Text;
            Console.WriteLine($"After method call, value of a : {userLogin}");
            Process Putty = new Process();

            Putty.StartInfo.FileName = "putty.exe"; // Needs to be full path
            Putty.StartInfo.Arguments = $"-ssh root@{userLogin}"; // If you have any arguments

            bool result = Putty.Start();
        }
    }
}
