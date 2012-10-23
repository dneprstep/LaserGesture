using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using videosource;

namespace motion
{
	/// <summary>
	/// Summary description for MainForm
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		//ChatClient.BatchMode.StartClient();
		// statistics
		private const int	statLength = 15;
		private int			statIndex = 0, statReady = 0;
		private int[]		statCount = new int[statLength];

        private MotionDetector1 detector = new MotionDetector1();
        private IContainer components;

        private StatusStrip statusStrip1;
        public ToolStripStatusLabel toolStripStatusLabel1;
        private OpenFileDialog ofd;
        private System.Timers.Timer timer;
        private PictureBox LineBlack;
        private CameraWindow cameraWindow;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem CameraButtonT;
        public ToolStripMenuItem CreateCelT;
        public ToolStripMenuItem CentrT;
        private ToolStripMenuItem RezaltedT;
        private Label label1;
        public bool controlWMP = false;
        private PictureBox LineCr2;
        private PictureBox LineCr1;

        bool Lines = false;
        private Timer timer1;
        public PictureBox pictureBox1;
        private Timer timer2;
        private ToolStripMenuItem Start;
        private ListBox listBox1;
        private DomainUpDown domainUpDown1;
        private Button button1;
        private Label label2;
        private ToolStripMenuItem Stop;
        private Label label3;
        private TabControl tabControl1;
        private TabPage tabPageRezalt;
        private TabPage tabPageusted;
        private DomainUpDown domainUpDown3;
        private DomainUpDown domainUpDown2;
        private Label label5;
        private Label label4;
        public bool startStop=false;
        int Xstart = 0;
        private ToolStripMenuItem Marks;
        private ToolStripMenuItem SettingsMarks;
        int Ystart = 0;



        int shotNumber = 0;
        int on5 = 0;
        int on4 = 0;
        int on3 = 0;
        int on2 = 0;
        private Button buttonLazerUst;
        private Button buttonAutoUst;

