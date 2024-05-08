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
                        int resultX = j;
                        int resultY = i;

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
                    if (i <= 127)
                    {
                        int red = 0;
                        int green = 0;
                        int blue = 255;
                        heatmapColors[i] = Color.FromArgb(red, green, blue);
                    }
                    else
                    {
                        int red = 255;
                        int green = 255;
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
                    resultImage.Save("C:\\Users\\HP\\source\\repos\\lab1\\lab1\\tree3.jpg");
                }
                catch (Exception)
                {
                    MessageBox.Show("WTF");
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


