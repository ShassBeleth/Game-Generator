using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// パラメータチップリポジトリ
	/// </summary>
	public class ParameterChipRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static ParameterChipRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static ParameterChipRepository GetInstance() {
			if( Instance == null ) {
				Instance = new ParameterChipRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// パラメータチップ一覧
		/// </summary>
		public List<ParameterChip> Rows {
			set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "parameter_chips.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private ParameterChipRepository() {
			if( this.Load<ParameterChips>( this.FilePath ) == null ) {
				this.Write<ParameterChips>( this.FilePath , new ParameterChips() { rows = new List<ParameterChip>() } );
			}
			this.Rows = this.Load<ParameterChips>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<ParameterChips>( this.FilePath , new ParameterChips() { rows = this.Rows } );

	}

}
