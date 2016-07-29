using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NantUI.Util
{
    /// <summary>
    /// Dumb helper class to encapsulte the nant process reqs
    /// </summary>
    public class NantExec
    {
        private const string NantArgsFormat = "-buildfile:\"{0}\" {1} {2}";

        public EventHandler<DataReceivedEventArgs> OutputDataReceived;
        public EventHandler<DataReceivedEventArgs> ErrorDataReceived;



        public string NantPath { get; set; }
        public List<Target> Targets { get; set; }
        public List<Property> Properties { get; set; }

        public bool HasValidPath
        {
            get { return !(string.IsNullOrEmpty(NantPath) || !File.Exists(NantPath)); }
        }

        public string CurrentTargetNames
        {
            get { return Targets[0].Name; }
        }

        private string AllProperties
        {
            get { return ""; }
        }

        public NantExec()
        {
            Properties = new List<Property>();
            Targets = new List<Target>();
        }

        public NantExec(string path)
            : this()
        {
            NantPath = path;
        }

        public void Run(string nantFile)
        {
            var nant = getNantProcess(nantFile);
            {
                nant.Start();
                nant.BeginOutputReadLine();
                nant.BeginErrorReadLine();
                //nant.WaitForExit();
            }
        }

        private void nant_OutputReceived(object sender, DataReceivedEventArgs e)
        {
            if (OutputDataReceived != null)
                OutputDataReceived(this, e);
        }

        private void nant_ErrorReceived(object sender, DataReceivedEventArgs e)
        {
            if (ErrorDataReceived != null)
                ErrorDataReceived(this, e);
        }

        private Process getNantProcess(string nantFile)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = NantPath;
            info.Arguments = string.Format(NantArgsFormat, nantFile, CurrentTargetNames, AllProperties);
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.CreateNoWindow = true;

            Process nant = new Process();
            nant.StartInfo = info;
            nant.EnableRaisingEvents = true;
            nant.OutputDataReceived += nant_OutputReceived;
            nant.ErrorDataReceived += nant_ErrorReceived;

            return nant;
        }

        #region Static Error check
        // kind of silly, but I want some flexibility here...
        private static List<string> errorKeywords = new List<string>() { "error", "failure" };
        public static bool HasError(string update)
        {
            if (string.IsNullOrEmpty(update))
                return false;

            update = update.ToLower();

            foreach (var k in errorKeywords)
            {
                if (update.Contains(k))
                    return true;
            }

            return false;
        }
        #endregion
    }
}
