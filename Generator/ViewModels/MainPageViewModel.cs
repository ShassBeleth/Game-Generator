﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	public class MainPageViewModel : INotifyPropertyChanged, IDisposable {

		#region INotifyPropertyChangedとIDisposableの実装

		public event PropertyChangedEventHandler PropertyChanged;

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
		private CompositeDisposable Disposable { get; } = new CompositeDisposable();

		#endregion

		#region 共通部

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

		/// <summary>
		/// 所持しているデータ
		/// </summary>
		public class HavingData {

			/// <summary>
			/// ID
			/// </summary>
			public int Id { set; get; }

			/// <summary>
			/// 所持しているかどうか
			/// </summary>
			public bool Having { set; get; }

			/// <summary>
			/// 名前
			/// </summary>
			public string Name { set; get; }

			/// <summary>
			/// 所持数
			/// </summary>
			public int Num { set; get; }

		}

		#endregion

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

		#region Body

		/// <summary>
		/// 保存コマンド
		/// </summary>
		public ReactiveCommand SaveToBodyCommand { get; } = new ReactiveCommand();

		/// <summary>
		/// 装備可能箇所
		/// </summary>
		private List<HavingData> equipablePlaceOfBody = new List<HavingData>();

		/// <summary>
		/// 装備可能箇所
		/// </summary>
		public List<HavingData> EquipablePlacesOfBody {
			set => this.SetProperty( ref this.equipablePlaceOfBody , value );
			get => this.equipablePlaceOfBody;
		}

		/// <summary>
		/// 素体効果
		/// </summary>
		private List<HavingData> effectsOfBody = new List<HavingData>();

		/// <summary>
		/// 素体効果
		/// </summary>
		public List<HavingData> EffectsOfBody {
			set => this.SetProperty( ref this.effectsOfBody , value );
			get => this.effectsOfBody;
		}

		#endregion

		#region Chapter

		/// <summary>
		/// 保存コマンド
		/// </summary>
		public ReactiveCommand SaveToChapterCommand { get; } = new ReactiveCommand();

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

		#region Equipment

		/// <summary>
		/// 装備できる装備可能箇所
		/// </summary>
		private List<HavingData> equipmentsEquipableInEquipablePalces = new List<HavingData>();

		/// <summary>
		/// 装備できる装備可能箇所
		/// </summary>
		public List<HavingData> EquipmentsEquipableInEquipablePalces {
			set => this.SetProperty( ref this.equipmentsEquipableInEquipablePalces , value );
			get => this.equipmentsEquipableInEquipablePalces;
		}

		/// <summary>
		/// 装備すると増える装備可能箇所
		/// </summary>
		private List<HavingData> equippedWhenIncreasingEquipablePlaces = new List<HavingData>();

		/// <summary>
		/// 装備すると増える装備可能箇所
		/// </summary>
		public List<HavingData> EquippedWhenIncreasingEquipablePlaces {
			set => this.SetProperty( ref this.equippedWhenIncreasingEquipablePlaces , value );
			get => this.equippedWhenIncreasingEquipablePlaces;
		}

		/// <summary>
		/// 装備すると装備できなくなる装備可能箇所
		/// </summary>
		private List<HavingData> equippedWhenUnequippingEquipablePlaces = new List<HavingData>();

		/// <summary>
		/// 装備すると装備できなくなる装備可能箇所
		/// </summary>
		public List<HavingData> EquippedWhenUnequippingEquipablePlaces {
			set => this.SetProperty( ref this.equippedWhenUnequippingEquipablePlaces , value );
			get => this.equippedWhenUnequippingEquipablePlaces;
		}

		/// <summary>
		/// 装備の効果
		/// </summary>
		private List<HavingData> effectsOfEquipment = new List<HavingData>();

		/// <summary>
		/// 装備の効果
		/// </summary>
		public List<HavingData> EffectsOfEquipment {
			set => this.SetProperty( ref this.effectsOfEquipment , value );
			get => this.effectsOfEquipment;
		}

		/// <summary>
		/// 保存コマンド
		/// </summary>
		public ReactiveCommand SaveToEquipmentCommand { get; } = new ReactiveCommand();

		#endregion

		#region ParameterChip

		/// <summary>
		/// パラメータチップの効果
		/// </summary>
		private List<HavingData> effectsOfParameterChips = new List<HavingData>();

		/// <summary>
		/// パラメータチップの効果
		/// </summary>
		public List<HavingData> EffectsOfParameterChips {
			set => this.SetProperty( ref this.effectsOfParameterChips , value );
			get => this.effectsOfParameterChips;
		}

		/// <summary>
		/// 保存コマンド
		/// </summary>
		public ReactiveCommand SaveToParameterChipCommand { get; } = new ReactiveCommand();

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

		#region Save

		/// <summary>
		/// 保存コマンド
		/// </summary>
		public ReactiveCommand SaveToSaveCommand { get; } = new ReactiveCommand();

		/// <summary>
		/// セーブ1が選択状態かどうか
		/// </summary>
		private bool isSelectedSave1 = true;

		/// <summary>
		/// セーブ1が選択状態かどうか
		/// </summary>
		public bool IsSelectedSave1 {
			set => this.SetProperty( ref this.isSelectedSave1 , value );
			get => this.isSelectedSave1;
		}

		/// <summary>
		/// セーブ2が選択状態かどうか
		/// </summary>
		private bool isSelectedSave2 = false;

		/// <summary>
		/// セーブ2が選択状態かどうか
		/// </summary>
		public bool IsSelectedSave2 {
			set => this.SetProperty( ref this.isSelectedSave2 , value );
			get => this.isSelectedSave2;
		}

		/// <summary>
		/// セーブ3が選択状態かどうか
		/// </summary>
		private bool isSelectedSave3 = false;

		/// <summary>
		/// セーブ3が選択状態かどうか
		/// </summary>
		public bool IsSelectedSave3 {
			set => this.SetProperty( ref this.isSelectedSave3 , value );
			get => this.isSelectedSave3;
		}

		/// <summary>
		/// セーブ4が選択状態かどうか
		/// </summary>
		private bool isSelectedSave4 = false;

		/// <summary>
		/// セーブ4が選択状態かどうか
		/// </summary>
		public bool IsSelectedSave4 {
			set => this.SetProperty( ref this.isSelectedSave4 , value );
			get => this.isSelectedSave4;
		}

		/// <summary>
		/// 水平方向のカメラを反転させるかどうか
		/// </summary>
		private bool isReverseHorizontalCamera = false;

		/// <summary>
		/// 水平方向のカメラを反転させるかどうか
		/// </summary>
		public bool IsReverseHorizontalCamera {
			set => this.SetProperty( ref this.isReverseHorizontalCamera , value );
			get => this.isReverseHorizontalCamera;
		}

		/// 垂直方向のカメラを反転させるかどうか
		/// </summary>
		private bool isReverseVerticalCamera = false;

		/// <summary>
		/// 垂直方向のカメラを反転させるかどうか
		/// </summary>
		public bool IsReverseVerticalCamera {
			set => this.SetProperty( ref this.isReverseVerticalCamera , value );
			get => this.isReverseVerticalCamera;
		}

		/// <summary>
		/// ラジオボタン変更時コマンド
		/// </summary>
		public ReactiveCommand UpdateSelectedSaveIdCommand { get; } = new ReactiveCommand();

		/// <summary>
		/// クリア済みチャプター状況一覧
		/// </summary>
		private List<HavingData> clearedChapters = new List<HavingData>();

		/// <summary>
		/// クリア済みチャプター状況一覧
		/// </summary>
		public List<HavingData> ClearedChapters {
			set => this.SetProperty( ref this.clearedChapters , value );
			get => this.clearedChapters;
		}

		/// <summary>
		/// 所持している素体一覧
		/// </summary>
		private List<HavingData> havingBodies = new List<HavingData>();

		/// <summary>
		/// 所持している素体一覧
		/// </summary>
		public List<HavingData> HavingBodies {
			set => this.SetProperty( ref this.havingBodies , value );
			get => this.havingBodies;
		}

		/// <summary>
		/// 所持しているパラメータチップ一覧
		/// </summary>
		private List<HavingData> havingParameterChips = new List<HavingData>();

		/// <summary>
		/// 所持しているパラメータチップ一覧
		/// </summary>
		public List<HavingData> HavingParameterChips {
			set => this.SetProperty( ref this.havingParameterChips , value );
			get => this.havingParameterChips;
		}

		/// <summary>
		/// 所持している装備一覧
		/// </summary>
		private List<HavingData> havingEquipments = new List<HavingData>();

		/// <summary>
		/// 所持している装備一覧
		/// </summary>
		public List<HavingData> HavingEquipments {
			set => this.SetProperty( ref this.havingEquipments , value );
			get => this.havingEquipments;
		}

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

			#region 共通部

			this.navigationService = navigationService;
			this.Log( $"Navigation Service取得できた？:{this.navigationService != null}" );

			this.BackToMainPage
				.Subscribe( _ => this.Transition( PageName.MainPage ) )
				.AddTo( this.Disposable );

			#endregion

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
				.Subscribe( _ => this.Transition( PageName.CreatingEquipment ) )
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

			EquipablePlaceRepository.GetInstance().Rows.ForEach( row => {
				this.EquipablePlacesOfBody.Add( new HavingData() {
					Having = false ,
					Id = row.Id ,
					Name = row.Name
				} );
				this.EquipmentsEquipableInEquipablePalces.Add( new HavingData() {
					Id = row.Id ,
					Having = row.Id % 2 == 0 ,
					Name = row.Name
				} );
				this.EquippedWhenIncreasingEquipablePlaces.Add( new HavingData() {
					Id = row.Id ,
					Having = row.Id % 2 == 0 ,
					Name = row.Name
				} );
				this.EquippedWhenUnequippingEquipablePlaces.Add( new HavingData() {
					Id = row.Id ,
					Having = row.Id % 2 == 0 ,
					Name = row.Name
				} );
			} );

			ParameterRepository.GetInstance().Rows.ForEach( row => {
				this.EffectsOfBody.Add( new HavingData() {
					Id = row.Id ,
					Name = row.Name ,
					Having = false ,
					Num = 0
				} );
				this.EffectsOfEquipment.Add( new HavingData() {
					Id = row.Id ,
					Having = row.Id % 2 == 0 ,
					Name = row.Name ,
					Num = row.Id
				} );
				this.EffectsOfParameterChips.Add( new HavingData() {
					Id = row.Id ,
					Having = row.Id % 2 == 0 ,
					Name = row.Name ,
					Num = row.Id
				} );
			} );

			this.EquipablePlaces = EquipablePlaceRepository.GetInstance().Rows;

			this.Parameters = ParameterRepository.GetInstance().Rows;

			#region Body

			this.SaveToBodyCommand
				.Subscribe( _ => this.SaveToBody() )
				.AddTo( this.Disposable );

			#endregion

			#region Chapter

			this.SaveToChapterCommand
				.Subscribe( _ => this.SaveToChapter() )
				.AddTo( this.Disposable );

			#endregion

			#region EquipablePlace

			this.SaveToEquipablePlaceCommand
				.Subscribe( _ => this.SaveToEquipablePlace() )
				.AddTo( this.Disposable );

			#endregion

			#region Equipment

			this.SaveToEquipmentCommand
				.Subscribe( _ => this.SaveToEquipment() )
				.AddTo( this.Disposable );

			#endregion

			#region ParameterChip

			this.SaveToParameterChipCommand
				.Subscribe( _ => this.SaveToParameterChip() )
				.AddTo( this.Disposable );

			#endregion

			#region Parameter

			this.SaveToParameterCommand
				.Subscribe( _ => this.SaveToParameter() )
				.AddTo( this.Disposable );

			#endregion

			#region Save

			this.SelectSave( 0 );

			this.UpdateSelectedSaveIdCommand
				.Subscribe( _ => this.SelectSave(
					this.IsSelectedSave1 ? 0 :
					this.IsSelectedSave2 ? 1 :
					this.IsSelectedSave3 ? 2 :
					3
				) )
				.AddTo( this.Disposable );

			this.SaveToSaveCommand
				.Subscribe( _ => this.SaveToSave() )
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

		#region 共通部

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

		#endregion

		#region Body

		/// <summary>
		/// 素体の保存
		/// </summary>
		private void SaveToBody() {
			BodyRepository.GetInstance().Write();
			BodyFreeSquareRepository.GetInstance().Write();
			BodyEffectRepository.GetInstance().Write();
			BodyEquipablePlaceRepository.GetInstance().Write();
		}

		/// <summary>
		/// 一覧削除
		/// </summary>
		/// <param name="id">素体ID</param>
		public void DeleteBody( int id ) => this.Log( "未実装" );

		#endregion

		#region Chapter

		/// <summary>
		/// チャプターの保存
		/// </summary>
		private void SaveToChapter() => ChapterRepository.GetInstance().Write();

		/// <summary>
		/// 一覧削除
		/// </summary>
		/// <param name="id">チャプターID</param>
		public void DeleteChapter( int id ) => this.Log( "未実装" );

		#endregion

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

		#region Equipment

		/// <summary>
		/// 装備の保存
		/// </summary>
		private void SaveToEquipment() {
			EquipmentRepository.GetInstance().Write();
			EquippedWhenIncreasingEquipablePlaceRepository.GetInstance().Write();
			EquippedWhenUnequippingEquipablePlaceRepository.GetInstance().Write();
			EquipmentEquipableInEquipablePlaceRepository.GetInstance().Write();
			EquipmentEffectRepository.GetInstance().Write();
			DesignatedPlaceToEquipmentByEffectRepository.GetInstance().Write();
			EquipmentFreeSquareRepository.GetInstance().Write();
		}

		/// <summary>
		/// 一覧削除
		/// </summary>
		/// <param name="id">装備ID</param>
		public void DeleteEquipment( int id ) => this.Log( "未実装" );

		#endregion

		#region ParameterChip

		/// <summary>
		/// パラメータチップの保存
		/// </summary>
		private void SaveToParameterChip() {

			ParameterChipRepository.GetInstance().Write();
			ParameterChipEffectRepository.GetInstance().Write();
			ParameterChipSquareRepository.GetInstance().Write();

		}

		/// <summary>
		/// 一覧削除
		/// </summary>
		/// <param name="id">パラメータチップID</param>
		public void DeleteParameterChip( int id ) => this.Log( "未実装" );

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

		#region Save

		/// <summary>
		/// セーブデータ選択
		/// </summary>
		/// <param name="saveId">セーブデータID</param>
		private void SelectSave( int saveId ) {

			this.Log( $"Save Id is {saveId}." );

			Save save = SaveRepository.GetInstance().Rows
				.FirstOrDefault( row => row.Id == saveId );
			this.IsReverseHorizontalCamera = save.IsReverseHorizontalCamera;
			this.IsReverseVerticalCamera = save.IsReverseVerticalCamera;
			;

			#region クリア済みチャプター一覧
			{
				// クリア済みのチャプターのIDを取得
				IEnumerable<int> clearedChapterIds = ChapterClearStatusRepository.GetInstance().Rows
					.Where( row => row.SaveId == saveId )
					.Select( row => row.ChapterId );

				List<HavingData> list = new List<HavingData>();
				ChapterRepository.GetInstance().Rows.ForEach( row => {
					list.Add( new HavingData() {
						Id = row.Id ,
						Name = row.Name ,
						Having = clearedChapterIds.FirstOrDefault( id => id == row.id ) != 0 ,
						Num = 0 ,
					} );
				} );
				this.ClearedChapters = list;
			}
			#endregion

			#region 所持している素体一覧
			{

				// 所持している素体のIDを取得
				IEnumerable<int> havingBodyIds = HavingBodyRepository.GetInstance().Rows
					.Where( row => row.SaveId == saveId )
					.Select( row => row.BodyId );

				List<HavingData> list = new List<HavingData>();
				BodyRepository.GetInstance().Rows.ForEach( row => {
					list.Add( new HavingData() {
						Id = row.Id ,
						Name = row.Name ,
						Having = havingBodyIds.FirstOrDefault( id => id == row.id ) != 0 ,
						Num = 0 ,
					} );
				} );
				this.HavingBodies = list;

			}
			#endregion

			#region 所持している装備一覧
			{

				// 所持している装備のIDを取得
				IEnumerable<int> havingEquipmentIds = HavingEquipmentRepository.GetInstance().Rows
					.Where( row => row.SaveId == saveId )
					.Select( row => row.EquipmentId );

				List<HavingData> list = new List<HavingData>();
				EquipmentRepository.GetInstance().Rows.ForEach( row => {
					list.Add( new HavingData() {
						Id = row.Id ,
						Name = row.Name ,
						Having = havingEquipmentIds.FirstOrDefault( id => id == row.id ) != 0 ,
						Num = 0 ,
					} );
				} );
				this.HavingEquipments = list;

			}
			#endregion

			#region 所持しているパラメータチップ一覧
			{

				// 所持しているパラメータチップのIDを取得
				IEnumerable<int> havingParameterChipIds = HavingParameterChipRepository.GetInstance().Rows
					.Where( row => row.SaveId == saveId )
					.Select( row => row.ParameterChipId );
				
				List<HavingData> list = new List<HavingData>();
				ParameterChipRepository.GetInstance().Rows.ForEach( row => {
					list.Add( new HavingData() {
						Id = row.Id ,
						Name = row.Name ,
						Having = havingParameterChipIds.FirstOrDefault( id => id == row.id ) != 0 ,
						Num = 0 ,
					} );
				} );
				this.HavingParameterChips = list;
			}
			#endregion

		}

		/// <summary>
		/// セーブの保存
		/// </summary>
		private void SaveToSave() {

			int saveId = 
				this.IsSelectedSave1 ? 0 :
				this.IsSelectedSave2 ? 1 :
				this.IsSelectedSave3 ? 2 :
				3;

			#region オプション
			Save save = SaveRepository.GetInstance().Rows
				.FirstOrDefault( row => row.Id == saveId );
			save.IsReverseHorizontalCamera = this.IsReverseHorizontalCamera;
			save.IsReverseVerticalCamera = this.IsReverseVerticalCamera;
			SaveRepository.GetInstance().Write();
			#endregion

			#region 素体
			{
				// 選択中のセーブデータ以外を保持しておく
				IEnumerable<HavingBody> another = HavingBodyRepository.GetInstance().Rows
					.Where( row => row.SaveId != saveId );
				// 画面上の一覧から新規にリストを作成する
				IEnumerable<HavingBody> newList = this.HavingBodies
					.Where( row => row.Having )
					.Select( row => new HavingBody() {
						SaveId = saveId ,
						BodyId = row.Id
					} );
				HavingBodyRepository.GetInstance().Rows.Clear();
				HavingBodyRepository.GetInstance().Rows.AddRange( another.Union( newList ).ToList() );
				HavingBodyRepository.GetInstance().Write();
			}
			#endregion

			#region 装備
			{
				// 選択中のセーブデータ以外を保持しておく
				IEnumerable<HavingEquipment> another = HavingEquipmentRepository.GetInstance().Rows
					.Where( row => row.SaveId != saveId );
				// 画面上の一覧から新規にリストを作成する
				IEnumerable<HavingEquipment> newList = this.HavingEquipments
					.Where( row => row.Having )
					.Select( row => new HavingEquipment() {
						SaveId = saveId ,
						EquipmentId = row.Id
					} );
				HavingEquipmentRepository.GetInstance().Rows.Clear();
				HavingEquipmentRepository.GetInstance().Rows.AddRange( another.Union( newList ).ToList() );
				HavingEquipmentRepository.GetInstance().Write();
			}
			#endregion

			#region チャプター
			{
				// 選択中のセーブデータ以外を保持しておく
				IEnumerable<ChapterClearStatus> another = ChapterClearStatusRepository.GetInstance().Rows
					.Where( row => row.SaveId != saveId );
				// 画面上の一覧から新規にリストを作成する
				IEnumerable<ChapterClearStatus> newList = this.ClearedChapters
					.Where( row => row.Having )
					.Select( row => new ChapterClearStatus() {
						SaveId = saveId ,
						ChapterId = row.Id
					} );
				ChapterClearStatusRepository.GetInstance().Rows.Clear();
				ChapterClearStatusRepository.GetInstance().Rows.AddRange( another.Union( newList ).ToList() );
				ChapterClearStatusRepository.GetInstance().Write();
			}
			#endregion

		}

		/// <summary>
		/// 一覧削除
		/// </summary>
		/// <param name="id">セーブID</param>
		public void DeleteSave( int id ) => this.Log( "未実装" );

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
