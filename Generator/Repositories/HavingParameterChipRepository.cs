using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// 保持しているパラメータチップリポジトリ
	/// </summary>
	public class HavingParameterChipRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static HavingParameterChipRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static HavingParameterChipRepository GetInstance() {
			if( Instance == null ) {
				Instance = new HavingParameterChipRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// 保持しているパラメータチップ一覧
		/// </summary>
		public List<HavingParameterChip> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "having_parameter_chips.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private HavingParameterChipRepository() {
			if( this.Load<HavingParameterChips>( this.FilePath ) == null ) {
				this.Write<HavingParameterChips>( this.FilePath , new HavingParameterChips() { rows = new List<HavingParameterChip>() } );
			}
			this.Rows = this.Load<HavingParameterChips>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<HavingParameterChips>( this.FilePath , new HavingParameterChips() { rows = this.Rows } );

	}

}
