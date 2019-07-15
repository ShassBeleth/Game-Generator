using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// チャプターのクリア状況リポジトリ
	/// </summary>
	public class ChapterClearStatusRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static ChapterClearStatusRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static ChapterClearStatusRepository GetInstance() {
			if( Instance == null ) {
				Instance = new ChapterClearStatusRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// 素体一覧
		/// </summary>
		public List<ChapterClearStatus> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "chapter_clear_statuses.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private ChapterClearStatusRepository() {
			if( this.Load<ChapterClearStatuses>( this.FilePath ) == null ) {
				this.Write<ChapterClearStatuses>( this.FilePath , new ChapterClearStatuses() { rows = new List<ChapterClearStatus>() } );
			}
			this.Rows = this.Load<ChapterClearStatuses>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<ChapterClearStatuses>( this.FilePath , new ChapterClearStatuses() { rows = this.Rows } );

	}

}
