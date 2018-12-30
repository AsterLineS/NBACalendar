using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace NBACalendar
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();

        public void Crawl()
        {
 
            //Crawler myCrawler = new Crawler();
            int month = 1;
            int year = 2017;
            int year1 = year + 1;
            string startUrl = "http://www.uhchina.com/lanqiu/"+year+"-"+year1+"nbachangguisai" + month;

            HttpWebRequest request = WebRequest.Create(startUrl) as HttpWebRequest;
            request.UserAgent = @"Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)";
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);

            //返回结果网页（html）代码

            string content = sr.ReadToEnd();
            var list = new List<string>();
            StreamWriter f = new StreamWriter(@"F:\saicheng.txt", false,Encoding.UTF8);

            if (content != "")
            {
                Regex reg = new Regex("(?is)(?<=<table[^>]*?[^>]*?>(?:(?!</?table).)*)(?is)<tr[^>]*?[^>]*?>(?:\\s*<td[^>]*>(.*?)</td>)*\\s*</tr>");

                MatchCollection mc = reg.Matches(content);

                //foreach (var item in mc)
                //{
                //    Console.WriteLine(item.ToString());
                //}


                
                foreach (Match mat in mc)
                {
                    try
                    {
                        Regex reg1 = new Regex("<td><a\\s+(.*?)+>(?<name>(.*?))</a></td>");
                        Regex reg2 = new Regex("<b\\s(.*?)>(?<score>(.*?))</b>");
                        Regex reg3 = new Regex("<td>(?<date>(.*?))</td><td><a\\s+(.*?)+>");

                        Regex reg4 = new Regex("<td\\sonclick+(.*?)+>(?<name>(.*?))</td>");
                        Regex reg5 = new Regex("<td>(?<date>(.*?))</td><td\\sonclick+(.*?)+>");


                        MatchCollection names1 = reg1.Matches(mat.Value);
                        MatchCollection scores = reg2.Matches(mat.Value);
                        MatchCollection date1 = reg3.Matches(mat.Value);
                        MatchCollection names2 = reg4.Matches(mat.Value);
                        MatchCollection date2 = reg5.Matches(mat.Value);
                        if (names1.Count == 2)
                        {
                            if (scores.Count == 2)
                            {
                                f.WriteLine(date1[0].Result("${date}" + " ") + names1[0].Result("${name}") + " " + scores[0].Result("${score}")
                                    + ":" + scores[1].Result("${score}") + " " + names1[1].Result("${name}"));
                            }
                        }
                        else if(names2.Count==2)
                        {
                            
                            if (scores.Count == 2)
                            {
                                f.WriteLine(date2[0].Result("${date}" + " ") + names2[0].Result("${name}") + " " + scores[0].Result("${score}")
                                    + ":" + scores[1].Result("${score}") + " " + names2[1].Result("${name}"));
                            }
                        }
                        //else if(date1.Count==1)
                        //{
                        //    if (scores.Count == 2)
                        //    {
                        //        f.WriteLine(date1[0].Result("${date}" + " ") + names2[0].Result("${name}") + " " + scores[0].Result("${score}")
                        //            + ":" + scores[1].Result("${score}") + " " + names1[0].Result("${name}"));
                        //    }
                        //}
                        
                    }
                    catch (Exception e)
                    {
                        f.WriteLine(e.Message);
                        f.WriteLine("正在解析" + mat.ToString());
                    }
                    
                }
                f.Close();
            }
            
        }
    }
}