using System;
using System.ComponentModel;
using System.Reactive.Disposables;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace Generator.ViewModels {

	/// <summary>
	/// メインWindowのViewModel
	/// </summary>
	public class MainWindowViewModel : INotifyPropertyChanged , IDisposable {

		public event PropertyChangedEventHandler PropertyChanged;

		private CompositeDisposable Disposable { get; } = new CompositeDisposable();

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
		/// コンストラクタ
		/// </summary>
		public MainWindowViewModel() {
			this.TransitionToSaveCreating
				.Subscribe( _ => Console.WriteLine( "セーブ画面に遷移" ) )
				.AddTo( this.Disposable );
			this.TransitionToEquipmentCreating
				.Subscribe( _ => Console.WriteLine( "装備画面に遷移" ) )
				.AddTo( this.Disposable );
			this.TransitionToParameterChipCreating
				.Subscribe( _ => Console.WriteLine( "パラメータチップ画面に遷移" ) )
				.AddTo( this.Disposable );
			this.TransitionToBodyCreating
				.Subscribe( _ => Console.WriteLine( "素体画面に遷移" ) )
				.AddTo( this.Disposable );
		}

		public void Dispose() => this.Disposable.Dispose();

	}

}
