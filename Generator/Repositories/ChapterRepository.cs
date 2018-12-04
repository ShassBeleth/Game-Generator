using Generator.Repositories.Models;
using System;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// チャプターリポジトリ
	/// </summary>
	public class ChapterRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static ChapterRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static ChapterRepository GetInstance() {
			if( Instance == null ) {
				Instance = new ChapterRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// 素体一覧
		/// </summary>
		public List<Chapter> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "chapters.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private ChapterRepository() {
			if( this.Load<Chapters>( this.FilePath ) == null ) {
				this.Write<Chapters>( this.FilePath , new Chapters() { rows = new List<Chapter>() } );
			}
			this.Rows = this.Load<Chapters>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<Chapters>( this.FilePath , new Chapters() { rows = this.Rows } );

	}

}
