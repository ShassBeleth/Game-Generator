using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 装備可能箇所に装備できる装備一覧
	/// </summary>
	[Serializable]
	public class EquipmentsEquipableInEquipablePlaces {

		/// <summary>
		/// 装備可能箇所に装備できる装備一覧
		/// </summary>
		public List<EquipmentEquipableInEquipablePlace> rows = new List<EquipmentEquipableInEquipablePlace>();

	}

	/// <summary>
	/// 装備可能箇所に装備できる装備
	/// </summary>
	[Serializable]
	public class EquipmentEquipableInEquipablePlace {

		/// <summary>
		/// 装備ID
		/// </summary>
		public int equipmentId;
		/// <summary>
		/// 装備ID
		/// </summary>
		[IgnoreDataMember]
		public int EquipmentId { get => this.equipmentId; set => this.equipmentId = value; }

		/// <summary>
		/// 装備可能箇所ID
		/// </summary>
		public int equipablePlaceId;
		/// <summary>
		/// 装備可能箇所ID
		/// </summary>
		[IgnoreDataMember]
		public int EquipablePlaceId { get => this.equipablePlaceId; set => this.equipablePlaceId = value; }

	}

}
