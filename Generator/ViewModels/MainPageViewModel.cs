using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Navigation;
using System.Xml;
using Generator.Repositories;
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

		/// <summary>
		/// 削除
		/// </summary>
		private CompositeDisposable Disposable { get; } = new CompositeDisposable();

		/// <summary>
		/// 画面名
		/// </summary>
		private enum PageName {
			CreatingBody,
			CreatingChapter,
			CreatingEquipablePlace,
			CreatingEquipment,
			CreatingParameterChip,
			CreatingParameter,
			CreatingSave,
			InitialSetting,
			MainPage
		}

		/// <summary>
		/// Navigation Service
		/// </summary>
		private readonly NavigationService navigationService;

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
		/// フォルダパス
		/// </summary>
		private string folderPath = "test";
		/// <summary>
		/// /フォルダパス
		/// </summary>
		public string FolderPath {
			set => this.SetProperty( ref this.folderPath , value );
			get => this.folderPath;
		}

		/// <summary>
		/// 保存コマンド
		/// </summary>
		public ReactiveCommand SaveToInitialSettingCommand { get; } = new ReactiveCommand();

		/// <summary>
		/// フォルダ選択コマンド
		/// </summary>
		public ReactiveCommand SelectFolderCommand { get; } = new ReactiveCommand();

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="navigationService">NavigationService</param>
		public MainPageViewModel( NavigationService navigationService ) {
			this.Log( "コンストラクタ" );

			#region データ取得
			this.EquipablePlaces = EquipablePlaceRepository.GetInstance().Rows;
			this.Parameters = ParameterRepository.GetInstance().Rows;
			#endregion

			this.navigationService = navigationService;
			this.Log( $"Navigation Service取得できた？:{this.navigationService != null}" );
			
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

			this.FolderPath = this.GetDataFolderPath();

			this.SaveToInitialSettingCommand
				.Subscribe( _ => this.SaveToInitialSetting() )
				.AddTo( this.Disposable );

			this.SelectFolderCommand
				.Subscribe( _ => this.SelectFolder() )
				.AddTo( this.Disposable );

			#endregion

		}
		
		private void SetProperty<T>( 
			ref T field , 
			T value , 
			[CallerMemberName]string propertyName = null 
		) {
			field = value;
			this.PropertyChanged?.Invoke( this , new PropertyChangedEventArgs( propertyName ) );
		}

		/// <summary>
		/// 削除
		/// </summary>
		public void Dispose() {
			this.Log( "削除" );
			this.Disposable.Dispose();
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
		private void SaveToEquipablePlace() => EquipablePlaceRepository.GetInstance().Write();

		/// <summary>
		/// 一覧削除
		/// </summary>
		/// <param name="id">装備可能箇所ID</param>
		public void DeleteEquipablePlace( int id )
			=> this.EquipablePlaces.Remove(
				this.EquipablePlaces.FirstOrDefault( row => row.Id == id )
			);

		#endregion

		#region Parameter

		/// <summary>
		/// パラメータの保存
		/// </summary>
		private void SaveToParameter() => ParameterRepository.GetInstance().Write();

		/// <summary>
		/// 一覧削除
		/// </summary>
		/// <param name="id">パラメータID</param>
		public void DeleteParameter( int id )
			=> this.Parameters.Remove(
				this.Parameters.FirstOrDefault( row => row.Id == id )
			);

		#endregion

		#region InitialSetting

		/// <summary>
		/// データフォルダのパス取得
		/// </summary>
		/// <returns>データフォルダのパス</returns>
		private string GetDataFolderPath() {

			// configのパスを取得
			string appConfigPath;
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
				appConfigPath = Path.Combine(
					Path.GetDirectoryName( assembly.Location ) ,
					"Generator.exe.config"
				);
			}
			this.Log( $"App.configのパス:{appConfigPath}" );

			// XmlDocumentからDataフォルダのパスを取得
			XmlDocument doc = new XmlDocument();
			string dataFolderPath = null;
			doc.Load( appConfigPath );
			{
				foreach( XmlNode node in doc[ "configuration" ][ "appSettings" ] ) {
					if( node.Name == "add" ) {
						if( node.Attributes.GetNamedItem( "key" ).Value == "DataFolderPath" ) {
							dataFolderPath = node.Attributes.GetNamedItem( "value" ).Value;
						}
					}
				}
			}
			this.Log( $"Dataフォルダのパス:{dataFolderPath}" );
			return dataFolderPath;
		}

		/// <summary>
		/// 初期設定の保存
		/// </summary>
		private void SaveToInitialSetting() {
			this.Log( "初期設定保存" );

			// configのパスを取得
			string appConfigPath;
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
				appConfigPath = Path.Combine( 
					Path.GetDirectoryName( assembly.Location ) , 
					"Generator.exe.config" 
				);
			}
			this.Log( $"App.configのパス:{appConfigPath}" );

			// XmlDocumentに値を書き込む
			XmlDocument doc = new XmlDocument();
			doc.Load( appConfigPath );
			{

				XmlNode node = doc[ "configuration" ][ "appSettings" ];

				// addノードを新規に追加
				{
					XmlElement addNode = doc.CreateElement( "add" );
					addNode.SetAttribute( "key" , "DataFolderPath" );
					addNode.SetAttribute( "value" , this.FolderPath );
					node.AppendChild( addNode );
				}

			}
			doc.Save( appConfigPath );

			this.Log( "保存成功！" );
		}

		/// <summary>
		/// フォルダ選択
		/// </summary>
		private void SelectFolder() {
			FolderBrowserDialog dialog = new FolderBrowserDialog {
				Description = "フォルダを選択してください"
			};
			if( dialog.ShowDialog() == DialogResult.OK ) {
				this.Log( "ダイアログOK返ってきた" );
				this.FolderPath = dialog.SelectedPath;
				this.Log( $"フォルダパス:{this.FolderPath}" );
			}
			else {
				this.Log( "ダイアログOK以外が返ってきた" );
			}
		}

		#endregion
		
	}

}
