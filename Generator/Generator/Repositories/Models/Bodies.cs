using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// 素体一覧
	/// </summary>
	[Serializable]
	public class Bodies {

		/// <summary>
		/// 素体一覧
		/// </summary>
		public List<Body> rows = new List<Body>();
		
	}

	/// <summary>
	/// 素体
	/// </summary>
	[Serializable]
	public class Body {

		#region 素体ID
		/// <summary>
		/// 素体ID
		/// </summary>
		public int id;
		/// <summary>
		/// 素体ID
		/// </summary>
		[IgnoreDataMember]
		public int Id { set => this.id = value; get => this.id; }
		#endregion

		#region 素体名
		/// <summary>
		/// 素体名
		/// </summary>
		public string name;
		/// <summary>
		/// 素体名
		/// </summary>
		[IgnoreDataMember]
		public string Name { set => this.name = value; get => this.name; }
		#endregion

		#region 素体名ルビ
		/// <summary>
		/// 素体名ルビ
		/// </summary>
		public string ruby;
		/// <summary>
		/// 素体名ルビ
		/// </summary>
		[IgnoreDataMember]
		public string Ruby { set => this.ruby = value; get => this.ruby; }
		#endregion

		#region フレーバーテキスト
		/// <summary>
		/// フレーバーテキスト
		/// </summary>
		public string flavor;
		/// <summary>
		/// フレーバーテキスト
		/// </summary>
		[IgnoreDataMember]
		public string Flavor { set => this.flavor = value; get => this.flavor; }
		#endregion

		#region 表示順
		/// <summary>
		/// 表示順
		/// </summary>
		public int displayOrder;
		/// <summary>
		/// 表示順
		/// </summary>
		public int DisplayOrder { set => this.displayOrder = value; get => this.displayOrder; }
		#endregion

	}

}
