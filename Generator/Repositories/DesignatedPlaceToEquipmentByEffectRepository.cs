using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// 指定箇所への装備による効果リポジトリ
	/// </summary>
	public class DesignatedPlaceToEquipmentByEffectRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static DesignatedPlaceToEquipmentByEffectRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static DesignatedPlaceToEquipmentByEffectRepository GetInstance() {
			if( Instance == null ) {
				Instance = new DesignatedPlaceToEquipmentByEffectRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// 素体一覧
		/// </summary>
		public List<DesignatedPlaceToEquipmentByEffect> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "designated_place_to_equipment_by_effects.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private DesignatedPlaceToEquipmentByEffectRepository() {
			if( this.Load<DesignatedPlaceToEquipmentByEffects>( this.FilePath ) == null ) {
				this.Write<DesignatedPlaceToEquipmentByEffects>( this.FilePath , new DesignatedPlaceToEquipmentByEffects() { rows = new List<DesignatedPlaceToEquipmentByEffect>() } );
			}
			this.Rows = this.Load<DesignatedPlaceToEquipmentByEffects>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<DesignatedPlaceToEquipmentByEffects>( this.FilePath , new DesignatedPlaceToEquipmentByEffects() { rows = this.Rows } );

	}

}
