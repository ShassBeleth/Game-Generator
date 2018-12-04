using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// チャプター一覧
	/// </summary>
	[Serializable]
	public class Chapters {

		/// <summary>
		/// チャプター一覧
		/// </summary>
		public List<Chapter> rows = new List<Chapter>();

	}

	/// <summary>
	/// チャプター
	/// </summary>
	[Serializable]
	public class Chapter {

		/// <summary>
		/// チャプターID
		/// </summary>
		public int id;
		/// <summary>
		/// チャプターID
		/// </summary>
		[IgnoreDataMember]
		public int Id { get => this.id; set => this.id = value; }

		/// <summary>
		/// カテゴリ
		/// </summary>
		public int category;
		/// <summary>
		/// カテゴリ
		/// </summary>
		[IgnoreDataMember]
		public int Category { get => this.category; set => this.category = value; }

		/// <summary>
		/// チャプター名
		/// </summary>
		public string name;
		/// <summary>
		/// チャプター名
		/// </summary>
		[IgnoreDataMember]
		public string Name { get => this.name; set => this.name = value; }

		/// <summary>
		/// 詳細テキスト
		/// </summary>
		public string text;
		/// <summary>
		/// 詳細テキスト
		/// </summary>
		[IgnoreDataMember]
		public string Text { get => this.text; set => this.text = value; }

		/// <summary>
		/// 一覧順
		/// </summary>
		public int numberOrder;
		/// <summary>
		/// 一覧順
		/// </summary>
		[IgnoreDataMember]
		public int NumberOrder { get => this.numberOrder; set => this.numberOrder = value; }

		/// <summary>
		/// イベント日時
		/// </summary>
		public string eventDateTime;
		/// <summary>
		/// イベント日時
		/// </summary>
		[IgnoreDataMember]
		public string EventDateTime { get => this.eventDateTime; set => this.eventDateTime = value; }

	}

}
