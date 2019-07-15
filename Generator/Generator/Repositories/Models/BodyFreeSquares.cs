using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 素体の空きマス一覧
	/// </summary>
	[Serializable]
	public class BodyFreeSquares {

		/// <summary>
		/// 素体の空きマス一覧
		/// </summary>
		public List<BodyFreeSquare> rows = new List<BodyFreeSquare>();

	}

	/// <summary>
	/// 素体の空きマス
	/// </summary>
	[Serializable]
	public class BodyFreeSquare {

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

	}

}
