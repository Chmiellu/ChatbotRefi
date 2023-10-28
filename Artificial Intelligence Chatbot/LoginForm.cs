using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artificial_Intelligence_Chatbot
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source = .\MSSQLSERVER2022; Initial Catalog=Logowanie;Integrated Security = True; Connect Timeout = 50");
        public static string Usershow;

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM LoginData where Login='" + LoginTB.Text + "' AND Haslo='" + HasloTB.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                WelcomeForm Obj = new WelcomeForm();
                Obj.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("Zły login lub hasło");
            }
            Con.Close();
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

        private void LoginButton_MouseEnter(object sender, EventArgs e)
        {
            LoginButton.Cursor = Cursors.Hand;
        }
    }
}
