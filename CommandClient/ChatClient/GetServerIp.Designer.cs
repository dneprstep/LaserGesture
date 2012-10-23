namespace ChatClient
{
	 partial class GetServerIp
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
            if ( disposing && ( components != null ) )
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
			  this.lblUserName = new Proshot.UtilityLib.Label();
			  this.btnEnter = new Proshot.UtilityLib.Button();
			  this.btnExit = new Proshot.UtilityLib.Button();
			  this.serverName = new System.Windows.Forms.MaskedTextBox();
			  this.SuspendLayout();
			  // 
			  // lblUserName
			  // 
			  this.lblUserName.AutoSize = true;
			  this.lblUserName.BorderWidth = 1F;
			  this.lblUserName.Location = new System.Drawing.Point(4, 9);
			  this.lblUserName.Name = "lblUserName";
			  this.lblUserName.Size = new System.Drawing.Size(84, 14);
			  this.lblUserName.TabIndex = 0;
			  this.lblUserName.Text = "Имя сервера:";
			  // 
			  // btnEnter
			  // 
			  this.btnEnter.Location = new System.Drawing.Point(66, 35);
			  this.btnEnter.Name = "btnEnter";
			  this.btnEnter.Size = new System.Drawing.Size(57, 23);
			  this.btnEnter.TabIndex = 2;
			  this.btnEnter.Text = "Ввести";
			  this.btnEnter.UseVisualStyleBackColor = true;
			  this.btnEnter.Click += new System.EventHandler(this.btnEnterClick);
			  // 
			  // btnExit
			  // 
			  this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			  this.btnExit.Location = new System.Drawing.Point(128, 35);
			  this.btnExit.Name = "btnExit";
			  this.btnExit.Size = new System.Drawing.Size(61, 23);
			  this.btnExit.TabIndex = 3;
			  this.btnExit.Text = "Отмена";
			  this.btnExit.UseVisualStyleBackColor = true;
			  this.btnExit.Click += new System.EventHandler(this.btnExitClick);
			  // 
			  // serverName
			  // 
			  this.serverName.Location = new System.Drawing.Point(90, 4);
			  this.serverName.Mask = "000.000.000.000";
			  this.serverName.Name = "serverName";
			  this.serverName.Size = new System.Drawing.Size(100, 22);
			  this.serverName.TabIndex = 1;
			  this.serverName.Text = "192168137";
			  // 
			  // GetServerIp
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			  this.ClientSize = new System.Drawing.Size(194, 62);
			  this.ControlBox = false;
			  this.Controls.Add(this.serverName);
			  this.Controls.Add(this.btnExit);
			  this.Controls.Add(this.btnEnter);
			  this.Controls.Add(this.lblUserName);
			  this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			  this.Name = "GetServerIp";
			  this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			  this.ShowIcon = false;
			  this.ShowInTaskbar = false;
			  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			  this.ResumeLayout(false);
			  this.PerformLayout();

        }

        #endregion

		  private Proshot.UtilityLib.Label lblUserName;
        private Proshot.UtilityLib.Button btnEnter;
        private Proshot.UtilityLib.Button btnExit;
		  private System.Windows.Forms.MaskedTextBox serverName;

    }
}