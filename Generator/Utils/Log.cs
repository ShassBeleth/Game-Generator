
using System;
using System.Diagnostics;

public static class LogExtensions {

	/// <summary>
	/// Object型にLogメソッド追加
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="message">メッセージ</param>
	public static void Log( this object obj , string message ) {
		StackFrame callerFrame = new StackFrame( 1 );
		string methodName = callerFrame.GetMethod().Name;
		Console.WriteLine( $"{DateTime.Now.ToString( "hh:MM:ss" )}:{methodName}:{message}" );
	}

}
