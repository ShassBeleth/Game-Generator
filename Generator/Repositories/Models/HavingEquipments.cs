using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 保持している装備一覧
	/// </summary>
	[Serializable]
	public class HavingEquipments {

		/// <summary>
		/// 保持している装備一覧
		/// </summary>
		public List<HavingEquipment> rows = new List<HavingEquipment>();

	}

	/// <summary>
	/// 保持している装備
	/// </summary>
	[Serializable]
	public class HavingEquipment {

		/// <summary>
		/// セーブID
		/// </summary>
		public int saveId;
		/// <summary>
		/// セーブID
		/// </summary>
		[IgnoreDataMember]
		public int SaveId { get => this.saveId; set => this.saveId = value; }

		/// <summary>
		/// 装備ID
		/// </summary>
		public int equipmentId;
		/// <summary>
		/// 装備ID
		/// </summary>
		[IgnoreDataMember]
		public int EquipmentId { get => this.equipmentId; set => this.equipmentId = value; }

	}

}
