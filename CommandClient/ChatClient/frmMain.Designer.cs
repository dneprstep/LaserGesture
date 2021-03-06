namespace ChatClient
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
			  this.components = new System.ComponentModel.Container();
			  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			  this.cnxMnuEdit = new Proshot.UtilityLib.ContextMenuStrip();
			  this.mniCopy = new System.Windows.Forms.ToolStripMenuItem();
			  this.mniPaste = new System.Windows.Forms.ToolStripMenuItem();
			  this.imgList = new System.Windows.Forms.ImageList(this.components);
			  this.mnuMain = new Proshot.UtilityLib.MenuStrip();
			  this.mniChat = new System.Windows.Forms.ToolStripMenuItem();
			  this.mniEnter = new System.Windows.Forms.ToolStripMenuItem();
			  this.ввестиIPСервераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			  this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			  this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
			  this.splitContainer = new System.Windows.Forms.SplitContainer();
			  this.lstViwUsers = new Proshot.UtilityLib.ListView();
			  this.colIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			  this.colUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			  this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			  this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			  this.pictureBox1 = new System.Windows.Forms.PictureBox();
			  this.CancelEvent = new System.Windows.Forms.Button();
			  this.StartEvent = new System.Windows.Forms.Button();
			  this.txtMessages = new System.Windows.Forms.TextBox();
			  this.cnxMniCopy = new Proshot.UtilityLib.ContextMenuStrip();
			  this.mniCopyText = new System.Windows.Forms.ToolStripMenuItem();
			  this.Messages = new System.Windows.Forms.Label();
			  this.GetImage = new System.Windows.Forms.Button();
			  this.cnxMnuEdit.SuspendLayout();
			  this.mnuMain.SuspendLayout();
			  this.splitContainer.Panel1.SuspendLayout();
			  this.splitContainer.Panel2.SuspendLayout();
			  this.splitContainer.SuspendLayout();
			  this.splitContainer1.Panel1.SuspendLayout();
			  this.splitContainer1.Panel2.SuspendLayout();
			  this.splitContainer1.SuspendLayout();
			  this.splitContainer2.Panel1.SuspendLayout();
			  this.splitContainer2.Panel2.SuspendLayout();
			  this.splitContainer2.SuspendLayout();
			  ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			  this.cnxMniCopy.SuspendLayout();
			  this.SuspendLayout();
			  // 
			  // cnxMnuEdit
			  // 
			  this.cnxMnuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCopy,
            this.mniPaste});
			  this.cnxMnuEdit.Name = "cnxMnuEdit";
			  this.cnxMnuEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			  this.cnxMnuEdit.Size = new System.Drawing.Size(127, 48);
			  // 
			  // mniCopy
			  // 
			  this.mniCopy.Name = "mniCopy";
			  this.mniCopy.Size = new System.Drawing.Size(126, 22);
			  this.mniCopy.Text = "کپی متن";
			  // 
			  // mniPaste
			  // 
			  this.mniPaste.Name = "mniPaste";
			  this.mniPaste.Size = new System.Drawing.Size(126, 22);
			  this.mniPaste.Text = "انداختن متن";
			  // 
			  // imgList
			  // 
			  this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			  this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			  this.imgList.Images.SetKeyName(0, "Smiely.png");
			  this.imgList.Images.SetKeyName(1, "Private.ico");
			  this.imgList.Images.SetKeyName(2, "SendMessage.ico");
			  this.imgList.Images.SetKeyName(3, "Enter.ico");
			  this.imgList.Images.SetKeyName(4, "Exit.ico");
			  // 
			  // mnuMain
			  // 
			  this.mnuMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mnuMain.BackgroundImage")));
			  this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniChat});
			  this.mnuMain.Location = new System.Drawing.Point(0, 0);
			  this.mnuMain.Name = "mnuMain";
			  this.mnuMain.Size = new System.Drawing.Size(1040, 24);
			  this.mnuMain.TabIndex = 7;
			  this.mnuMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MakeShot);
			  // 
			  // mniChat
			  // 
			  this.mniChat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniEnter,
            this.ввестиIPСервераToolStripMenuItem,
            this.toolStripMenuItem1,
            this.mniExit});
			  this.mniChat.Name = "mniChat";
			  this.mniChat.Size = new System.Drawing.Size(111, 20);
			  this.mniChat.Text = "Аутентификация";
			  // 
			  // mniEnter
			  // 
			  this.mniEnter.Enabled = false;
			  this.mniEnter.Image = ((System.Drawing.Image)(resources.GetObject("mniEnter.Image")));
			  this.mniEnter.Name = "mniEnter";
			  this.mniEnter.Size = new System.Drawing.Size(171, 22);
			  this.mniEnter.Text = "Вход";
			  this.mniEnter.Click += new System.EventHandler(this.mniEnter_Click);
			  // 
			  // ввестиIPСервераToolStripMenuItem
			  // 
			  this.ввестиIPСервераToolStripMenuItem.Name = "ввестиIPСервераToolStripMenuItem";
			  this.ввестиIPСервераToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			  this.ввестиIPСервераToolStripMenuItem.Text = "Ввести IP сервера";
			  this.ввестиIPСервераToolStripMenuItem.Click += new System.EventHandler(this.SetServerIp);
			  // 
			  // toolStripMenuItem1
			  // 
			  this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			  this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
			  // 
			  // mniExit
			  // 
			  this.mniExit.Image = ((System.Drawing.Image)(resources.GetObject("mniExit.Image")));
			  this.mniExit.Name = "mniExit";
			  this.mniExit.Size = new System.Drawing.Size(171, 22);
			  this.mniExit.Text = "Выход";
			  this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
			  // 
			  // splitContainer
			  // 
			  this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							  | System.Windows.Forms.AnchorStyles.Left)
							  | System.Windows.Forms.AnchorStyles.Right)));
			  this.splitContainer.Enabled = false;
			  this.splitContainer.Location = new System.Drawing.Point(0, 27);
			  this.splitContainer.Name = "splitContainer";
			  // 
			  // splitContainer.Panel1
			  // 
			  this.splitContainer.Panel1.Controls.Add(this.lstViwUsers);
			  this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			  this.splitContainer.Panel1MinSize = 130;
			  // 
			  // splitContainer.Panel2
			  // 
			  this.splitContainer.Panel2.Controls.Add(this.splitContainer1);
			  this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			  this.splitContainer.Size = new System.Drawing.Size(1040, 451);
			  this.splitContainer.SplitterDistance = 180;
			  this.splitContainer.TabIndex = 8;
			  this.splitContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MakeShot);
			  // 
			  // lstViwUsers
			  // 
			  this.lstViwUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
			  this.lstViwUsers.Alignment = System.Windows.Forms.ListViewAlignment.Default;
			  this.lstViwUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIcon,
            this.colUserName});
			  this.lstViwUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.lstViwUsers.FullRowSelect = true;
			  this.lstViwUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			  this.lstViwUsers.HideSelection = false;
			  this.lstViwUsers.LabelWrap = false;
			  this.lstViwUsers.Location = new System.Drawing.Point(0, 0);
			  this.lstViwUsers.MultiSelect = false;
			  this.lstViwUsers.Name = "lstViwUsers";
			  this.lstViwUsers.RightToLeftLayout = true;
			  this.lstViwUsers.Size = new System.Drawing.Size(180, 451);
			  this.lstViwUsers.SmallImageList = this.imgList;
			  this.lstViwUsers.TabIndex = 8;
			  this.lstViwUsers.UseCompatibleStateImageBehavior = false;
			  this.lstViwUsers.View = System.Windows.Forms.View.Details;
			  this.lstViwUsers.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MakeShot);
			  // 
			  // colIcon
			  // 
			  this.colIcon.Text = "";
			  this.colIcon.Width = 23;
			  // 
			  // colUserName
			  // 
			  this.colUserName.Text = "";
			  this.colUserName.Width = 85;
			  // 
			  // splitContainer1
			  // 
			  this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			  this.splitContainer1.Name = "splitContainer1";
			  // 
			  // splitContainer1.Panel1
			  // 
			  this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			  // 
			  // splitContainer1.Panel2
			  // 
			  this.splitContainer1.Panel2.Controls.Add(this.txtMessages);
			  this.splitContainer1.Size = new System.Drawing.Size(856, 451);
			  this.splitContainer1.SplitterDistance = 645;
			  this.splitContainer1.TabIndex = 0;
			  // 
			  // splitContainer2
			  // 
			  this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			  this.splitContainer2.Name = "splitContainer2";
			  this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			  // 
			  // splitContainer2.Panel1
			  // 
			  this.splitContainer2.Panel1.Controls.Add(this.pictureBox1);
			  this.splitContainer2.Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MakeShot);
			  // 
			  // splitContainer2.Panel2
			  // 
			  this.splitContainer2.Panel2.Controls.Add(this.GetImage);
			  this.splitContainer2.Panel2.Controls.Add(this.CancelEvent);
			  this.splitContainer2.Panel2.Controls.Add(this.StartEvent);
			  this.splitContainer2.Panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MakeShot);
			  this.splitContainer2.Size = new System.Drawing.Size(645, 451);
			  this.splitContainer2.SplitterDistance = 326;
			  this.splitContainer2.TabIndex = 12;
			  // 
			  // pictureBox1
			  // 
			  this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			  this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			  this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			  this.pictureBox1.Location = new System.Drawing.Point(136, 12);
			  this.pictureBox1.Name = "pictureBox1";
			  this.pictureBox1.Size = new System.Drawing.Size(400, 300);
			  this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			  this.pictureBox1.TabIndex = 11;
			  this.pictureBox1.TabStop = false;
			  this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MakeShot);
			  // 
			  // CancelEvent
			  // 
			  this.CancelEvent.Enabled = false;
			  this.CancelEvent.Location = new System.Drawing.Point(391, 14);
			  this.CancelEvent.Name = "CancelEvent";
			  this.CancelEvent.Size = new System.Drawing.Size(243, 89);
			  this.CancelEvent.TabIndex = 0;
			  this.CancelEvent.Text = "Закончить";
			  this.CancelEvent.UseVisualStyleBackColor = true;
			  this.CancelEvent.Click += new System.EventHandler(this.cancelServer);
			  // 
			  // StartEvent
			  // 
			  this.StartEvent.Location = new System.Drawing.Point(144, 14);
			  this.StartEvent.Name = "StartEvent";
			  this.StartEvent.Size = new System.Drawing.Size(237, 89);
			  this.StartEvent.TabIndex = 0;
			  this.StartEvent.Text = "Старт";
			  this.StartEvent.UseVisualStyleBackColor = true;
			  this.StartEvent.Click += new System.EventHandler(this.startServer);
			  // 
			  // txtMessages
			  // 
			  this.txtMessages.Location = new System.Drawing.Point(4, 3);
			  this.txtMessages.Multiline = true;
			  this.txtMessages.Name = "txtMessages";
			  this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			  this.txtMessages.Size = new System.Drawing.Size(192, 424);
			  this.txtMessages.TabIndex = 0;
			  this.txtMessages.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MakeShot);
			  // 
			  // cnxMniCopy
			  // 
			  this.cnxMniCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCopyText});
			  this.cnxMniCopy.Name = "cnxMniCopy";
			  this.cnxMniCopy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			  this.cnxMniCopy.Size = new System.Drawing.Size(114, 26);
			  // 
			  // mniCopyText
			  // 
			  this.mniCopyText.Name = "mniCopyText";
			  this.mniCopyText.Size = new System.Drawing.Size(113, 22);
			  this.mniCopyText.Text = "کپی متن";
			  // 
			  // Messages
			  // 
			  this.Messages.AutoSize = true;
			  this.Messages.Font = new System.Drawing.Font("Tahoma", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			  this.Messages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			  this.Messages.Location = new System.Drawing.Point(33, 489);
			  this.Messages.Name = "Messages";
			  this.Messages.Size = new System.Drawing.Size(974, 18);
			  this.Messages.TabIndex = 9;
			  this.Messages.Text = "Подключение не выполнено. Повторите подключение выбрав в пункте меню \"Аутентифика" +
					"я\" раздел \"ВВЕСТИ IP СЕРВЕРА\"";
			  // 
			  // GetImage
			  // 
			  this.GetImage.Location = new System.Drawing.Point(16, 14);
			  this.GetImage.Name = "GetImage";
			  this.GetImage.Size = new System.Drawing.Size(118, 89);
			  this.GetImage.TabIndex = 1;
			  this.GetImage.Text = "Достать\r\nизображение";
			  this.GetImage.UseVisualStyleBackColor = true;
			  // 
			  // frmMain
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			  this.ClientSize = new System.Drawing.Size(1040, 516);
			  this.Controls.Add(this.mnuMain);
			  this.Controls.Add(this.Messages);
			  this.Controls.Add(this.splitContainer);
			  this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			  this.MinimumSize = new System.Drawing.Size(643, 493);
			  this.Name = "frmMain";
			  this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			  this.RightToLeftLayout = true;
			  this.ShowIcon = false;
			  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			  this.Text = "Public Room";
			  this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			  this.Shown += new System.EventHandler(this.mniEnter_Click);
			  this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MakeShot);
			  this.cnxMnuEdit.ResumeLayout(false);
			  this.mnuMain.ResumeLayout(false);
			  this.mnuMain.PerformLayout();
			  this.splitContainer.Panel1.ResumeLayout(false);
			  this.splitContainer.Panel2.ResumeLayout(false);
			  this.splitContainer.ResumeLayout(false);
			  this.splitContainer1.Panel1.ResumeLayout(false);
			  this.splitContainer1.Panel2.ResumeLayout(false);
			  this.splitContainer1.Panel2.PerformLayout();
			  this.splitContainer1.ResumeLayout(false);
			  this.splitContainer2.Panel1.ResumeLayout(false);
			  this.splitContainer2.Panel2.ResumeLayout(false);
			  this.splitContainer2.ResumeLayout(false);
			  ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			  this.cnxMniCopy.ResumeLayout(false);
			  this.ResumeLayout(false);
			  this.PerformLayout();

        }

        #endregion

		  private System.Windows.Forms.ImageList imgList;
        private Proshot.UtilityLib.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mniChat;
		  private System.Windows.Forms.ToolStripMenuItem mniEnter;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		  private System.Windows.Forms.ToolStripMenuItem mniExit;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Proshot.UtilityLib.ListView lstViwUsers;
        private System.Windows.Forms.ColumnHeader colIcon;
		  private System.Windows.Forms.ColumnHeader colUserName;
        private Proshot.UtilityLib.ContextMenuStrip cnxMnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mniCopy;
        private System.Windows.Forms.ToolStripMenuItem mniPaste;
        private Proshot.UtilityLib.ContextMenuStrip cnxMniCopy;
        private System.Windows.Forms.ToolStripMenuItem mniCopyText;
		  public System.Windows.Forms.PictureBox pictureBox1;
		  private System.Windows.Forms.SplitContainer splitContainer1;
		  private System.Windows.Forms.TextBox txtMessages;
		  private System.Windows.Forms.ToolStripMenuItem ввестиIPСервераToolStripMenuItem;
		  private System.Windows.Forms.SplitContainer splitContainer2;
		  private System.Windows.Forms.Button CancelEvent;
		  private System.Windows.Forms.Button StartEvent;
		  private System.Windows.Forms.Label Messages;
		  private System.Windows.Forms.Button GetImage;
    }
}

