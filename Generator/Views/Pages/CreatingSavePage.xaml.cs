using System.Windows;
using System.Windows.Controls;
using Generator.ViewModels;

namespace Generator.Views.Pages {

	/// <summary>
	/// CreatingSavePage.xaml の相互作用ロジック
	/// </summary>
	public partial class CreatingSavePage : Page {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public CreatingSavePage() => this.InitializeComponent();

		/// <summary>
		/// 列削除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Delete( object sender , RoutedEventArgs e ) => ( (MainPageViewModel)this.DataContext ).DeleteSave( (int)( (Button)sender ).Tag );

	}

}
