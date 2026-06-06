namespace Reforger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label9 = new Label();
            textBox4 = new TextBox();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            button3 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            panel2 = new Panel();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            panel3 = new Panel();
            checkedListBox1 = new CheckedListBox();
            label12 = new Label();
            button2 = new Button();
            button4 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(label9);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button3);
            panel1.Dock = DockStyle.Right;
            panel1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            panel1.Location = new Point(629, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 409);
            panel1.TabIndex = 13;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label9.Location = new Point(12, 324);
            label9.Name = "label9";
            label9.Size = new Size(127, 15);
            label9.TabIndex = 23;
            label9.Text = "Download Updates To:";
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox4.Location = new Point(12, 342);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(223, 23);
            textBox4.TabIndex = 23;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Orange;
            label8.Location = new Point(12, 70);
            label8.Name = "label8";
            label8.Size = new Size(166, 17);
            label8.TabIndex = 27;
            label8.Text = "0 Not Found on Modrinth";
            label8.Click += label8_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(12, 40);
            label6.Name = "label6";
            label6.Size = new Size(85, 20);
            label6.TabIndex = 26;
            label6.Text = "0 Outdated";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label5.ForeColor = Color.Lime;
            label5.Location = new Point(12, 12);
            label5.Name = "label5";
            label5.Size = new Size(144, 20);
            label5.TabIndex = 15;
            label5.Text = "0 Updates Available";
            label5.Click += label5_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.Enabled = false;
            button3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            button3.Image = Properties.Resources.modrinth;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(12, 371);
            button3.Name = "button3";
            button3.Size = new Size(223, 26);
            button3.TabIndex = 25;
            button3.Text = "Update All";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.TextImageRelation = TextImageRelation.TextBeforeImage;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(2, 7);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 14;
            label1.Text = "Your Mods Folder:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(109, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(455, 23);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += RefreshUI;
            // 
            // button1
            // 
            button1.Location = new Point(570, 3);
            button1.Name = "button1";
            button1.Size = new Size(40, 23);
            button1.TabIndex = 16;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(textBox1);
            panel2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            panel2.Location = new Point(10, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(613, 82);
            panel2.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label7.Location = new Point(327, 58);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 22;
            label7.Text = "(e.g \"fabric\")";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label4.Location = new Point(109, 58);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 21;
            label4.Text = "(e.g \"26.1\" or \"26.x\")";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.Location = new Point(246, 35);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 19;
            label3.Text = "Architecture:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(327, 32);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(131, 23);
            textBox3.TabIndex = 20;
            textBox3.TextChanged += RefreshUI;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(20, 35);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 17;
            label2.Text = "Game Version:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(109, 32);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(131, 23);
            textBox2.TabIndex = 18;
            textBox2.TextChanged += RefreshUI;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(checkedListBox1);
            panel3.Controls.Add(label12);
            panel3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            panel3.Location = new Point(10, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(613, 265);
            panel3.TabIndex = 23;
            // 
            // checkedListBox1
            // 
            checkedListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBox1.BackColor = SystemColors.ControlLightLight;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(13, 32);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(586, 220);
            checkedListBox1.TabIndex = 15;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label12.Location = new Point(2, 7);
            label12.Name = "label12";
            label12.Size = new Size(108, 15);
            label12.TabIndex = 14;
            label12.Text = "Found JAR Files (0)";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            button2.Image = Properties.Resources.modrinth;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(12, 371);
            button2.Name = "button2";
            button2.Size = new Size(530, 26);
            button2.TabIndex = 24;
            button2.Text = "Query All";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.TextImageRelation = TextImageRelation.TextBeforeImage;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(548, 371);
            button4.Name = "button4";
            button4.Size = new Size(75, 26);
            button4.TabIndex = 25;
            button4.Text = "See Note";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(876, 409);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(892, 448);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reforger";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Panel panel2;
        private Label label2;
        private TextBox textBox2;
        private Label label4;
        private Label label3;
        private TextBox textBox3;
        private Label label7;
        private Panel panel3;
        private Label label12;
        private Button button2;
        private Button button3;
        private Label label5;
        private Label label6;
        private Label label8;
        private CheckedListBox checkedListBox1;
        private TextBox textBox4;
        private Label label9;
        private Button button4;
    }
}
