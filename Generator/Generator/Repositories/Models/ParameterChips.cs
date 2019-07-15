using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// パラメータチップ一覧
	/// </summary>
	[Serializable]
	public class ParameterChips {

		/// <summary>
		/// パラメータチップ一覧
		/// </summary>
		public List<ParameterChip> rows = new List<ParameterChip>();
	}

	/// <summary>
	/// パラメータチップ
	/// </summary>
	[Serializable]
	public class ParameterChip {

		/// <summary>
		/// パラメータチップID
		/// </summary>
		public int id;
		/// <summary>
		/// パラメータチップID
		/// </summary>
		[IgnoreDataMember]
		public int Id { get => this.id; set => this.id = value; }

		/// <summary>
		/// チップ名
		/// </summary>
		public string name;
		/// <summary>
		/// チップ名
		/// </summary>
		[IgnoreDataMember]
		public string Name { get => this.name; set => this.name = value; }

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
