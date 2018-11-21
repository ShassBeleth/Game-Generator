using System.Windows;
using Generator.ViewModels;

namespace Generator.Views {

	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindow() {
			InitializeComponent();
			this.DataContext = new MainWindowViewModel();
		}

	}

}
