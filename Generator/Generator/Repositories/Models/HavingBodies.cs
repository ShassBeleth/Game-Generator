using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 保持している素体一覧
	/// </summary>
	[Serializable]
	public class HavingBodies {

		/// <summary>
		/// 保持している素体一覧
		/// </summary>
		public List<HavingBody> rows = new List<HavingBody>();

	}

	/// <summary>
	/// 保持している素体
	/// </summary>
	[Serializable]
	public class HavingBody {
		
		/// <summary>
		/// 素体ID
		/// </summary>
		public int bodyId;
		/// <summary>
		/// 素体ID
		/// </summary>
		[IgnoreDataMember]
		public int BodyId { get => this.bodyId; set => this.bodyId = value; }

	}

}
