namespace PoE_Profile_Selector
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProfiles = new System.Windows.Forms.ComboBox();
            this.btnCreateProfile = new System.Windows.Forms.Button();
            this.txtPoEpath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSelectFolder = new System.Windows.Forms.Button();
            this.btnRunPoE = new System.Windows.Forms.Button();
            this.btnDelProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select profile or create new:";
            // 
            // cmbProfiles
            // 
            this.cmbProfiles.FormattingEnabled = true;
            this.cmbProfiles.Location = new System.Drawing.Point(158, 10);
            this.cmbProfiles.MaxLength = 32;
            this.cmbProfiles.Name = "cmbProfiles";
            this.cmbProfiles.Size = new System.Drawing.Size(121, 21);
            this.cmbProfiles.Sorted = true;
            this.cmbProfiles.TabIndex = 1;
            this.cmbProfiles.SelectedValueChanged += new System.EventHandler(this.cmbProfiles_SelectedValueChanged);
            this.cmbProfiles.TextChanged += new System.EventHandler(this.cmbProfiles_TextChanged);
            // 
            // btnCreateProfile
            // 
            this.btnCreateProfile.Enabled = false;
            this.btnCreateProfile.Location = new System.Drawing.Point(285, 2);
            this.btnCreateProfile.Name = "btnCreateProfile";
            this.btnCreateProfile.Size = new System.Drawing.Size(114, 34);
            this.btnCreateProfile.TabIndex = 2;
            this.btnCreateProfile.Text = "Create profile from current config";
            this.btnCreateProfile.UseVisualStyleBackColor = true;
            this.btnCreateProfile.Click += new System.EventHandler(this.btnCreateProfile_Click);
            // 
            // txtPoEpath
            // 
            this.txtPoEpath.Location = new System.Drawing.Point(109, 47);
            this.txtPoEpath.Name = "txtPoEpath";
            this.txtPoEpath.Size = new System.Drawing.Size(170, 20);
            this.txtPoEpath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path to PoE exe:";
            // 
            // cmbSelectFolder
            // 
            this.cmbSelectFolder.Location = new System.Drawing.Point(285, 45);
            this.cmbSelectFolder.Name = "cmbSelectFolder";
            this.cmbSelectFolder.Size = new System.Drawing.Size(25, 23);
            this.cmbSelectFolder.TabIndex = 5;
            this.cmbSelectFolder.Text = "...";
            this.cmbSelectFolder.UseVisualStyleBackColor = true;
            this.cmbSelectFolder.Click += new System.EventHandler(this.cmbSelectFolder_Click);
            // 
            // btnRunPoE
            // 
            this.btnRunPoE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRunPoE.Location = new System.Drawing.Point(217, 74);
            this.btnRunPoE.Name = "btnRunPoE";
            this.btnRunPoE.Size = new System.Drawing.Size(75, 23);
            this.btnRunPoE.TabIndex = 6;
            this.btnRunPoE.Text = "Run PoE";
            this.btnRunPoE.UseVisualStyleBackColor = true;
            this.btnRunPoE.Click += new System.EventHandler(this.btnRunPoE_Click);
            // 
            // btnDelProfile
            // 
            this.btnDelProfile.Enabled = false;
            this.btnDelProfile.Location = new System.Drawing.Point(405, 2);
            this.btnDelProfile.Name = "btnDelProfile";
            this.btnDelProfile.Size = new System.Drawing.Size(96, 34);
            this.btnDelProfile.TabIndex = 7;
            this.btnDelProfile.Text = "Delete selected profile";
            this.btnDelProfile.UseVisualStyleBackColor = true;
            this.btnDelProfile.Click += new System.EventHandler(this.btnDelProfile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 101);
            this.Controls.Add(this.btnDelProfile);
            this.Controls.Add(this.btnRunPoE);
            this.Controls.Add(this.cmbSelectFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPoEpath);
            this.Controls.Add(this.btnCreateProfile);
            this.Controls.Add(this.cmbProfiles);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PoE Profile Selector";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProfiles;
        private System.Windows.Forms.Button btnCreateProfile;
        private System.Windows.Forms.TextBox txtPoEpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmbSelectFolder;
        private System.Windows.Forms.Button btnRunPoE;
        private System.Windows.Forms.Button btnDelProfile;
    }
}

