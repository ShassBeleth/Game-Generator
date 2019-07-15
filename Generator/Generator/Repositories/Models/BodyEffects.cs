using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 素体の効果一覧
	/// </summary>
	[Serializable]
	public class BodyEffects {

		/// <summary>
		/// 素体の効果一覧
		/// </summary>
		public List<BodyEffect> rows = new List<BodyEffect>();

	}

	/// <summary>
	/// 素体の効果
	/// </summary>
	[Serializable]
	public class BodyEffect {

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
