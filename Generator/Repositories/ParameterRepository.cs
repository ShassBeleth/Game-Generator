using Generator.Repositories.Models;
using System.Collections.Generic;

namespace Generator.Repositories {

	/// <summary>
	/// パラメータリポジトリ
	/// </summary>
	public class ParameterRepository : RepositoryBase {

		#region シングルトン

		/// <summary>
		/// インスタンス
		/// </summary>
		private static ParameterRepository Instance = null;

		/// <summary>
		/// インスタンス取得
		/// </summary>
		/// <returns>インスタンス</returns>
		public static ParameterRepository GetInstance() {
			if( Instance == null ) {
				Instance = new ParameterRepository();
			}
			return Instance;
		}

		#endregion

		/// <summary>
		/// パラメータ一覧
		/// </summary>
		public List<Parameter> Rows {
			set;
			get;
		}

		/// <summary>
		/// ファイルパス
		/// </summary>
		private readonly string FilePath = "parameters.json";

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private ParameterRepository() {
			if( this.Load<Parameters>( this.FilePath ) == null ) {
				this.Write<Parameters>( this.FilePath , new Parameters() { rows = new List<Parameter>() } );
			}
			this.Rows = this.Load<Parameters>( this.FilePath ).rows;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write() => this.Write<Parameters>( this.FilePath , new Parameters() { rows = this.Rows } );
		
	}

}
