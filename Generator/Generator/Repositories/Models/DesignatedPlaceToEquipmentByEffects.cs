using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 指定箇所への装備による効果一覧
	/// </summary>
	[Serializable]
	public class DesignatedPlaceToEquipmentByEffects {

		/// <summary>
		/// 指定箇所への装備による効果一覧
		/// </summary>
		public List<DesignatedPlaceToEquipmentByEffect> rows = new List<DesignatedPlaceToEquipmentByEffect>();

	}

	/// <summary>
	/// 指定箇所への装備による効果
	/// </summary>
	[Serializable]
	public class DesignatedPlaceToEquipmentByEffect {

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

		/// <summary>
		/// パラメータID
		/// </summary>
		public int parameterId;
		/// <summary>
		/// パラメータID
		/// </summary>
		[IgnoreDataMember]
		public int ParameterId { get => this.parameterId; set => this.parameterId = value; }

		/// <summary>
		/// 増減値
		/// </summary>
		public int num;
		/// <summary>
		/// 増減値
		/// </summary>
		[IgnoreDataMember]
		public int Num { get => this.num; set => this.num = value; }

	}

}
