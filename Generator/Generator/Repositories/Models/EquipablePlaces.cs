using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 装備可能箇所一覧
	/// </summary>
	[Serializable]
	public class EquipablePlaces {

		/// <summary>
		/// 装備可能箇所一覧
		/// </summary>
		public List<EquipablePlace> rows = new List<EquipablePlace>();

	}

	/// <summary>
	/// 装備可能箇所
	/// </summary>
	[Serializable]
	public class EquipablePlace {

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
