using System.Windows;
using System.Windows.Controls;
using Generator.ViewModels;

namespace Generator.Views.Pages {

	/// <summary>
	/// CreatingParameterPage.xaml の相互作用ロジック
	/// </summary>
	public partial class CreatingParameterPage : Page {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public CreatingParameterPage() => this.InitializeComponent();

		/// <summary>
		/// 列削除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Delete( object sender , RoutedEventArgs e ) => ( (MainPageViewModel)this.DataContext ).DeleteParameter( (int)( (Button)sender ).Tag );

	}

}
