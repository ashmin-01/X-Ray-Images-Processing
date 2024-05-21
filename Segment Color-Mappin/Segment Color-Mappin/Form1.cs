using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Segment_Color_Mappin
{
    public partial class Form1 : Form
    {
        private Rectangle selectedRectangle;
        private bool isSelecting = false;
        private Point startPoint;
        private Bitmap rgbImage;
        public Form1()
        {
            InitializeComponent();
            image1.MouseDown += image1_MouseDown;
            image1.MouseMove += image1_MouseMove;
            image1.MouseUp += image1_MouseUp;
            image1.Paint += image1_Paint;

        }
        private void image1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("aaaaaaaaaaaaaaaaa");
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                isSelecting = true;
            }
        }

        private void image1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                int x = Math.Min(e.X, startPoint.X);
                int y = Math.Min(e.Y, startPoint.Y);
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);

                //Console.WriteLine("x: " + x , "y: " + y , "startPoint.X" + startPoint.X + "startPoint.Y" + startPoint.Y);

                selectedRectangle = new Rectangle(x, y, width, height);
                image1.Invalidate();
            }
        }

        private void image1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isSelecting = false;
            }
        }

        private void image1_Paint(object sender, PaintEventArgs e)
        {
            if (selectedRectangle.Width > 0 && selectedRectangle.Height > 0)
            {
                using (Pen pen = new Pen(Color.Yellow))
                {
                    e.Graphics.DrawRectangle(pen, selectedRectangle);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = dialog.FileName;
                    rgbImage = new Bitmap(imagePath);
                    image1.SizeMode = PictureBoxSizeMode.StretchImage;
                    image1.Image = rgbImage;
                }
            }

            catch (Exception)
            {
                MessageBox.Show("WTF");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Console.WriteLine("FFFFFFFFFF");

        }

        private Color GetGradientColor(int intensity)
        {
            int minIntensity = 0;
            int maxIntensity = 255;

            double ratio = (double)(intensity - minIntensity) / (maxIntensity - minIntensity);

            if (intensity >= 200)
            {
                int red = 255;
                int green = (int)(255 * (1 - ratio));
                int blue = (int)(255 * (1 - ratio));
                return Color.FromArgb(red, green, blue);
            }

            else if (intensity >= 128)
            {
                int red = 255;
                int green = (int)(255 * ratio);
                int blue = 0;
                return Color.FromArgb(red, green, blue);
            }
            else if (intensity >= 55)
            {
                int red = (int)(255 * (1 - ratio));
                int green = (int)(255 * (1 - ratio));
                int blue = 255;
                return Color.FromArgb(red, green, blue);
            }
            else
            {
                int red = 0;
                int green = (int)(255 * ratio);
                int blue = (int)(255 * (1 - ratio));
                return Color.FromArgb(red, green, blue);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColormap = comboBox1.SelectedItem.ToString();

            switch (selectedColormap)
            {
                case "Colormap 1":

                    ApplyColormap1();
                    break;
                
                case "Colormap 2":

                    ApplyColormap2();
                    break;

                case "Colormap 3":

                    ApplyColormap3();
                    break;

                case "Colormap 4":

                    ApplyColormap4();
                    break;
                case "Colormap 5":

                    ApplyColormap5();
                    break;
                case "Colormap 6":

                    ApplyColormap6();
                    break;
                case "Blue Colormap":

                    ApplyBlueColormap();
                    break;
                case "Yellow Colormap":

                    ApplyYellowColormap();
                    break;
                case "Red Colormap":

                    ApplyRedColormap();
                    break;

                case "Filter 1":

                    Filter1();
                    break;

                case "Filter 2":

                    Filter2();
                    break;
            }
        }

        private void ApplyColormap1()
        {
            if (selectedRectangle != null && selectedRectangle.Width > 0 && selectedRectangle.Height > 0)
            {
                Bitmap resultImage = new Bitmap(rgbImage);

                int startX = selectedRectangle.Left;
                int startY = selectedRectangle.Top;

                float scaleX = (float)rgbImage.Width / image1.DisplayRectangle.Width;
                float scaleY = (float)rgbImage.Height / image1.DisplayRectangle.Height;

                int originalStartX = (int)(startX * scaleX);
                int originalStartY = (int)(startY * scaleY);
                int originalEndX = (int)((startX + selectedRectangle.Width) * scaleX);
                int originalEndY = (int)((startY + selectedRectangle.Height) * scaleY);


                int originalWidth = originalEndX - originalStartX;
                int originalHeight = originalEndY - originalStartY;

                Color[] heatmapColors = new Color[256];
                for (int i = 0; i < 256; i++)
                {
                    if (i <= 127)
                    {
                        int red = 0;
                        int green = 255;
                        int blue = 0;
                        heatmapColors[i] = Color.FromArgb(red, green, blue);
                    }
                    else
                    {
                        int red = Math.Min(i * 2, 255);
                        int green = 0;
                        int blue = 0;
                        heatmapColors[i] = Color.FromArgb(red, green, blue);
                    }
                }

                int drawX = originalStartX;
                int drawY = originalStartY;
                for (int i = 0; i < originalHeight; i++)
                {
                    for (int j = 0; j < originalWidth; j++)
                    {
                        int originalX = originalStartX + j;
                        int originalY = originalStartY + i;

                        if (originalX >= 0 && originalX < rgbImage.Width && originalY >= 0 && originalY < rgbImage.Height)
                        {
                            Color pixelColor = rgbImage.GetPixel(originalX, originalY);
                            int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);

                            Color heatmapColor = GetGradientColor(intensity);

                            resultImage.SetPixel(drawX, drawY, heatmapColor);
                            drawX++;
                        }
                    }
                    drawX = originalStartX;
                    drawY++;
                }


                image1.Image = resultImage;

                try
                {
                    resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree3.jpg");
                }
                catch (Exception)
                {
                    MessageBox.Show("WTF");
                }
            }
        }

        private void Filter1()
        {
            Bitmap resultImage = new Bitmap(rgbImage);

            Color[] heatmapColors = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                if (i <= 63)
                {
                    int red = 0;
                    int green = i * 4; // Gradient from black to green
                    int blue = 0;
                    heatmapColors[i] = Color.FromArgb(red, green, blue);
                }
                else if (i <= 127)
                {
                    int red = 0;
                    int green = 255 - (i - 64) * 4; // Gradient from green to yellow
                    int blue = 0;
                    heatmapColors[i] = Color.FromArgb(red, green, blue);
                }
                else if (i <= 191)
                {
                    int red = (i - 128) * 4; // Gradient from yellow to red
                    int green = 255;
                    int blue = 0;
                    heatmapColors[i] = Color.FromArgb(red, green, blue);
                }
                else
                {
                    int red = 255;
                    int green = 255 - (i - 192) * 4; // Gradient from red to black
                    int blue = 0;
                    heatmapColors[i] = Color.FromArgb(red, green, blue);
                }
            }

            for (int y = 0; y < rgbImage.Height; y++)
            {
                for (int x = 0; x < rgbImage.Width; x++)
                {
                    Color pixelColor = rgbImage.GetPixel(x, y);
                    int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);

                    Color heatmapColor = heatmapColors[intensity];
                    resultImage.SetPixel(x, y, heatmapColor);
                }
            }

            image1.Image = resultImage;

            try
            {
                resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree3.jpg");
            }
            catch (Exception)
            {
                MessageBox.Show("WTF");
            }
        }




        private void ApplyColormap2()
        {
            if (selectedRectangle != null && selectedRectangle.Width > 0 && selectedRectangle.Height > 0)
            {
                Bitmap resultImage = new Bitmap(rgbImage);

                int startX = selectedRectangle.Left;
                int startY = selectedRectangle.Top;

                float scaleX = (float)rgbImage.Width / image1.DisplayRectangle.Width;
                float scaleY = (float)rgbImage.Height / image1.DisplayRectangle.Height;

                int originalStartX = (int)(startX * scaleX);
                int originalStartY = (int)(startY * scaleY);
                int originalEndX = (int)((startX + selectedRectangle.Width) * scaleX);
                int originalEndY = (int)((startY + selectedRectangle.Height) * scaleY);

                int originalWidth = originalEndX - originalStartX;
                int originalHeight = originalEndY - originalStartY;

                Color[] heatmapColors = new Color[256];
                for (int i = 0; i < 256; i++)
                {
                    if (i < 51)
                    {
                        heatmapColors[i] = Color.Blue; // Intensity 0-50: Blue
                    }
                    else if (i < 102)
                    {
                        heatmapColors[i] = Color.Cyan; // Intensity 51-101: Cyan
                    }
                    else if (i < 153)
                    {
                        heatmapColors[i] = Color.Green; // Intensity 102-152: Green
                    }
                    else if (i < 204)
                    {
                        heatmapColors[i] = Color.Yellow; // Intensity 153-203: Yellow
                    }
                    else
                    {
                        heatmapColors[i] = Color.Red; // Intensity 204-255: Red
                    }
                }

                int drawX = originalStartX;
                int drawY = originalStartY;
                for (int i = 0; i < originalHeight; i++)
                {
                    for (int j = 0; j < originalWidth; j++)
                    {
                        int originalX = originalStartX + j;
                        int originalY = originalStartY + i;

                        if (originalX >= 0 && originalX < rgbImage.Width && originalY >= 0 && originalY < rgbImage.Height)
                        {
                            Color pixelColor = rgbImage.GetPixel(originalX, originalY);
                            int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);
                            Color heatmapColor = heatmapColors[intensity];
                            resultImage.SetPixel(drawX, drawY, heatmapColor);
                            drawX++;
                        }
                    }
                    drawX = originalStartX;
                    drawY++;
                }

                image1.Image = resultImage;

                try
                {
                    resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree3.jpg");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error saving the image.");
                }
            }
        }

        private void Filter2()
        {
            Bitmap resultImage = new Bitmap(rgbImage);

            Color[] heatmapColors = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                if (i <= 63)
                {
                    int red = 255;
                    int green = 0;
                    int blue = 0;
                    heatmapColors[i] = Color.FromArgb(red, green, blue); // Gradient from black to red
                }
                else if (i <= 127)
                {
                    int red = 0;
                    int green = 255;
                    int blue = i * 2; // Gradient from red to blue
                    heatmapColors[i] = Color.FromArgb(red, green, blue);
                }
                else if (i <= 191)
                {
                    int red = 0;
                    int green = 255 - (i - 128) * 2; // Gradient from blue to cyan
                    int blue = 255;
                    heatmapColors[i] = Color.FromArgb(red, green, blue);
                }
                else
                {
                    int red = (i - 192) * 2; // Gradient from cyan to green
                    int green = 255;
                    int blue = 0;
                    heatmapColors[i] = Color.FromArgb(red, green, blue);
                }
            }

            for (int y = 0; y < rgbImage.Height; y++)
            {
                for (int x = 0; x < rgbImage.Width; x++)
                {
                    Color pixelColor = rgbImage.GetPixel(x, y);
                    int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);

                    Color heatmapColor = heatmapColors[intensity];
                    resultImage.SetPixel(x, y, heatmapColor);
                }
            }

            image1.Image = resultImage;

            try
            {
                resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree4.jpg");
            }
            catch (Exception)
            {
                MessageBox.Show("WTH.");
            }
        }


        private void ApplyColormap3()
        {
            if (selectedRectangle != null && selectedRectangle.Width > 0 && selectedRectangle.Height > 0)
            {
                Bitmap resultImage = new Bitmap(rgbImage);

                int startX = selectedRectangle.Left;
                int startY = selectedRectangle.Top;

                float scaleX = (float)rgbImage.Width / image1.DisplayRectangle.Width;
                float scaleY = (float)rgbImage.Height / image1.DisplayRectangle.Height;

                int originalStartX = (int)(startX * scaleX);
                int originalStartY = (int)(startY * scaleY);
                int originalEndX = (int)((startX + selectedRectangle.Width) * scaleX);
                int originalEndY = (int)((startY + selectedRectangle.Height) * scaleY);

                int originalWidth = originalEndX - originalStartX;
                int originalHeight = originalEndY - originalStartY;

                Color[] heatmapColors = new Color[256];
                for (int i = 0; i < 256; i++)
                {
                    if (i <= 127)
                    {
                        int red = 0;
                        int green = i * 2; // Gradient from black to green
                        int blue = 255 - i * 2; // Gradient from blue to black
                        heatmapColors[i] = Color.FromArgb(red, green, blue);
                    }
                    else
                    {
                        int red = (i - 128) * 2; // Gradient from black to red
                        int green = 255 - (i - 128) * 2; // Gradient from green to black
                        int blue = 0;
                        heatmapColors[i] = Color.FromArgb(red, green, blue);
                    }
                }

                int drawX = originalStartX;
                int drawY = originalStartY;
                for (int i = 0; i < originalHeight; i++)
                {
                    for (int j = 0; j < originalWidth; j++)
                    {
                        int originalX = originalStartX + j;
                        int originalY = originalStartY + i;

                        if (originalX >= 0 && originalX < rgbImage.Width && originalY >= 0 && originalY < rgbImage.Height)
                        {
                            Color pixelColor = rgbImage.GetPixel(originalX, originalY);
                            int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);
                            Color heatmapColor = heatmapColors[intensity];
                            resultImage.SetPixel(drawX, drawY, heatmapColor);
                            drawX++;
                        }
                    }
                    drawX = originalStartX;
                    drawY++;
                }

                image1.Image = resultImage;

                try
                {
                    resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree_colormap3.jpg");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error saving the image.");
                }
            }
        }

        private void ApplyColormap4()
        {
            if (selectedRectangle != null && selectedRectangle.Width > 0 && selectedRectangle.Height > 0)
            {
                Bitmap resultImage = new Bitmap(rgbImage);

                int startX = selectedRectangle.Left;
                int startY = selectedRectangle.Top;

                float scaleX = (float)rgbImage.Width / image1.DisplayRectangle.Width;
                float scaleY = (float)rgbImage.Height / image1.DisplayRectangle.Height;

                int originalStartX = (int)(startX * scaleX);
                int originalStartY = (int)(startY * scaleY);
                int originalEndX = (int)((startX + selectedRectangle.Width) * scaleX);
                int originalEndY = (int)((startY + selectedRectangle.Height) * scaleY);

                int originalWidth = originalEndX - originalStartX;
                int originalHeight = originalEndY - originalStartY;

                Color[] heatmapColors = new Color[256];
                for (int i = 0; i < 256; i++)
                {
                    if (i <= 127)
                    {
                        int red = i * 2; // Gradient from black to yellow (yellow is red + green)
                        int green = i * 2;
                        int blue = 0;
                        heatmapColors[i] = Color.FromArgb(red, green, blue);
                    }
                    else
                    {
                        int red = 0;
                        int green = 255 - (i - 128) * 2; // Gradient from yellow to cyan (cyan is green + blue)
                        int blue = (i - 128) * 2;
                        heatmapColors[i] = Color.FromArgb(red, green, blue);
                    }
                }

                int drawX = originalStartX;
                int drawY = originalStartY;
                for (int i = 0; i < originalHeight; i++)
                {
                    for (int j = 0; j < originalWidth; j++)
                    {
                        int originalX = originalStartX + j;
                        int originalY = originalStartY + i;

                        if (originalX >= 0 && originalX < rgbImage.Width && originalY >= 0 && originalY < rgbImage.Height)
                        {
                            Color pixelColor = rgbImage.GetPixel(originalX, originalY);
                            int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);
                            Color heatmapColor = heatmapColors[intensity];
                            resultImage.SetPixel(drawX, drawY, heatmapColor);
                            drawX++;
                        }
                    }
                    drawX = originalStartX;
                    drawY++;
                }

                image1.Image = resultImage;

                try
                {
                    resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree_colormap4.jpg");
                }
                catch (Exception)
                {
                    MessageBox.Show("WTH.");
                }
            }
        }

        private void ApplyColormap5()
        {
            Bitmap resultImage = new Bitmap(rgbImage);

            // Create the gradient color map from black to blue
            Color[] heatmapColors = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                int red = 0;
                int green = 0;
                int blue = i; // Gradient from black to blue
                heatmapColors[i] = Color.FromArgb(red, green, blue);
            }

            for (int y = 0; y < rgbImage.Height; y++)
            {
                for (int x = 0; x < rgbImage.Width; x++)
                {
                    Color pixelColor = rgbImage.GetPixel(x, y);
                    int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);
                    Color heatmapColor = heatmapColors[intensity];
                    resultImage.SetPixel(x, y, heatmapColor);
                }
            }

            image1.Image = resultImage;

            try
            {
                resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree_colormap5.jpg");
            }
            catch (Exception)
            {
                MessageBox.Show("WTH.");
            }
        }

        private void ApplyColormap6()
        {
            Bitmap resultImage = new Bitmap(rgbImage);

            // Create the gradient color map from black to green
            Color[] heatmapColors = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                int red = 0;
                int green = i; // Gradient from black to green
                int blue = 0;
                heatmapColors[i] = Color.FromArgb(red, green, blue);
            }

            for (int y = 0; y < rgbImage.Height; y++)
            {
                for (int x = 0; x < rgbImage.Width; x++)
                {
                    Color pixelColor = rgbImage.GetPixel(x, y);
                    int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);
                    Color heatmapColor = heatmapColors[intensity];
                    resultImage.SetPixel(x, y, heatmapColor);
                }
            }

            image1.Image = resultImage;

            try
            {
                resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree_colormap5.jpg");
            }
            catch (Exception)
            {
                MessageBox.Show("WTH.");
            }
        }

        private void ApplyBlueColormap()
        {
            if (selectedRectangle != null && selectedRectangle.Width > 0 && selectedRectangle.Height > 0)
            {
                Bitmap resultImage = new Bitmap(rgbImage);

                int startX = selectedRectangle.Left;
                int startY = selectedRectangle.Top;

                float scaleX = (float)rgbImage.Width / image1.DisplayRectangle.Width;
                float scaleY = (float)rgbImage.Height / image1.DisplayRectangle.Height;

                int originalStartX = (int)(startX * scaleX);
                int originalStartY = (int)(startY * scaleY);
                int originalEndX = (int)((startX + selectedRectangle.Width) * scaleX);
                int originalEndY = (int)((startY + selectedRectangle.Height) * scaleY);

                int originalWidth = originalEndX - originalStartX;
                int originalHeight = originalEndY - originalStartY;

                Color[] heatmapColors = new Color[256];
                for (int i = 0; i < 256; i++)
                {
                    int red = 0;
                    int green = 0;
                    int blue = i; // Gradient from black to blue
                    heatmapColors[i] = Color.FromArgb(red, green, blue);
                }

                int drawX = originalStartX;
                int drawY = originalStartY;
                for (int i = 0; i < originalHeight; i++)
                {
                    for (int j = 0; j < originalWidth; j++)
                    {
                        int originalX = originalStartX + j;
                        int originalY = originalStartY + i;

                        if (originalX >= 0 && originalX < rgbImage.Width && originalY >= 0 && originalY < rgbImage.Height)
                        {
                            Color pixelColor = rgbImage.GetPixel(originalX, originalY);
                            int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);
                            Color heatmapColor = heatmapColors[intensity];
                            resultImage.SetPixel(drawX, drawY, heatmapColor);
                            drawX++;
                        }
                    }
                    drawX = originalStartX;
                    drawY++;
                }

                image1.Image = resultImage;

                try
                {
                    resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree_colormap4.jpg");
                }
                catch (Exception)
                {
                    MessageBox.Show("WTH.");
                }
            }
        }

        private void ApplyYellowColormap()
        {
            if (selectedRectangle != null && selectedRectangle.Width > 0 && selectedRectangle.Height > 0)
            {
                Bitmap resultImage = new Bitmap(rgbImage);

                int startX = selectedRectangle.Left;
                int startY = selectedRectangle.Top;

                float scaleX = (float)rgbImage.Width / image1.DisplayRectangle.Width;
                float scaleY = (float)rgbImage.Height / image1.DisplayRectangle.Height;

                int originalStartX = (int)(startX * scaleX);
                int originalStartY = (int)(startY * scaleY);
                int originalEndX = (int)((startX + selectedRectangle.Width) * scaleX);
                int originalEndY = (int)((startY + selectedRectangle.Height) * scaleY);

                int originalWidth = originalEndX - originalStartX;
                int originalHeight = originalEndY - originalStartY;

                Color[] heatmapColors = new Color[256];
                for (int i = 0; i < 256; i++)
                {
                    int red = i ;
                    int green = i;
                    int blue = 0; 
                    heatmapColors[i] = Color.FromArgb(red, green, blue);
                }

                int drawX = originalStartX;
                int drawY = originalStartY;
                for (int i = 0; i < originalHeight; i++)
                {
                    for (int j = 0; j < originalWidth; j++)
                    {
                        int originalX = originalStartX + j;
                        int originalY = originalStartY + i;

                        if (originalX >= 0 && originalX < rgbImage.Width && originalY >= 0 && originalY < rgbImage.Height)
                        {
                            Color pixelColor = rgbImage.GetPixel(originalX, originalY);
                            int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);
                            Color heatmapColor = heatmapColors[intensity];
                            resultImage.SetPixel(drawX, drawY, heatmapColor);
                            drawX++;
                        }
                    }
                    drawX = originalStartX;
                    drawY++;
                }

                image1.Image = resultImage;

                try
                {
                    resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree_colormap4.jpg");
                }
                catch (Exception)
                {
                    MessageBox.Show("WTH.");
                }
            }
        }

        private void ApplyRedColormap()
        {
            if (selectedRectangle != null && selectedRectangle.Width > 0 && selectedRectangle.Height > 0)
            {
                Bitmap resultImage = new Bitmap(rgbImage);

                int startX = selectedRectangle.Left;
                int startY = selectedRectangle.Top;

                float scaleX = (float)rgbImage.Width / image1.DisplayRectangle.Width;
                float scaleY = (float)rgbImage.Height / image1.DisplayRectangle.Height;

                int originalStartX = (int)(startX * scaleX);
                int originalStartY = (int)(startY * scaleY);
                int originalEndX = (int)((startX + selectedRectangle.Width) * scaleX);
                int originalEndY = (int)((startY + selectedRectangle.Height) * scaleY);

                int originalWidth = originalEndX - originalStartX;
                int originalHeight = originalEndY - originalStartY;

                Color[] heatmapColors = new Color[256];
                for (int i = 0; i < 256; i++)
                {
                    int red = i;
                    int green = 0;
                    int blue = 0;
                    heatmapColors[i] = Color.FromArgb(red, green, blue);
                }

                int drawX = originalStartX;
                int drawY = originalStartY;
                for (int i = 0; i < originalHeight; i++)
                {
                    for (int j = 0; j < originalWidth; j++)
                    {
                        int originalX = originalStartX + j;
                        int originalY = originalStartY + i;

                        if (originalX >= 0 && originalX < rgbImage.Width && originalY >= 0 && originalY < rgbImage.Height)
                        {
                            Color pixelColor = rgbImage.GetPixel(originalX, originalY);
                            int intensity = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);
                            Color heatmapColor = heatmapColors[intensity];
                            resultImage.SetPixel(drawX, drawY, heatmapColor);
                            drawX++;
                        }
                    }
                    drawX = originalStartX;
                    drawY++;
                }

                image1.Image = resultImage;

                try
                {
                    resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree_colormap4.jpg");
                }
                catch (Exception)
                {
                    MessageBox.Show("WTH.");
                }
            }
        }




        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (image1.Image != null)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveDialog.FileName;
                        image1.Image.Save(savePath);
                        MessageBox.Show("Image saved successfully.");
                    }
                }
                else
                {
                    MessageBox.Show("No image to save.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message);
            }
        }
    }
}


