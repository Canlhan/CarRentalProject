using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelpers
{
    public class FileHelper
    {
        static string uploadPath = Environment.CurrentDirectory + @"\wwwroot\images\";
        public static string newPath( IFormFile file)
        {
          
            
            
            
            // var sourcepath = @"C:\\Users\\ilhan\\source\\repos\\RecapHome\\"+images.Name;
            var sourcepath = Path.GetTempFileName();
            
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            var newFileName = Guid.NewGuid().ToString()+new FileInfo(file.FileName).Extension;
            File.Move(sourcepath,uploadPath+newFileName);
                                                                                                                                                                                                                                                                            
            return newFileName;
        }
        public static string Update(string sourcepath,IFormFile file)
        {
            var result = newPath(file);
            if (sourcepath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcepath);
            return result;
            
        }

    }
}
