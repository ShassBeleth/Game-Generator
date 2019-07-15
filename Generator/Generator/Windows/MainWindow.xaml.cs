using System;
using System.Windows;

namespace Generator.Windows {

	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {

		public MainWindow() {
			this.InitializeComponent();

			this.menu.Visibility = Visibility.Visible;
			this.body.Visibility = Visibility.Collapsed;
			this.chapter.Visibility = Visibility.Collapsed;
			this.equipablePlace.Visibility = Visibility.Collapsed;
			this.equipment.Visibility = Visibility.Collapsed;
			this.initialSetting.Visibility = Visibility.Collapsed;
			this.parameter.Visibility = Visibility.Collapsed;
			this.parameterChip.Visibility = Visibility.Collapsed;
			this.save.Visibility = Visibility.Collapsed;

			this.menu.OnClickCreateSaveDataEventHandler = () => {
				this.menu.Visibility = Visibility.Collapsed;
				this.save.Visibility = Visibility.Visible;
			};
			this.menu.OnClickCreateBodyEventHandler = () => {
				this.menu.Visibility = Visibility.Collapsed;
				this.body.Visibility = Visibility.Visible;
			};
			this.menu.OOnClickCreateEquipmentEventHandler = () => {
				this.menu.Visibility = Visibility.Collapsed;
				this.equipment.Visibility = Visibility.Visible;
			};
			this.menu.OnClickParameterChipEventHandler = () => {
				this.menu.Visibility = Visibility.Collapsed;
				this.parameterChip.Visibility = Visibility.Visible;
			};
			this.menu.OnClickCreateParameterEventHandler = () => {
				this.menu.Visibility = Visibility.Collapsed;
				this.parameter.Visibility = Visibility.Visible;
			};
			this.menu.OnClickCreateChapterEventHandler = () => {
				this.menu.Visibility = Visibility.Collapsed;
				this.chapter.Visibility = Visibility.Visible;
			};
			this.menu.OnClickCreateEquipablePlaceEventHandler = () => {
				this.menu.Visibility = Visibility.Collapsed;
				this.equipablePlace.Visibility = Visibility.Visible;
			};
			this.menu.OnClickInitialEventHandler = () => {
				this.menu.Visibility = Visibility.Collapsed;
				this.initialSetting.Visibility = Visibility.Visible;
			};

			this.body.OnClickCloseEventHandler = () => {
				this.body.Visibility = Visibility.Collapsed;
				this.menu.Visibility = Visibility.Visible;
			};
			this.save.OnClickCloseEventHandler = () => {
				this.save.Visibility = Visibility.Collapsed;
				this.menu.Visibility = Visibility.Visible;
			};
			this.chapter.OnClickCloseEventHandler = () => {
				this.chapter.Visibility = Visibility.Collapsed;
				this.menu.Visibility = Visibility.Visible;
			};
			this.equipablePlace.OnClickCloseEventHandler = () => {
				this.equipablePlace.Visibility = Visibility.Collapsed;
				this.menu.Visibility = Visibility.Visible;
			};
			this.equipment.OnClickCloseEventHandler = () => {
				this.equipment.Visibility = Visibility.Collapsed;
				this.menu.Visibility = Visibility.Visible;
			};
			this.initialSetting.OnClickCloseEventHandler = () => {
				this.initialSetting.Visibility = Visibility.Collapsed;
				this.menu.Visibility = Visibility.Visible;
			};
			this.parameter.OnClickCloseEventHandler = () => {
				this.parameter.Visibility = Visibility.Collapsed;
				this.menu.Visibility = Visibility.Visible;
			};
			this.parameterChip.OnClickCloseEventHandler = () => {
				this.parameterChip.Visibility = Visibility.Collapsed;
				this.menu.Visibility = Visibility.Visible;
			};

		}

	}

}
