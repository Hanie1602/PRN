namespace BookManagerGUIForms
{
	partial class btnSayHello
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
			btnButton = new Button();
			btnQuit = new Button();
			button3 = new Button();
			btnShowCountry = new Button();
			cboCountry = new ComboBox();
			dgvBookList = new DataGridView();
			btnLoadBooks = new Button();
			btnCreate = new Button();
			button1 = new Button();
			((System.ComponentModel.ISupportInitialize)dgvBookList).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.Yellow;
			label1.Location = new Point(301, 47);
			label1.Name = "label1";
			label1.Size = new Size(136, 28);
			label1.TabIndex = 0;
			label1.Text = "Select country";
			label1.Click += label1_Click;
			// 
			// btnButton
			// 
			btnButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnButton.ForeColor = SystemColors.ActiveCaptionText;
			btnButton.Location = new Point(21, 12);
			btnButton.Name = "btnButton";
			btnButton.Size = new Size(94, 29);
			btnButton.TabIndex = 1;
			btnButton.Text = "Nút";
			btnButton.UseVisualStyleBackColor = true;
			btnButton.Click += btnButton_Click;
			// 
			// btnQuit
			// 
			btnQuit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnQuit.ForeColor = SystemColors.ActiveCaptionText;
			btnQuit.Location = new Point(131, 12);
			btnQuit.Name = "btnQuit";
			btnQuit.Size = new Size(94, 29);
			btnQuit.TabIndex = 2;
			btnQuit.Text = "Quit";
			btnQuit.UseVisualStyleBackColor = true;
			btnQuit.Click += btnQuit_Click;
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
			// btnShowCountry
			// 
			btnShowCountry.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnShowCountry.ForeColor = SystemColors.ActiveCaptionText;
			btnShowCountry.Location = new Point(402, 12);
			btnShowCountry.Name = "btnShowCountry";
			btnShowCountry.Size = new Size(129, 29);
			btnShowCountry.TabIndex = 4;
			btnShowCountry.Text = "Show Country";
			btnShowCountry.UseVisualStyleBackColor = true;
			btnShowCountry.Click += btnShowCountry_Click;
			// 
			// cboCountry
			// 
			cboCountry.BackColor = SystemColors.InfoText;
			cboCountry.FormattingEnabled = true;
			cboCountry.Location = new Point(443, 47);
			cboCountry.Name = "cboCountry";
			cboCountry.Size = new Size(151, 28);
			cboCountry.TabIndex = 5;
			// 
			// dgvBookList
			// 
			dgvBookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvBookList.Location = new Point(24, 211);
			dgvBookList.Name = "dgvBookList";
			dgvBookList.RowHeadersWidth = 51;
			dgvBookList.Size = new Size(586, 215);
			dgvBookList.TabIndex = 6;
			dgvBookList.CellContentClick += dgvBookList_CellContentClick;
			// 
			// btnLoadBooks
			// 
			btnLoadBooks.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnLoadBooks.ForeColor = SystemColors.ActiveCaptionText;
			btnLoadBooks.Location = new Point(24, 164);
			btnLoadBooks.Name = "btnLoadBooks";
			btnLoadBooks.Size = new Size(94, 29);
			btnLoadBooks.TabIndex = 7;
			btnLoadBooks.Text = "Fill Books";
			btnLoadBooks.UseVisualStyleBackColor = true;
			btnLoadBooks.Click += btnLoadBooks_Click;
			// 
			// btnCreate
			// 
			btnCreate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCreate.ForeColor = SystemColors.ActiveCaptionText;
			btnCreate.Location = new Point(177, 164);
			btnCreate.Name = "btnCreate";
			btnCreate.Size = new Size(123, 29);
			btnCreate.TabIndex = 8;
			btnCreate.Text = "Create Books";
			btnCreate.UseVisualStyleBackColor = true;
			btnCreate.Click += btnCreate_Click;
			// 
			// button1
			// 
			button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button1.ForeColor = SystemColors.ActiveCaptionText;
			button1.Location = new Point(366, 164);
			button1.Name = "button1";
			button1.Size = new Size(123, 29);
			button1.TabIndex = 9;
			button1.Text = "Create Books";
			button1.UseVisualStyleBackColor = true;
			button1.Click += btnCreateBook_Click;
			// 
			// btnSayHello
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaptionText;
			ClientSize = new Size(800, 450);
			Controls.Add(button1);
			Controls.Add(btnCreate);
			Controls.Add(btnLoadBooks);
			Controls.Add(dgvBookList);
			Controls.Add(cboCountry);
			Controls.Add(btnShowCountry);
			Controls.Add(button3);
			Controls.Add(btnQuit);
			Controls.Add(btnButton);
			Controls.Add(label1);
			Name = "btnSayHello";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)dgvBookList).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Button btnButton;
		private Button btnQuit;
		private Button button3;
		private Button btnShowCountry;
		private ComboBox cboCountry;
		private DataGridView dgvBookList;
		private Button btnLoadBooks;
		private Button btnCreate;
		protected internal Button button1;
	}
}
