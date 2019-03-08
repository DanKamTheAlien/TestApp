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
using System.IO;

namespace Test_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
      

        private static string userLogin;
        public static string path=@"c:\test\IpAddress.txt";
        public MainWindow()
        {
            InitializeComponent();
            string path = @"c:\test\IpAddress.txt";

            // This text is added only once to the file.
            if (!File.Exists(path1))
            {
                // Create a file to write to.
                string createText = "192.168.0.146" + Environment.NewLine;
                File.WriteAllText(path1, createText);
            }
            string readText = File.ReadAllText(path1);
            IP.Text = readText;


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
        private void button2_Click(object sender, RoutedEventArgs e)
        {
          //  string path = @"C:\Test\MyTest.txt";
          //  userLogin = LoginName.Text;
            MessageBox.Show(Application.Current.MainWindow,"Version 2","Version");
            // Create a file to write to.
           // string createText = $"{userLogin}" + Environment.NewLine;
            //File.WriteAllText(path, createText);
            // Open the file to read from.
           // string readText = File.ReadAllText(path);
           // Console.WriteLine(readText);
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            userLogin = IP.Text;
            string path = @"c:\test\IpAddress.txt";
            string createText = $"{userLogin}" + Environment.NewLine;
            File.WriteAllText(path, createText);
            string readText = File.ReadAllText(path);
        }
        }
}
