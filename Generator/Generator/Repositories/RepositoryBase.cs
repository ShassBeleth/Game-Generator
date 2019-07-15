using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Security;
using System.Text;
using System.Xml;

namespace Generator.Repositories {

	/// <summary>
	/// リポジトリ共通部
	/// </summary>
	public abstract class RepositoryBase {
		
		/// <summary>
		/// フォルダパスの取得
		/// </summary>
		/// <returns>フォルダパス</returns>
		private string GetDirectoryPath() {
			// configのパスを取得
			string appConfigPath;
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
				appConfigPath = Path.Combine(
					Path.GetDirectoryName( assembly.Location ) ,
					"Generator.exe.config"
				);
			}

			// XmlDocumentからDataフォルダのパスを取得
			XmlDocument doc = new XmlDocument();
			string directoryPath = "";
			doc.Load( appConfigPath );
			{
				foreach( XmlNode node in doc[ "configuration" ][ "appSettings" ] ) {
					if( node.Name == "add" ) {
						if( node.Attributes.GetNamedItem( "key" ).Value == "DataFolderPath" ) {
							directoryPath = node.Attributes.GetNamedItem( "value" ).Value;
						}
					}
				}
			}

			return directoryPath;

		}

		/// <summary>
		/// ディレクトリが存在するか確認
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>存在している場合TRUE</returns>
		private bool ExistsDirectory( string filePath ) {
			string directoryPath = this.GetDirectoryPath();
			string directoryName = Path.GetDirectoryName( Path.Combine( directoryPath , filePath ) );
			return Directory.Exists( directoryName );
		}

		/// <summary>
		/// ディレクトリ作成
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		private void CreateDirectory( string filePath ) {
			string directoryPath = this.GetDirectoryPath();
			string directoryName = Path.GetDirectoryName( Path.Combine( directoryPath , filePath ) );
			Directory.CreateDirectory( directoryName );
		}

		/// <summary>
		/// ファイルが存在するか確認
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>存在している場合TRUE</returns>
		private bool ExistsFile( string filePath ) {
			string directoryPath = this.GetDirectoryPath();
			string absolutePath = Path.Combine( directoryPath , filePath );
			return File.Exists( absolutePath );
		}

		/// <summary>
		/// ファイル作成
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		private void CreateFile( string filePath ) {
			string directoryPath = this.GetDirectoryPath();
			string absolutePath = Path.Combine( directoryPath , filePath );
			File.CreateText( absolutePath );
		}
		
		/// <summary>
		/// 読み込み
		/// </summary>
		/// <typeparam name="T">読み込むデータの型</typeparam>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>読み込んだデータモデル</returns>
		protected T Load<T>( string filePath ) where T : class {

			// ディレクトリが存在するか確認
			if( !this.ExistsDirectory( filePath ) ) {
				this.CreateDirectory( filePath );
			}

			// ファイルが存在するか確認
			if( !this.ExistsFile( filePath ) ) {
				this.CreateFile( filePath );
			}
			
			string jsonData = "";
			jsonData = File.ReadAllText( Path.Combine( this.GetDirectoryPath() , filePath ) , Encoding.UTF8 );

			// 何かしらエラーの影響で取得したjsonデータが空文字だった場合nullを返す
			if( "".Equals( jsonData ) ) {
				return default;
			}

			// jsonデータをクラスに変換
			T data = JsonConvert.DeserializeObject<T>( jsonData );

			return data;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		/// <typeparam name="T">書き込むモデルの型</typeparam>
		/// <param name="filePath">ファイルパス</param>
		/// <param name="model">モデル</param>
		protected void Write<T>( string filePath , T model ) {
			
			// モデルをjsonに変換
			string jsonData = JsonConvert.SerializeObject( model );
			
			// ディレクトリが存在するか確認
			string directoryPath = this.GetDirectoryPath();
			string directoryName = Path.GetDirectoryName( Path.Combine( directoryPath , filePath ) );
			if( !Directory.Exists( directoryName ) ) {
				Directory.CreateDirectory( directoryName );
			}

			// ファイルへ書き込み
			File.WriteAllText( Path.Combine( directoryPath , filePath ) , jsonData );
		}

		/// <summary>
		/// ファイルの削除
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		protected void Delete(string filePath)
			=> File.Delete(this.GetDirectoryPath() + filePath);

	}

}
