using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;


namespace NBACalendar
{
    public partial class Calendar : Form
    {
        private DateTime dtNow = DateTime.Now;   //初始化当天日期
        private int daysOfMonth = 30;     //初始化每月天数
        private int weekOfFirstDay = 1;   //初始化某月第一天的星期
        private int selectYear=2018;     //初始化选择年份
        private int selectMonth=12;   //初始化选择月份
        private DateTime dtInfo = DateTime.Now;    //初始化日期信息
        private string[,] dateArray = new string[7, 6];   //记录日期信息
        private bool flag = true; //标记是否重绘panel

        private Hashtable urls = new Hashtable();


        public void Init()
        {
            
            //Crawler crawler = new Crawler();
            //crawler.Crawl();
            //Crawl();
            

            //List<int> list = new List<int>();
            //for (int i = 1949; i <= 2049; i++)
            //{
            //    list.Add(i);
            //}
            //comboBox1.DataSource = list;
            for (int i = 1949; i <= 2049; i++)
            {
                comboBox1.Items.Add(i);
                if (i == dtNow.Year)
                {
                    comboBox1.SelectedItem = i;
                    selectYear = i;
                }
            }
            for (int i = 1; i <= 12; i++)
            {
                comboBox2.Items.Add(i);
                if (i == dtNow.Month)
                {
                    comboBox2.SelectedItem = i;
                    selectMonth = i;
                }
            }

        }
        public Calendar()
        {
            InitializeComponent();
            Init();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //获取某月首日星期及某月天数
        private void GetWeekInfo(ref int weekOfFirstDay, ref int daysOfMonth, int year = 1900, int month = 1, int day = 1)
        {
            DateTime dt =
                DateTime.Parse(year.ToString(CultureInfo.InvariantCulture) + "/" +
                               month.ToString(CultureInfo.InvariantCulture) + "/" +
                               day.ToString(CultureInfo.InvariantCulture));
            weekOfFirstDay = (int)dt.DayOfWeek;
            daysOfMonth = (int)DateTime.DaysInMonth(year, month);
        }

        //绘制月历日期
        private void DrawDateNum(int firstDayofWeek, int endMonthDay, int year, int month)
        {
            DateTime dtNow = DateTime.Parse(DateTime.Now.ToShortDateString());

            var font = new Font("", 14);
            var solidBrushWeekdays = new SolidBrush(Color.SteelBlue);
            var solidBrushWeekend = new SolidBrush(Color.IndianRed);
            var solidBrushHoliday = new SolidBrush(Color.Indigo);
            Graphics g = panelMonthInfo.CreateGraphics();
            int num = 1;

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (j == 0 && i < firstDayofWeek) //定义当月第一天的星期的位置
                    {
                        continue;
                    }
                    else
                    {
                        if (num > endMonthDay) //定义当月最后一天的位置
                        {
                            break;
                        }
                        string cMonth = null;
                        string cDay = null;
                        string cHoliday = null;
                        string ccHoliday = null;

                        if (i > 0 && i < 6)
                        {
                            DateTime dt = DateTime.Parse(year + "-" + month + "-" + num);
                            TimeSpan ts = dt - dtNow;
                            dateArray[i, j] = dt.ToShortDateString();

                            if (ts.Days == 0)
                            {
                                g.DrawEllipse(new Pen(Color.Chocolate, 3), (15 + 80 * i), (85 + 60 * j), 30, 15);
                            }

                            cMonth = ChineseDate.GetMonth(dt);
                            cDay = ChineseDate.GetDay(dt);
                            cHoliday = ChineseDate.GetHoliday(dt);
                            ccHoliday = ChineseDate.GetChinaHoliday(dt);

                            if (cHoliday != null)
                            {
                                //绘阳历节日
                                g.DrawString(cHoliday.Length > 3 ? cHoliday.Substring(0, 3) : cHoliday, new Font("华文琥珀", 9),
                                             solidBrushHoliday, (40 + 80 * i), (90 + 60 * j));
                            }
                            //绘农历
                            if (ccHoliday != "")
                            {
                                g.DrawString(ccHoliday, new Font("华文琥珀", 10), solidBrushWeekdays, (25 + 80 * i),
                                                                         (115 + 60 * j));
                            }
                            else
                            {
                                g.DrawString(cDay == "初一" ? cMonth : cDay, new Font("华文琥珀", 10), solidBrushWeekdays, (25 + 80 * i),
                                                                         (115 + 60 * j));
                            }


                            //绘日期
                            g.DrawString(num.ToString(CultureInfo.InvariantCulture), font, solidBrushWeekdays,
                                         (15 + 80 * i), (80 + 60 * j));

                        }
                        else
                        {
                            var dt = DateTime.Parse(year + "-" + month + "-" + num);
                            var ts = dt - dtNow;
                            dateArray[i, j] = dt.ToShortDateString();
                            if (ts.Days == 0)
                            {
                                g.DrawEllipse(new Pen(Color.Chocolate, 3), (15 + 80 * i), (85 + 60 * j), 30, 15);
                            }

                            cMonth = ChineseDate.GetMonth(dt);
                            cDay = ChineseDate.GetDay(dt);
                            cHoliday = ChineseDate.GetHoliday(dt);
                            ccHoliday = ChineseDate.GetChinaHoliday(dt);

                            if (cHoliday != null)
                            {
                                //绘阳历节日
                                g.DrawString(cHoliday.Length > 3 ? cHoliday.Substring(0, 3) : cHoliday, new Font("华文琥珀", 9),
                                             solidBrushHoliday, (40 + 80 * i), (90 + 60 * j));
                            }
                            //绘农历
                            if (ccHoliday != "")
                            {
                                g.DrawString(ccHoliday, new Font("华文琥珀", 10), solidBrushWeekend, (25 + 80 * i),
                                         (115 + 60 * j));
                            }
                            else
                            {
                                g.DrawString(cDay == "初一" ? cMonth : cDay, new Font("华文琥珀", 10), solidBrushWeekend, (25 + 80 * i),
                                         (115 + 60 * j));
                            }

                            //绘日期
                            g.DrawString(num.ToString(CultureInfo.InvariantCulture), font, solidBrushWeekend,
                                         (15 + 80 * i), (80 + 60 * j));
                        }

                        num++;

                    }

                }
            }
        }

