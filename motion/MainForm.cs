using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Proshot.CommandClient;
using videosource;
using CommandType = Proshot.CommandClient.CommandType;
using TIRDatabase;

namespace motion
{
    /// <summary>
    /// Summary description for MainForm
    /// </summary>
    public class MainForm : Form
    {
        private CaptureDeviceForm form = new CaptureDeviceForm();
        private MotionDetector1 detector = new MotionDetector1();
        private VideoServer _videoServer = new VideoServer();
        private IContainer components;
        private List<Point> listPoint = new List<Point>();
        private List<Point> p = new List<Point>();
        private StatusStrip statusStrip1;
        public ToolStripStatusLabel toolStripStatusLabel1;
        private OpenFileDialog ofd;
        private System.Timers.Timer timer;
        private PictureBox LineBlack;
        private CameraWindow cameraWindow;
        private MenuStrip menuStrip1;
        public ToolStripMenuItem CameraButtonT;
        public ToolStripMenuItem CreateCelT;
        public ToolStripMenuItem CentrT;
        private ToolStripMenuItem RezaltedT;
        private Label label1;
        private PictureBox LineCr2;
        private PictureBox LineCr1;
        private bool Lines = false;
        private Timer timer1;
        public PictureBox pictureBox1;
        private Timer timer2;
        private ToolStripMenuItem Start;
        private ListBox listBox1;
        private DomainUpDown UstedBoxCenter;
        private Button button1;
        private Label label2;
        private ToolStripMenuItem Stop;
        private Label label3;
        public TabControl tabControl1;
        private TabPage tabPageRezalt;
        private TabPage tabPageusted;
        private DomainUpDown UstedBoxY;
        private DomainUpDown UstedBoxX;
        private Label label5;
        private Label label4;
        public bool startStop = false;
        private int _xstart = 0;
        private ToolStripMenuItem Marks;
        private ToolStripMenuItem SettingsMarks;
        private int _ystart = 0;
        private int _shotNumber = 0;
        private int _on5 = 0;
        private int _on4 = 0;
        private int _on3 = 0;
        private int _on2 = 0;
        private Button buttonAutoUst;
        private Panel panelUstedHand;
        private Button buttonHandUst;
        private Timer timerDrawingUst2;
        private CheckBox checkBoxRound;
        private DomainUpDown domainUpDownXa;
        private Label label6;
        private bool StartBunnonEnable = false;
        private ArrayList rezalt = new ArrayList();
        private Button buttonHelp;
        private Panel panel1;
        private Label label10;
        private Label label9;
        private Label label7;
        private Label label8;
        private Label label11;
        private ToolStripMenuItem обратиВзводToolStripMenuItem;
        private string Devaice;
        Datamanager DM;
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.обратиВзводToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.UstedBoxCenter = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRezalt = new System.Windows.Forms.TabPage();
            this.tabPageusted = new System.Windows.Forms.TabPage();
            this.panelUstedHand = new System.Windows.Forms.Panel();
            this.checkBoxRound = new System.Windows.Forms.CheckBox();
            this.domainUpDownXa = new System.Windows.Forms.DomainUpDown();
            this.UstedBoxY = new System.Windows.Forms.DomainUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.UstedBoxX = new System.Windows.Forms.DomainUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonHandUst = new System.Windows.Forms.Button();
            this.buttonAutoUst = new System.Windows.Forms.Button();
            this.timerDrawingUst2 = new System.Windows.Forms.Timer(this.components);
            this.buttonHelp = new System.Windows.Forms.Button();
            this.LineCr2 = new System.Windows.Forms.PictureBox();
            this.LineCr1 = new System.Windows.Forms.PictureBox();
            this.LineBlack = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.cameraWindow = new motion.CameraWindow();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageRezalt.SuspendLayout();
            this.tabPageusted.SuspendLayout();
            this.panelUstedHand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineCr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineCr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
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
            this.Stop,
            this.обратиВзводToolStripMenuItem});
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
            this.CameraButtonT.Click += new System.EventHandler(this.CameraButtonTClick);
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
            this.CentrT.Click += new System.EventHandler(this.CentrTClick);
            // 
            // CreateCelT
            // 
            this.CreateCelT.Enabled = false;
            this.CreateCelT.Image = ((System.Drawing.Image)(resources.GetObject("CreateCelT.Image")));
            this.CreateCelT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CreateCelT.Name = "CreateCelT";
            this.CreateCelT.Size = new System.Drawing.Size(145, 36);
            this.CreateCelT.Text = "Створити мішень";
            this.CreateCelT.Click += new System.EventHandler(this.CreateCelTClick);
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
            // 
            // Marks
            // 
            this.Marks.CheckOnClick = true;
            this.Marks.Name = "Marks";
            this.Marks.Size = new System.Drawing.Size(156, 22);
            this.Marks.Text = "Оцінювання";
            this.Marks.Click += new System.EventHandler(this.MarksClick);
            // 
            // SettingsMarks
            // 
            this.SettingsMarks.Name = "SettingsMarks";
            this.SettingsMarks.Size = new System.Drawing.Size(156, 22);
            this.SettingsMarks.Text = "Налаштування";
            this.SettingsMarks.Visible = false;
            this.SettingsMarks.Click += new System.EventHandler(this.SettingsMarksClick);
            // 
            // Start
            // 
            this.Start.Enabled = false;
            this.Start.Image = ((System.Drawing.Image)(resources.GetObject("Start.Image")));
            this.Start.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(82, 36);
            this.Start.Text = "Старт";
            this.Start.Click += new System.EventHandler(this.StartClick);
            // 
            // Stop
            // 
            this.Stop.Enabled = false;
            this.Stop.Image = ((System.Drawing.Image)(resources.GetObject("Stop.Image")));
            this.Stop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(78, 36);
            this.Stop.Text = "Стоп";
            this.Stop.Click += new System.EventHandler(this.StopClick);
            // 
            // обратиВзводToolStripMenuItem
            // 
            this.обратиВзводToolStripMenuItem.Name = "обратиВзводToolStripMenuItem";
            this.обратиВзводToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.обратиВзводToolStripMenuItem.Text = "База даних";
            this.обратиВзводToolStripMenuItem.Click += new System.EventHandler(this.обратиВзводToolStripMenuItem_Click);
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
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
            // 
            // UstedBoxCenter
            // 
            this.UstedBoxCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UstedBoxCenter.Location = new System.Drawing.Point(68, 79);
            this.UstedBoxCenter.Name = "UstedBoxCenter";
            this.UstedBoxCenter.Size = new System.Drawing.Size(70, 20);
            this.UstedBoxCenter.TabIndex = 19;
            this.UstedBoxCenter.TextChanged += new System.EventHandler(this.DomainUpDown1TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ye - ";
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
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.Timer2Tick);
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
            this.tabPageusted.Controls.Add(this.panelUstedHand);
            this.tabPageusted.Controls.Add(this.buttonHandUst);
            this.tabPageusted.Controls.Add(this.buttonAutoUst);
            this.tabPageusted.Location = new System.Drawing.Point(4, 22);
            this.tabPageusted.Name = "tabPageusted";
            this.tabPageusted.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageusted.Size = new System.Drawing.Size(160, 389);
            this.tabPageusted.TabIndex = 1;
            this.tabPageusted.Text = "Юстування";
            this.tabPageusted.UseVisualStyleBackColor = true;
            // 
            // panelUstedHand
            // 
            this.panelUstedHand.Controls.Add(this.checkBoxRound);
            this.panelUstedHand.Controls.Add(this.domainUpDownXa);
            this.panelUstedHand.Controls.Add(this.UstedBoxCenter);
            this.panelUstedHand.Controls.Add(this.UstedBoxY);
            this.panelUstedHand.Controls.Add(this.button1);
            this.panelUstedHand.Controls.Add(this.label6);
            this.panelUstedHand.Controls.Add(this.UstedBoxX);
            this.panelUstedHand.Controls.Add(this.label2);
            this.panelUstedHand.Controls.Add(this.label5);
            this.panelUstedHand.Controls.Add(this.label4);
            this.panelUstedHand.Location = new System.Drawing.Point(13, 86);
            this.panelUstedHand.Name = "panelUstedHand";
            this.panelUstedHand.Size = new System.Drawing.Size(141, 236);
            this.panelUstedHand.TabIndex = 20;
            // 
            // checkBoxRound
            // 
            this.checkBoxRound.AutoSize = true;
            this.checkBoxRound.Location = new System.Drawing.Point(11, 14);
            this.checkBoxRound.Name = "checkBoxRound";
            this.checkBoxRound.Size = new System.Drawing.Size(49, 17);
            this.checkBoxRound.TabIndex = 20;
            this.checkBoxRound.Text = "Круг";
            this.checkBoxRound.UseVisualStyleBackColor = true;
            this.checkBoxRound.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
            // 
            // domainUpDownXa
            // 
            this.domainUpDownXa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.domainUpDownXa.Location = new System.Drawing.Point(68, 42);
            this.domainUpDownXa.Name = "domainUpDownXa";
            this.domainUpDownXa.Size = new System.Drawing.Size(70, 20);
            this.domainUpDownXa.TabIndex = 19;
            this.domainUpDownXa.TextChanged += new System.EventHandler(this.DomainUpDown1TextChanged);
            // 
            // UstedBoxY
            // 
            this.UstedBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UstedBoxY.Location = new System.Drawing.Point(68, 153);
            this.UstedBoxY.Name = "UstedBoxY";
            this.UstedBoxY.Size = new System.Drawing.Size(70, 20);
            this.UstedBoxY.TabIndex = 19;
            this.UstedBoxY.TextChanged += new System.EventHandler(this.DomainUpDown3TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(11, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 27);
            this.button1.TabIndex = 18;
            this.button1.Text = "Застосувати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Xe - ";
            // 
            // UstedBoxX
            // 
            this.UstedBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UstedBoxX.Location = new System.Drawing.Point(68, 118);
            this.UstedBoxX.Name = "UstedBoxX";
            this.UstedBoxX.Size = new System.Drawing.Size(70, 20);
            this.UstedBoxX.TabIndex = 19;
            this.UstedBoxX.TextChanged += new System.EventHandler(this.DomainUpDown2TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Y - ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Х - ";
            // 
            // buttonHandUst
            // 
            this.buttonHandUst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHandUst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHandUst.Location = new System.Drawing.Point(24, 53);
            this.buttonHandUst.Name = "buttonHandUst";
            this.buttonHandUst.Size = new System.Drawing.Size(107, 27);
            this.buttonHandUst.TabIndex = 18;
            this.buttonHandUst.Text = "Ручна настройка";
            this.buttonHandUst.UseVisualStyleBackColor = true;
            this.buttonHandUst.Visible = false;
            this.buttonHandUst.Click += new System.EventHandler(this.ButtonHandUstClick);
            // 
            // buttonAutoUst
            // 
            this.buttonAutoUst.Enabled = false;
            this.buttonAutoUst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAutoUst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAutoUst.Location = new System.Drawing.Point(24, 20);
            this.buttonAutoUst.Name = "buttonAutoUst";
            this.buttonAutoUst.Size = new System.Drawing.Size(107, 27);
            this.buttonAutoUst.TabIndex = 18;
            this.buttonAutoUst.Text = "Автоюстування";
            this.buttonAutoUst.UseVisualStyleBackColor = true;
            this.buttonAutoUst.Visible = false;
            this.buttonAutoUst.Click += new System.EventHandler(this.ButtonAutoUstClick);
            // 
            // timerDrawingUst2
            // 
            this.timerDrawingUst2.Interval = 1;
            this.timerDrawingUst2.Tick += new System.EventHandler(this.TimerDrawingUst2Tick);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHelp.Location = new System.Drawing.Point(20, 376);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(201, 94);
            this.buttonHelp.TabIndex = 17;
            this.buttonHelp.Text = "Кнопка настройки програми";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.ButtonHelpClick);
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
            this.pictureBox1.Location = new System.Drawing.Point(460, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "1) Виберіть камеру";
            this.label7.Click += new System.EventHandler(this.Label7Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(24, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "2) Створіть мішень";
            this.label8.Click += new System.EventHandler(this.Label8Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(51, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "3) від\'юстуйте зображення";
            this.label9.Click += new System.EventHandler(this.Label9Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(554, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Переконайтеся в наявності мережевого з\'єднання між комп\'ютерами, якщо воно відсут" +
    "нє - натисніть сюди";
            this.label10.Click += new System.EventHandler(this.Label10Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(241, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 100);
            this.panel1.TabIndex = 19;
            this.panel1.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(320, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Після встановлення з\'єднання запустіть клієнтську програму";
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
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonHelp);
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
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExitFileItemClick);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageRezalt.ResumeLayout(false);
            this.tabPageRezalt.PerformLayout();
            this.tabPageusted.ResumeLayout(false);
            this.panelUstedHand.ResumeLayout(false);
            this.panelUstedHand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineCr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineCr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.Run(new MainForm());
        }

        private CMDClient _client;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            Client();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public void Client()
        {
            if (!Process.GetProcesses().ToList().Where(item => item.ProcessName == "ConsoleServer").Any())
            {
                ConsoleServer.BatchMode.StartServer("8001");
                ChatClient.BatchMode.StartClient();
                _client = ChatClient.BatchMode.GetClient();
                _client.CommandReceived += SetMessage;
            }
        }

        public void SetMessage(object sender, CommandEventArgs e)
        {

            if (e.Command.CommandType == CommandType.Message)
            {
                switch (e.Command.MetaData)
                {
                    case "start":
                        {
                            Marks.Checked = true;
                            StartClick(sender, e);
                        }
                        break;
                    case "cancel":
                        {
                            StopClick(sender, e);
                        }
                        break;
                    case "mark":
                        {
                            SendMarks();
                        }
                        break;
                    case "getimage":
                        {
                            CreateCelTClick(sender, e);
                        }
                        break;
                    case "getcameralist":
                        {
                            GetCameraList();
                        } break;
                    default:
                        {
                            SetCameraDevice(e.Command.MetaData);
                        }
                        break;
                }
            }
        }

        private void SetCameraDevice(string nom)
        {
            if (!nom.Contains("setcamera"))
                return;

            nom = nom.Replace("setcamera", "");

            form.Device = nom;
            var localSource = new CaptureDevice();
            localSource.VideoSource = form.Device;
            Devaice = form.Device;
            // open it
            OpenVideoSource(localSource);
        }

        private void GetCameraList()
        {

            ChatClient.BatchMode.SendMessage(new CaptureDeviceForm().DeviceNames());
        }

        // On form closing
        private void MainFormClosing(object sender, CancelEventArgs e)
        {
            CloseFile();
        }

        private void openCamera(object sender, EventArgs e)
        {


            if (form.ShowDialog(this) == DialogResult.OK)
            {
                // create video source
                var localSource = new CaptureDevice();
                localSource.VideoSource = form.Device;
                Devaice = form.Device;
                // open it
                OpenVideoSource(localSource);
                CentrT.Enabled = true;

            }
        }

        public void rezet()
        {
            var form = new CaptureDeviceForm();
            var localDevice = new CaptureDevice();
            localDevice.VideoSource = Devaice;
            OpenVideoSource(localDevice);
        }

        // Open video source
        public void OpenVideoSource(IVideoSource source)
        {
            // set busy cursor
            Cursor = Cursors.WaitCursor;

            // close previous file
            CloseFile();

            // create camera
            var camera = new Camera(source, detector);
            // start camera
            camera.Start();
            // attach camera to camera window
            cameraWindow.Camera = camera;
            if (!Lines)
            {
                Graphics dc = cameraWindow.CreateGraphics();
                var redPen = new Pen(Color.Red, 1);
                dc.DrawLine(redPen, pictureBox1.Size.Width / 2, 0, pictureBox1.Size.Width / 2, pictureBox1.Size.Height);
                dc.DrawLine(redPen, 0, pictureBox1.Size.Height / 2, pictureBox1.Size.Width, pictureBox1.Size.Height / 2);
            }


            // reset statistics
            //  statIndex = statReady = 0;

            // start timer
            timer.Start();

            this.Cursor = Cursors.Default;
        }

        // Close current file
        public void CloseFile()
        {
            Camera camera = cameraWindow.Camera;

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

        private void MainFormLoad(object sender, EventArgs e)
        {
            if (!File.Exists("C:\\Program Files\\LazerShot\\ust.tir"))
            {
                string s = "10.0.0.10";
                string rez = string.Format(s + "/#97.99.101.");
                if (!Directory.Exists("C:\\Program Files\\LazerShot"))
                    Directory.CreateDirectory("C:\\Program Files\\LazerShot");
                var str = new StreamWriter("C:\\Program Files\\LazerShot\\ust.tir");
                str.Write(rez);
                str.Close();

                string pass = ".#...";
                var str1 = new StreamWriter("C:\\Program Files\\LazerShot\\pass.tir");
                str1.Write(pass);
                str1.Close();
            }
            InDomainItems();
            UpdateMarks();
            detector.mForm = this;
            MinimizeBox = false;
            MaximizeBox = false;
            _videoServer.StartListening();

        }

        public void CreateCelTClick(object sender, EventArgs e)
        {
            rezalt.Clear();
            listBox1.Items.Clear();
            label3.Text = "Сума:";
            CreateCel();
            Start.Enabled = true;
            UstedCel();


            if (StartBunnonEnable)
            {
                Start.Enabled = true;
            }
            else
            {
                StartBunnonEnable = true;
            }
        }

        private void CentrTClick(object sender, EventArgs e)
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
        }

        //лінії для виставлення камери
        public void CameraButtonTClick(object sender, EventArgs e)
        {
            StartBunnonEnable = false;
            Start.Enabled = false;
            listBox1.Items.Clear();
            CreateCelT.Enabled = false;
            CentrT.Enabled = false;
            openCamera(sender, e);
            timer1.Start();
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            CreateCelT.Enabled = true;
        }

        private void CreateCel()
        {
            toolStripStatusLabel1.Text = "Start";
            Bitmap bmp = new Bitmap(cameraWindow.Camera.LastFrame);
            pictureBox1.BackgroundImage = bmp;
            pictureBox1.Image = Properties.Resources.clear;

            //ChatClient.BatchMode.SendMessage(string.Format("true {0} {1}", bmp.Size.Height, bmp.Size.Width));


            //for (var y = 0; y < bmp.Size.Height; y++)
            //{
            //    string sendString = "true ";
            //    for (var x = 0; x < bmp.Size.Width; x++)
            //    {
            //        sendString = string.Format("{0}{1},", sendString, bmp.GetPixel(x, y).ToArgb());
            //    }
            // ChatClient.BatchMode.SendMessage(sendString);
            //}

            //   _videoServer.SetImage(bmp);
            _videoServer.SendImage(bmp);
        }

        // створеня скріна мішені
        private void UstedCel() // юстування
        {
            //пеереключення між режимами
            label1.Visible = false;
            string[] line;

            //створення/доставання файла з  значеннями
            if (Directory.Exists("C:\\Program Files\\LazerShot"))
            {
                const string addres = "C:\\Program Files\\LazerShot\\ust.tir";
                var str = new StreamReader(addres);
                string s = str.ReadToEnd();
                str.Close();
                string[] ss = s.Split('/');
                line = ss[0].Split('.');
                UstedBoxCenter.Text = line[0];
                UstedBoxX.Text = line[1];
                UstedBoxY.Text = line[2];
                domainUpDownXa.Text = line[3];
                timer2.Start();
            }
        }

        private void InDomainItems()
        {
            for (int i = 299; i > 0; i--)
            {
                UstedBoxCenter.Items.Add(i);
                domainUpDownXa.Items.Add(i);
            }
            for (int i = 200; i > -201; i--)
            {
                UstedBoxX.Items.Add(i);
                UstedBoxY.Items.Add(i);
            }
        }

        //заповнення вікон юстування
        public void DrawingP()
        {
            try
            {
                int xe;
                int ye;

                if (checkBoxRound.Checked)
                {
                    ye = int.Parse(UstedBoxCenter.Text);
                    xe = ye;
                }
                else
                {
                    ye = int.Parse(UstedBoxCenter.Text);
                    xe = int.Parse(domainUpDownXa.Text);
                }
                Graphics graph = pictureBox1.CreateGraphics();
                Pen p = new Pen(Brushes.Red, 1);
                for (int i = 1; i < 6; i++)
                    graph.DrawEllipse(p, (pictureBox1.Size.Width - xe * i) / 2 + _xstart,
                                      (pictureBox1.Size.Height - ye * i) / 2 + _ystart, xe * i, ye * i);

                graph.DrawRectangle(p, (pictureBox1.Size.Width - xe * 5) / 2 + _xstart,
                                    (pictureBox1.Size.Height - ye * 5) / 2 + _ystart, xe * 5, ye * 5);

                float f1 = xe * 27 / 20;
                float f2 = ye * 36 / 20;

                graph.DrawRectangle(p, (pictureBox1.Size.Width - xe * 5) / 2 + _xstart,
                                    (pictureBox1.Size.Height - ye * 5) / 2 + _ystart, f1, f2);
                graph.DrawRectangle(p, (pictureBox1.Size.Width + xe * 5) / 2 - f1 + _xstart,
                                    _ystart + (pictureBox1.Size.Height - ye * 5) / 2, f1, f2);
            }
            catch
            {
            }

        }

        // замальовка
        public void Shot(int x, int y)
        {
            if (startStop)
            {
                listPoint.Add(new Point(x, y));
                Statistic(x, y);
            }
        }

        // точка вистрілу
        private void Statistic(int x, int y) // запис результату
        {
            double x1 = pictureBox1.Size.Width / 2 + _xstart;
            double y1 = pictureBox1.Size.Height / 2 + _ystart;
            double length = Math.Sqrt((x - x1) * (x - x1) + (y1 - y) * (y1 - y));

            double Ye = double.Parse(UstedBoxCenter.Text) / 2;
            double Xe;
            if (checkBoxRound.Checked)
            {
                Xe = Ye;
            }
            else
            {
                Xe = double.Parse(domainUpDownXa.Text) / 2;
            }

            bool zero = false;
            if (y < y1 - 1.4 * Ye)
            {
                if ((x < x1 - 2.3 * Xe) || (x > x1 + 2.3 * Xe))
                {
                    rezalt.Add("0");
                    zero = true;
                }
            }
            if (!zero)
            {
                if ((y < y1 - Ye * 5 - 7) || (y > y1 + 7 + Ye * 5))
                {
                    rezalt.Add("0");
                    zero = true;
                }
                if ((x < x1 - Xe * 5 - 7) || (x > x1 + 7 + Xe * 5))
                {
                    rezalt.Add("0");
                    zero = true;
                }
                if (!zero)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        if (length <= 5 + Diametr(length, x1, y1, x, y, i))
                        {
                            switch (i)
                            {
                                case 1:
                                    rezalt.Add("10");
                                    break;
                                case 2:
                                    rezalt.Add("9");
                                    break;
                                case 3:
                                    rezalt.Add("8");
                                    break;
                                case 4:
                                    rezalt.Add("7");
                                    break;
                                case 5:
                                    rezalt.Add("6");
                                    break;
                                case 6:
                                    rezalt.Add("5");
                                    break;
                            }
                            break;
                        }
                    }
                }
            }
            try
            {
                ChatClient.BatchMode.SendMessage(string.Format("false {0}", rezalt[rezalt.Count - 1]));
            }
            catch
            {
            }

            RezaltWrite(rezalt);
        }

        private double Diametr(double length, double x1, double y1, int x, int y, int mn)
        {
            if (checkBoxRound.Checked)
            {
                return mn * double.Parse(UstedBoxCenter.Text) / 2;
            }
            else
            {
                double cos = Math.Abs(x - x1) / length;
                double sin = Math.Abs(y - y1) / length;
                double a = double.Parse(domainUpDownXa.Text) * mn / 2;
                double b = double.Parse(UstedBoxCenter.Text) * mn / 2;
                return Math.Sqrt(a * a * cos * cos + b * b * sin * sin);
            }
        }

        private void RezaltWrite(ArrayList rezalt)
        {
            try
            {
                this.BeginInvoke(new Action(() =>
                                                {
                                                    listBox1.Items.Clear();
                                                    int symmaryRez = 0;
                                                    for (int i = 0; i < rezalt.Count; i++)
                                                    {
                                                        listBox1.Items.Add(string.Format("{0} - {1}",
                                                                                         listBox1.Items.Count + 1,
                                                                                         rezalt[i]));
                                                        symmaryRez += int.Parse(rezalt[i].ToString());
                                                    }
                                                    listBox1.Items.Add("---------------------");
                                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                                    label3.Text = string.Format("Сума: < {0} > очок", symmaryRez);
                                                    if ((rezalt.Count == _shotNumber) && (Marks.Checked))
                                                    {
                                                        FinalityShot(symmaryRez);
                                                    }
                                                }));
            }
            catch
            {
                RezaltWrite(rezalt);
            }
        }

        private void FinalityShot(int symmaryRez)
        {
            var mark = 0;
            if (symmaryRez >= _on5)
            {
                listBox1.Items.Add("Оцінка - 5");
                mark = 5;
            }
            else
            {
                if (symmaryRez >= _on4)
                {
                    listBox1.Items.Add("Оцінка - 4");
                    mark = 4;
                }
                else
                {
                    if (symmaryRez >= _on3)
                    {
                        listBox1.Items.Add("Оцінка - 3");
                        mark = 3;
                    }
                    else
                    {
                        if (symmaryRez >= _on2)
                        {
                            listBox1.Items.Add("Оцінка - 2");
                            mark = 2;
                        }
                        else
                        {
                            listBox1.Items.Add("Оцінка менше 2");
                            mark = 1;
                        }
                    }
                }
            }
            //  ChatClient.BatchMode.SendMessage(string.Format("true {0}", mark));
            startStop = false;
            Stop.Enabled = false;
            Start.Enabled = true;
        }

        // функціонал по кнопках, зміни\запуски
        private void Timer2Tick(object sender, EventArgs e)
        {
            DrawingP();
            ThisShot(p);
        }

        private void StartClick(object sender, EventArgs e)
        {
            startStop = true;
            Stop.Enabled = true;
            Start.Enabled = false;
            rezalt.Clear();
            listPoint.Clear();
            listBox1.Items.Clear();
            pictureBox1.Image = Properties.Resources.clear;
        }

        private void StopClick(object sender, EventArgs e)
        {
            startStop = false;
            Stop.Enabled = false;
            Start.Enabled = true;
            listBox1.Items.Clear();
            listPoint.Clear();
            p.Clear();
        }

        private void Button1Click1(object sender, EventArgs e)
        {
            string s = string.Format("{0}.{1}.{2}.{3}", UstedBoxCenter.Text, UstedBoxX.Text, UstedBoxY.Text, domainUpDownXa.Text);
            string addres = "C:\\Program Files\\LazerShot\\ust.tir";
            var str = new System.IO.StreamReader(addres);
            string s1 = str.ReadToEnd();
            str.Close();
            string[] ss = s1.Split('/');
            string rezalt = string.Format(s + "/" + ss[1]);
            File.Delete("C:\\Program Files\\LazerShot\\ust.tir");
            System.IO.StreamWriter str1 = new System.IO.StreamWriter("C:\\Program Files\\LazerShot\\ust.tir");
            str1.Write(rezalt);
            str1.Close();
        }

        private void DomainUpDown1TextChanged(object sender, EventArgs e) //замальовка непропорційна
        {
            pictureBox1.Image = Properties.Resources.clear;
            timer2.Start();
        }

        private void DomainUpDown2TextChanged(object sender, EventArgs e)
        {
            _xstart = int.Parse(UstedBoxX.Text);
            pictureBox1.Image = Properties.Resources.clear;
            timer2.Start();
        }

        private void DomainUpDown3TextChanged(object sender, EventArgs e)
        {
            _ystart = int.Parse(UstedBoxY.Text);
            pictureBox1.Image = Properties.Resources.clear;
            timer2.Start();
        }

        private void MarksClick(object sender, EventArgs e)
        {
            if (Marks.Checked)
            {
                SettingsMarks.Visible = true;
            }
            else
                SettingsMarks.Visible = false;
        }

        private void SettingsMarksClick(object sender, EventArgs e)
        {
            sequreMarks f = new sequreMarks();
            f.ShowDialog();
            UpdateMarks();
        }

        public void UpdateMarks()
        {
            try
            {
                var str = new StreamReader("C:\\Program Files\\LazerShot\\pass.tir");
                string s = str.ReadToEnd();
                char[] sq = s.ToCharArray();
                _shotNumber = sq[0];
                _on5 = sq[2];
                _on4 = sq[4];
                _on3 = sq[6];
                _on2 = sq[8];
                str.Close();
            }
            catch
            {
                if (System.IO.File.Exists("C:\\Program Files\\LazerShot\\pass.tir"))
                    System.IO.File.Delete("C:\\Program Files\\LazerShot\\pass.tir");
                string pass = ".#...";
                var str1 = new System.IO.StreamWriter("C:\\Program Files\\LazerShot\\pass.tir");
                str1.Write(pass);
                str1.Close();
            }
        }

        //private void AutoUst()
        //{
        //    Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap((Bitmap)pictureBox1.BackgroundImage);
        //    uBitmap.LockBitmap();
        //    byte r, g, b;

        //    Point p1 = new Point(-1, -1);
        //    Point p2 = new Point(-1, -1);
        //    Point p3 = new Point(-1, -1);
        //    Point p4 = new Point(-1, -1);
        //    for (int y = 0; y < uBitmap.Bitmap.Size.Height; y += 2)
        //    {
        //        for (int x = 0; x < uBitmap.Bitmap.Size.Width; x += 2)
        //        {
        //            r = uBitmap.GetPixel(x, y).red;
        //            g = uBitmap.GetPixel(x, y).green;
        //            b = uBitmap.GetPixel(x, y).blue;

        //            if ((r - g > 80) && (r - b > 80))
        //            {
        //                ColorControl f = new ColorControl();
        //                if (p1.X == -1)
        //                {
        //                    p1 = f.PPoint(x - 5, y - 5);
        //                    if (p1.X != -1)
        //                    {
        //                        x += 20;
        //                        continue;
        //                    }
        //                }
        //                if ((p1.X != -1) && (p2.X == -1))
        //                {
        //                    p2 = f.PPoint(x - 5, y - 5);
        //                    if (p2.X != -1)
        //                    {
        //                        x += 20;
        //                        y += 20;
        //                        continue;
        //                    }
        //                }
        //                if ((p2.X != -1) && (p3.X == -1))
        //                {
        //                    p3 = f.PPoint(x - 5, y - 5);
        //                    if (p3.X != -1)
        //                    {
        //                        x += 20;
        //                        continue;
        //                    }
        //                }
        //                if ((p3.X != -1) && (p4.X == -1))
        //                {
        //                    p4 = f.PPoint(x - 5, y - 5);
        //                    if (p4.X != -1)
        //                    {
        //                        x += 20;
        //                        y += 20;
        //                        continue;
        //                    }
        //                }
        //                if (p4.X != -1)
        //                {
        //                    MathUst(p1, p3, p2, p4);
        //                }
        //            }
        //        }
        //    }
        //}  // autoUsted

        private double Xcoef;
        private double Ycoef;
        private Point pStatic;

        private void MathUst(Point pLU, Point pLD, Point pRD)
        {
            timer2.Stop(); // off first drawing

            Xcoef = Math.Abs((pRD.X - pLD.X) / 500);
            Ycoef = Math.Abs((pLD.Y - pLU.Y) / 320);
            pStatic.X = pLU.X;
            pStatic.Y = pLU.Y;

            timerDrawingUst2.Start();
        }

        private void TimerDrawingUst2Tick(object sender, EventArgs e)
        {
            DrawingAutoUst();
        }

        private void DrawingAutoUst()
        {
            try
            {
                Graphics graph = pictureBox1.CreateGraphics();
                var p = new Pen(Brushes.Red, 1);
                graph.DrawRectangle(p, pStatic.X, pStatic.Y - (int)(Ycoef * 180), (int)(Xcoef * 500), (int)(Ycoef * 500));
            }
            catch
            {
            }
        }

        //private void statisticAuto(int x, int y)
        //{
        //    bool NotZero = true;
        //    Point Centr = new Point();
        //    Centr.X = pStatic.X + (int)(Xcoef * 250);
        //    Centr.Y = pStatic.Y + (int)(Ycoef * 250);

        //    if ((x < pStatic.X + (int)(Xcoef * 135)) || (x > pStatic.X + (int)(Xcoef * 365)))
        //    {
        //        if (y < pStatic.Y)
        //            NotZero = false;
        //    }
        //    if (NotZero)
        //    {
        //        double Lenght = Math.Sqrt((x - Centr.X) * (x - Centr.X) + (y - Centr.Y) * (y - Centr.Y) - 255);
        //        double sint = Math.Abs(x - Centr.X) / Lenght;
        //        double cost = Math.Abs(y - Centr.Y) / Lenght;
        //        double a = 0;
        //        double b = 0;
        //        if (Xcoef > Ycoef)
        //        {
        //            a = Xcoef;
        //            b = Ycoef;
        //        }
        //        else
        //        {
        //            a = Ycoef;
        //            b = Xcoef;
        //        }

        //        for (int i = 1; i < 8; i++)
        //        {
        //            if (Lenght < RadiusElipce(a * 50 * i, b * 50 * i, sint, cost))
        //            {
        //                switch (i)
        //                {
        //                    case 1:
        //                        { rezalt.Add("10"); } break;
        //                    case 2:
        //                        { rezalt.Add("9"); } break;
        //                    case 3:
        //                        { rezalt.Add("8"); } break;
        //                    case 4:
        //                        { rezalt.Add("7"); } break;
        //                    case 5:
        //                        { rezalt.Add("6"); } break;
        //                    case 6:
        //                        { rezalt.Add("5"); } break;
        //                    case 7:
        //                        { rezalt.Add("4"); } break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }
        //    }

        //    RezaltWrite(rezalt);
        //}

        private class ColorControl
        {
            private Point StartControl(int x, int y)
            {
                MainForm f = new MainForm();
                Bitmap image = new Bitmap(f.pictureBox1.BackgroundImage);
                Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
                image.Save("D:\\saveImage.bmp");
                uBitmap.LockBitmap();
                Point pStart = new Point(-1, -1);
                for (int Y = y; Y < y + 30; Y++)
                {
                    if (y >= 480)
                        break;
                    for (int X = x; X < x + 30; X++)
                    {
                        if (X >= 640)
                            break;
                        int r = uBitmap.GetPixel(X, Y).red;
                        int b = uBitmap.GetPixel(X, Y).blue;
                        int g = uBitmap.GetPixel(X, Y).green;
                        if ((r - 80 > g) && (r - 80 > b))
                        {
                            if (pStart.X == -1) // save start point
                            {
                                pStart.X = X;
                                pStart.Y = Y;
                                break;
                            }
                        } //if ((r - 100 > g) && (r - 100 > b))
                    } //for (int x = 0; x < uBitmap.Bitmap.Width; x++)
                    if (pStart.X != -1)
                    {
                        break;
                    }
                }
                uBitmap.UnlockBitmap();
                uBitmap.Dispose();
                image.Dispose();
                //pWEnd = GorizontalControl(pStart, image);
                //pHEnd = VerticalControl(pStart, image);
                return pStart;
            }

            private Point GorizontalControl(Point pStart)
            {
                Point pHEnd = new Point(-1, -1);
                MainForm f = new MainForm();
                Bitmap image = new Bitmap(f.pictureBox1.BackgroundImage);
                Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
                uBitmap.LockBitmap();
                for (int x = pStart.X; x < 30 + pStart.X; x++)
                {
                    int r = uBitmap.GetPixel(x, pStart.Y).red;
                    int b = uBitmap.GetPixel(x, pStart.Y).blue;
                    int g = uBitmap.GetPixel(x, pStart.Y).green;
                    if (((r - 80 > b) && (r - 80 > g)) || ((r > 150) && (g > 120) && (b > 120)))
                    {
                    }
                    else
                    {
                        pHEnd.X = x;
                        pHEnd.Y = pStart.Y;
                        break;
                    }
                }
                uBitmap.UnlockBitmap();
                uBitmap.Dispose();
                image.Dispose();
                return pHEnd;
            }

            private Point VerticalControl(Point pStart)
            {
                MainForm f = new MainForm();
                Bitmap image = new Bitmap(f.pictureBox1.BackgroundImage);
                Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
                uBitmap.LockBitmap();
                Point pEnd = new Point(-1, -1);
                for (int y = pStart.Y; y < 30 + pStart.Y; y++)
                {
                    int r = uBitmap.GetPixel(pStart.X, y).red;
                    int b = uBitmap.GetPixel(pStart.X, y).blue;
                    int g = uBitmap.GetPixel(pStart.X, y).green;
                    if (((r - 80 > b) && (r - 80 > g)) || ((r > 150) && (g > 120) && (b > 120)))
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
                image.Dispose();
                return pEnd;
            }

            public Point PPoint(int x, int y)
            {
                Point pStart = StartControl(x - 2, y - 2);
                if (pStart.X != -1)
                {
                    Point pWEnd = GorizontalControl(pStart);
                    Point pHEnd = VerticalControl(pStart);
                    x = (pStart.X + (pWEnd.X - pStart.X) / 2);
                    y = (pStart.Y + (pHEnd.Y - pStart.Y) / 2);
                }
                else
                {
                    x = -1;
                    y = -1;
                }
                Point pEnd = new Point(x, y);
                return pEnd;
            }
        }

        private void ButtonAutoUstClick(object sender, EventArgs e)
        {
            //buttonAutoUst.Enabled = false;
            //buttonHandUst.Enabled = true;
            //AutoUst();
        }

        private void ButtonHandUstClick(object sender, EventArgs e)
        {
            timerDrawingUst2.Stop();
            buttonAutoUst.Enabled = true;
            buttonHandUst.Enabled = false;
            timer2.Start();
        }

        private void ExitFileItemClick(object sender, FormClosedEventArgs e)
        {
            ConsoleServer.BatchMode.Stop();
            _videoServer.CloseConnect();
            KillProces();
        }

        private void KillProces()
        {
            var proces = Process.GetCurrentProcess();
            proces.Kill();
        }

        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRound.Checked)
            {
                domainUpDownXa.Visible = false;
                label6.Visible = false;
                label2.Text = "Центр - ";
            }
            else
            {
                domainUpDownXa.Visible = true;
                label6.Visible = true;
                label2.Text = "Ye - ";
            }
        }

        private void ListBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.clear;
            int n = 0;
            if (Marks.Checked && listBox1.Items.Count == 7)
                n = 2;
            else
            {
                n = 1;
            }
            if (listBox1.SelectedIndex == listBox1.Items.Count - n)
            {
                foreach (var point in listPoint)
                {
                    p.Add(point);
                }

            }
            else
            {
                if (listBox1.SelectedIndex != -1)
                {
                    p.Clear();
                    p.Add(listPoint[listBox1.SelectedIndex]);
                }
            }
        }

        private void ThisShot(List<Point> p)
        {
            foreach (var point in p)
            {
                pictureBox1.CreateGraphics().FillEllipse(Brushes.Red, point.X - 7 / 2, point.Y - 7 / 2, 6, 6);
                pictureBox1.CreateGraphics().DrawEllipse(new Pen(Brushes.Black, 1), point.X - 7 / 2, point.Y - 7 / 2, 7, 7);
            }
        }

        private void SendMarks()
        {
            if (File.Exists(@"C:\Program Files\LazerShot\pass.tir"))
            {
                var str = new StreamReader("C:\\Program Files\\LazerShot\\pass.tir");
                string s = str.ReadToEnd();
                ChatClient.BatchMode.SendMessage(s);
            }
        }

        private void ButtonHelpClick(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label10.BackColor = Color.Red;
        }

        private void Label10Click(object sender, EventArgs e)
        {
            label10.BackColor = label7.BackColor;
            label7.BackColor = Color.Red;
            if (Process.GetProcesses().ToList().Where(item => item.ProcessName == "ConsoleServer").Any())
            {
                foreach (var VARIABLE in Process.GetProcesses().ToList())
                {
                    if (VARIABLE.ProcessName.Equals("ConsoleServer"))
                    {
                        VARIABLE.Kill();
                        break;
                    }
                }
            }
            Client();
        }

        private void Label7Click(object sender, EventArgs e)
        {
            label7.BackColor = label9.BackColor;
            label8.BackColor = Color.Red;
            CameraButtonTClick(sender, e);
            label8.Enabled = true;
        }

        private void Label8Click(object sender, EventArgs e)
        {
            label8.BackColor = label7.BackColor;
            label9.BackColor = Color.Red;
            CreateCelTClick(sender, e);
            label9.Enabled = true;
        }

        private void Label9Click(object sender, EventArgs e)
        {
            label9.BackColor = label7.BackColor;
            panel1.Visible = false;
            tabControl1.SelectedIndex = 1;
            label8.Enabled = false;
            label9.Enabled = false;
        }

        private void обратиВзводToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (DM == null)
                 DM = new TIRDatabase.Datamanager();
             DM.Show();
        }
    }
}