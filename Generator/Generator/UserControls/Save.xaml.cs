using System;
using System.Windows.Controls;

namespace Generator.UserControls {

	/// <summary>
	/// Save.xaml の相互作用ロジック
	/// </summary>
	public partial class Save : UserControl {

		public Save() => this.InitializeComponent();

		#region 閉じる
		public Action OnClickCloseEventHandler;
		private void OnClickBack(object sender, System.Windows.RoutedEventArgs e)
			=> this.OnClickCloseEventHandler?.Invoke();
		#endregion

	}

}
