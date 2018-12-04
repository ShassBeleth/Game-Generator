using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 装備一覧
	/// </summary>
	[Serializable]
	public class Equipments {

		/// <summary>
		/// 装備一覧
		/// </summary>
		public List<Equipment> rows = new List<Equipment>();

	}

	/// <summary>
	/// 装備
	/// </summary>
	[Serializable]
	public class Equipment {

		/// <summary>
		/// 装備ID
		/// </summary>
		public int id;
		/// <summary>
		/// 装備ID
		/// </summary>
		[IgnoreDataMember]
		public int Id { get => this.id; set => this.id = value; }

		/// <summary>
		/// 装備名
		/// </summary>
		public string name;
		/// <summary>
		/// 装備名
		/// </summary>
		[IgnoreDataMember]
		public string Name { get => this.name; set => this.name = value; }

		/// <summary>
		/// 装備名ルビ
		/// </summary>
		public string ruby;
		/// <summary>
		/// 装備名ルビ
		/// </summary>
		[IgnoreDataMember]
		public string Ruby { get => this.ruby; set => this.ruby = value; }

		/// <summary>
		/// フレーバーテキスト
		/// </summary>
		public string flavor;
		/// <summary>
		/// フレーバーテキスト
		/// </summary>
		[IgnoreDataMember]
		public string Flavor { get => this.flavor; set => this.flavor = value; }

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
