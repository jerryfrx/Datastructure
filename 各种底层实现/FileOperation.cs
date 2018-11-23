using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavaProcessToFile {
    class Program {
        /// <summary>
        /// 保存数据data到文件的处理过程；
        /// </summary>
        /// <param name="data"></param>
        public static string SavaProcess(string data) {
            //System.DateTime currentTime = System.DateTime.Now;
            //获取当前日期的前一天转换成ToFileTime
            //string strYMD = currentTime.AddDays(-1).ToString("yyyyMMdd");
            //按照日期建立一个文件名
            string FileName = "MyFileSend" + ".txt";
            //设置目录
            string CurDir = System.AppDomain.CurrentDomain.BaseDirectory + @"SaveDir" + @"\";
            //判断路径是否存在
            if (!System.IO.Directory.Exists(CurDir)) {
                System.IO.Directory.CreateDirectory(CurDir);
            }
            //不存在就创建
            string FilePath = CurDir + FileName;
            Console.WriteLine(FilePath);
            //文件追加方式添加内容
            System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath, true);
            //保存数据到文件
            file.Write(data);
            //关闭文件
            file.Close();
            //释放对象
            file.Dispose();

            return FilePath;
        }

        /// <summary>
        /// 获取文件中的数据
        /// </summary>
        /// <param name="args"></param>
        public static string fileToString(String filePath) {
            string strData = "";
            try {
                string line;
                // 创建一个 StreamReader 的实例来读取文件 ,using 语句也能关闭 StreamReader
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath)) {
                    // 从文件读取并显示行，直到文件的末尾 
                    while ((line = sr.ReadLine()) != null) {
                        //Console.WriteLine(line);
                        strData = line;
                    }
                }
            }
            catch (Exception e) {
                // 向用户显示出错消息
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return strData;
        }

        static void Main(string[] args) {
            string data = "第二次";
            String filePath = SavaProcess(data);
            string strData = fileToString(filePath);
            Console.WriteLine(strData);
        }
    }
}
