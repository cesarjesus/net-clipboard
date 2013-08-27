using System;
using clipboardlistener;

namespace netclip
{
	class NetClipboard
	{
		public static void Main (string[] args)
		{
			ClipboardListener cbListener = new ClipboardListener();
			Console.WriteLine(cbListener.ToString());
		}
	}
}
