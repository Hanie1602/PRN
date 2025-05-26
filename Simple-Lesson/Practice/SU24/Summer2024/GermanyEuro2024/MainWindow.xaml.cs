using GermanyEuro2024_BLL.Services;
using GermanyEuro2024_DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GermanyEuro2024
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Uefaaccount Uefaaccount { get; set; }
		private FootballPlayerService _service = new();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadGird();
			if(Uefaaccount.Role == 2)
			{
				CreateButton.IsEnabled = false;
				UpdateButton.IsEnabled = false;
				DeleteButton.IsEnabled = false;
			}
		}

		private void LoadGird()
		{
			ItemDataGrid.ItemsSource = null;
			ItemDataGrid.ItemsSource = _service.GetAllFootballPlayer();
		}
		
		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			List<FootballPlayer> result = null;
			if (!string.IsNullOrEmpty(AchievementsTextBox.Text))
			{
				string achivement = AchievementsTextBox.Text.ToLower();
				result = _service.SearchByAchivement(achivement);
			}
			if (!string.IsNullOrEmpty(PlayeNameTextBoxx.Text))
			{
				string name = PlayeNameTextBoxx.Text.ToLower();
				result = _service.SearchByPlayerNam(name);
			}

			ItemDataGrid.ItemsSource = null;
			ItemDataGrid.ItemsSource = result;
		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void QuitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}