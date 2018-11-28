using System.Windows;
using System.Windows.Controls;
using Generator.ViewModels;

namespace Generator.Views.Pages {

	/// <summary>
	/// CreatingChapterPage.xaml の相互作用ロジック
	/// </summary>
	public partial class CreatingChapterPage : Page {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public CreatingChapterPage() => this.InitializeComponent();

		/// <summary>
		/// 列削除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Delete( object sender , RoutedEventArgs e ) => ( (MainPageViewModel)this.DataContext ).DeleteChapter( (int)( (Button)sender ).Tag );
		
	}

}
