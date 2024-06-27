using Repositories;

namespace BookManagerGUIForms
{
	public partial class BookManagerMainForm : Form
	{
		public BookManagerMainForm()
		{
			InitializeComponent();
		}

		private void btnSayHello_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Xin chào! Welcome to winforms - a kind of desktop app", "Xin chào", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			DialogResult = MessageBox.Show("Do you really want to quit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (DialogResult == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			List<Country> arr = new List<Country>();
			arr.Add(new Country() { CountryCode = 84, Name = "Việt Nam" });
			arr.Add(new Country() { CountryCode = 1, Name = "USA" });
			arr.Add(new Country() { CountryCode = 44, Name = "United Kingdom" });

			cboCountry.DataSource = arr;
			cboCountry.DisplayMember = "Name";
			cboCountry.ValueMember = "CountryCode"; //chọn tên nhưng lấy mã 
		}

		private void btnShowCountry_Click(object sender, EventArgs e)
		{
			MessageBox.Show("You have selected the country code: " + cboCountry.SelectedValue);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnLoadBook_Click(object sender, EventArgs e)
		{
			//đổ data vào lưới dgvBookList - object đc render theo style table
			BookManagementDbContext context = new BookManagementDbContext();
			dvgBookList.DataSource = context.Books.ToList();

		}

		private void btnCreateBook_Click(object sender, EventArgs e)
		{
			BookDetailForm detail = new BookDetailForm(); //new ms tạo, nhưng chx render
			detail.Text = "Tạo mới | Cập nhật sách";
			detail.ShowDialog();//render, đẩy ra màn hình xem
		}
	}
}
