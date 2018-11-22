﻿using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// 装備リポジトリ
	/// </summary>
	public class EquipmentRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static EquipmentRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static EquipmentRepository GetInstance() {
			if( Instance == null ) {
				Instance = new EquipmentRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// 素体一覧
		/// </summary>
		public List<Equipment> Rows {
			private set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "equipments.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private EquipmentRepository() => this.Rows = this.Load<Equipments>( this.FilePath ).rows;

	}
}
