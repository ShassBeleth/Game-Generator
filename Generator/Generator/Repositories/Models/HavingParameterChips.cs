using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 保持しているパラメータチップ一覧
	/// </summary>
	[Serializable]
	public class HavingParameterChips {

		/// <summary>
		/// 保持しているパラメータチップ一覧
		/// </summary>
		public List<HavingParameterChip> rows = new List<HavingParameterChip>();

	}

	/// <summary>
	/// 保持しているパラメータチップ
	/// </summary>
	[Serializable]
	public class HavingParameterChip {

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
		/// 個数
		/// </summary>
		public int count;
		/// <summary>
		/// 個数
		/// </summary>
		[IgnoreDataMember]
		public int Count { get => this.count; set => this.count = value; }

	}

}
