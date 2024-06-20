namespace BookManagerGUIForms
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
			label1 = new Label();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			button4 = new Button();
			cboCountry = new ComboBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.Yellow;
			label1.Location = new Point(265, 165);
			label1.Name = "label1";
			label1.Size = new Size(136, 28);
			label1.TabIndex = 0;
			label1.Text = "Select country";
			label1.Click += label1_Click;
			// 
			// button1
			// 
			button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button1.ForeColor = SystemColors.ActiveCaptionText;
			button1.Location = new Point(21, 12);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 1;
			button1.Text = "Nút";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button2.ForeColor = SystemColors.ActiveCaptionText;
			button2.Location = new Point(131, 12);
			button2.Name = "button2";
			button2.Size = new Size(94, 29);
			button2.TabIndex = 2;
			button2.Text = "Quit";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button3
			// 
			button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button3.ForeColor = SystemColors.ActiveCaptionText;
			button3.Location = new Point(244, 12);
			button3.Name = "button3";
			button3.Size = new Size(141, 29);
			button3.TabIndex = 3;
			button3.Text = "Fill Country";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// button4
			// 
			button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button4.ForeColor = SystemColors.ActiveCaptionText;
			button4.Location = new Point(402, 12);
			button4.Name = "button4";
			button4.Size = new Size(129, 29);
			button4.TabIndex = 4;
			button4.Text = "Show Country";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// cboCountry
			// 
			cboCountry.BackColor = SystemColors.InfoText;
			cboCountry.FormattingEnabled = true;
			cboCountry.Location = new Point(265, 134);
			cboCountry.Name = "cboCountry";
			cboCountry.Size = new Size(151, 28);
			cboCountry.TabIndex = 5;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaptionText;
			ClientSize = new Size(800, 450);
			Controls.Add(cboCountry);
			Controls.Add(button4);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(label1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;
		private ComboBox cboCountry;
	}
}
