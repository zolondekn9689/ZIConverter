using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2.ImageBuilders
{
    class ImageBuilder
    {
        private ImageFormat format;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        public ImageBuilder(ImageFormat format)
        {
            this.format = format;
        }

        /// 
        /// <summary>
        /// Builds a singular image from a file path that includes file.
        /// </summary>
        /// <param name="target_filepath">full file path of the image with extension.</param>
        public void BuildImage(string target_filepath)
        {

            string dir = FileParser.GetDirectory(target_filepath);
            string filename = FileParser.GetFileName(target_filepath);

            string filename_path = target_filepath;

            // What you want the name stored.
            string dest_filepath = dir + "\\" + FileParser.GetFileNameWithoutExtension(filename) + "." + format.ToString();

            try
            {

                Image im = Image.FromFile(filename_path);
                im.Save(dest_filepath, format);
            }
            catch (IOException e)
            {

                MessageBox.Show(e.Source.ToString(), "Failed");
            }
            
        }

        // Given the target file you want to copy.
        public string BuildDirectory(string target_filepath)
        {
            string dir = FileParser.GetDirectory(target_filepath) + "\\" + format.ToString();


            // Make directory
            if (!Directory.Exists(dir))
            {

                Directory.CreateDirectory(dir);

            }
            else
            {
                MessageBox.Show("A directory already exists. ");
                //TODO Add a menu setting that decide what to do here.

            }
            return dir;
        }

        // target file_path is the file you want to copy. Destination Directory is the name of the directory you want to save files into.
        public void BuildImageInDirectory(string target_filepath)
        {
            string perm_dir = FileParser.GetDirectory(target_filepath) + "\\" + format.ToString();
            if (!Directory.Exists(perm_dir))
            {
                perm_dir = BuildDirectory(target_filepath);
            }

            string filename = FileParser.GetFileName(target_filepath);

            string filename_path = target_filepath;

            // What you want the name stored.

            string dest_filepath = perm_dir + "\\" + FileParser.GetFileNameWithoutExtension(filename) + "." + format.ToString();

            try
            {

                Image im = Image.FromFile(filename_path);
                im.Save(dest_filepath, format);
            }
            catch (IOException e)
            {

                MessageBox.Show(e.Source.ToString(), "Failed");
            }
        }



    }
}
