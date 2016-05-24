public partial class frmAddUpdate
{
    #region Windows Form Designer generated code
    private void InitializeComponent()
    {
        this.btnOK = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.txtZipCode = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.lblLastUpdated = new System.Windows.Forms.Label();
        this.chkActive = new System.Windows.Forms.CheckBox();
        this.txtCity = new System.Windows.Forms.TextBox();
        this.txtState = new System.Windows.Forms.TextBox();
        this.txtLongitude = new System.Windows.Forms.TextBox();
        this.txtLatitude = new System.Windows.Forms.TextBox();
        this.txtLastUpdated = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // btnOK
        // 
        this.btnOK.Location = new System.Drawing.Point(104, 221);
        this.btnOK.Name = "btnOK";
        this.btnOK.Size = new System.Drawing.Size(75, 23);
        this.btnOK.TabIndex = 7;
        this.btnOK.Text = "OK";
        this.btnOK.UseVisualStyleBackColor = true;
        this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(196, 221);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 23);
        this.btnCancel.TabIndex = 8;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // txtZipCode
        // 
        this.txtZipCode.Location = new System.Drawing.Point(104, 12);
        this.txtZipCode.Name = "txtZipCode";
        this.txtZipCode.Size = new System.Drawing.Size(167, 20);
        this.txtZipCode.TabIndex = 1;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(15, 15);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(53, 13);
        this.label1.TabIndex = 3;
        this.label1.Text = "Zip Code:";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(15, 41);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(27, 13);
        this.label2.TabIndex = 4;
        this.label2.Text = "City:";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(15, 67);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(35, 13);
        this.label3.TabIndex = 5;
        this.label3.Text = "State:";
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(15, 93);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(57, 13);
        this.label4.TabIndex = 6;
        this.label4.Text = "Longitude:";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(15, 119);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(48, 13);
        this.label5.TabIndex = 7;
        this.label5.Text = "Latitude:";
        // 
        // lblLastUpdated
        // 
        this.lblLastUpdated.AutoSize = true;
        this.lblLastUpdated.Location = new System.Drawing.Point(15, 179);
        this.lblLastUpdated.Name = "lblLastUpdated";
        this.lblLastUpdated.Size = new System.Drawing.Size(74, 13);
        this.lblLastUpdated.TabIndex = 8;
        this.lblLastUpdated.Text = "Last Updated:";
        // 
        // chkActive
        // 
        this.chkActive.AutoSize = true;
        this.chkActive.Location = new System.Drawing.Point(104, 153);
        this.chkActive.Name = "chkActive";
        this.chkActive.Size = new System.Drawing.Size(56, 17);
        this.chkActive.TabIndex = 6;
        this.chkActive.Text = "Active";
        this.chkActive.UseVisualStyleBackColor = true;
        // 
        // txtCity
        // 
        this.txtCity.Location = new System.Drawing.Point(104, 38);
        this.txtCity.Name = "txtCity";
        this.txtCity.Size = new System.Drawing.Size(167, 20);
        this.txtCity.TabIndex = 2;
        // 
        // txtState
        // 
        this.txtState.Location = new System.Drawing.Point(104, 64);
        this.txtState.Name = "txtState";
        this.txtState.Size = new System.Drawing.Size(167, 20);
        this.txtState.TabIndex = 3;
        // 
        // txtLongitude
        // 
        this.txtLongitude.Location = new System.Drawing.Point(104, 90);
        this.txtLongitude.Name = "txtLongitude";
        this.txtLongitude.Size = new System.Drawing.Size(167, 20);
        this.txtLongitude.TabIndex = 4;
        // 
        // txtLatitude
        // 
        this.txtLatitude.Location = new System.Drawing.Point(104, 116);
        this.txtLatitude.Name = "txtLatitude";
        this.txtLatitude.Size = new System.Drawing.Size(167, 20);
        this.txtLatitude.TabIndex = 5;
        // 
        // txtLastUpdated
        // 
        this.txtLastUpdated.Location = new System.Drawing.Point(104, 176);
        this.txtLastUpdated.Name = "txtLastUpdated";
        this.txtLastUpdated.ReadOnly = true;
        this.txtLastUpdated.Size = new System.Drawing.Size(167, 20);
        this.txtLastUpdated.TabIndex = 15;
        // 
        // frmAddUpdate
        // 
        this.AcceptButton = this.btnOK;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(287, 256);
        this.Controls.Add(this.txtLastUpdated);
        this.Controls.Add(this.txtLatitude);
        this.Controls.Add(this.txtLongitude);
        this.Controls.Add(this.txtState);
        this.Controls.Add(this.txtCity);
        this.Controls.Add(this.chkActive);
        this.Controls.Add(this.lblLastUpdated);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.txtZipCode);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnOK);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmAddUpdate";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Load += new System.EventHandler(this.frmAddUpdate_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    #endregion

    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TextBox txtZipCode;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblLastUpdated;
    private System.Windows.Forms.CheckBox chkActive;
    private System.Windows.Forms.TextBox txtCity;
    private System.Windows.Forms.TextBox txtState;
    private System.Windows.Forms.TextBox txtLongitude;
    private System.Windows.Forms.TextBox txtLatitude;
    private System.Windows.Forms.TextBox txtLastUpdated;
}

