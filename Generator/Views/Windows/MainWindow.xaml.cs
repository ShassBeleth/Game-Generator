using System.Windows.Navigation;
using Generator.ViewModels;
using Generator.Views.Pages;

namespace Generator.Views.Windows {

	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : NavigationWindow {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindow() {
			InitializeComponent();

			this.DataContext = new MainPageViewModel( this.NavigationService );
		}

	}

}
