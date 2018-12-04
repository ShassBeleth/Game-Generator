using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 装備の効果一覧
	/// </summary>
	[Serializable]
	public class EquipmentEffects {

		/// <summary>
		/// 装備の効果一覧
		/// </summary>
		public List<EquipmentEffect> rows = new List<EquipmentEffect>();

	}

	/// <summary>
	/// 装備の効果
	/// </summary>
	[Serializable]
	public class EquipmentEffect {

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
