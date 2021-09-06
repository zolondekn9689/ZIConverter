using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Drawing.Imaging;
using System.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> files;
        private string dir;
        private string Selected_Filename;

        public MainWindow()
        {
            InitializeComponent();
            files = new List<string>();
        }

        
        


        

        // Ask user to find destinated file location.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Images Files (*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif)|*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif" +
            "|PNG Portable Network Graphics (*.png)|*.png" +
            "|JPEG File Interchange Format (*.jpg *.jpeg *jfif)|*.jpg;*.jpeg;*.jfif" +
            "|BMP Windows Bitmap (*.bmp)|*.bmp" +
            "|TIF Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff" +
            "|GIF Graphics Interchange Format (*.gif)|*.gif";
            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;


            if (openFileDialog.ShowDialog() == true)
            {
                
                string path = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                this.Selected_Filename = openFileDialog.SafeFileName;
                
                folderBox.Text = path;
                dir = path;
            }
        }





        // Convert entire folder.
        private void Button_ConvertClick(object sender, RoutedEventArgs e)
        {
            
            if (menu_option_jpg.IsChecked)
            {
                MakeDirectory(ImageFormat.Jpeg);

                Thread t = new Thread(() => GenerateFile(ImageFormat.Jpeg));
                t.Start();

                

            }
            if (menu_option_png.IsChecked)
            {
                
                // Make a PNG directory and navigate through the files.
                MakeDirectory(ImageFormat.Png);
                Thread t = new Thread(() => GenerateFile(ImageFormat.Png));
                t.Start();

                

            }

            if (menu_option_tif.IsChecked)
            {
                // Make a TIF directory and navigate through the files.
            }




        }


        public bool MakeDirectory(ImageFormat formatType)
        {
            

            string newDir = dir + @"\" + formatType.ToString();

            // Make directory
            if (!Directory.Exists(newDir))
            {
                
                Directory.CreateDirectory(newDir);
                

                return true;
            }
            else
            {
                MessageBox.Show("A directory already exists. ");
                //TODO Add a menu setting that decide what to do here.
                return false;
            }

        }




        /**
         * Use this to go through files and generate a file.
         * */
        private void GenerateFile(ImageFormat imageType)
        {
            string[] filePaths = Directory.GetFiles(dir, "*.tif",
                                        SearchOption.TopDirectoryOnly);


            foreach (string x in filePaths)
            {
                ImageConversion.ConvertImage(dir, FileParser.GetFileName(x), imageType);
                if (FileParser.ExistsChildImage(dir, FileParser.GetFileName(x), imageType))
                {
                    
                }
                else
                {
                    MessageBox.Show("Duplicate Error");
                    return;
                }

            }

        }

    }
}
