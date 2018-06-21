namespace CsscSettings.forms
{
    partial class FrmSystemTools
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
            this.btnChangePsd = new System.Windows.Forms.Button();
            this.btnRecovery = new System.Windows.Forms.Button();
            this.btnReboot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangePsd
            // 
            this.btnChangePsd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangePsd.Location = new System.Drawing.Point(12, 12);
            this.btnChangePsd.Name = "btnChangePsd";
            this.btnChangePsd.Size = new System.Drawing.Size(214, 73);
            this.btnChangePsd.TabIndex = 0;
            this.btnChangePsd.Text = "修改登录密码";
            this.btnChangePsd.UseVisualStyleBackColor = true;
            this.btnChangePsd.Click += new System.EventHandler(this.btnChangePsd_Click);
            // 
            // btnRecovery
            // 
            this.btnRecovery.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecovery.Location = new System.Drawing.Point(12, 109);
            this.btnRecovery.Name = "btnRecovery";
            this.btnRecovery.Size = new System.Drawing.Size(214, 73);
            this.btnRecovery.TabIndex = 0;
            this.btnRecovery.Text = "恢  复";
            this.btnRecovery.UseVisualStyleBackColor = true;
            this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click);
            // 
            // btnReboot
            // 
            this.btnReboot.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReboot.Location = new System.Drawing.Point(12, 206);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(214, 73);
            this.btnReboot.TabIndex = 0;
            this.btnReboot.Text = "重  启";
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.btnReboot_Click);
            // 
            // FrmSystemTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 290);
            this.Controls.Add(this.btnReboot);
            this.Controls.Add(this.btnRecovery);
            this.Controls.Add(this.btnChangePsd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSystemTools";
            this.Text = "FrmSystemTools";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSystemTools_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChangePsd;
        private System.Windows.Forms.Button btnRecovery;
        private System.Windows.Forms.Button btnReboot;
    }
}