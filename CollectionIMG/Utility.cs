using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionIMG
{
	public class Utility
	{
		public static string BulidSign(string token, string t, string appKey, string data)
		{
			return Tools.MD5(token + "&" + t + "&" + appKey + "&" + data, Encoding.UTF8);
		}

		public static string BulidData(string sellerId, int pageNum)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\"params\":\"{\\\"nodeId\\\":\\\"\\\",\\\"sellerId\\\":\\\"");
			stringBuilder.Append(sellerId);
			stringBuilder.Append("\\\",\\\"pagination\\\":{\\\"direction\\\":\\\"1\\\",\\\"hasMore\\\":\\\"true\\\",\\\"pageNum\\\":\\\"");
			stringBuilder.Append(pageNum);
			stringBuilder.Append("\\\",\\\"pageSize\\\":\\\"20\\\"}}\",\"cursor\":\"");
			stringBuilder.Append(pageNum);
			stringBuilder.Append("\",\"pageNum\":\"");
			stringBuilder.Append(pageNum);
			stringBuilder.Append("\",\"pageId\":5703,\"env\":\"1\"}");
			return stringBuilder.ToString();
		}
	}

}
