using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Artificial_Intelligence_Chatbot
{
    public partial class AnswerForm : Form
    {
        public QuestionForm ParentQuestionForm { get; set; }
        public AnswerForm(string question,string answer)
        {
            InitializeComponent();

            questionTB.Text = question;
            answerTB.Text = answer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            if (ParentQuestionForm != null)
            {
                ParentQuestionForm.EnableButton();
            }

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Cursor = Cursors.Hand;
        }
    }
}
