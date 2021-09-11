using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.ImageBuilders;

namespace WpfApp2
{
    class JpgBuilder : ImageBuilder
    {
       public JpgBuilder() : base(ImageFormat.Jpeg)
        {}

    }
}