        //跳转到今天
        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, dtNow.Year, dtNow.Month);
            DrawDateNum(weekOfFirstDay, daysOfMonth, dtNow.Year, dtNow.Month);
            dtInfo = dtNow;
            panelDateInfo.Refresh();
            panelCalendarInfo.Refresh();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //选择年份
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag = false;
            var cmbSelectYear = sender as ComboBox;
            selectYear = (int)cmbSelectYear.SelectedItem;
            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, selectYear, selectMonth);
            DrawDateNum(weekOfFirstDay, daysOfMonth, selectYear, selectMonth);
            //Crawl();
            
        }

        //选择月份
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag = false;
            var cmbSelectMonth = sender as ComboBox;
            selectMonth = (int)cmbSelectMonth.SelectedItem;
            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, selectYear, selectMonth);
            DrawDateNum(weekOfFirstDay, daysOfMonth, selectYear, selectMonth);
            //Crawl();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //绘制日期
        private void panelDateInfo_Paint(object sender, PaintEventArgs e)
        {
            ChineseCalendar cc = new ChineseCalendar(dtInfo);
            string dateString = cc.DateString; //阳历
            string chineseDateString = cc.ChineseDateString; //农历
            string dateHoliday = cc.DateHoliday; //阳历节日
            string chineseTwentyFourDay = cc.ChineseTwentyFourDay; //农历节日
            string constellation = cc.Constellation; //星座
            string weekDayString = cc.WeekDayStr; //星期
            string ganZhiDateString = cc.GanZhiDateString;
            string animalString = cc.AnimalString;
            string chineseConstellation = cc.ChineseConstellation;

            //Image nba1 = ZoomPicture(Properties.Resources.nba5, 179, 391);

            //var tb = new TextureBrush(nba1, WrapMode.TileFlipXY);

            //Graphics g1 = e.Graphics;
            //g1.FillRectangle(tb, 0, 0, 179, 391);


            if (panelDateInfo != null)
            {
                Graphics g = panelDateInfo.CreateGraphics();
                if (dateString != null)
                    g.DrawString(dateString, new Font("华文琥珀", 12), new SolidBrush(Color.Sienna), 8, 10);
                g.DrawString( weekDayString, new Font("华文琥珀", 15), new SolidBrush(Color.Sienna), 57, 40);
                g.DrawString(dtInfo.ToString("dd"), new Font("", 45 ),
                             new SolidBrush(Color.DarkGray), 54, 60);
                var family = new FontFamily("华文琥珀");
                g.DrawString(chineseDateString.Substring(7, chineseDateString.Length - 7), new Font(family, 14 ),
                             new SolidBrush(Color.BurlyWood), 45, 120);
                //g.DrawString(constellation, new Font(family, 9), new SolidBrush(Color.Goldenrod), 60, 120);
                g.DrawString(ganZhiDateString.Substring(0, 3) + " 【" + animalString + "年】", new Font(family, 14 ),
                             new SolidBrush(Color.BurlyWood), 27, 150);
                g.DrawString(ganZhiDateString.Substring(3, ganZhiDateString.Length - 3), new Font(family, 14 ),
                             new SolidBrush(Color.BurlyWood), 35, 180);
                g.DrawString(constellation + "   " + chineseConstellation, new Font(family, 14),
                             new SolidBrush(Color.BurlyWood), 27, 210);
                //g.DrawString(chineseConstellation, new Font(family, 10), new SolidBrush(Color.Goldenrod), 50, 180);

                g.DrawString(chineseTwentyFourDay, new Font(family, 10), new SolidBrush(Color.Goldenrod), 40, 200);
            }
        }
        
        //点击日期
        private void panelMonthInfo_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.X + "\n" + e.Y);
            if (e.Button == MouseButtons.Left)
            {


                if (e.X < 10 || e.X > 575)
                {
                    return;
                }
                if (e.Y < 75 || e.Y > 435)
                {
                    return;
                }
                int x = (e.X - 10) / 80;
                int y = (e.Y - 75) / 60;
                if (dateArray[x, y] == null)
                {
                    return;
                }
                DateTime dtSelect = DateTime.Parse(dateArray[x, y]);
                dtInfo = dtSelect;
                // DrawDateInfo(dtSelect);
            }
            panelDateInfo.Refresh();
            panelCalendarInfo.Refresh();
        }

        //绘制月历
        private void panelMonthInfo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var pen1 = new Pen(Color.Blue, 2);
            var pen = new Pen(Color.FromArgb(255, 235, 211), 4);

           
            //g.DrawImage(new Bitmap(Properties.Resources.xionglu1), 0, 0);
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            //this.BackgroundImage = Image.FromFile(@"G:\virsual studio\C#source\NBACalendar\NBACalendar\Resources\xionglu1.jpg");
            //BackgroundImageLayout = ImageLayout.Stretch;

            //var tb = new TextureBrush(global::NBACalendar.Properties.Resources.NBABG, WrapMode.TileFlipXY);
            //g.FillRectangle(tb, 0, 0, 750, 475);

            //g.FillRectangle(new SolidBrush(Color.LightCyan), 5, 40, 740, 400);

            SolidBrush sb = new SolidBrush(Color.FromArgb(50, 255, 247, 241));
            g.FillRectangle(sb, 10, 45, 560, 30);

            //画横线
            g.DrawLine(pen, 10, 45, 570, 45);
            g.DrawLine(pen, 10, 75, 570, 75);
            for (int i = 1; i < 7; i++)
            {
                g.DrawLine(pen, 10, 75 + 60 * i, 570, 75 + 60 * i);
            }


            //画竖线
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(pen, 10 + 80 * i, 45, 10 + 80 * i, 435);
            }


            var solidBrushWeekday = new SolidBrush(Color.White);
            var solidBrushWeekend = new SolidBrush(Color.Brown);
            g.DrawString("日", new Font("华文琥珀", 12), solidBrushWeekend, 35, 50);
            g.DrawString("一", new Font("华文琥珀", 12), solidBrushWeekday, 115, 50);
            g.DrawString("二", new Font("华文琥珀", 12), solidBrushWeekday, 195, 50);
            g.DrawString("三", new Font("华文琥珀", 12), solidBrushWeekday, 275, 50);
            g.DrawString("四", new Font("华文琥珀", 12), solidBrushWeekday, 355, 50);
            g.DrawString("五", new Font("华文琥珀", 12), solidBrushWeekday, 435, 50);
            g.DrawString("六", new Font("华文琥珀", 12), solidBrushWeekend, 515, 50);

            if (flag)
            {
                GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, dtNow.Year, dtNow.Month);
                DrawDateNum(weekOfFirstDay, daysOfMonth, dtNow.Year, dtNow.Month);
                //DrawDateInfo(dtNow);
            }
            

        }

        //绘制NBA赛程
        private void panelCalendarInfo_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            var pen = new Pen(Color.FromArgb(255, 235, 211), 1);

            var pen1 = new Pen(Color.LightCoral, 4);
            var pen2 = new Pen(Color.SandyBrown, 10);


            //g.FillRectangle(tb, 0, 0, 150, 350);
            //g.FillRectangle(tb, 600, 0, 150, 350);

            Font myFont = new Font("华文琥珀", 12);
            Brush bush = new SolidBrush(Color.SteelBlue);//填充的颜色
            Brush bush1 = new SolidBrush(Color.Sienna);//填充的颜色
            Brush bush2 = new SolidBrush(Color.Salmon);//填充的颜色
            Font myFont1 = new Font("华文琥珀", 30);
            Font myFont2 = new Font("华文琥珀", 24);

            g.DrawString("今", myFont1, bush1, 50, 100);
            g.DrawString("日", myFont1, bush1, 50, 160);
            g.DrawString("赛", myFont1, bush1, 50, 220);
            g.DrawString("程", myFont1, bush1, 50, 280);
            g.DrawLine(pen2, 110, 95, 110, 320);


            if (File.Exists(@"F:\Schedule\" + selectYear.ToString() + "-" + selectMonth.ToString() + ".txt"))
            {
                StreamReader r = new StreamReader(@"F:\Schedule\" + selectYear.ToString() + "-" + selectMonth.ToString() + ".txt", Encoding.UTF8);
                string s = "";
                int x = 0;
                int y = 0;
                int k = 0;
                while ((s = r.ReadLine()) != null)
                {
                    string getStr = s.Substring(0, 5);
                    if (getStr == dtInfo.ToString("MM-dd"))
                    {
                        g.DrawString(s.ToString(), myFont, bush, 140, 100 + y);
                       
                        y = y + 25;
                        g.DrawLine(pen1, 115, 95 + y, 405, 95 + y);
                        k++;
                    }
                }
                if(k==0)
                {
                    g.DrawString("今日没有NBA比赛！", myFont2, bush2, 120, 190);
                }
            }

            else
            {
                g.DrawString("今日没有NBA比赛！", myFont2, bush2, 120, 190);
            }
            
           
        }

        public bool UrlIsExist(string URL)
        {
            try
            {
                WebRequest request = WebRequest.Create(URL);
                request.Timeout = 10000;
                WebResponse response = request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //按比例缩放图片
          public Image ZoomPicture(Image SourceImage, int TargetWidth, int TargetHeight)
          {
            int IntWidth; //新的图片宽
            int IntHeight; //新的图片高
            try
            {
                System.Drawing.Imaging.ImageFormat format = SourceImage.RawFormat;
                System.Drawing.Bitmap SaveImage = new System.Drawing.Bitmap(TargetWidth, TargetHeight);
                Graphics g = Graphics.FromImage(SaveImage);
                g.Clear(Color.White);


                if (SourceImage.Width > TargetWidth && SourceImage.Height <= TargetHeight)//宽度比目的图片宽度大，长度比目的图片长度小
                {
                    IntWidth = TargetWidth;
                    IntHeight = (IntWidth * SourceImage.Height) / SourceImage.Width;
                }
                else if (SourceImage.Width <= TargetWidth && SourceImage.Height > TargetHeight)//宽度比目的图片宽度小，长度比目的图片长度大
                {
                    IntHeight = TargetHeight;
                    IntWidth = (IntHeight * SourceImage.Width) / SourceImage.Height;
                }
                else if (SourceImage.Width <= TargetWidth && SourceImage.Height <= TargetHeight) //长宽比目的图片长宽都小
                {
                    IntHeight = SourceImage.Width;
                    IntWidth = SourceImage.Height;
                }
                else//长宽比目的图片的长宽都大
                {
                    IntWidth = TargetWidth;
                    IntHeight = (IntWidth * SourceImage.Height) / SourceImage.Width;
                    if (IntHeight > TargetHeight)//重新计算
                    {
                        IntHeight = TargetHeight;
                        IntWidth = (IntHeight * SourceImage.Width) / SourceImage.Height;
                    }
                }

                g.DrawImage(SourceImage, (TargetWidth - IntWidth) / 2, (TargetHeight - IntHeight) / 2, IntWidth, IntHeight);
                SourceImage.Dispose();

                return SaveImage;
            }
            catch (Exception ex)
            {

            }

            return null;
        }



        //爬虫
        //public void Crawl()
        //{
        //    //Crawler myCrawler = new Crawler();
        //    int month = selectMonth;
        //    int year = selectYear;
        //    int year1 = selectYear + 1;
        //    string startUrl = "http://www.uhchina.com/lanqiu/" + year + "-" + year1 + "nbachangguisai" + month;
        //    bool isExist = UrlIsExist(startUrl);

        //    if (isExist)
        //    {
        //        HttpWebRequest request = WebRequest.Create(startUrl) as HttpWebRequest;
        //        request.UserAgent = @"Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)";
        //        //发送请求并获取相应回应数据
        //        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        //        Stream responseStream = response.GetResponseStream();
        //        StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);

        //        //返回结果网页（html）代码

        //        string content = sr.ReadToEnd();
        //        var list = new List<string>();
        //        StreamWriter f = new StreamWriter(@"F:\Schedule\" + selectYear.ToString()+"-"+selectMonth.ToString() + ".txt", false, Encoding.UTF8);

        //        if (content != "")
        //        {
        //            Regex reg = new Regex("(?is)(?<=<table[^>]*?[^>]*?>(?:(?!</?table).)*)(?is)<tr[^>]*?[^>]*?>(?:\\s*<td[^>]*>(.*?)</td>)*\\s*</tr>");

        //            MatchCollection mc = reg.Matches(content);

        //            //foreach (var item in mc)
        //            //{
        //            //    Console.WriteLine(item.ToString());
        //            //}



        //            foreach (Match mat in mc)
        //            {
        //                try
        //                {
        //                    Regex reg1 = new Regex("<td><a\\s+(.*?)+>(?<name>(.*?))</a></td>");
        //                    Regex reg2 = new Regex("<b\\s(.*?)>(?<score>(.*?))</b>");
        //                    Regex reg3 = new Regex("<td>(?<date>(.*?))</td><td><a\\s+(.*?)+>");

        //                    Regex reg4 = new Regex("<td\\sonclick+(.*?)+>(?<name>(.*?))</td>");
        //                    Regex reg5 = new Regex("<td>(?<date>(.*?))</td><td\\sonclick+(.*?)+>");


        //                    MatchCollection names1 = reg1.Matches(mat.Value);
        //                    MatchCollection scores = reg2.Matches(mat.Value);
        //                    MatchCollection date1 = reg3.Matches(mat.Value);
        //                    MatchCollection names2 = reg4.Matches(mat.Value);
        //                    MatchCollection date2 = reg5.Matches(mat.Value);
        //                    if (names1.Count == 2)
        //                    {
        //                        if (scores.Count == 2)
        //                        {
        //                            f.WriteLine(date1[0].Result("${date}" + " ") + names1[0].Result("${name}") + " " + scores[0].Result("${score}")
        //                                + ":" + scores[1].Result("${score}") + " " + names1[1].Result("${name}"));
        //                        }
        //                    }
        //                    else if (names2.Count == 2)
        //                    {

        //                        if (scores.Count == 2)
        //                        {
        //                            f.WriteLine(date2[0].Result("${date}" + " ") + names2[0].Result("${name}") + " " + scores[0].Result("${score}")
        //                                + ":" + scores[1].Result("${score}") + " " + names2[1].Result("${name}"));
        //                        }
        //                    }
        //                    //else if(date1.Count==1)
        //                    //{
        //                    //    if (scores.Count == 2)
        //                    //    {
        //                    //        f.WriteLine(date1[0].Result("${date}" + " ") + names2[0].Result("${name}") + " " + scores[0].Result("${score}")
        //                    //            + ":" + scores[1].Result("${score}") + " " + names1[0].Result("${name}"));
        //                    //    }
        //                    //}

        //                }
        //                catch (Exception e)
        //                {
        //                    f.WriteLine(e.Message);
        //                    f.WriteLine("正在解析" + mat.ToString());
        //                }

        //            }
        //            f.Close();
        //        }
        //    }


        //}
    }
}
