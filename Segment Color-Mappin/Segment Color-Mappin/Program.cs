using ImageCompressionApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Segment_Color_Mappin
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new SearchForm());
            //Application.Run(new PDFCompressionForm());
            //Application.Run(new ImageCompressionForm());
            //Application.Run(new VoiceCompressionForm());
            Application.Run(new ImageCompare());
        }
    }
}
