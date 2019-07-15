using System;
using System.Windows;
using System.Windows.Controls;

namespace Generator.UserControls {

	/// <summary>
	/// Menu.xaml の相互作用ロジック
	/// </summary>
	public partial class Menu : UserControl {

		public Menu() => this.InitializeComponent();

		public Action OnClickCreateSaveDataEventHandler;
		private void OnClickCreateSaveData(object sender, RoutedEventArgs e)
			=> this.OnClickCreateSaveDataEventHandler?.Invoke();

		public Action OnClickCreateBodyEventHandler;
		private void OnClickCreateBody(object sender, RoutedEventArgs e)
			=> this.OnClickCreateBodyEventHandler?.Invoke();

		public Action OOnClickCreateEquipmentEventHandler;
		private void OnClickCreateEquipment(object sender, RoutedEventArgs e)
			=> this.OOnClickCreateEquipmentEventHandler?.Invoke();

		public Action OnClickParameterChipEventHandler;
		private void OnClickParameterChip(object sender, RoutedEventArgs e)
			=> this.OnClickParameterChipEventHandler?.Invoke();

		public Action OnClickCreateParameterEventHandler;
		private void OnClickCreateParameter(object sender, RoutedEventArgs e)
			=> this.OnClickCreateParameterEventHandler?.Invoke();

		public Action OnClickCreateChapterEventHandler;
		private void OnClickCreateChapter(object sender, RoutedEventArgs e)
			=> this.OnClickCreateChapterEventHandler?.Invoke();

		public Action OnClickCreateEquipablePlaceEventHandler;
		private void OnClickCreateEquipablePlace(object sender, RoutedEventArgs e)
			=> this.OnClickCreateEquipablePlaceEventHandler?.Invoke();

		public Action OnClickInitialEventHandler;
		private void OnClickInitialSetting(object sender, RoutedEventArgs e)
			=> this.OnClickInitialEventHandler?.Invoke();

	}

}