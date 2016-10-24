using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ParkReceipts
{
    internal class MainProcess
    {
        private const string LOGIN_URL = "https://expressexpense.com/login.php";

        private IWebDriver driver;

        public string DownloadPath
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public Form MyForm
        {
            get;
            set;
        }

        public RichTextBox MyRichTextBox
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        public MainProcess()
        {
        }

        private void FillData()
        {
            FileInfo fileInfo = new FileInfo(this.FileName);
            try
            {
                this.Log(string.Concat("Loading file ", fileInfo.Name));
                ExcelPackage package = new ExcelPackage(fileInfo);
                try
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets.First<ExcelWorksheet>();
                    this.Log("Loading info...");
                    for (int i = 2; i < sheet.Dimension.End.Row + 1; i++)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddUserProfilePreference("download.default_directory", this.DownloadPath);
                        this.driver = new ChromeDriver(options);
                        this.Login();
                        Thread.Sleep(3000);
                        
                        driver.FindElement(By.XPath("//a[@href='itemize4.php']")).Click();
                        
                        IWebElement dateTextBox = this.driver.FindElement(By.Name("text-date"));
                        IWebElement timeTextBox = this.driver.FindElement(By.Name("text-time"));
                        IWebElement businessTextBox = this.driver.FindElement(By.Name("text-business"));
                        IWebElement addressTextBox = this.driver.FindElement(By.Name("text-address"));
                        IWebElement cityTextBox = this.driver.FindElement(By.Name("text-location"));
                        IWebElement costTextBox = this.driver.FindElement(By.Name("text-cost"));
                        IWebElement tipTextBox = this.driver.FindElement(By.Name("text-tip"));
                        IWebElement paymentTextBox = this.driver.FindElement(By.Name("text-last4"));
                        IWebElement submitBtn = this.driver.FindElement(By.Name("createmark"));
                        IWebElement qty = this.driver.FindElement(By.Name("p_qty[]"));
                        IWebElement item = this.driver.FindElement(By.Name("p_scnt[]"));
                        IWebElement cost = this.driver.FindElement(By.Name("p_price[]"));
                        dateTextBox.Clear();
                        timeTextBox.Clear();
                        businessTextBox.Clear();
                        addressTextBox.Clear();
                        cityTextBox.Clear();
                        costTextBox.Clear();
                        tipTextBox.Clear();
                        paymentTextBox.Clear();
                        dateTextBox.SendKeys(sheet.Cells[i, 1].Text);
                        timeTextBox.SendKeys(sheet.Cells[i, 2].Text);
                        businessTextBox.SendKeys(sheet.Cells[i, 3].Text);
                        addressTextBox.SendKeys(sheet.Cells[i, 4].Text);
                        cityTextBox.SendKeys(sheet.Cells[i, 5].Text);
                        costTextBox.SendKeys(sheet.Cells[i, 6].Text);
                        tipTextBox.SendKeys(sheet.Cells[i, 7].Text);
                        paymentTextBox.SendKeys(sheet.Cells[i, 8].Text);
                        qty.SendKeys(sheet.Cells[i, 9].Text);
                        item.SendKeys(sheet.Cells[i, 10].Text);
                        cost.SendKeys(sheet.Cells[i, 11].Text);
                        this.Log(string.Concat("Loaded data on row ", i - 1));
                        submitBtn.Click();
                        Thread.Sleep(1000);
                        this.Log(string.Concat("Downloading receipt image ", i - 1));
                        //this.driver.FindElement(By.Name("createmark")).Click();
                        //Thread.Sleep(5000);
                        this.driver.FindElement(By.XPath("//a[contains(@href, 'dl')]")).Click();
                        this.Log(string.Concat("Downloaded receipt image ", i - 1));
                        Thread.Sleep(5000);
                        this.driver.Quit();
                    }
                    this.Log("Finished task");
                    this.driver.Quit();
                }
                finally
                {
                    if (package != null)
                    {
                        ((IDisposable)package).Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                this.LogException(exception);
            }
        }

        private void Log(string text)
        {
            this.MyForm.Invoke(new Action(() =>
            {
                RichTextBox myRichTextBox = this.MyRichTextBox;
                myRichTextBox.Text = string.Concat(myRichTextBox.Text, text, Environment.NewLine);
                this.MyRichTextBox.SelectionStart = this.MyRichTextBox.Text.Length;
                this.MyRichTextBox.ScrollToCaret();
            }));
            this.MyForm.Invoke(new Action(() => this.MyForm.Refresh()));
        }

        private void LogException(Exception ex)
        {
            this.MyForm.Invoke(new Action(() =>
            {
                RichTextBox myRichTextBox = this.MyRichTextBox;
                myRichTextBox.Text = string.Concat(myRichTextBox.Text, ex.Message, Environment.NewLine);
                RichTextBox richTextBox = this.MyRichTextBox;
                richTextBox.Text = string.Concat(richTextBox.Text, ex.StackTrace, Environment.NewLine);
                this.MyRichTextBox.SelectionStart = this.MyRichTextBox.Text.Length;
                this.MyRichTextBox.ScrollToCaret();
            }));
            this.MyForm.Invoke(new Action(() => this.MyForm.Refresh()));
        }

        private bool Login()
        {
            bool returnValue = false;
            this.driver.Url = "https://expressexpense.com/login.php";
            this.driver.Navigate();
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5000));
            try
            {
                IWebElement userTextBox = this.driver.FindElement(By.Name("user_name"));
                IWebElement pwTextBox = this.driver.FindElement(By.Name("password"));
                IWebElement submitBtn = this.driver.FindElement(By.Name("createmark"));
                userTextBox.SendKeys(this.User);
                pwTextBox.SendKeys(this.Password);
                submitBtn.Click();
                Thread.Sleep(5000);
                returnValue = (!(this.driver.Url == "https://expressexpense.com/index.php") ? false : true);
            }
            catch (Exception exception)
            {
                this.LogException(exception);
            }
            return returnValue;
        }

        public void Run()
        {
            this.Log(string.Concat("Starting scraping job on thread ID ", Thread.CurrentThread.ManagedThreadId));
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", this.DownloadPath);
            this.driver = new ChromeDriver(options);
            this.Log(string.Concat("Trying to log user in on thread ID: ", Thread.CurrentThread.ManagedThreadId));
            if (!this.Login())
            {
                this.Log("Failed login! Check your credentials");
                this.driver.Close();
            }
            else
            {
                this.Log("Logged in correctly!");
                this.driver.Quit();
                this.FillData();
            }
        }
    }
}
