using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 素体：装備可能箇所一覧
	/// </summary>
	[Serializable]
	public class BodiesEquipablePlaces {

		/// <summary>
		/// 素体：装備可能箇所一覧
		/// </summary>
		public List<BodyEquipablePlace> rows = new List<BodyEquipablePlace>();

	}

	/// <summary>
	/// 素体：装備可能箇所一覧
	/// </summary>
	[Serializable]
	public class BodyEquipablePlace {

		/// <summary>
		/// 素体ID
		/// </summary>
		public int bodyId;
		/// <summary>
		/// 素体ID
		/// </summary>
		[IgnoreDataMember]
		public int BodyId { get => this.bodyId; set => this.bodyId = value; }

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
		/// 表示順
		/// </summary>
		public int displayOrder;
		/// <summary>
		/// 表示順
		/// </summary>
		[IgnoreDataMember]
		public int DisplayOrder { get => this.displayOrder; set => this.displayOrder = value; }

	}

}
