using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_App : Form
    {
        
            Angajat angajat = new Angajat();

            private DBWinFormEntities Datab;

            public Form_App()
            {
            InitializeComponent();
            Datab = new DBWinFormEntities();

            var types = Datab.Categories.ToList<Categorie>();
            foreach (var item in types)
            {
                comboBox.Items.Add(item.NumeCategorie);

            }

        }

        private void btn_LogOut_Click_1(object sender, EventArgs e)
         
        {
            this.Hide();
            Form_Login form = new Form_Login();
            form.Show();
        }

        private void Form_App_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form_App_Load(object sender, EventArgs e)
        {
            populateDataGridView();

            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriti sa stergeti obiectul selectat?", "EF CRUDOperations", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var entry = Datab.Entry(angajat);
                if (entry.State == EntityState.Detached)
                {
                    Datab.Angajats.Attach(angajat);

                }
                Datab.Angajats.Remove(angajat);
                Datab.SaveChanges();
                populateDataGridView();
                Clear();
                MessageBox.Show("Stergerea s-a realizat cu succes");
            }
        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            Clear();

        }
        private void Clear()
        {
            txt_nume.Text = string.Empty;
            comboBox.Text = "Selectati...";
            txt_an.Text = string.Empty;
            txt_vanzari.Text = string.Empty;
            txt_adresa.Text = string.Empty;
            btn_save.Text = "Salveaza";
            btn_delete.Enabled = false;

        }
        private void btn_save_Click_1(object sender, EventArgs e)
        {
            angajat.Name = txt_nume.Text.Trim();
            angajat.An = int.Parse(txt_an.Text.Trim());
            angajat.Adresa = txt_adresa.Text.Trim();
            angajat.Vanzari = int.Parse(txt_vanzari.Text.Trim());
            angajat.Categorie1 = comboBox.SelectedItem as Categorie;
            if (btn_save.Text == "Update")
            {
                Datab.Entry(angajat).State = EntityState.Modified;
                Datab.SaveChanges();
                populateDataGridView();
            }
            else
            {
                Datab.Angajats.Add(angajat);
                Datab.SaveChanges();
                populateDataGridView();
            }


            Clear();

            MessageBox.Show("Submitted Successfully");

        }
        public void populateDataGridView()
        {

            dataGridProduct.DataSource = Datab.Angajats.ToList<Angajat>();
        }

        private void dataGridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridProduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridProduct.CurrentRow.Index != -1)
            {
                angajat.Id = Convert.ToInt32(dataGridProduct.CurrentRow.Cells["Id"].Value);


                angajat = Datab.Angajats.Where(x => x.Id == angajat.Id).FirstOrDefault();
                txt_nume.Text = angajat.Name;
                txt_an.Text = angajat.An.ToString();
                txt_adresa.Text = angajat.Adresa;
                txt_vanzari.Text = angajat.Vanzari.ToString();
                //comboBox.Text = products.CategoryId.ToString();


                btn_save.Text = "Update";
                btn_delete.Enabled = true;
            }
        }

        

        private void Formm_App_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form_Chart ch = new Form_Chart();
            ch.Show();
        }
    }
}
