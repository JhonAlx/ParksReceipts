using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ParkReceipts
{
    partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(this.CallSelenium))
            {
                Name = this.FileTxtBox.Text
            };
            t.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.FileTxtBox.Text = this.openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.destFolderTxtBox.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void CallSelenium()
        {
            MainProcess mp = new MainProcess()
            {
                MyForm = this,
                MyRichTextBox = this.statusRTB,
                FileName = this.FileTxtBox.Text,
                DownloadPath = this.destFolderTxtBox.Text,
                User = this.UserTxtBox.Text,
                Password = this.PwdTxtBox.Text
            };
            mp.Run();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}