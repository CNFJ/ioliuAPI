using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionIMG
{
    public partial class Form1 : Form
    {
        private Thread thread;



        private GroupBox groupBox1;

        private GroupBox groupBox2;

        private TextBox textBox_sellerId;



        private Button button_start;

        private TextBox textBox_activity_window;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void activity_window_Appent(string text)
        {
            Invoke((Action)delegate
            {
                textBox2.AppendText(text + "\r\n");
            });
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            ThreadStart start = CollectionStart;
            thread = new Thread(start);
            thread.Priority = ThreadPriority.Normal;
            thread.Start();
        }

        private void set_startBtn_state(bool state)
        {
            Invoke((Action)delegate
            {
                if (state)
                {
                    button1.Text = "开始采集";
                }
                else
                {
                    button1.Text = "采集中...";
                }
                button1.Enabled = state;
            });
        }

        private void CollectionStart()
        {
            set_startBtn_state(state: false);
            string sellerId = textBox1.Text.Trim();
            CookieCollection cookie = CollectionService.GetCookie();
            if (cookie == null)
            {
                MessageBox.Show("哟，cookie居然没拿到，等会再试试吧！");
                return;
            }
            string token = cookie["_m_h5_tk"].Value.Split('_')[0];
            int num = 1;
            while (true)
            {
                string data = Utility.BulidData(sellerId, num);
                ResponseModel imgList = CollectionService.GetImgList(token, data, cookie);
                if (imgList.data.list.Count() < 1)
                {
                    break;
                }
                Parallel.ForEach(imgList.data.list, new ParallelOptions
                {
                    MaxDegreeOfParallelism = 5
                }, delegate (List item)
                {
                    if (item.pics != null && item.pics.Count() != 0)
                    {
                        activity_window_Appent($"{item.pics.Count()}P {item.title}");
                      //  DownPic(item);
                    }
                });
                num++;
                Thread.Sleep(300);
            }
            if (num > 1)
            {
                set_startBtn_state(state: true);
                MessageBox.Show("没有了！");
            }
            else
            {
                set_startBtn_state(state: true);
                MessageBox.Show("暂无内容哦 “万千的世界，怎么会没有你的真爱呢…”");
            }
        }

        private void DownPic(IMGurl list)
        {
            WebClient web = new WebClient();
            try
            {
                string path = "./" + textBox1.Text.Trim();
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                web.DownloadFile(list.imgLists[0].Url, path + "/" + list.imgLists[0].Url);
                //Parallel.ForEach(list.imgLists, delegate (ImgList pic)
                //{
                //    string text = path + "/" + pic.Url + ".png";
                //    if (!File.Exists(text))
                //    {
                //        try
                //        {
                //            web.DownloadFile(pic.Url, text);
                //        }
                //        catch (Exception ex)
                //        {
                //           // textBox2.Text = ex.Message.ToString();
                //        }
                //    }
                //});
            }
            finally
            {
                if (web != null)
                {
                    ((IDisposable)web).Dispose();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart start = CollectionStart;
            thread = new Thread(start);
            thread.Priority = ThreadPriority.Normal;
            thread.Start();
        }

        private string GetHtmlCode(string url, Encoding encoding)
        {
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream resStream = response.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, encoding);
            string html = (sr.ReadToEnd());
            resStream.Close();
            sr.Close();
            return html;
        }
        //取图片链接
        private void button2_Click(object sender, EventArgs e)
        {
            string html = GetHtmlCode("http://nsfwpicx.com/2020/04/14/1333.html", Encoding.GetEncoding("gb2312"));
            Regex reg = new Regex(@"(?i)<img\b[^>]*?src=(['""]?)([^'""\s>]+)\1[^>]*>");
            MatchCollection mc = reg.Matches(html);
            textBox2.Clear();
            List<ImgList> lst = new List<ImgList> { };
            ImgList[] array = new ImgList[] { };
            List<IMGurl> lst1 = new List<IMGurl> { };
            IMGurl[] array1 = new IMGurl[] { };
            int img = 0;
            if (mc.Count > 0)
            {

                foreach (Match m in mc)
                {
                    lst.Add(new ImgList {  Url= m.Groups[2].Value }) ;

                    textBox2.Text += m.Groups[2].Value + "\r\n";
                    img++;
                }
                array = lst.ToArray();
                lst1.Add(new IMGurl { title = "1", imgLists = array });
                array1 = lst1.ToArray();
                int num = 1;
                while (true)
                {
                    //string data = Utility.BulidData(sellerId, num);
                    //ResponseModel imgList = CollectionService.GetImgList(token, data, cookie);

                    if (array.Count() < 1)
                    {
                        break;
                    }
                    ParallelLoopResult result = Parallel.ForEach(array1, new ParallelOptions
                    {
                        MaxDegreeOfParallelism = 5
                    }, delegate (IMGurl item)
                    {
                       
                            activity_window_Appent($"ran");
                            DownPic(item);
                        
                    });
                    num++;
                    Thread.Sleep(300);
                }
                if (num > 1)
                {
                    set_startBtn_state(state: true);
                    MessageBox.Show("没有了！");
                }
                else
                {
                    set_startBtn_state(state: true);
                    MessageBox.Show("暂无内容哦 “万千的世界，怎么会没有你的真爱呢…”");
                }
            }
            else
            {
                return;
            }


        }


    }
}