        bool StartBunnonEnable = false;
		public MainForm()
		{
			InitializeComponent();
			//var p= new Process
			//         {
			//            StartInfo =
			//               {
			//                  WorkingDirectory = System.IO.Directory.GetCurrentDirectory(),
			//                  FileName = "ConsoleServer.exe",
			//                  Arguments = ConsoleServer.BatchMode.GetIp() + " 8001"
			//               }
			//         };
			//p.Start();
			ConsoleServer.BatchMode.StartServer("8001");
			ChatClient.BatchMode.StartClient();
		}
      ArrayList rezalt = new ArrayList();
      string Devaice;
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.timer = new System.Timers.Timer();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.CameraButtonT = new System.Windows.Forms.ToolStripMenuItem();
			this.CentrT = new System.Windows.Forms.ToolStripMenuItem();
			this.CreateCelT = new System.Windows.Forms.ToolStripMenuItem();
			this.RezaltedT = new System.Windows.Forms.ToolStripMenuItem();
			this.Marks = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsMarks = new System.Windows.Forms.ToolStripMenuItem();
			this.Start = new System.Windows.Forms.ToolStripMenuItem();
			this.Stop = new System.Windows.Forms.ToolStripMenuItem();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageRezalt = new System.Windows.Forms.TabPage();
			this.tabPageusted = new System.Windows.Forms.TabPage();
			this.domainUpDown3 = new System.Windows.Forms.DomainUpDown();
			this.domainUpDown2 = new System.Windows.Forms.DomainUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonAutoUst = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.LineCr2 = new System.Windows.Forms.PictureBox();
			this.LineCr1 = new System.Windows.Forms.PictureBox();
			this.LineBlack = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonLazerUst = new System.Windows.Forms.Button();
			this.cameraWindow = new motion.CameraWindow();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.timer)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageRezalt.SuspendLayout();
			this.tabPageusted.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LineCr2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LineCr1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LineBlack)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 487);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1051, 22);
			this.statusStrip1.TabIndex = 12;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// ofd
			// 
			this.ofd.Filter = "AVI files (*.avi)|*.avi";
			this.ofd.Title = "Open movie";
			// 
			// timer
			// 
			this.timer.Interval = 1000D;
			this.timer.SynchronizingObject = this;
			// 
			// menuStrip1
			// 
			this.menuStrip1.AutoSize = false;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CameraButtonT,
            this.CentrT,
            this.CreateCelT,
            this.RezaltedT,
            this.Start,
            this.Stop});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1051, 40);
			this.menuStrip1.TabIndex = 13;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// CameraButtonT
			// 
			this.CameraButtonT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CameraButtonT.Image = ((System.Drawing.Image)(resources.GetObject("CameraButtonT.Image")));
			this.CameraButtonT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CameraButtonT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.CameraButtonT.Name = "CameraButtonT";
			this.CameraButtonT.Size = new System.Drawing.Size(126, 36);
			this.CameraButtonT.Text = "Вибір камери";
			this.CameraButtonT.Click += new System.EventHandler(this.CameraButtonT_Click);
			// 
			// CentrT
			// 
			this.CentrT.Enabled = false;
			this.CentrT.Image = ((System.Drawing.Image)(resources.GetObject("CentrT.Image")));
			this.CentrT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.CentrT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.CentrT.Name = "CentrT";
			this.CentrT.Size = new System.Drawing.Size(85, 36);
			this.CentrT.Text = "Центр";
			this.CentrT.Click += new System.EventHandler(this.CentrT_Click);
			// 
			// CreateCelT
			// 
			this.CreateCelT.Enabled = false;
			this.CreateCelT.Image = ((System.Drawing.Image)(resources.GetObject("CreateCelT.Image")));
			this.CreateCelT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.CreateCelT.Name = "CreateCelT";
			this.CreateCelT.Size = new System.Drawing.Size(145, 36);
			this.CreateCelT.Text = "Створити мішень";
			this.CreateCelT.Click += new System.EventHandler(this.CreateCelT_Click);
			// 
			// RezaltedT
			// 
			this.RezaltedT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Marks,
            this.SettingsMarks});
			this.RezaltedT.Image = ((System.Drawing.Image)(resources.GetObject("RezaltedT.Image")));
			this.RezaltedT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.RezaltedT.Name = "RezaltedT";
			this.RezaltedT.Size = new System.Drawing.Size(119, 36);
			this.RezaltedT.Text = "Оцінювання";
			this.RezaltedT.Click += new System.EventHandler(this.RezaltedT_Click);
			// 
			// Marks
			// 
			this.Marks.CheckOnClick = true;
			this.Marks.Name = "Marks";
			this.Marks.Size = new System.Drawing.Size(156, 22);
			this.Marks.Text = "Оцінювання";
			this.Marks.Click += new System.EventHandler(this.Marks_Click);
			// 
			// SettingsMarks
			// 
			this.SettingsMarks.Name = "SettingsMarks";
			this.SettingsMarks.Size = new System.Drawing.Size(156, 22);
			this.SettingsMarks.Text = "Налаштування";
			this.SettingsMarks.Visible = false;
			this.SettingsMarks.Click += new System.EventHandler(this.SettingsMarks_Click);
			// 
			// Start
			// 
			this.Start.Enabled = false;
			this.Start.Image = ((System.Drawing.Image)(resources.GetObject("Start.Image")));
			this.Start.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.Start.Name = "Start";
			this.Start.Size = new System.Drawing.Size(82, 36);
			this.Start.Text = "Старт";
			this.Start.Click += new System.EventHandler(this.Start_Click);
			// 
			// Stop
			// 
			this.Stop.Enabled = false;
			this.Stop.Image = ((System.Drawing.Image)(resources.GetObject("Stop.Image")));
			this.Stop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.Stop.Name = "Stop";
			this.Stop.Size = new System.Drawing.Size(78, 36);
			this.Stop.Text = "Стоп";
			this.Stop.Click += new System.EventHandler(this.Stop_Click);
			// 
			// listBox1
			// 
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(3, 46);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(137, 289);
			this.listBox1.TabIndex = 17;
			// 
			// domainUpDown1
			// 
			this.domainUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.domainUpDown1.Location = new System.Drawing.Point(75, 66);
			this.domainUpDown1.Name = "domainUpDown1";
			this.domainUpDown1.Size = new System.Drawing.Size(70, 20);
			this.domainUpDown1.TabIndex = 19;
			this.domainUpDown1.TextChanged += new System.EventHandler(this.domainUpDown1_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(15, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 15);
			this.label2.TabIndex = 17;
			this.label2.Text = "Центр - ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(7, 353);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 15);
			this.label3.TabIndex = 0;
			this.label3.Text = "Сума: ";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(7, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Вистрілів: ";
			// 
			// timer1
			// 
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Interval = 1;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageRezalt);
			this.tabControl1.Controls.Add(this.tabPageusted);
			this.tabControl1.Location = new System.Drawing.Point(871, 55);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(168, 415);
			this.tabControl1.TabIndex = 16;
			// 
			// tabPageRezalt
			// 
			this.tabPageRezalt.Controls.Add(this.listBox1);
			this.tabPageRezalt.Controls.Add(this.label1);
			this.tabPageRezalt.Controls.Add(this.label3);
			this.tabPageRezalt.Location = new System.Drawing.Point(4, 22);
			this.tabPageRezalt.Name = "tabPageRezalt";
			this.tabPageRezalt.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRezalt.Size = new System.Drawing.Size(160, 389);
			this.tabPageRezalt.TabIndex = 0;
			this.tabPageRezalt.Text = "Результат";
			this.tabPageRezalt.UseVisualStyleBackColor = true;
			// 
			// tabPageusted
			// 
			this.tabPageusted.Controls.Add(this.domainUpDown3);
			this.tabPageusted.Controls.Add(this.domainUpDown2);
			this.tabPageusted.Controls.Add(this.label5);
			this.tabPageusted.Controls.Add(this.domainUpDown1);
			this.tabPageusted.Controls.Add(this.label4);
			this.tabPageusted.Controls.Add(this.label2);
			this.tabPageusted.Controls.Add(this.buttonAutoUst);
			this.tabPageusted.Controls.Add(this.button1);
			this.tabPageusted.Location = new System.Drawing.Point(4, 22);
			this.tabPageusted.Name = "tabPageusted";
			this.tabPageusted.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageusted.Size = new System.Drawing.Size(160, 389);
			this.tabPageusted.TabIndex = 1;
			this.tabPageusted.Text = "Юстування";
			this.tabPageusted.UseVisualStyleBackColor = true;
			// 
			// domainUpDown3
			// 
			this.domainUpDown3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.domainUpDown3.Location = new System.Drawing.Point(75, 140);
			this.domainUpDown3.Name = "domainUpDown3";
			this.domainUpDown3.Size = new System.Drawing.Size(70, 20);
			this.domainUpDown3.TabIndex = 19;
			this.domainUpDown3.TextChanged += new System.EventHandler(this.domainUpDown3_TextChanged);
			// 
			// domainUpDown2
			// 
			this.domainUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.domainUpDown2.Location = new System.Drawing.Point(75, 105);
			this.domainUpDown2.Name = "domainUpDown2";
			this.domainUpDown2.Size = new System.Drawing.Size(70, 20);
			this.domainUpDown2.TabIndex = 19;
			this.domainUpDown2.TextChanged += new System.EventHandler(this.domainUpDown2_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(16, 140);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(24, 15);
			this.label5.TabIndex = 17;
			this.label5.Text = "Y - ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(15, 105);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(25, 15);
			this.label4.TabIndex = 17;
			this.label4.Text = "Х - ";
			// 
			// buttonAutoUst
			// 
			this.buttonAutoUst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonAutoUst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAutoUst.Location = new System.Drawing.Point(18, 21);
			this.buttonAutoUst.Name = "buttonAutoUst";
			this.buttonAutoUst.Size = new System.Drawing.Size(107, 27);
			this.buttonAutoUst.TabIndex = 18;
			this.buttonAutoUst.Text = "Автоюстування";
			this.buttonAutoUst.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(18, 186);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(107, 27);
			this.button1.TabIndex = 18;
			this.button1.Text = "Застосувати";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// LineCr2
			// 
			this.LineCr2.BackColor = System.Drawing.Color.Red;
			this.LineCr2.Location = new System.Drawing.Point(220, 55);
			this.LineCr2.Name = "LineCr2";
			this.LineCr2.Size = new System.Drawing.Size(1, 300);
			this.LineCr2.TabIndex = 11;
			this.LineCr2.TabStop = false;
			this.LineCr2.Visible = false;
			// 
			// LineCr1
			// 
			this.LineCr1.BackColor = System.Drawing.Color.Red;
			this.LineCr1.Location = new System.Drawing.Point(20, 205);
			this.LineCr1.Name = "LineCr1";
			this.LineCr1.Size = new System.Drawing.Size(400, 1);
			this.LineCr1.TabIndex = 11;
			this.LineCr1.TabStop = false;
			this.LineCr1.Visible = false;
			// 
			// LineBlack
			// 
			this.LineBlack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.LineBlack.Location = new System.Drawing.Point(440, 42);
			this.LineBlack.Name = "LineBlack";
			this.LineBlack.Size = new System.Drawing.Size(1, 327);
			this.LineBlack.TabIndex = 11;
			this.LineBlack.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(465, 55);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(400, 300);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// buttonLazerUst
			// 
			this.buttonLazerUst.Enabled = false;
			this.buttonLazerUst.Location = new System.Drawing.Point(214, 370);
			this.buttonLazerUst.MaximumSize = new System.Drawing.Size(206, 370);
			this.buttonLazerUst.Name = "buttonLazerUst";
			this.buttonLazerUst.Size = new System.Drawing.Size(206, 23);
			this.buttonLazerUst.TabIndex = 19;
			this.buttonLazerUst.Text = "Налаштування сприйняття лазера";
			this.buttonLazerUst.UseVisualStyleBackColor = true;
			this.buttonLazerUst.Click += new System.EventHandler(this.buttonLazerUst_Click);
			// 
			// cameraWindow
			// 
			this.cameraWindow.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.cameraWindow.Camera = null;
			this.cameraWindow.Location = new System.Drawing.Point(20, 55);
			this.cameraWindow.Name = "cameraWindow";
			this.cameraWindow.Size = new System.Drawing.Size(400, 300);
			this.cameraWindow.TabIndex = 6;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1051, 509);
			this.Controls.Add(this.buttonLazerUst);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.LineCr2);
			this.Controls.Add(this.LineCr1);
			this.Controls.Add(this.LineBlack);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.cameraWindow);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LazerShot";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.timer)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPageRezalt.ResumeLayout(false);
			this.tabPageRezalt.PerformLayout();
			this.tabPageusted.ResumeLayout(false);
			this.tabPageusted.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LineCr2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LineCr1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LineBlack)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		// On form closing
		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			CloseFile();		
		}

		// Close the main form
		private void exitFileItem_Click(object sender, System.EventArgs e)
		{
			ConsoleServer.BatchMode.Stop();
			Close();
		}

		
        private void openCamera(object sender, System.EventArgs e)
        {
            CaptureDeviceForm form = new CaptureDeviceForm();

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				// create video source
				CaptureDevice localSource = new CaptureDevice();
				localSource.VideoSource = form.Device;
                Devaice = form.Device;
				// open it
				OpenVideoSource(localSource);
                CentrT.Enabled = true;
               
			}
        }
        public void rezet()
        {
            CaptureDeviceForm form = new CaptureDeviceForm();
            CaptureDevice localDevice = new CaptureDevice();
            localDevice.VideoSource = Devaice;
            OpenVideoSource(localDevice);
        }
		// Open video source
		public void OpenVideoSource(IVideoSource source)
		{
			// set busy cursor
			this.Cursor = Cursors.WaitCursor;

			// close previous file
			CloseFile();

			// create camera
			Camera camera = new Camera(source, detector);
			// start camera
			camera.Start();

			// attach camera to camera window
			cameraWindow.Camera = camera;

            if (!Lines)
            {
                Graphics dc = cameraWindow.CreateGraphics();
                Pen redPen = new Pen(Color.Red, 1);
                dc.DrawLine(redPen, pictureBox1.Size.Width / 2, 0, pictureBox1.Size.Width / 2, pictureBox1.Size.Height);
                dc.DrawLine(redPen, 0, pictureBox1.Size.Height / 2, pictureBox1.Size.Width, pictureBox1.Size.Height / 2);
            }


			// reset statistics
			statIndex = statReady = 0;

			// start timer
			timer.Start();

			this.Cursor = Cursors.Default;
		}

		// Close current file
		public void CloseFile()
		{
			Camera	camera = cameraWindow.Camera;

			if (camera != null)
			{
				// detach camera from camera window
				cameraWindow.Camera = null;

				// signal camera to stop
				camera.SignalToStop();
				// wait for the camera
				camera.WaitForStop();
                
				camera = null;

				if (detector != null)
					detector.Reset();
			}
		}

		// On timer event - gather statistic
		private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Camera	camera = cameraWindow.Camera;
		
			if (camera != null)
			{
				// get number of frames for the last second
				statCount[statIndex] = camera.FramesReceived;

				// increment indexes
				if (++statIndex >= statLength)
					statIndex = 0;
				if (statReady < statLength)
					statReady++;

				float	fps = 0;

				// calculate average value
				for (int i = 0; i < statReady; i++)
				{
					fps += statCount[i];
				}
				fps /= statReady;

				statCount[statIndex] = 0;
                
			}
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("C:\\Program Files\\LazerShot\\ust.tir"))
            {
                string s = "10.0.0";
                string rez = string.Format(s + "/#97.99.101.");
                if (!System.IO.Directory.Exists("C:\\Program Files\\LazerShot"))
                System.IO.Directory.CreateDirectory("C:\\Program Files\\LazerShot");
                System.IO.StreamWriter str = new System.IO.StreamWriter("C:\\Program Files\\LazerShot\\ust.tir");
                str.Write(rez);
                str.Close();

                string pass = "....";
                System.IO.StreamWriter str1 = new System.IO.StreamWriter("C:\\Program Files\\LazerShot\\pass.tir");
                str1.Write(pass);
                str1.Close();
            }
            updateMarks();
            detector.mForm = this;
            MinimizeBox = false;
            MaximizeBox = false;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            buttonLazerUst.Enabled = true;
        }

        private void CreateCelT_Click(object sender, EventArgs e)
        {
            rezalt.Clear();
            listBox1.Items.Clear();
            label3.Text = "Сума:";
            CreateCel();
            Start.Enabled = true;
            UstedCel();
            
            
            if (StartBunnonEnable)
                Start.Enabled = true;
            else
            {
                StartBunnonEnable = true;
            }
        }
        private void CentrT_Click(object sender, EventArgs e)
        {
            Krest();
        }
        private void CameraButtonT_Click(object sender, EventArgs e)
        {
            StartBunnonEnable = false;
            Start.Enabled = false;
            listBox1.Items.Clear();
            CreateCelT.Enabled = false;
            CentrT.Enabled = false;
            openCamera(sender, e);
            timer1.Start();
        }

        private void Krest()
        {
            if (!Lines)
            {
                LineCr1.Visible = true;
                LineCr2.Visible = true;
                Lines = true;
            }
            else
            {
                LineCr1.Visible = false;
                LineCr2.Visible = false;
                Lines = false;
            }
        }     //лінії для виставлення камери5
        private void CreateCel()
        {
            try
            {
                try
                {
                    toolStripStatusLabel1.Text = "Start";
                    pictureBox1.BackgroundImage = new Bitmap(cameraWindow.Camera.LastFrame);
                    pictureBox1.Image = Properties.Resources.clear;
						// отправить картинку
						//pictureBox1.Image.
                	//ChatClient.BatchMode.SendMessage("");
                }
                catch
                {
                    CreateCel();
                }
            }
            catch { CreateCel(); }
        }    // створеня скріна мішені
        private void UstedCel()    // юстування
        {
                //пеереключення між режимами
                label1.Visible = false;
                string[] line;

                //створення/доставання файла з  значеннями
                if (System.IO.Directory.Exists("C:\\Program Files\\LazerShot"))
                {
                    string addres = "C:\\Program Files\\LazerShot\\ust.tir";
                    System.IO.StreamReader str = new System.IO.StreamReader(addres);
                    string s = str.ReadToEnd();
                    str.Close();
                    string[] ss = s.Split('/');
                    line = ss[0].Split('.');
                    domainUpDown1.Text = line[0];
                    domainUpDown2.Text = line[1];
                    domainUpDown3.Text = line[2];
                    timer2.Start();
                }
               
                InDomainItems();
               
        }
       
        private void InDomainItems()
        {
            for (int i = 299; i > 0; i--)
            {
                domainUpDown1.Items.Add(i);
            }
            for (int i = 200; i > -201; i--)
            {
                domainUpDown2.Items.Add(i);
                domainUpDown3.Items.Add(i);
            }
 
        }    //заповнення вікон юстування
       
        public void DrawingP()
        {
                try
                {
                    int diam =  int.Parse(string.Format("{0}", domainUpDown1.Text));
                    Graphics graph = pictureBox1.CreateGraphics();

                    Pen p = new Pen(Brushes.Red, 1);
                    for (int i = 1; i < 6; i++)
                        graph.DrawEllipse(p, (pictureBox1.Size.Width - diam * i) / 2 + Xstart, (pictureBox1.Size.Height - diam * i) / 2+Ystart, diam * i, diam * i);
                    graph.DrawRectangle(p, (pictureBox1.Size.Width - diam * 5) / 2 + Xstart, (pictureBox1.Size.Height - diam * 5) / 2+Ystart, diam * 5, diam * 5);
                    float f1 = diam * 27 / 20;
                    float f2 = diam * 36 / 20;

                    graph.DrawRectangle(p, (pictureBox1.Size.Width - diam * 5) / 2+Xstart, (pictureBox1.Size.Height - diam * 5) / 2+Ystart, f1, f2);
                    graph.DrawRectangle(p, (pictureBox1.Size.Width + diam * 5) / 2 - f1+Xstart, Ystart+(pictureBox1.Size.Height - diam * 5) / 2, f1, f2);

                   /* graph.DrawEllipse(p,100, Xstart,  5, 5);
                    graph.DrawEllipse(p, 150,Ystart,  5, 5);
                    graph.DrawEllipse(p, 200,diam, 5, 5);*/
                }
                catch { }
           
        }    // замальовка
       
        public void shot(int x, int y)
        {
            if (startStop)
            {
                pictureBox1.CreateGraphics().FillEllipse(Brushes.Red, x - 7 / 2 , y - 7 / 2, 6, 6);
                pictureBox1.CreateGraphics().DrawEllipse(new Pen(Brushes.Black, 1), x - 7 / 2,y - 7 / 2, 7, 7);
                statistic(x, y);
            }
        }  // точка вистрілу
        private void statistic(int x, int y)  // запис результату
        {
            double x1=pictureBox1.Size.Width/2+Xstart;
            double y1 = pictureBox1.Size.Height/2+Ystart;
            double length = Math.Sqrt((x-x1)*(x-x1)+(y1-y)*(y1-y));

            double diam = double.Parse(domainUpDown1.Text)/2;
            bool zero=false;
            if (y<y1-1.4*diam)
            {
                if ((x<x1-2.3*diam)||(x>x1+2.3*diam))
                {
                     rezalt.Add("0");
                    zero = true;
                }
            }
            if (!zero)
            {
                if ((y < y1 - diam * 5-7) || (y > y1+7 + diam * 5))
                {
                    rezalt.Add("0");
                    zero = true;
                }
                if ((x < x1 - diam * 5 - 7) || (x > x1 +7+ diam * 5))
                {
                    rezalt.Add("0");
                    zero = true;
                }
            }

            if (!zero)
            {
                if (length <= 5 + diam)
                {
                    rezalt.Add("10");
                }
                else
                    if (length <= 5 + diam * 2)
                    {
                        rezalt.Add("9");
                    }
                    else
                        if (length <= 5 + diam * 3)
                        {
                            rezalt.Add("8");
                        }
                        else
                            if (length <= 5 + diam * 4)
                        {
                            rezalt.Add("7");
                        }
                        else
                                if (length <= 5+diam * 5)
                        {
                            rezalt.Add("6");
                        }
                        else
                        {
                             rezalt.Add("5");
                        }

            }
            rezaltWrite(rezalt);
            
        }
        private void rezaltWrite(ArrayList rezalt)
        {
            try
            {
                this.BeginInvoke(new Action(() => {
                    listBox1.Items.Clear();
                    int symmaryRez = 0;
                    for (int i=0;i<rezalt.Count;i++)
                    {
                        listBox1.Items.Add(string.Format("{0} - {1}",listBox1.Items.Count+1,rezalt[i]));
                        symmaryRez += int.Parse(rezalt[i].ToString());
                    }
                    listBox1.Items.Add("---------------------");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    label3.Text = string.Format("Сума: < {0} > очок", symmaryRez);
                    if ((rezalt.Count == shotNumber)&&(Marks.Checked))
                    {

                        finalityShot(rezalt,symmaryRez);
                    }
                }));
            }
            catch
            {
                rezaltWrite(rezalt);
            }
        }
        private void finalityShot(ArrayList rezalt, int symmaryRez)
        {
            if (symmaryRez >= on5)
                listBox1.Items.Add("Оцінка - 5");
            else
            {
                if (symmaryRez >= on4)
                    listBox1.Items.Add("Оцінка - 4");
                else
                {
                    if (symmaryRez >= on3)
                        listBox1.Items.Add("Оцінка - 3");
                    else
                    {
                        if (symmaryRez >= on2)
                            listBox1.Items.Add("Оцінка - 2");
                        else
                            listBox1.Items.Add("Оцінка менше 2");
                    }
                }
            }
            startStop = false;
            Stop.Enabled = false;
            Start.Enabled = true;
        }

        // функціонал по кнопках, зміни\запуски
        private void timer2_Tick(object sender, EventArgs e)
        {
            DrawingP();
        }
        private void domainUpDown1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.clear;
            timer2.Start();
        }
        private void Start_Click(object sender, EventArgs e)
        {
            startStop = true;
            Stop.Enabled = true;
            Start.Enabled = false;
            rezalt.Clear();
            listBox1.Items.Clear();
            pictureBox1.Image = Properties.Resources.clear;
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            startStop = false;
            Stop.Enabled = false;
            Start.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string s = string.Format("{0}.{1}.{2}",domainUpDown1.Text,domainUpDown2.Text,domainUpDown3.Text);
            string addres = "C:\\Program Files\\LazerShot\\ust.tir";
            System.IO.StreamReader str = new System.IO.StreamReader(addres);
            string s1 = str.ReadToEnd();
            str.Close();
            string [] ss = s1.Split('/');
            string rezalt = string.Format(s+"/"+ss[1]);
            System.IO.File.Delete("C:\\Program Files\\LazerShot\\ust.tir");
            System.IO.StreamWriter str1 = new System.IO.StreamWriter("C:\\Program Files\\LazerShot\\ust.tir");
            str1.Write(rezalt);
            str1.Close();
        }

        private void domainUpDown1_TextChanged(object sender, EventArgs e)  //замальовка непропорційна
        {
            pictureBox1.Image = Properties.Resources.clear;
            timer2.Start();
        }
        private void domainUpDown2_TextChanged(object sender, EventArgs e)
        {
            Xstart = int.Parse(domainUpDown2.Text);
            pictureBox1.Image = Properties.Resources.clear;
            timer2.Start();
        }
        private void domainUpDown3_TextChanged(object sender, EventArgs e)
        {
            Ystart = int.Parse(domainUpDown3.Text);
            pictureBox1.Image = Properties.Resources.clear;
            timer2.Start();
        }

        private void Marks_Click(object sender, EventArgs e)
        {
            if (Marks.Checked)
            {
                SettingsMarks.Visible = true;
            }
            else
                SettingsMarks.Visible = false;
        }
        private void SettingsMarks_Click(object sender, EventArgs e)
        {
            sequreMarks f = new sequreMarks();
            f.ShowDialog();
            updateMarks();
        }
        public void updateMarks()
        {
            try
            {
                System.IO.StreamReader str = new System.IO.StreamReader("C:\\Program Files\\LazerShot\\pass.tir");
                string s = str.ReadToEnd();
                char[] sq = s.ToCharArray();
                shotNumber = sq[0];
                on5 = sq[2];
                on4 = sq[4];
                on3 = sq[6];
                on2 = sq[8];
                str.Close();
            }
            catch
            {
                if (System.IO.File.Exists("C:\\Program Files\\LazerShot\\pass.tir"))
                    System.IO.File.Delete("C:\\Program Files\\LazerShot\\pass.tir");
                string pass = "....";
                System.IO.StreamWriter str1 = new System.IO.StreamWriter("C:\\Program Files\\LazerShot\\pass.tir");
                str1.Write(pass);
                str1.Close();
            }
        }

		  //private void AutoUstedCheck_CheckedChanged(object sender, EventArgs e)
		  //{
		  //    if (AutoUstedCheck.Checked)
		  //    {
		  //        domainUpDown1.Enabled = false;
		  //        domainUpDown2.Enabled = false;
		  //        domainUpDown3.Enabled = false;
		  //        label2.Enabled = false;
		  //        label4.Enabled = false;
		  //        label5.Enabled = false;
                
		  //       // autoUst();
		  //    }
		  //    else
		  //    {
		  //        domainUpDown1.Enabled = true;
		  //        domainUpDown2.Enabled = true;
		  //        domainUpDown3.Enabled = true;
		  //        label2.Enabled = true;
		  //        label4.Enabled = true;
		  //        label5.Enabled = true;
		  //    }
		  //}

        private void buttonLazerUst_Click(object sender, EventArgs e)
        {
            CreateCelT.Enabled = true;
        }


        private void autoUst()
        {
            Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap((Bitmap)pictureBox1.BackgroundImage);
            uBitmap.LockBitmap();

            byte r, g, b;

            Point p1 = new Point(-1, -1);
            Point p2 = new Point(-1, -1);
            Point p3 = new Point(-1, -1);
            Point p4 = new Point(-1, -1);
            for (int y = 0; y < uBitmap.Bitmap.Size.Height; y+=2)
            {
                for (int x = 0; x < uBitmap.Bitmap.Size.Width; x+=2)
                {
                    r = uBitmap.GetPixel(x, y).red;
                    g = uBitmap.GetPixel(x, y).green;
                    b = uBitmap.GetPixel(x, y).blue;

                    if ((r - g > 100) && (r - b > 100))
                    {
                        ColorControl f = new ColorControl();
                        if (p1.X == -1)
                        {
                            p1 = f.PPoint(x, y, uBitmap.Bitmap);
                            x +=20;
                            y += 20;
                            continue;
                        }
                        if ((p1.X != -1) && (p2.X == -1))
                        {
                            p2 = f.PPoint(x,y,uBitmap.Bitmap);
                            x += 20;
                            y += 20;
                            continue;
                        }
                        if ((p2.X != -1) && (p3.X == -1))
                        {
                            p3 = f.PPoint(x, y, uBitmap.Bitmap);
                            x += 20;
                            y += 20;
                            continue;
                        }
                        if ((p3.X != -1) && (p4.X == -1))
                        {
                            p4 = f.PPoint(x, y, uBitmap.Bitmap);
                            x += 20;
                            y += 20;
                            continue;
                        }
                    }
                }
                
            }
        

        }  // autoUsted

        private class ColorControl
        {
            private Point StartControl(int x, int y, Bitmap image)
            {
                Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
                uBitmap.LockBitmap();

                Point pStart = new Point(-1, -1);

                for (int Y = y; Y < y + 30; Y++)
                {
                    for (int X = x; X < x + 30; X++)
                    {
                        int r = uBitmap.GetPixel(X, Y).red;
                        int b = uBitmap.GetPixel(X, Y).blue;
                        int g = uBitmap.GetPixel(X, Y).green;
                        if ((r - 100 > g) && (r - 100 > b))
                        {
                            if (pStart.X == -1)     // save start point
                            {
                                pStart.X = X;
                                pStart.Y = Y;
                                break;
                            }
                        }//if ((r - 100 > g) && (r - 100 > b))
                    }//for (int x = 0; x < uBitmap.Bitmap.Width; x++)
                    if (pStart.X != -1)
                    {
                        break;
                    }
                }//for (int y = 0; y < uBitmap.Bitmap.Height; y+=5)


                uBitmap.UnlockBitmap();
                uBitmap.Dispose();

                //pWEnd = GorizontalControl(pStart, image);
                //pHEnd = VerticalControl(pStart, image);
                return pStart;
            }

            private Point GorizontalControl(Point pStart, Bitmap image)
            {
                Point pHEnd = new Point(-1, -1);
                Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
                uBitmap.LockBitmap();

                for (int x = pStart.X; x < 30 + pStart.X; x++)
                {
                    int r = uBitmap.GetPixel(x, pStart.Y).red;
                    int b = uBitmap.GetPixel(x, pStart.Y).blue;
                    int g = uBitmap.GetPixel(x, pStart.Y).green;
                    if (((r - 100 > b) && (r - 100 > g)) || ((r > 200) && (g > 120) && (b > 120)))
                    {
                    }
                    else
                    {
                        pHEnd.X = x;
                        pHEnd.Y = pStart.Y;
                        break;
                    }
                }//for (int x = 0; x < uBitmap.Bitmap.Width; x++)


                uBitmap.UnlockBitmap();
                uBitmap.Dispose();

                
                return pHEnd;
            }

            private Point VerticalControl(Point pStart, Bitmap image)
            {
                Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
                uBitmap.LockBitmap();
                Point pEnd = new Point(-1, -1);
                for (int y = pStart.Y; y < 30 + pStart.Y; y++)
                {
                    int r = uBitmap.GetPixel(pStart.X, y).red;
                    int b = uBitmap.GetPixel(pStart.X, y).blue;
                    int g = uBitmap.GetPixel(pStart.X, y).green;

                    if (((r - 100 > b) && (r - 100 > g)) || ((r > 150) && (g > 120) && (b > 120)))
                    {
                    }
                    else
                    {
                        pEnd.X = pStart.X;
                        pEnd.Y = y;
                        break;
                    }
                }

                uBitmap.UnlockBitmap();
                uBitmap.Dispose();
                return pEnd;
            }
             
            public Point PPoint (int x, int y, Bitmap image)
            {
                Point pStart = StartControl(x-2, y-2, image);
                Point pWEnd = GorizontalControl(pStart, image);
                Point pHEnd = VerticalControl(pStart, image);
                
                x = (pStart.X + (pWEnd.X - pStart.X) / 2);
                y = (pStart.Y + (pHEnd.Y - pStart.Y) / 2);
                Point pEnd = new Point(x, y);
                return pEnd;
            }
        }

		  private void RezaltedT_Click(object sender, EventArgs e)
		  {

		  }
	}
}
