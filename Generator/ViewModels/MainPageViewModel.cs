using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows.Controls;
using System.Windows.Navigation;
using Generator.Repositories.Models;
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
		/// Navigation Service
		/// </summary>
		private NavigationService navigationService;

		/// <summary>
		/// 戻るコマンド
		/// </summary>
		public ReactiveCommand BackToMainPage { get; } = new ReactiveCommand();

		#region MainPage

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

		#endregion

		#region EquipablePlace

		/// <summary>
		/// 保存コマンド
		/// </summary>
		public ReactiveCommand SaveToEquipablePlaceCommand { get; } = new ReactiveCommand();

		/// <summary>
		/// 装備可能箇所一覧
		/// </summary>
		public List<EquipablePlace> EquipablePlaces { set; get; } = new List<EquipablePlace>();

		#endregion

		#region Parameter

		/// <summary>
		/// 保存コマンド
		/// </summary>
		public ReactiveCommand SaveToParameterCommand { get; } = new ReactiveCommand();

		/// <summary>
		/// 装備可能箇所一覧
		/// </summary>
		public List<Parameter> Parameters { set; get; } = new List<Parameter>();

		#endregion

		#region InitialSetting

		/// <summary>
		/// 保存コマンド
		/// </summary>
		public ReactiveCommand SaveToInitialSettingCommand { get; } = new ReactiveCommand();

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="navigationService">NavigationService</param>
		public MainPageViewModel( NavigationService navigationService ) {

			this.navigationService = navigationService;

			#region 仮

			for( int i = 0 ; i< 100 ; i++ ) {
				this.EquipablePlaces.Add( new EquipablePlace() {
					id = i ,
					name = "装備可能箇所" + i
				} );
			}
			for( int i = 0 ; i < 100 ; i++ ) {
				this.Parameters.Add( new Parameter() {
					id = i ,
					name = "パラメータ" + i
				} );
			}

			#endregion

			this.BackToMainPage
				.Subscribe( _ => this.Transition( PageName.MainPage ) )
				.AddTo( this.Disposable );

			#region MainPage

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

			#endregion
			
			#region EquipablePlace

			this.SaveToEquipablePlaceCommand
				.Subscribe( _ => this.SaveToEquipablePlace() )
				.AddTo( this.Disposable );

			#endregion

			#region Parameter

			this.SaveToParameterCommand
				.Subscribe( _ => this.SaveToParameter() )
				.AddTo( this.Disposable );

			#endregion

			#region InitialSetting

			this.SaveToInitialSettingCommand
				.Subscribe( _ => this.SaveToInitialSetting() )
				.AddTo( this.Disposable );

			#endregion

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

		#region EquipablePlace

		/// <summary>
		/// 装備可能箇所の保存
		/// </summary>
		private void SaveToEquipablePlace() => Console.WriteLine( "装備可能箇所の保存" );

		/// <summary>
		/// 一覧削除
		/// </summary>
		/// <param name="id">装備可能箇所ID</param>
		public void DeleteEquipablePlace( int id ) => Console.WriteLine( $"装備可能箇所列削除:{id}" );

		#endregion

		#region Parameter

		/// <summary>
		/// パラメータの保存
		/// </summary>
		private void SaveToParameter() => Console.WriteLine( "パラメータの保存" );

		/// <summary>
		/// 一覧削除
		/// </summary>
		/// <param name="id">パラメータID</param>
		public void DeleteParameter( int id ) => Console.WriteLine( $"パラメータ列削除:{id}" );

		#endregion
		
		#region InitialSetting

		/// <summary>
		/// 初期設定の保存
		/// </summary>
		private void SaveToInitialSetting() => Console.WriteLine( "初期設定保存" );

		#endregion

	}

}
