namespace TIRDatabase
{
    partial class Manager
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
            this.SelectedTeacher = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectedSquad = new System.Windows.Forms.ComboBox();
            this.Refresh = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectedFiretake = new System.Windows.Forms.ComboBox();
            this.WriteToBase = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectedTeacher
            // 
            this.SelectedTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedTeacher.Location = new System.Drawing.Point(107, 12);
            this.SelectedTeacher.Name = "SelectedTeacher";
            this.SelectedTeacher.Size = new System.Drawing.Size(121, 21);
            this.SelectedTeacher.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Преподаватель:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Взвод:";
            // 
            // SelectedSquad
            // 
            this.SelectedSquad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedSquad.Location = new System.Drawing.Point(305, 12);
            this.SelectedSquad.Name = "SelectedSquad";
            this.SelectedSquad.Size = new System.Drawing.Size(121, 21);
            this.SelectedSquad.TabIndex = 3;
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(272, 75);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(154, 23);
            this.Refresh.TabIndex = 4;
            this.Refresh.Text = "Обновить записи";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(18, 75);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(144, 23);
            this.Start.TabIndex = 5;
            this.Start.Text = "Начать стрельбу";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Стрельба:";
            // 
            // SelectedFiretake
            // 
            this.SelectedFiretake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedFiretake.FormattingEnabled = true;
            this.SelectedFiretake.Location = new System.Drawing.Point(79, 121);
            this.SelectedFiretake.Name = "SelectedFiretake";
            this.SelectedFiretake.Size = new System.Drawing.Size(347, 21);
            this.SelectedFiretake.TabIndex = 7;
            // 
            // WriteToBase
            // 
            this.WriteToBase.Location = new System.Drawing.Point(26, 166);
            this.WriteToBase.Name = "WriteToBase";
            this.WriteToBase.Size = new System.Drawing.Size(136, 23);
            this.WriteToBase.TabIndex = 8;
            this.WriteToBase.Text = "Записать в базу";
            this.WriteToBase.UseVisualStyleBackColor = true;
            this.WriteToBase.Click += new System.EventHandler(this.WriteToBase_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(212, 166);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(125, 23);
            this.Delete.TabIndex = 9;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 211);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.WriteToBase);
            this.Controls.Add(this.SelectedFiretake);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.SelectedSquad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectedTeacher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SelectedSquad;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button WriteToBase;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.ComboBox SelectedTeacher;
        private System.Windows.Forms.ComboBox SelectedFiretake;
    }
}