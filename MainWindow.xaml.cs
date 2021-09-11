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
using WpfApp2.ImageBuilders;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        private OpenFileDialog dialog;
        private ImageFormat currentFormatSelected;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Makes all menu options visible.
        /// </summary>
        private void Enable()
        {
            menu_option_bmp.Visibility = Visibility.Visible;
            menu_option_jpg.Visibility = Visibility.Visible;
            menu_option_tif.Visibility = Visibility.Visible;
            menu_option_png.Visibility = Visibility.Visible;
        }
        

        /// <summary>
        /// disables the image format that is being used.
        /// </summary>
        private void Cancelize()
        {

            Enable();

            if (currentFormatSelected == ImageFormat.Jpeg)
            {
                menu_option_jpg.Visibility = Visibility.Hidden;
                menu_option_jpg.IsChecked = false;
            } 
            if (currentFormatSelected == ImageFormat.Png)
            {
                menu_option_png.Visibility = Visibility.Hidden;
                menu_option_png.IsChecked = false;

            }
            if (currentFormatSelected == ImageFormat.Bmp)
            {
                menu_option_bmp.Visibility = Visibility.Hidden;
                menu_option_bmp.IsChecked = false;
            }
            if (currentFormatSelected == ImageFormat.Tiff)
            {
                menu_option_tif.Visibility = Visibility.Hidden;
                menu_option_tif.IsChecked = false;
            }

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
                this.dialog = openFileDialog;
                folderBox.Text = path;
            }
            currentFormatSelected = FileParser.GetImageFormat(openFileDialog.FileName);
            Cancelize();
        }





        // Convert entire folder of images.
        private void Button_ConvertClick(object sender, RoutedEventArgs e)
        {
            
            if (menu_option_jpg.IsChecked)
            {
                //MakeDirectory(ImageFormat.Jpeg);

                Thread t = new Thread(() => GenerateFile(ImageFormat.Jpeg));
                t.Start();

            }
            if (menu_option_png.IsChecked)
            {
                
                // Make a PNG directory and navigate through the files.
                Thread t = new Thread(() => GenerateFile(ImageFormat.Png));
                t.Start();
            }

            if (menu_option_bmp.IsChecked)
            {
                Thread t = new Thread(() => GenerateFile(ImageFormat.Bmp));
                t.Start();
            }

            if (menu_option_tif.IsChecked)
            {
                // Make a TIF directory and navigate through the files.
            }




        }






        /**
         * Use this to go through files and generate a file.
         */
        private void GenerateFile(ImageFormat imageType)
        {
            string dir = System.IO.Path.GetDirectoryName(this.dialog.FileName);
            string[] filePaths = Directory.GetFiles(dir, "*.tif",
                                        SearchOption.TopDirectoryOnly);

            ImageBuilder builder = null;

            if (imageType == ImageFormat.Png)
                builder = new PngBuilder();
            if (imageType == ImageFormat.Jpeg)
                builder = new JpgBuilder();
            if (imageType == ImageFormat.Bmp)
                builder = new BmpBuilder();



            if (builder != null)
            {
                foreach (string x in filePaths)
                {
                    builder.BuildImageInDirectory(x);
                }

                MessageBox.Show("Conversion Completed Successfully!");
            }

        }




        /***
         * This click handler converts one image.
         * */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Path.GetFullPath(dialog.FileName);


            if (menu_option_jpg.IsChecked)
            {
                JpgBuilder builder = new JpgBuilder();
                builder.BuildImageInDirectory(path);
            }

            if (menu_option_png.IsChecked)
            {
                PngBuilder builder = new PngBuilder();
                builder.BuildImageInDirectory(path);
            }
            if (menu_option_bmp.IsChecked)
            {
                BmpBuilder builder = new BmpBuilder();
                builder.BuildImageInDirectory(path);
            }

        }

        
    }
}
