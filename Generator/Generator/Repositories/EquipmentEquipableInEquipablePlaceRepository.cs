using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// 装備可能箇所に装備できる装備リポジトリ
	/// </summary>
	public class EquipmentEquipableInEquipablePlaceRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static EquipmentEquipableInEquipablePlaceRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static EquipmentEquipableInEquipablePlaceRepository GetInstance() {
			if( Instance == null ) {
				Instance = new EquipmentEquipableInEquipablePlaceRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// 素体一覧
		/// </summary>
		public List<EquipmentEquipableInEquipablePlace> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "equipments_equipable_in_equipable_places.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private EquipmentEquipableInEquipablePlaceRepository() {
			if( this.Load<EquipmentsEquipableInEquipablePlaces>( this.FilePath ) == null ) {
				this.Write<EquipmentsEquipableInEquipablePlaces>( this.FilePath , new EquipmentsEquipableInEquipablePlaces() { rows = new List<EquipmentEquipableInEquipablePlace>() } );
			}
			this.Rows = this.Load<EquipmentsEquipableInEquipablePlaces>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<EquipmentsEquipableInEquipablePlaces>( this.FilePath , new EquipmentsEquipableInEquipablePlaces() { rows = this.Rows } );

	}

}
