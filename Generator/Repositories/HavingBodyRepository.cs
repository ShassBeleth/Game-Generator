using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// 保持している素体リポジトリ
	/// </summary>
	public class HavingBodyRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static HavingBodyRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static HavingBodyRepository GetInstance() {
			if( Instance == null ) {
				Instance = new HavingBodyRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// 保持している素体一覧
		/// </summary>
		public List<HavingBody> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "having_bodies.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private HavingBodyRepository() {
			if( this.Load<HavingBodies>( this.FilePath ) == null ) {
				this.Write<HavingBodies>( this.FilePath , new HavingBodies() { rows = new List<HavingBody>() } );
			}
			this.Rows = this.Load<HavingBodies>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<HavingBodies>( this.FilePath , new HavingBodies() { rows = this.Rows } );

	}

}
