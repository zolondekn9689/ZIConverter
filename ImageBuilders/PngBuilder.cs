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
    class PngBuilder : ImageBuilder
    {
        public PngBuilder() : base(ImageFormat.Png)
        { 
        }

    }
}
