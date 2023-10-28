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
using AIMLbot;
namespace Artificial_Intelligence_Chatbot
{
    public partial class QuestionForm : Form
    {
        public QuestionForm()
        {
            InitializeComponent();
        }

        public void EnableButton()
        {
            button1.Enabled = true;
            button1.BackgroundImage = AdjustImageBrightness(button1.BackgroundImage, 0.1f);
        }

        public void GetBotResponse()
        {
            Bot refi = new Bot();
            refi.loadSettings(); 
            refi.loadAIMLFromFiles(); 
            refi.isAcceptingUserInput = false; 
            User tomek = new User("userID", refi);
            refi.isAcceptingUserInput = true; 
            Request request = new Request(InputBox.Text, tomek, refi); 
            Result result = refi.Chat(request); 
            AnswerForm answerForm = new AnswerForm(InputBox.Text, result.Output);
            answerForm.ParentQuestionForm = this;
            answerForm.Show();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            GetBotResponse();
            button1.Enabled = false;
            button1.BackgroundImage = AdjustImageBrightness(button1.BackgroundImage, -0.1f);

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

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Hand;
        }


        //private void InputBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Return)
        //    {
        //        GetBotResponse();
        //        e.Handled = e.SuppressKeyPress = true; //This Code for Disabling Beep Sound On Enter Key
        //    }
        //}

    }
}
