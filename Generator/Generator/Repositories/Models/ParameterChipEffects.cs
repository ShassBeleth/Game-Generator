using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// パラメータチップの効果一覧
	/// </summary>
	[Serializable]
	public class ParameterChipEffects {

		/// <summary>
		/// パラメータチップの効果一覧
		/// </summary>
		public List<ParameterChipEffect> rows = new List<ParameterChipEffect>();
	}

	/// <summary>
	/// パラメータチップの効果
	/// </summary>
	[Serializable]
	public class ParameterChipEffect {

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
