﻿using System;
using System.Collections.Generic;

namespace Generator.Repositories.Models {

	/// <summary>
	/// パラメータ一覧
	/// </summary>
	[Serializable]
	public class Parameters {

		/// <summary>
		/// パラメータ一覧
		/// </summary>
		public List<Parameter> rows;

	}

	/// <summary>
	/// パラメータ
	/// </summary>
	[Serializable]
	public class Parameter {
		
		/// <summary>
		/// パラメータID
		/// </summary>
		public int id;

		/// <summary>
		/// パラメータ名
		/// </summary>
		public string name;
		
	}

}
