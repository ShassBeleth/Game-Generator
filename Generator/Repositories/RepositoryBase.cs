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
		/// 読み込み
		/// </summary>
		/// <typeparam name="T">読み込むデータの型</typeparam>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>読み込んだデータモデル</returns>
		protected T Load<T>( string filePath ) where T : class {

			string jsonData = "";
			try {
				jsonData = File.ReadAllText( Path.Combine( this.GetDirectoryPath() , filePath ) , Encoding.UTF8 );
			}
			catch( ArgumentNullException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( ArgumentException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( PathTooLongException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( DirectoryNotFoundException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( FileNotFoundException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( IOException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( UnauthorizedAccessException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( NotSupportedException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( SecurityException e ) {
				this.Log( $"{e.Message}." );
			}

			this.Log( $"Json Data is {jsonData}" );

			// 何かしらエラーの影響で取得したjsonデータが空文字だった場合nullを返す
			if( "".Equals( jsonData ) ) {
				this.Log( "Load File is Empty String." );
				return null;
			}

			// jsonデータをクラスに変換
			T data = JsonConvert.DeserializeObject<T>( jsonData );
			
			this.Log( "End" );
			return data;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		/// <typeparam name="T">書き込むモデルの型</typeparam>
		/// <param name="filePath">ファイルパス</param>
		/// <param name="model">モデル</param>
		protected void Write<T>( string filePath , T model ) {
			this.Log( "Start" );
			this.Log( $"File Path is {filePath}" );

			// モデルをjsonに変換
			string jsonData = JsonConvert.SerializeObject( model );
			this.Log( $"Json Data is {jsonData}" );

			// ディレクトリが存在するか確認
			string directoryPath = this.GetDirectoryPath();
			this.Log( $"Directory Path is {directoryPath}." );
			this.Log( $"File Path is {filePath}." );
			string directoryName = Path.GetDirectoryName( Path.Combine( directoryPath , filePath ) );
			this.Log( $"Directory Name is {directoryName}" );
			if( !Directory.Exists( directoryName ) ) {
				this.Log( "Directory Doesn't Exist." );
				Directory.CreateDirectory( directoryName );
			}

			// ファイルへ書き込み
			try {
				File.WriteAllText( Path.Combine( directoryPath , filePath ) , jsonData );
			}
			catch( ArgumentNullException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( ArgumentException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( PathTooLongException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( DirectoryNotFoundException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( IOException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( UnauthorizedAccessException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( NotSupportedException e ) {
				this.Log( $"{e.Message}." );
			}
			catch( SecurityException e ) {
				this.Log( $"{e.Message}." );
			}

			this.Log( "End" );
		}

		/// <summary>
		/// ファイルの削除
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		protected void Delete( string filePath ) {
			this.Log( "Start" );
			this.Log( $"File Path is {filePath}" );

			File.Delete( this.GetDirectoryPath() + filePath );

			this.Log( "End" );
		}

	}

}
