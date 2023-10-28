using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artificial_Intelligence_Chatbot
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }
        private void StartButton_MouseEnter(object sender, EventArgs e)
        {
            StartButton.Cursor = Cursors.Hand;
        }
        private System.Drawing.Image AdjustImageBrightness(System.Drawing.Image image, float brightness)
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            float[][] colorMatrixElements = {
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {brightness, brightness, brightness, 0, 1}
            };
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Bitmap resultBitmap = new Bitmap(image.Width, image.Height);
            Graphics graphics = Graphics.FromImage(resultBitmap);
            graphics.DrawImage(image, new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height),
            0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
            return resultBitmap;
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false;
            StartButton.BackgroundImage = AdjustImageBrightness(StartButton.BackgroundImage, -0.1f);
            QuestionForm questionForm = new QuestionForm();
            questionForm.ShowDialog();
            this.Close();
        }
    }
}
