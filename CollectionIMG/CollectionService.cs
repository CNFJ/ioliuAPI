using Newtonsoft.Json;
using SufeiUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CollectionIMG
{
   public class CollectionService
    {
		public static ResponseModel GetImgList(string token, string data, CookieCollection cookie)
		{
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			string text = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000L) / 10000).ToString();
			string text2 = Utility.BulidSign(token, text, "12574478", data);
			string uRL = "https://acs.m.taobao.com/h5/mtop.taobao.social.feed.aggregate/1.0/?appKey=12574478&t=" + text + "&sign=" + text2 + "&data=" + data;
			//string uRL = "http://nsfwpicx.com/2020/04/14/1333.html";
			HttpHelper val = new HttpHelper();
			HttpItem val2 = new HttpItem();
			val2.URL=uRL;
			val2.CookieCollection=cookie;
			val2.ResultCookieType=(ResultCookieType)1;
			HttpItem val3 = (HttpItem)(object)val2;
			return JsonConvert.DeserializeObject<ResponseModel>(val.GetHtml(val3).Html);
		}

		public static CookieCollection GetCookie()
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			string uRL = "https://acs.m.taobao.com/h5/mtop.taobao.social.feed.aggregate/1.0/?appKey=12574478";
			HttpHelper val = new HttpHelper();
			HttpItem val2 = new HttpItem();
			val2.URL=uRL;
			val2.ResultCookieType=(ResultCookieType)1;
			return val.GetHtml((HttpItem)(object)val2).CookieCollection;
		}
	}
}
