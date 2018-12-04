using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// パラメータチップのマス一覧
	/// </summary>
	[Serializable]
	public class ParameterChipSquares {

		/// <summary>
		/// パラメータチップのマス一覧
		/// </summary>
		public List<ParameterChipSquare> rows = new List<ParameterChipSquare>();
	}

	/// <summary>
	/// パラメータチップ
	/// </summary>
	[Serializable]
	public class ParameterChipSquare {

		/// <summary>
		/// パラメータチップID
		/// </summary>
		public int parameterChipId;
		/// <summary>
		/// パラメータチップID
		/// </summary>
		[IgnoreDataMember]
		public int ParameterChipId { get => this.parameterChipId; set => this.parameterChipId = value; }

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

	}

}
