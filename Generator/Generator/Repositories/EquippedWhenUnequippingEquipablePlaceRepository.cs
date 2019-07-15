using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// 装備すると装備できなくなる装備可能箇所リポジトリ
	/// </summary>
	public class EquippedWhenUnequippingEquipablePlaceRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static EquippedWhenUnequippingEquipablePlaceRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static EquippedWhenUnequippingEquipablePlaceRepository GetInstance() {
			if( Instance == null ) {
				Instance = new EquippedWhenUnequippingEquipablePlaceRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// 素体一覧
		/// </summary>
		public List<EquippedWhenUnequippingEquipablePlace> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "equipped_when_unequipping_equipable_places.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private EquippedWhenUnequippingEquipablePlaceRepository() {
			if( this.Load<EquippedWhenUnequippingEquipablePlaces>( this.FilePath ) == null ) {
				this.Write<EquippedWhenUnequippingEquipablePlaces>( this.FilePath , new EquippedWhenUnequippingEquipablePlaces() { rows = new List<EquippedWhenUnequippingEquipablePlace>() } );
			}
			this.Rows = this.Load<EquippedWhenUnequippingEquipablePlaces>( this.FilePath ).rows;
		}
		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<EquippedWhenUnequippingEquipablePlaces>( this.FilePath , new EquippedWhenUnequippingEquipablePlaces() { rows = this.Rows } );

	}

}
