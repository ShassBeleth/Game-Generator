using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Generator.Repositories.Models {

	/// <summary>
	/// チャプターのクリア状況一覧
	/// </summary>
	[Serializable]
	public class ChapterClearStatuses {

		/// <summary>
		/// チャプターのクリア状況一覧
		/// </summary>
		public List<ChapterClearStatus> rows = new List<ChapterClearStatus>();

	}

	/// <summary>
	/// チャプターのクリア状況
	/// </summary>
	[Serializable]
	public class ChapterClearStatus {
		
		/// <summary>
		/// チャプターID
		/// </summary>
		public int chapterId;
		/// <summary>
		/// チャプターID
		/// </summary>
		[IgnoreDataMember]
		public int ChapterId { get => this.chapterId; set => this.chapterId = value; }

	}

}
