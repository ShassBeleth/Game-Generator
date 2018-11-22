using System;
using System.Collections.Generic;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 装備することで増える空きマス一覧
	/// </summary>
	[Serializable]
	public class EquipmentFreeSquares {

		/// <summary>
		/// 装備することで増える空きマス一覧
		/// </summary>
		public List<EquipmentFreeSquare> rows;

	}

	/// <summary>
	/// 装備することで増える空きマス
	/// </summary>
	[Serializable]
	public class EquipmentFreeSquare {
	}

}
