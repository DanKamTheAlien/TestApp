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
using System.Net.NetworkInformation;
using System.Net;
using MahApps.Metro.Controls.Dialogs;

namespace Test_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
      

        private static string ipAddress;
        public static string path=@"c:\test\IpAddress.txt";

        public MainWindow()
        {
            InitializeComponent();
            ipSettings();


        }

        private void ipSettings()
        {
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = "192.168.0.146";
                File.WriteAllText(path, createText);
            }
            string readText = File.ReadAllText(path);
            IP.Text = readText;
            currentIP.Text = readText;
        }

        private void putty_Click(object sender, RoutedEventArgs e)
        {
            string readText = File.ReadAllText(path);
            Console.WriteLine($"After method call, value of a : {ipAddress}");
            Process Putty = new Process();

            Putty.StartInfo.FileName = "putty.exe"; // Needs to be full path
            Putty.StartInfo.Arguments = $"-ssh root@{readText}"; // If you have any arguments

            bool result = Putty.Start();
        }
        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Application.Current.MainWindow,"Version 2","Version");
        }
        private void ip_save_Click(object sender, RoutedEventArgs e)
        {
            ipAddress = IP.Text;
            string createText = $"{ipAddress}";
            File.WriteAllText(path, createText);
            string readText = File.ReadAllText(path);
            currentIP.Text = readText;
        }
        private void gdata_Click(object sender, RoutedEventArgs e)
        {
            string path = @"c:\MyDir";
   
            // Determine whether the directory exists.
            if (Directory.Exists(path))
            {
                Console.WriteLine("That path exists already.");
                MessageBox.Show(Application.Current.MainWindow, "Directory already exists", "GData");
            return;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
        }
        private void ping_Click(object sender, RoutedEventArgs e)
        {
            string readText = File.ReadAllText(path);
            Ping pingSender = new Ping();
            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            // Wait 10 seconds for a reply.
            int timeout = 1000;
        
            // Set options for transmission:
            // The data can go through 64 gateways or routers
            // before it is destroyed, and the data packet
            // cannot be fragmented.
            PingOptions options = new PingOptions(64, true);

            // Send the request.
            PingReply reply = pingSender.Send(IPAddress.Parse($"{readText}"), timeout, buffer, options);

            if (reply.Status == IPStatus.Success)
            {
                MessageBox.Show(Application.Current.MainWindow, "Connection Successful", "Connect Test");
            }
            else
            {
                MessageBox.Show(Application.Current.MainWindow, "Connection Failed", "Connect Test");
            }
        }
        private async void ShowInputDialog(object sender, RoutedEventArgs e)
        {
            var result = await this.ShowInputAsync("Hello!", "What is your name?");

            if (result == null) //user pressed cancel
                return;

            await this.ShowMessageAsync("Hello", "Hello " + result + "!");
        }

    }
}
