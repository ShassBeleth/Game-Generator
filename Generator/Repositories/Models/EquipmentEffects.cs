﻿using System;
using System.Collections.Generic;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 装備の効果一覧
	/// </summary>
	[Serializable]
	public class EquipmentEffects {

		/// <summary>
		/// 装備の効果一覧
		/// </summary>
		public List<EquipmentEffect> rows;

	}

	/// <summary>
	/// 装備の効果
	/// </summary>
	[Serializable]
	public class EquipmentEffect {
	}

}
