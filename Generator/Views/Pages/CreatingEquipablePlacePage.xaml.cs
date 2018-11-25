using System.Windows;
using System.Windows.Controls;
using Generator.ViewModels;

namespace Generator.Views.Pages {

	/// <summary>
	/// CreatingEquipablePlacePage.xaml の相互作用ロジック
	/// </summary>
	public partial class CreatingEquipablePlacePage : Page {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public CreatingEquipablePlacePage() => this.InitializeComponent();

		/// <summary>
		/// 列削除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Delete( object sender , RoutedEventArgs e ) => ( (MainPageViewModel)this.DataContext ).DeleteEquipablePlace( (int)( (Button)sender ).Tag );

	}

}
