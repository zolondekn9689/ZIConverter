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
        class ZFile
        {
            public string directory;
            public string filename;
            public string extension;
        }

        /***
         * Absolute filepath: The windows file path that includes the directory with filename with extension.
         **/
        public static string GetDirectory(string absolute_filepath)
        {
            return GetDirectoryInfo(absolute_filepath).directory;
        }



        public static string GetFileName(string absolute_filepath)
        {
            return GetDirectoryInfo(absolute_filepath).filename;
        }


        private static ZFile GetDirectoryInfo(string absolute_filepath)
        {
            string[] directory = absolute_filepath.Split("\\");
            string dir = "";
            string filename = "";

            for (int index = 0; index < directory.Length - 1; index++)
            {
                if (index == directory.Length - 2)
                {
                    dir += directory[index];
                } else
                {
                    dir += directory[index] + @"\";
                }
               
            }

            // Store filename;
            filename = directory[directory.Length - 1];

            ZFile f = new ZFile();
            f.directory = dir;
            f.filename = filename;
            f.extension = GetExtension(absolute_filepath);
            return f;
        }

        public static string GetExtension(string filepath)
        {
            string[] names = filepath.Split('.');
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


        

        /// <summary>
        /// Gets the ImageFormat type from any filename.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static ImageFormat GetImageFormat(string filename)
        {

            string extension = Path.GetExtension(filename);
            if (string.IsNullOrEmpty(extension))
                throw new ArgumentException(
                    string.Format("Unable to determine file extension for fileName: {0}", filename));

            switch (extension.ToLower())
            {
                case @".bmp":
                    return ImageFormat.Bmp;

                case @".gif":
                    return ImageFormat.Gif;

                case @".ico":
                    return ImageFormat.Icon;

                case @".jpg":
                case @".jpeg":
                    return ImageFormat.Jpeg;

                case @".png":
                    return ImageFormat.Png;

                case @".tif":
                case @".tiff":
                    return ImageFormat.Tiff;

                case @".wmf":
                    return ImageFormat.Wmf;

                default:
                    throw new NotImplementedException();
            }
        }




        public ImageFormat[] ImageFormatList()
        {
            ImageFormat[] types = { ImageFormat.Jpeg, ImageFormat.Gif, ImageFormat.Tiff, ImageFormat.Bmp, ImageFormat.Jpeg };
            return types;
        }
    }
}
