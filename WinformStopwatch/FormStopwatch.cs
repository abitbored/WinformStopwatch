using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Fiddler;
using Timer = System.Timers.Timer;

namespace WinformStopwatch
{
    public partial class FormStopwatch : Form
    {
        private const string _startStopwatchDisplay = "00:00:00.00";
        private Timer _timer;

        int h, m, s, ms;
        string Firstline { get; set; }

        public FormStopwatch()
        {
            InitializeComponent();

            lblStopwatch.Text = _startStopwatchDisplay;

            _timer = new Timer(interval: 1);
            _timer.Elapsed += OnTimerElapse;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ClassUrl.startUrl = tbStartUrl.Text;
            ClassUrl.stopUrl = tbStopUrl.Text;

            ShowSubmitMessageBox();
            tbStartUrl.ReadOnly = true;
            tbStopUrl.ReadOnly = true;
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            Installcert();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Removecert();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Starts();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stops();
        }

        private void OnTimerElapse(object sender, ElapsedEventArgs e)
        {
            //Application.Current.Dispatcher.Invoke(() =>
            //{
            //    ms += 1;
            //    if (ms == 100)
            //    {
            //        ms = 0;
            //        s += 1;
            //    }
            //    if (s == 60)
            //    {
            //        s = 0;
            //        m += 1;
            //    }
            //    if (m == 60)
            //    {
            //        m = 0;
            //        h += 1;

            //    }

            //    StopwatchDisplay.Text = String.Format("{0}:{1}:{2}.{3}", h.ToString().ToString().PadLeft(2, '0'), m.ToString().ToString().PadLeft(2, '0'), s.ToString().ToString().PadLeft(2, '0'), ms.ToString().ToString().PadLeft(2, '0'));
            //});

            this.Invoke((MethodInvoker)delegate {
                ms += 1;
                if (ms == 60)
                {
                    ms = 0;
                    s += 1;
                }
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;

                }

                lblStopwatch.Text = String.Format("{0}:{1}:{2}.{3}", h.ToString().ToString().PadLeft(2, '0'), m.ToString().ToString().PadLeft(2, '0'), s.ToString().ToString().PadLeft(2, '0'), ms.ToString().ToString().PadLeft(2, '0'));
            });
        }

        private void Installcert()
        {
            if (CertMaker.rootCertExists() == false)
            {
                CertMaker.createRootCert();
                CertMaker.trustRootCert();
            }
        }

        private void Removecert()
        {
            if (CertMaker.rootCertExists())
            {
                CertMaker.removeFiddlerGeneratedCerts();
            }
        }

        private void Starts()
        {
            if (!FiddlerApplication.IsStarted())
            {
                FiddlerCoreStartupSettings startupSettings =
                    new FiddlerCoreStartupSettingsBuilder()
                        .ListenOnPort(8888)
                        .RegisterAsSystemProxy()
                        .DecryptSSL()
                        .AllowRemoteClients()
                        .Build();

                FiddlerApplication.AfterSessionComplete += FiddlerApplication_AfterSessionComplete;
                FiddlerApplication.Startup(startupSettings);
            }
            else
            {

            }
        }

        private void FiddlerApplication_AfterSessionComplete(Session oSession)
        {
            if (oSession.RequestMethod == "CONNECT")
            {
                return;
            }
            if (oSession.RequestMethod == null || oSession.oRequest == null || oSession.oRequest.headers == null)
            {
                return;
            }

            string Headers = oSession.oRequest.headers.ToString();
            //string Body = Encoding.UTF8.GetString(oSession.RequestBody);
            //Firstline = oSession.RequestMethod + " " + oSession.fullUrl + " " + oSession.oRequest.headers.HTTPVersion;
            //Firstline = oSession.RequestMethod + " " + oSession.fullUrl;
            Firstline = oSession.fullUrl;
            int at = Headers.IndexOf("\r\n");
            if (at < 0)
            {
                return;
            }
            //string Output = Firstline + Environment.NewLine + Headers.Substring(at + 1);
            string Output = Firstline;
            //if (Body!= null)
            //{
            //    Output += Body + Environment.NewLine;
            //}
            //appentext(Output);
            Console.WriteLine(Output);
            Comparetext(Firstline);
            Comparestop(Firstline);
        }

        private void Stops()
        {
            if (!FiddlerApplication.IsStarted())
            {

            }
            else
            {
                FiddlerApplication.Shutdown();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ms = 0;
            s = 0;
            m = 0;
            h = 0;
            lblStopwatch.Text = _startStopwatchDisplay;

            tbStartUrl.ReadOnly = false;
            tbStopUrl.ReadOnly = false;
        }

        private void FormStopwatch_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CertMaker.rootCertExists())
            {
                CertMaker.removeFiddlerGeneratedCerts();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var stopwatchData = new List<string>();
                    stopwatchData.Add("Start URL,Stop URL,Start Time,Stop Time,Stopwatch");
                    stopwatchData.Add($"{ClassUrl.startUrl},{ClassUrl.stopUrl},{ClassUrl.startTime},{ClassUrl.stopTime},{lblStopwatch.Text}");

                    File.WriteAllLines(sfd.FileName, stopwatchData);

                    MessageBox.Show("Your data has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormStopwatch_Load(object sender, EventArgs e)
        {
            if (CertMaker.rootCertExists() == false)
            {
                CertMaker.createRootCert();
                CertMaker.trustRootCert();
            }
        }

        //private void btnExport_Click(object sender, EventArgs e)
        //{
        //    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
        //    {
        //        if (sfd.ShowDialog() == DialogResult.OK)
        //        {
        //            var classCollectionCSV = new List<string>();
        //            classCollectionCSV.Add("Class Name,Super Class Name,Class ID,Class Target");
        //            foreach (var item in ClassCollection)
        //            {
        //                classCollectionCSV.Add($"{item.className},{item.superClass},{item.id},{item.target}");
        //            }
        //            File.WriteAllLines(sfd.FileName, classCollectionCSV);

        //            MessageBox.Show("Your data has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //}

        private bool Comparetext(string value)
        {
            if (value == ClassUrl.startUrl)
            {
                _timer.Start();
                ClassUrl.startTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            }
            return true;
        }

        private async void Comparestop(string value)
        {
            await Task.Run(async () =>
            {
                if (Comparetext(Firstline) == true)
                {
                    if (value == ClassUrl.stopUrl)
                    {
                        _timer.Stop();
                        ClassUrl.stopTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    }
                    else
                    {
                        await Task.Delay(10000);
                        Comparestop(Firstline);
                    }
                }
            });

        }

        private void ShowSubmitMessageBox()
        {
            string message = "URL Submitted";
            string title = "Submit";

            MessageBox.Show(message, title);
        }
    }
}
