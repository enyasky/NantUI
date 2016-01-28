namespace NantUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panTool = new System.Windows.Forms.Panel();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnReloadBuild = new System.Windows.Forms.Button();
            this.btnLoadBuild = new System.Windows.Forms.Button();
            this.btnLoadNant = new System.Windows.Forms.Button();
            this.labBuildFile = new System.Windows.Forms.Label();
            this.lstTarget = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.edtLog = new System.Windows.Forms.TextBox();
            this.panTool.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTool
            // 
            this.panTool.Controls.Add(this.btnBuild);
            this.panTool.Controls.Add(this.btnReloadBuild);
            this.panTool.Controls.Add(this.btnLoadBuild);
            this.panTool.Controls.Add(this.btnLoadNant);
            this.panTool.Controls.Add(this.labBuildFile);
            this.panTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTool.Location = new System.Drawing.Point(0, 0);
            this.panTool.Name = "panTool";
            this.panTool.Size = new System.Drawing.Size(707, 65);
            this.panTool.TabIndex = 0;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(605, 33);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(99, 25);
            this.btnBuild.TabIndex = 4;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // btnReloadBuild
            // 
            this.btnReloadBuild.Location = new System.Drawing.Point(219, 33);
            this.btnReloadBuild.Name = "btnReloadBuild";
            this.btnReloadBuild.Size = new System.Drawing.Size(99, 25);
            this.btnReloadBuild.TabIndex = 3;
            this.btnReloadBuild.Text = "Reload Build";
            this.btnReloadBuild.UseVisualStyleBackColor = true;
            this.btnReloadBuild.Click += new System.EventHandler(this.btnReloadBuild_Click);
            // 
            // btnLoadBuild
            // 
            this.btnLoadBuild.Location = new System.Drawing.Point(112, 33);
            this.btnLoadBuild.Name = "btnLoadBuild";
            this.btnLoadBuild.Size = new System.Drawing.Size(99, 25);
            this.btnLoadBuild.TabIndex = 2;
            this.btnLoadBuild.Text = "Build File ..";
            this.btnLoadBuild.UseVisualStyleBackColor = true;
            this.btnLoadBuild.Click += new System.EventHandler(this.btnLoadBuild_Click);
            // 
            // btnLoadNant
            // 
            this.btnLoadNant.Location = new System.Drawing.Point(3, 33);
            this.btnLoadNant.Name = "btnLoadNant";
            this.btnLoadNant.Size = new System.Drawing.Size(99, 25);
            this.btnLoadNant.TabIndex = 1;
            this.btnLoadNant.Text = "Nant File ..";
            this.btnLoadNant.UseVisualStyleBackColor = true;
            this.btnLoadNant.Click += new System.EventHandler(this.btnLoadNant_Click);
            // 
            // labBuildFile
            // 
            this.labBuildFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.labBuildFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.labBuildFile.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labBuildFile.ForeColor = System.Drawing.Color.White;
            this.labBuildFile.Location = new System.Drawing.Point(0, 0);
            this.labBuildFile.Name = "labBuildFile";
            this.labBuildFile.Size = new System.Drawing.Size(707, 24);
            this.labBuildFile.TabIndex = 0;
            this.labBuildFile.Text = "label1";
            this.labBuildFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstTarget
            // 
            this.lstTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.lstTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstTarget.ForeColor = System.Drawing.Color.White;
            this.lstTarget.FullRowSelect = true;
            this.lstTarget.Location = new System.Drawing.Point(0, 65);
            this.lstTarget.Name = "lstTarget";
            this.lstTarget.Size = new System.Drawing.Size(707, 242);
            this.lstTarget.TabIndex = 1;
            this.lstTarget.UseCompatibleStateImageBehavior = false;
            this.lstTarget.View = System.Windows.Forms.View.Details;
            this.lstTarget.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstTarget_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 593);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip1.Size = new System.Drawing.Size(707, 27);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = false;
            this.labStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(611, 20);
            this.labStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edtLog
            // 
            this.edtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.edtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLog.ForeColor = System.Drawing.Color.White;
            this.edtLog.Location = new System.Drawing.Point(0, 307);
            this.edtLog.Multiline = true;
            this.edtLog.Name = "edtLog";
            this.edtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edtLog.Size = new System.Drawing.Size(707, 286);
            this.edtLog.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 620);
            this.Controls.Add(this.edtLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstTarget);
            this.Controls.Add(this.panTool);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nant UI";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panTool.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panTool;
        private System.Windows.Forms.ListView lstTarget;
        private System.Windows.Forms.Label labBuildFile;
        private System.Windows.Forms.Button btnLoadBuild;
        private System.Windows.Forms.Button btnLoadNant;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnReloadBuild;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labStatus;
        private System.Windows.Forms.TextBox edtLog;
    }
}

