using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// 保持している装備リポジトリ
	/// </summary>
	public class HavingEquipmentRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static HavingEquipmentRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static HavingEquipmentRepository GetInstance() {
			if( Instance == null ) {
				Instance = new HavingEquipmentRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// 保持している装備一覧
		/// </summary>
		public List<HavingEquipment> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "having_equipments.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private HavingEquipmentRepository() {
			if( this.Load<HavingEquipments>( this.FilePath ) == null ) {
				this.Write<HavingEquipments>( this.FilePath , new HavingEquipments() { rows = new List<HavingEquipment>() } );
			}
			this.Rows = this.Load<HavingEquipments>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<HavingEquipments>( this.FilePath , new HavingEquipments() { rows = this.Rows } );

	}

}
