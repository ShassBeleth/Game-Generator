using Newtonsoft.Json;
using System;
using System.IO;
using System.Security;
using System.Text;

namespace Generator.Repositories {

	/// <summary>
	/// リポジトリ共通部
	/// </summary>
	public abstract class RepositoryBase {

		/// <summary>
		/// フォルダパス
		/// </summary>
		protected readonly string DirectoryPath = Directory.GetCurrentDirectory() + "/Data/";
		
		/// <summary>
		/// 読み込み
		/// </summary>
		/// <typeparam name="T">読み込むデータの型</typeparam>
		/// <param name="filePath">ファイルパス</param>
		/// <returns>読み込んだデータモデル</returns>
		protected T Load<T>( string filePath ) where T : class {

			string jsonData = "";
			try {
				jsonData = File.ReadAllText( Path.Combine( this.DirectoryPath , filePath ) , Encoding.UTF8 );
			}
			catch( ArgumentNullException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( ArgumentException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( PathTooLongException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( DirectoryNotFoundException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( FileNotFoundException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( IOException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( UnauthorizedAccessException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( NotSupportedException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( SecurityException e ) {
				Console.WriteLine( $"{e.Message}." );
			}

			Console.WriteLine( $"Json Data is {jsonData}" );

			// 何かしらエラーの影響で取得したjsonデータが空文字だった場合nullを返す
			if( "".Equals( jsonData ) ) {
				Console.WriteLine( "Load File is Empty String." );
				return null;
			}

			// jsonデータをクラスに変換
			T data = JsonConvert.DeserializeObject<T>( jsonData );
			
			Console.WriteLine( "End" );
			return data;
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		/// <typeparam name="T">書き込むモデルの型</typeparam>
		/// <param name="filePath">ファイルパス</param>
		/// <param name="model">モデル</param>
		protected void Write<T>( string filePath , T model ) {
			Console.WriteLine( "Start" );
			Console.WriteLine( $"File Path is {filePath}" );

			// モデルをjsonに変換
			string jsonData = JsonConvert.SerializeObject( model );
			Console.WriteLine( $"Json Data is {jsonData}" );

			// ディレクトリが存在するか確認
			Console.WriteLine( $"Directory Path is {this.DirectoryPath}." );
			Console.WriteLine( $"File Path is {filePath}." );
			string directoryName = Path.GetDirectoryName( Path.Combine( this.DirectoryPath , filePath ) );
			Console.WriteLine( $"Directory Name is {directoryName}" );
			if( !Directory.Exists( directoryName ) ) {
				Console.WriteLine( "Directory Doesn't Exist." );
				Directory.CreateDirectory( directoryName );
			}

			// ファイルへ書き込み
			try {
				File.WriteAllText( Path.Combine( this.DirectoryPath , filePath ) , jsonData );
			}
			catch( ArgumentNullException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( ArgumentException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( PathTooLongException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( DirectoryNotFoundException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( IOException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( UnauthorizedAccessException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( NotSupportedException e ) {
				Console.WriteLine( $"{e.Message}." );
			}
			catch( SecurityException e ) {
				Console.WriteLine( $"{e.Message}." );
			}

			Console.WriteLine( "End" );
		}

		/// <summary>
		/// ファイルの削除
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		protected void Delete( string filePath ) {
			Console.WriteLine( "Start" );
			Console.WriteLine( $"File Path is {filePath}" );

			File.Delete( this.DirectoryPath + filePath );

			Console.WriteLine( "End" );
		}

	}

}
