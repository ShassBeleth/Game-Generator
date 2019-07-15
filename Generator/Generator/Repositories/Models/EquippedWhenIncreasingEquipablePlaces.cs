using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 装備すると増える装備可能箇所一覧
	/// </summary>
	[Serializable]
	public class EquippedWhenIncreasingEquipablePlaces {

		/// <summary>
		/// 装備すると増える装備可能箇所一覧
		/// </summary>
		public List<EquippedWhenIncreasingEquipablePlace> rows = new List<EquippedWhenIncreasingEquipablePlace>();

	}

	/// <summary>
	/// 装備すると増える装備可能箇所
	/// </summary>
	[Serializable]
	public class EquippedWhenIncreasingEquipablePlace {

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
