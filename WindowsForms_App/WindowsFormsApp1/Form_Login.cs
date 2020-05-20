
using DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
   
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Introduceti nume si parola");
                return;
            }

            using (var connection = DataBase.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select * from Login where UserName=@username and Password=@password", connection);
                    cmd.Parameters.AddWithValue("@username", txt_UserName.Text);
                    cmd.Parameters.AddWithValue("@password", txt_Password.Text);
                    connection.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    connection.Close();

                    int count = ds.Tables[0].Rows.Count;
                    
                    connection.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("Logarea s-a realizat cu succes!");
                        this.Hide();
                        Form_App fm = new Form_App();
                        fm.Show();
                        connection.Close();

                    }
                    else
                    {
                        MessageBox.Show("Logarea a esuat!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Source);
                }

            }


        }

        private void Form_Login_Load(object sender, EventArgs e)
        {

        }


    }
}


