using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
namespace Services.Student
{
 public   class Base64ToImage
    {

        public static string BaseToImage(string imagestr)
        {
            try
            {
                string DefaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"); //HttpContext.Current.Server.MapPath("~/c:/image");

                byte[] bytes = Convert.FromBase64String(imagestr);
                string name;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    Image pic = Image.FromStream(ms);
                    name = Guid.NewGuid().ToString();
                    DefaultImagePath = DefaultImagePath + @"\\" + name + ".jpg";
                    pic.Save(DefaultImagePath);
                }
                return name;

            }
            catch (Exception ex)
            {

                return null;

            }
        }
    }
}
