namespace FactorioSave
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
            this.saveList = new System.Windows.Forms.CheckedListBox();
            this.Thumbnail = new System.Windows.Forms.PictureBox();
            this.saveName_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveList
            // 
            this.saveList.BackColor = System.Drawing.Color.AliceBlue;
            this.saveList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.saveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveList.FormattingEnabled = true;
            this.saveList.Location = new System.Drawing.Point(0, 0);
            this.saveList.Name = "saveList";
            this.saveList.Size = new System.Drawing.Size(200, 547);
            this.saveList.TabIndex = 0;
            this.saveList.SelectedIndexChanged += new System.EventHandler(this.saveList_SelectedIndexChanged);
            // 
            // Thumbnail
            // 
            this.Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Thumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Thumbnail.Location = new System.Drawing.Point(0, 0);
            this.Thumbnail.Name = "Thumbnail";
            this.Thumbnail.Size = new System.Drawing.Size(300, 304);
            this.Thumbnail.TabIndex = 1;
            this.Thumbnail.TabStop = false;
            // 
            // saveName_label
            // 
            this.saveName_label.AutoSize = true;
            this.saveName_label.Location = new System.Drawing.Point(628, 13);
            this.saveName_label.Name = "saveName_label";
            this.saveName_label.Size = new System.Drawing.Size(0, 12);
            this.saveName_label.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 67);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.saveList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 547);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.Thumbnail);
            this.panel3.Location = new System.Drawing.Point(206, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 304);
            this.panel3.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(970, 614);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.saveName_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "팩볶음오";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox saveList;
        private System.Windows.Forms.PictureBox Thumbnail;
        private System.Windows.Forms.Label saveName_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
    }
}

