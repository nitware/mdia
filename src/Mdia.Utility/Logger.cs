using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Utility.Interfaces;

namespace Mdia.Utility
{
    public class Logger : ILogger
    {
        private readonly IFileManager _file;

        public Logger(IFileManager file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }

            _file = file;
        }

        public void LogError(Exception ex)
        {
            try
            {
                DateTime currentDate = DateTime.Now;

                string year = AppUtil.PaddNumber(currentDate.Year, 4);
                string month = AppUtil.PaddNumber(currentDate.Month, 2);
                string day = AppUtil.PaddNumber(currentDate.Month, 2);
                string hour = AppUtil.PaddNumber(currentDate.Hour, 2);
                string minute = AppUtil.PaddNumber(currentDate.Minute, 2);
                string second = AppUtil.PaddNumber(currentDate.Second, 2);
                string millisecond = AppUtil.PaddNumber(currentDate.Millisecond, 3);

                string folderPath = _file.BasePath + @"Content\" + _file.LogFolderPath;
                string date = year + month + day + hour + minute + second + millisecond;
                string file = folderPath + @"\EL_" + date + ".txt";

                _file.CreateFolderIfNeeded(folderPath);
                _file.CreateLog(file, ex.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
