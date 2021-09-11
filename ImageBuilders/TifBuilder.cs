using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.ImageBuilders
{
    class TifBuilder : ImageBuilder
    {

        public TifBuilder() : base(ImageFormat.Tiff)
        {}
    }
}
