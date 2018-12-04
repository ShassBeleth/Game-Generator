using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// パラメータチップの効果リポジトリ
	/// </summary>
	public class ParameterChipEffectRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static ParameterChipEffectRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static ParameterChipEffectRepository GetInstance() {
			if( Instance == null ) {
				Instance = new ParameterChipEffectRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// パラメータチップの効果一覧
		/// </summary>
		public List<ParameterChipEffect> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "parameter_chip_effects.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private ParameterChipEffectRepository() {
			if( this.Load<ParameterChipEffects>( this.FilePath ) == null ) {
				this.Write<ParameterChipEffects>( this.FilePath , new ParameterChipEffects() { rows = new List<ParameterChipEffect>() } );
			}
			this.Rows = this.Load<ParameterChipEffects>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<ParameterChipEffects>( this.FilePath , new ParameterChipEffects() { rows = this.Rows } );

	}

}
