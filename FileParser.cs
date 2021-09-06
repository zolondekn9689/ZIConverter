using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class FileParser
    {



        public static string GetExtension(string filepath)
        {
            string[] names = filepath.Split('.');
            return names[names.Length - 1]; 
        }


        public static string GetFileName(string filepath)
        {
            string[] names = filepath.Split('\\');
            return names[names.Length - 1];
        }


        public static string GetFileNameWithPathWithoutExtension(string filepath)
        {
            string[] names = filepath.Split('\\');
            string n = names[names.Length - 1];
            string[] removeExtension = n.Split('.');

            return removeExtension[0];
        }

        public static string GetFileNameWithoutExtension(string filename)
        {
            
            
            string[] removeExtension = filename.Split('.');
            return removeExtension[0];
        }



        public static string BuildFilePath(string dir, string filename)
        {
            return (dir + @"\" + filename);
        }


        public static bool ExistsChildImage(string dir, string filename, ImageFormat type)
        {
            // Step 1:
            string nextDirectory = dir + @"\" + type.ToString();

            if (Directory.Exists(nextDirectory))
            {
                
                string childPath = nextDirectory + @"\" + GetFileNameWithoutExtension(filename) + "." + type.ToString();
                if (File.Exists(childPath))
                {
                    return true;
                }
            }
            return false;
        }
        


        public ImageFormat GetImageFormat(string filename)
        {

            ImageFormat[] types = ImageFormatList();

            string ext1 = GetExtension(filename.ToLower());
            

            foreach (var ext in types)
            {
                if (ext.ToString().ToLower() == ext1)
                {
                    return ext;
                }

                if (ext1 == ".tif")
                {
                    return types[2];
                }
            }



            return null;
        }




        public ImageFormat[] ImageFormatList()
        {
            ImageFormat[] types = { ImageFormat.Jpeg, ImageFormat.Gif, ImageFormat.Tiff, ImageFormat.Bmp, ImageFormat.Jpeg };
            return types;
        }
    }
}
