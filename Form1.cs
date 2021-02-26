using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_06
{
    public partial class Form1 : Form
    {
        private const decimal priceChoc = 1.50M;
        private const decimal priceVan = 1.00M;
        private const decimal priceStraw = 2.00M;
                                                        // Price constants
        private const decimal priceNuts = 1.00M;
        private const decimal priceCherry = 0.75M;
        private const decimal priceSprink = 0.50M;

        private decimal totalPrice = 0.00M;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            decimal orderPrice = 0.00M;
            if (radioButtonChoc.Checked == true)
            {
                orderPrice += priceChoc;

            }
            else if (radioButtonStraw.Checked == true)
            {
                orderPrice += priceStraw;

            }
            else if (radioButtonVan.Checked == true)
            {
                orderPrice += priceVan;
            }
            if (checkBoxCherry.Checked == true)
            {
                orderPrice += priceCherry;
            }
            if (checkBoxNuts.Checked == true)
            {
                orderPrice += priceNuts;
            }
            if (checkBoxSprinkles.Checked == true)
            {
                orderPrice += priceSprink;
            }

            listBoxOrders.Items.Add(orderPrice);
            totalPrice += orderPrice;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            totalPrice = 0.0M;
            listBoxOrders.Items.Clear();
        }

        private void buttonTotal_Click(object sender, EventArgs e)
        {
            textBoxTotal.Text = "$" + totalPrice;
        }
    }
}
