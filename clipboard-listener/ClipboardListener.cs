using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace clipboardlistener
{
	class ClipboardListener
	{
		public static event EventHandler ClipboardUpdate;
		
		private static CBFNotification notification = new CBFNotification();
			
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			notification.GetType();
		}
		
		private static void OnClipboardUpdate(EventArgs e)
		{
			var handler = ClipboardUpdate;
			if(handler != null)
			{
				handler(null, e);
			}
		}
		
		private class CBFNotification :  Form
		{
			public CBFNotification()
			{
				NativeCalls.SetParent(Handle, NativeCalls.HWND_MESSAGE);
				NativeCalls.AddClipboardFormatListener(Handle);
			}
			
			protected override void WndProc(ref Message message)
			{
				if(message.Msg == NativeCalls.WM_CLIPBOARDUPDATE)
				{
					OnClipboardUpdate(null);
				}
				base.WndProc(ref message);
			}
		}
	}
	
	internal static class NativeCalls
	{
		public const int WM_CLIPBOARDUPDATE = 0x031D;
		public static IntPtr HWND_MESSAGE = new IntPtr(-3);
		
		[DllImport("user32.dll", SetLastError = true)]
		[return:MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddClipboardFormatListener(IntPtr hwnd);
		
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetParent(IntPtr hwndClild, IntPtr hwndNewParent);
	}
}
