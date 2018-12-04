using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// セーブデータ一覧
	/// </summary>
	[Serializable]
	public class Saves {

		/// <summary>
		/// セーブデータ一覧
		/// </summary>
		public List<Save> rows = new List<Save>();

	}

	/// <summary>
	/// セーブデータ
	/// </summary>
	[Serializable]
	public class Save {

		/// <summary>
		/// ID
		/// </summary>
		public int id;
		/// <summary>
		/// ID
		/// </summary>
		[IgnoreDataMember]
		public int Id { get => this.id; set => this.id = value; }

		/// <summary>
		/// 既にセーブデータが存在するかどうか
		/// </summary>
		public bool exsitsAlreadyData;
		/// <summary>
		/// 既にセーブデータが存在するかどうか
		/// </summary>
		[IgnoreDataMember]
		public bool ExsitsAlreadyData { get => this.exsitsAlreadyData; set => this.exsitsAlreadyData = value; }

		/// <summary>
		/// 垂直方向のカメラ移動を反転させるかどうか
		/// </summary>
		public bool isReverseVerticalCamera;
		/// <summary>
		/// 垂直方向のカメラ移動を反転させるかどうか
		/// </summary>
		[IgnoreDataMember]
		public bool IsReverseVerticalCamera { get => this.isReverseVerticalCamera; set => this.isReverseVerticalCamera = value; }

		/// <summary>
		/// 水平方向のカメラ移動を反転させるかどうか
		/// </summary>
		public bool isReverseHorizontalCamera;
		/// <summary>
		/// 水平方向のカメラ移動を反転させるかどうか
		/// </summary>
		[IgnoreDataMember]
		public bool IsReverseHorizontalCamera { get => this.isReverseHorizontalCamera; set => this.isReverseHorizontalCamera = value; }

		/// <summary>
		/// 最終更新日時
		/// </summary>
		public string latestUpdateDatetime;
		/// <summary>
		/// 最終更新日時
		/// </summary>
		[IgnoreDataMember]
		public string LatestUpdateDatetime { get => this.latestUpdateDatetime; set => this.latestUpdateDatetime = value; }

	}

}
