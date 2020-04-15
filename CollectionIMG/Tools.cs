using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CollectionIMG
{
	public class Tools
	{
		public static string MD5(string source, Encoding encoding)
		{
			byte[] bytes = encoding.GetBytes(source);
			bytes = new MD5CryptoServiceProvider().ComputeHash(bytes);
			string text = "";
			for (int i = 0; i < bytes.Length; i++)
			{
				text += bytes[i].ToString("x").PadLeft(2, '0');
			}
			return text;
		}
	}

}
