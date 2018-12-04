using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// パラメータ一覧
	/// </summary>
	[Serializable]
	public class Parameters {

		/// <summary>
		/// パラメータ一覧
		/// </summary>
		public List<Parameter> rows = new List<Parameter>();

	}

	/// <summary>
	/// パラメータ
	/// </summary>
	[Serializable]
	public class Parameter {

		/// <summary>
		/// ID
		/// </summary>
		public int id;
		/// <summary>
		/// ID
		/// </summary>
		[IgnoreDataMember]
		public int Id { set => this.id = value; get => this.id; }

		/// <summary>
		/// 名前
		/// </summary>
		public string name;
		/// <summary>
		/// 名前
		/// </summary>
		[IgnoreDataMember]
		public string Name { set => this.name = value; get => this.name; }

	}

}
