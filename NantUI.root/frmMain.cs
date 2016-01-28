using System;
using System.ComponentModel;
using System.Windows.Forms;
using NantUI.Util;
using System.IO;
using System.Diagnostics;

namespace NantUI
{
    public partial class frmMain : Form
    {
        delegate void UpdateOutputDelegate(string output);

        //private KeyPressHandler keyHandler;
        private NantExec nant;
        private NantFile parsedFile;
        private BackgroundWorker loadWorker;
        private BackgroundWorker runWorker;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            loadWorker = new BackgroundWorker();
            loadWorker.DoWork += loadWorker_DoWork;
            loadWorker.RunWorkerCompleted += loadWorker_RunWorkerCompleted;

            runWorker = new BackgroundWorker();
            runWorker.DoWork += runWorker_DoWork;
            runWorker.RunWorkerCompleted += runWorker_RunWorkerCompleted;


            if (string.IsNullOrEmpty(Config.NantPath) || !File.Exists(Config.NantPath))
            {
                UpdateStatus(StatusType.Update, "You must set a location for NAnt before you will be able to run.");
                btnLoadNant.Visible = true;
            }

            nant = new NantExec(Config.NantPath);
            nant.OutputDataReceived += nant_OutputDataReceived;
            nant.ErrorDataReceived += nant_ErrorDataReceived;

            labBuildFile.Text = File.Exists(Config.DefaultFile) ? Config.DefaultFile : string.Empty;

            LoadTargets();
        }
        enum StatusType
        {
            LoadError,
            InputError,
            FileError,
            RunError,
            Update
        }
        private void UpdateStatus(StatusType type, string msg)
        {
            string typeMsg = "";
            switch (type)
            {
                case StatusType.LoadError:
                    typeMsg = "Cannot Load: ";
                    break;
                case StatusType.FileError:
                    typeMsg = "File Error: ";
                    break;
                case StatusType.InputError:
                    typeMsg = "Validation Error: ";
                    break;
                case StatusType.RunError:
                    typeMsg = "NAnt Execution Error: ";
                    break;
            }
            labStatus.Text = typeMsg + msg;
        }

        void nant_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
                UpdateOutput("ERROR: " + e.Data);
        }

        void nant_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            UpdateOutput(e.Data);
        }

        private void UpdateOutput(string data)
        {
            if (edtLog.InvokeRequired)
            {
                var d = new UpdateOutputDelegate(UpdateOutput);
                edtLog.BeginInvoke(d, new object[] { data });
            }
            else
                edtLog.AppendText(Environment.NewLine + data);
        }

        private void LoadTargets()
        {
            nant.Targets.Clear();
            string nantFile = labBuildFile.Text;

            if (!string.IsNullOrEmpty(nantFile))
            {
                if (!File.Exists(nantFile))
                {
                    UpdateStatus(StatusType.InputError, "File not found.");
                    return;
                }

                UpdateStatus(StatusType.Update, "Loading file...");

                loadWorker.RunWorkerAsync(nantFile);
            }
            else
                UpdateStatus(StatusType.InputError, "No file selected.");
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                parsedFile = new NantFile((string)e.Argument);
            }
            catch
            {
                parsedFile = null;
            }
        }

        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (parsedFile == null)
            {
                UpdateStatus(StatusType.FileError, "Error parsing nant file.");
                return;
            }
            lstTarget.Clear();
            ColumnHeader head;
            head = new ColumnHeader();
            head.Text = "Target";
            head.Width = 200;
            lstTarget.Columns.Add(head);
            head = new ColumnHeader();
            head.Name = "Description";
            head.Width = 300;
            lstTarget.Columns.Add(head);

            for (int i = 0; i < parsedFile.Targets.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = parsedFile.Targets[i].Name;
                item.SubItems.Add(parsedFile.Targets[i].Description);
                item.SubItems.Add(i.ToString());
                lstTarget.Items.Add(item);
            }

            if (lstTarget.Items.Count == 0)
                UpdateStatus(StatusType.FileError, "No valid targets found.");
            else
            {
                UpdateStatus(StatusType.Update, "Load completed.");
            }
        }

        void runWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateStatus(StatusType.Update, "Execution completed.");
        }

        void runWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!nant.HasValidPath)
            {
                UpdateOutput("ERROR : No valid Nant File found..");
                return;
            }

            nant.Run((string)e.Argument);
        }

        private void lstTarget_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edtLog.Clear();
            ListViewHitTestInfo info = lstTarget.HitTest(e.X, e.Y);
            nant.Targets.Clear();
            nant.Targets.Add(parsedFile.Targets[int.Parse(info.Item.SubItems[2].Text)]);
            runWorker.RunWorkerAsync(labBuildFile.Text);
        }

        private void btnLoadNant_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Exe File(*.exe)|*.exe";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                nant.NantPath = dlg.FileName;
            }
        }

        private void btnReloadBuild_Click(object sender, EventArgs e)
        {
            LoadTargets();
        }

        private void btnLoadBuild_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                labBuildFile.Text = dlg.FileName;
                LoadTargets();
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (lstTarget.FocusedItem != null)
            {
                nant.Targets.Clear();
                nant.Targets.Add(parsedFile.Targets[int.Parse(lstTarget.FocusedItem.SubItems[2].Text)]);
                runWorker.RunWorkerAsync(labBuildFile.Text);
            }
        }
    }
}
