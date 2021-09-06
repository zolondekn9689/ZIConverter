using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;

namespace WpfApp2
{
    class ImageConversion
    {
        public ImageConversion()
        {

        }



       


        /**
         * dir: directory with filename excluded.
         * @filename: Include extension.
         * **/
        static public void ConvertImage(string dir, string filename, ImageFormat format)
        {

            
            string childDirectory = dir + @"\" + format.ToString();


            string filename_path = FileParser.BuildFilePath(dir, filename);

            // What you want the name stored.
            string newFileName = FileParser.GetFileNameWithoutExtension(filename) + "." + format.ToString();

           
            try
            {
                
                
                Image im = Image.FromFile(filename_path);
                im.Save(childDirectory + @"\" + newFileName, format);
            }catch(IOException e)
            {
                
                MessageBox.Show(e.Source.ToString(), "Failed");
            }
            
        }




    }
}
