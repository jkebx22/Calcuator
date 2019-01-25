using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2
{
    public partial class Calculator : Form
    {
        Double resultVal = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if(!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;

        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(resultVal !=0)
            {
                buttonEquals.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultVal + " " + operationPerformed;
                isOperationPerformed = true;
            }else
            {
                operationPerformed = button.Text;
                resultVal = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = resultVal + " " + operationPerformed;
                isOperationPerformed = true;
            }

            
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultVal = 0;

        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch(operationPerformed)
            {
                case "+":
                    textBox_Result.Text = (resultVal + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultVal - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (resultVal * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (resultVal / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;

            }
            resultVal = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
        }
    }
}
