using Repositories;

namespace BookManagerGUIForms
{
	public partial class btnSayHello : Form
	{
		public btnSayHello()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void btnButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Xin chào! Welcome to Win Forms - a kind of desktop app", "Xin chào", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			DialogResult = MessageBox.Show("Do you really want to quit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (DialogResult == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			List<Country> arr = new List<Country>();
			arr.Add(new Country() { CountryCode = 84, Name = "VietNam" });
			arr.Add(new Country() { CountryCode = 1, Name = "USA" });
			arr.Add(new Country() { CountryCode = 44, Name = "United Kingdom" });

			cboCountry.DataSource = arr;
			cboCountry.DisplayMember = "Name";  //Show cột name, ẩn cột code
			cboCountry.ValueMember = "CountryCode"; //Chọn tên quốc gia, nhưng cái ta cần là mã quốc gia

		}

		private void btnShowCountry_Click(object sender, EventArgs e)
		{
			MessageBox.Show("You have selected the country code: " + cboCountry.SelectedValue);
		}

		private void btnLoadBooks_Click(object sender, EventArgs e)
		{
			//Đổ table Book  vào lưới dgvBookList - Object được render tho style table
			BookManagementDbContext context = new();
			//dgvBookList DataSource = context.Books.ToList();

		}

		private void btnCreate_Click(object sender, EventArgs e)
		{

		}

		private void dgvBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnCreateBook_Click(object sender, EventArgs e)
		{
			BookDetailForm detail = new();  //New mới tạo nhưng chưa render
			detail.Text = "Tạo mới | Cập nhất list";
			detail.ShowDialog();
		}

	}
}
