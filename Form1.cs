using System;
using System.Data.SqlClient;
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

        private string stringConnect = "data source = (local);DataBase=Project06; Integrated Security = SSPI";
        private SqlConnection conn = new SqlConnection();
        

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
            string date = DateTime.Today.ToString("MM/dd/yyyy");
            string time = DateTime.Now.ToString("HH:mm");
            int id = getUniqueId();
            string values = id + ",'" + date + "'" + "," +  "'"+ time + "'" + "," +  totalPrice;

            conn.ConnectionString = stringConnect;
            conn.Open();
            SqlCommand add = new SqlCommand("Insert Into [Orders] (Id, Date, Time, Price) values (" + values + ")", conn);
            add.ExecuteNonQuery();

            textBoxTotal.Text = "$" + totalPrice;

            listBoxTotTrans.Items.Add(totalPrice);
            conn.Close();
        }

        private void buttonTotalTrans_Click(object sender, EventArgs e)
        {

            Decimal dayTotal = 0.0M;
            foreach (Decimal d in listBoxTotTrans.Items)
            {
                dayTotal += d;
            }

            textBoxTransSummary.Text = "$" + dayTotal;
        }

        private int getUniqueId ()
        {
            conn.ConnectionString = stringConnect;
            conn.Open();
            Random rand = new Random();
            int temp = rand.Next(100001);
            SqlCommand search = new SqlCommand("Select Id From Orders Where Id =" + temp, conn);
            SqlDataReader reader = search.ExecuteReader();
            if (reader.HasRows)
            {
                return getUniqueId();
            } else
            {
                conn.Close();
                return temp;
            }   
        }
    }
}
