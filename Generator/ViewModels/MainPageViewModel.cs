using System;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows.Controls;
using System.Windows.Navigation;
using Generator.Views.Pages;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace Generator.ViewModels {

	/// <summary>
	/// メインWindowのViewModel
	/// </summary>
	public class MainPageViewModel : INotifyPropertyChanged , IDisposable {

		public event PropertyChangedEventHandler PropertyChanged;

		private CompositeDisposable Disposable { get; } = new CompositeDisposable();

		/// <summary>
		/// 初期設定に遷移するコマンド
		/// </summary>
		public ReactiveCommand TransitionToInitialSetting { get; } = new ReactiveCommand();

		/// <summary>
		/// セーブ作成画面に遷移するコマンド
		/// </summary>
		public ReactiveCommand TransitionToSaveCreating { get; } = new ReactiveCommand();

		/// <summary>
		/// 装備作成画面に遷移するコマンド
		/// </summary>
		public ReactiveCommand TransitionToEquipmentCreating { get; } = new ReactiveCommand();

		/// <summary>
		/// パラメータチップ作成画面に遷移するコマンド
		/// </summary>
		public ReactiveCommand TransitionToParameterChipCreating { get; } = new ReactiveCommand();

		/// <summary>
		/// 素体作成画面に遷移するコマンド
		/// </summary>
		public ReactiveCommand TransitionToBodyCreating { get; } = new ReactiveCommand();

		/// <summary>
		/// チャプター作成画面に遷移するコマンド
		/// </summary>
		public ReactiveCommand TransitionToChapterCreating { get; } = new ReactiveCommand();

		/// <summary>
		/// パラメータ作成画面に遷移するコマンド
		/// </summary>
		public ReactiveCommand TransitionToParameterCreating { get; } = new ReactiveCommand();

		/// <summary>
		/// 装備可能箇所作成画面に遷移するコマンド
		/// </summary>
		public ReactiveCommand TransitionToEquipablePlaceCreating { get; } = new ReactiveCommand();


		/// <summary>
		/// Navigation Service
		/// </summary>
		private NavigationService navigationService;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="navigationService">NavigationService</param>
		public MainPageViewModel( NavigationService navigationService ) {

			this.navigationService = navigationService;

			this.TransitionToBodyCreating
				.Subscribe( _ => this.Transition( PageName.CreatingBody ) )
				.AddTo( this.Disposable );

			this.TransitionToChapterCreating
				.Subscribe( _ => this.Transition( PageName.CreatingChapter ) )
				.AddTo( this.Disposable );

			this.TransitionToEquipablePlaceCreating
				.Subscribe( _ => this.Transition( PageName.CreatingEquipablePlace ) )
				.AddTo( this.Disposable );

			this.TransitionToEquipmentCreating
				.Subscribe( _ => this.Transition( PageName.CreatingEquipment) )
				.AddTo( this.Disposable );

			this.TransitionToParameterChipCreating
				.Subscribe( _ => this.Transition( PageName.CreatingParameterChip ) )
				.AddTo( this.Disposable );
			
			this.TransitionToParameterCreating
				.Subscribe( _ => this.Transition( PageName.CreatingParameter ) )
				.AddTo( this.Disposable );

			this.TransitionToSaveCreating
				.Subscribe( _ => this.Transition( PageName.CreatingSave ) )
				.AddTo( this.Disposable );
			
			this.TransitionToInitialSetting
				.Subscribe( _ => this.Transition( PageName.InitialSetting ) )
				.AddTo( this.Disposable );
			
		}
		
		public void Dispose() => this.Disposable.Dispose();

		/// <summary>
		/// 画面名
		/// </summary>
		private enum PageName {
			CreatingBody ,
			CreatingChapter ,
			CreatingEquipablePlace ,
			CreatingEquipment ,
			CreatingParameterChip ,
			CreatingParameter ,
			CreatingSave ,
			InitialSetting ,
			MainPage
		}

		/// <summary>
		/// 画面遷移
		/// </summary>
		/// <param name="pageName">遷移先画面名</param>
		private void Transition( PageName pageName ) {
			Page page;
			switch( pageName ) {
				case PageName.CreatingBody:
					page = new CreatingBodyPage();
					break;
				case PageName.CreatingChapter:
					page = new CreatingChapterPage();
					break;
				case PageName.CreatingEquipablePlace:
					page = new CreatingEquipablePlacePage();
					break;
				case PageName.CreatingEquipment:
					page = new CreatingEquipmentPage();
					break;
				case PageName.CreatingParameterChip:
					page = new CreatingParameterChipPage();
					break;
				case PageName.CreatingParameter:
					page = new CreatingParameterPage();
					break;
				case PageName.CreatingSave:
					page = new CreatingSavePage();
					break;
				case PageName.InitialSetting:
					page = new InitialSettingPage();
					break;
				case PageName.MainPage:
					page = new MainPage();
					break;
				default:
					return;
			}

			this.navigationService?.Navigate( page );

		}

	}

}
