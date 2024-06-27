namespace BookManagerGUIForms
{
	partial class BookManagerMainForm
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
			btnSayHello = new Button();
			btnQuit = new Button();
			btnShowCountry = new Button();
			button4 = new Button();
			cboCountry = new ComboBox();
			label1 = new Label();
			dvgBookList = new DataGridView();
			btnFillBook = new Button();
			btnCreateBook = new Button();
			dateTimePicker1 = new DateTimePicker();
			((System.ComponentModel.ISupportInitialize)dvgBookList).BeginInit();
			SuspendLayout();
			// 
			// btnSayHello
			// 
			btnSayHello.FlatStyle = FlatStyle.Popup;
			btnSayHello.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnSayHello.ForeColor = Color.Yellow;
			btnSayHello.Location = new Point(35, 25);
			btnSayHello.Name = "btnSayHello";
			btnSayHello.Size = new Size(129, 56);
			btnSayHello.TabIndex = 0;
			btnSayHello.Text = "Say Hello";
			btnSayHello.UseVisualStyleBackColor = true;
			btnSayHello.Click += btnSayHello_Click;
			// 
			// btnQuit
			// 
			btnQuit.FlatAppearance.BorderColor = Color.Yellow;
			btnQuit.FlatAppearance.BorderSize = 2;
			btnQuit.FlatStyle = FlatStyle.Popup;
			btnQuit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnQuit.ForeColor = Color.Yellow;
			btnQuit.Location = new Point(220, 25);
			btnQuit.Name = "btnQuit";
			btnQuit.Size = new Size(129, 56);
			btnQuit.TabIndex = 1;
			btnQuit.Text = "Quit";
			btnQuit.UseVisualStyleBackColor = true;
			btnQuit.Click += btnQuit_Click;
			// 
			// btnShowCountry
			// 
			btnShowCountry.FlatStyle = FlatStyle.Popup;
			btnShowCountry.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnShowCountry.ForeColor = Color.Yellow;
			btnShowCountry.Location = new Point(611, 25);
			btnShowCountry.Name = "btnShowCountry";
			btnShowCountry.Size = new Size(129, 56);
			btnShowCountry.TabIndex = 2;
			btnShowCountry.Text = "Show Country";
			btnShowCountry.UseVisualStyleBackColor = true;
			btnShowCountry.Click += btnShowCountry_Click;
			// 
			// button4
			// 
			button4.FlatStyle = FlatStyle.Popup;
			button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button4.ForeColor = Color.Yellow;
			button4.Location = new Point(416, 25);
			button4.Name = "button4";
			button4.Size = new Size(129, 56);
			button4.TabIndex = 3;
			button4.Text = "Fill Country";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// cboCountry
			// 
			cboCountry.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			cboCountry.FormattingEnabled = true;
			cboCountry.Location = new Point(409, 101);
			cboCountry.Name = "cboCountry";
			cboCountry.Size = new Size(527, 45);
			cboCountry.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.Yellow;
			label1.Location = new Point(178, 108);
			label1.Name = "label1";
			label1.Size = new Size(205, 38);
			label1.TabIndex = 5;
			label1.Text = "Select country";
			// 
			// dvgBookList
			// 
			dvgBookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dvgBookList.Location = new Point(35, 216);
			dvgBookList.Name = "dvgBookList";
			dvgBookList.RowHeadersWidth = 51;
			dvgBookList.Size = new Size(890, 241);
			dvgBookList.TabIndex = 6;
			dvgBookList.CellContentClick += dataGridView1_CellContentClick;
			// 
			// btnFillBook
			// 
			btnFillBook.FlatStyle = FlatStyle.Popup;
			btnFillBook.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnFillBook.ForeColor = Color.Yellow;
			btnFillBook.Location = new Point(35, 143);
			btnFillBook.Name = "btnFillBook";
			btnFillBook.Size = new Size(129, 56);
			btnFillBook.TabIndex = 7;
			btnFillBook.Text = "Fill Book";
			btnFillBook.UseVisualStyleBackColor = true;
			btnFillBook.Click += btnLoadBook_Click;
			// 
			// btnCreateBook
			// 
			btnCreateBook.FlatStyle = FlatStyle.Popup;
			btnCreateBook.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCreateBook.ForeColor = Color.Yellow;
			btnCreateBook.Location = new Point(254, 149);
			btnCreateBook.Name = "btnCreateBook";
			btnCreateBook.Size = new Size(129, 56);
			btnCreateBook.TabIndex = 8;
			btnCreateBook.Text = "Create Book";
			btnCreateBook.UseVisualStyleBackColor = true;
			btnCreateBook.Click += btnCreateBook_Click;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Format = DateTimePickerFormat.Short;
			dateTimePicker1.Location = new Point(1045, 561);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(138, 27);
			dateTimePicker1.TabIndex = 9;
			// 
			// BookManagerMainForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Red;
			ClientSize = new Size(1340, 692);
			Controls.Add(dateTimePicker1);
			Controls.Add(btnCreateBook);
			Controls.Add(btnFillBook);
			Controls.Add(dvgBookList);
			Controls.Add(label1);
			Controls.Add(cboCountry);
			Controls.Add(button4);
			Controls.Add(btnShowCountry);
			Controls.Add(btnQuit);
			Controls.Add(btnSayHello);
			Name = "BookManagerMainForm";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)dvgBookList).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnSayHello;
		private Button btnQuit;
		private Button btnShowCountry;
		private Button button4;
		private ComboBox cboCountry;
		private Label label1;
		private DataGridView dvgBookList;
		private Button btnFillBook;
		private Button btnCreateBook;
		private DateTimePicker dateTimePicker1;
	}
}
