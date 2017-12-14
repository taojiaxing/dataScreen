using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WebCrawl
{
    internal class WebCrawl
    {
        private string baseAddress = "https://github.com/";
        private string codeWareHouse = "ThinkGeo";

        private string BaseUrl
        {
            get
            {
                return baseAddress + codeWareHouse;
            }
        }

        private string result = "";
        private Collection<string> selectKeys = new Collection<string>();

        private static void Main(string[] args)
        {
            WebCrawl crawler = new WebCrawl();
            int number = int.Parse(ConfigurationManager.AppSettings["selectKeysCount"]);
            for (int i = 0; i < number + 1; i++)
            {
                String selectKey = ConfigurationManager.AppSettings["selectKey" + i];
                //如果该序号的关键字存在且不为空，则将关键字加入keys集合中
                if (!string.IsNullOrEmpty(selectKey))
                {
                   //如果关键字为all，则keys中已添加的关键字，直接设置为搜索所有
                    if (selectKey.Equals("all"))
                    {
                        crawler.selectKeys.Clear();
                        selectKey = @"[\w]+";
                        crawler.selectKeys.Add(selectKey);
                        break;
                    }
                }
                crawler.selectKeys.Add(selectKey);
            }
            Console.WriteLine("select...");
            Console.WriteLine("please wait a minute...");
            crawler.result = crawler.CrawlByKeys();
            crawler.WriteResult();
        }

        public string CrawlByKeys()
        {
            Collection<string> allLinks = GetAllPageLinks();
            Collection<string> keys = new Collection<string>(selectKeys);
            foreach (string link in allLinks)
            {
                if (keys.Count > 0)
                {
                    string html = visitUrl(link);
                    for (var i = 0; i < keys.Count; i++)
                    {
                        //匹配带搜索关键字的链接
                        Regex regexKey = new Regex(@"a[\s]+href=(?:""|')/" + codeWareHouse + @"/([^<>""']*)" + keys[i] + @"([^<>""']*)(?:""|')", RegexOptions.IgnoreCase);
                        MatchCollection matchResults = regexKey.Matches(html);
                        foreach (var str in matchResults)
                        {
                            var start = str.ToString().IndexOf(codeWareHouse);
                            start += codeWareHouse.Length + 1; //加上ThinkGeo后面的/
                            var r = str.ToString().Substring(start, str.ToString().Length - start - 1);  //去掉后面的引号，r即为sample名
                            Console.WriteLine(r);
                            //如果sample的名字和搜索关键字完全相等，则说明已经找到想要的sample，不用再继续为该关键字找下一个匹配了，所以移除
                            if (r.Equals(keys[i]))
                            {
                                keys.RemoveAt(i);
                                break;
                            }
                            result += r + "\r\n";
                        }
                    }
                }
            }
            return result;
        }

        public void WriteResult()
        {
            String path = ConfigurationManager.AppSettings["resultPath"];
            FileStream fs = new FileStream(@path, FileMode.Create, FileAccess.Write);
            fs.Position = fs.Length;
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(result);
            sw.Close();
        }

        public Collection<string> GetAllPageLinks()
        {
            string html = visitUrl(BaseUrl);
            string pagination = "";
            int paginationIndex = html.IndexOf(@"<div class=""pagination"">");
            string restStr = html.Substring(paginationIndex);
            int endIndex = restStr.IndexOf("</div>");
            pagination = restStr.Substring(0, endIndex);
            //得到html中pagination部分里的链接个数，并根据这些页数按固定格式进行匹配
            Regex regexLink = new Regex(@"<[^<>]+>[^<>\s]+</[^<>]+>");
            MatchCollection matchLinks = regexLink.Matches(pagination.ToString());
            Collection<string> links = new Collection<string>();
            int pageCount = matchLinks.Count - 2; //去掉这个pagination中的previous和next模块，所以是减2
            for (var i = 1; i <= pageCount; i++)
            {
                links.Add(baseAddress + codeWareHouse + "?page=" + i);
            }
            return links;
        }

        public string visitUrl(string url)
        {
            WebRequest request = WebRequest.Create(url.Trim());
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(resStream, Encoding.Default);
            StringBuilder stringBuilder = new StringBuilder();
            while ((url = streamReader.ReadLine()) != null)  //将得到的html代码写入到StringBuilder中
            {
                stringBuilder.Append(url);
            }
            return stringBuilder.ToString();
        }
    }
}