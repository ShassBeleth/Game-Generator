using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// 装備の効果リポジトリ
	/// </summary>
	public class EquipmentEffectRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static EquipmentEffectRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static EquipmentEffectRepository GetInstance() {
			if( Instance == null ) {
				Instance = new EquipmentEffectRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// 素体一覧
		/// </summary>
		public List<EquipmentEffect> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "equipment_effects.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private EquipmentEffectRepository() {
			if( this.Load<EquipmentEffects>( this.FilePath ) == null ) {
				this.Write<EquipmentEffects>( this.FilePath , new EquipmentEffects() { rows = new List<EquipmentEffect>() } );
			}
			this.Rows = this.Load<EquipmentEffects>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<EquipmentEffects>( this.FilePath , new EquipmentEffects() { rows = this.Rows } );

	}

}
