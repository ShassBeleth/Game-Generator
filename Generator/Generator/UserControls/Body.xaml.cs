using System;
using System.Windows.Controls;

namespace Generator.UserControls {

	/// <summary>
	/// Body.xaml の相互作用ロジック
	/// </summary>
	public partial class Body : UserControl {


		public Body() => this.InitializeComponent();

		#region 閉じる
		public Action OnClickCloseEventHandler;
		private void OnClickBack(object sender, System.Windows.RoutedEventArgs e)
			=> this.OnClickCloseEventHandler?.Invoke();
		#endregion

	}

}
