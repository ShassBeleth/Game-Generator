using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 装備することで増える空きマス一覧
	/// </summary>
	[Serializable]
	public class EquipmentFreeSquares {

		/// <summary>
		/// 装備することで増える空きマス一覧
		/// </summary>
		public List<EquipmentFreeSquare> rows = new List<EquipmentFreeSquare>();

	}

	/// <summary>
	/// 装備することで増える空きマス
	/// </summary>
	[Serializable]
	public class EquipmentFreeSquare {

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
		/// X座標
		/// </summary>
		public int x;
		/// <summary>
		/// X座標
		/// </summary>
		[IgnoreDataMember]
		public int X { get => this.x; set => this.x = value; }

		/// <summary>
		/// Y座標
		/// </summary>
		public int y;
		/// <summary>
		/// Y座標
		/// </summary>
		[IgnoreDataMember]
		public int Y { get => this.y; set => this.y = value; }

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
