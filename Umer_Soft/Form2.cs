using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace Umer_Soft
{
    public partial class Form2 : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source = UmerDataBase.db");

        public Form2()
        {
            InitializeComponent();
           
            datagrid.Enabled = false;
            random_id();
            show();
        }
        void random_id()
        {
            Random rand = new Random();
            int iref = rand.Next(8765, 987634);
            textBox1.Text = "MTN_" + iref;
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            random_id();
            insert_data();
            show();
            Empty_Box();
            label13.Text = "00";

        }
        void delte()
        {
            con.Open();
            string queray = "Delete from UmerDataBase where ID = '" + label13.Text + "'";
            SQLiteCommand delcmd = new SQLiteCommand(queray, con);
        int a = delcmd.ExecuteNonQuery();


            if (a > 0)
            {
                MessageBox.Show("Data has Been Deleted Successfully !","Data Delted !!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data has Been Deleted failed !", "Data not Delted !!!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            con.Close();
        }
        void Empty_Box()
        {
            TXTAdress.Text = "";
            TXTDepartment.Text ="";
            TXTEmail.Text = "";
            TXTGener.Text = "";
            TXTMobile.Text = "";
            TXTName.Text = "";
            TXTProjectName.Text = "";
            TXTSearch.Text = "";
            TXTSection.Text = "";
            textBox3.Text = "";
        }
        void insert_data()
        {
            con.Open();
            string queary = "Insert into UmerDataBase (STUDENT_Name,Son_OF,Adress,Generated_ID, EMAIL , Department , Gender , Section , Mobile_Number , Project_Name)" 
                + "values ('"+TXTName.Text+"','"+textBox3.Text+"','"+TXTAdress.Text+"','"+textBox1.Text+"','"+TXTEmail.Text+"','"+ TXTDepartment.Text+"', '"+TXTGener.Text+"','"+TXTSection.Text+"','"+ TXTMobile.Text+ "' ,'"+ TXTProjectName.Text+ "') ";
            SQLiteCommand cm = new SQLiteCommand(queary,con);
            cm.ExecuteNonQuery();
            cm.Dispose();
            con.Close();
        }
        void show()
        {
            try
            {
                con.Open();
                string show_queary = "Select*from UmerDataBase";
                SQLiteCommand cmd = new SQLiteCommand(show_queary, con);
                SQLiteDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);

                dataGridView1.DataSource = tb;
                con.Close();
            }
            catch (Exception)
            {

               
            }

        }
        void delete()
        {
            con.Open();
            
            con.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                label13.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                TXTName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                TXTAdress.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                TXTEmail.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                TXTDepartment.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                TXTGener.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                TXTSection.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                TXTMobile.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                TXTProjectName.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Please Right the way of Your Clicking !", " Invalid Sytanx or way ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Empty_Box();
            label13.Text = "00";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            con.Open();
            string queary = "update from UmerDataBase set" +
                " STUDENT_Name = @Name ,Son_OF = @Sonof,Adress = @Adr," +
                "Generated_ID = @GenID,EMAIL = @email, Department = @depart" +
                "Gender = @gender,Section = @section , Mobile_Number = @mobilenumb," +
                " Project_Name = @projectname ";
            
                
            SQLiteCommand cm = new SQLiteCommand(queary, con);
            cm.Parameters.AddWithValue(TXTName.Text, "@Name");
            cm.Parameters.AddWithValue(textBox3.Text, "@Sonof");
            cm.Parameters.AddWithValue(TXTAdress.Text, "@Adr");
            cm.Parameters.AddWithValue(textBox1.Text, "@GenID");
            cm.Parameters.AddWithValue(TXTEmail.Text, " @email");
            cm.Parameters.AddWithValue(TXTDepartment.Text, "@depart");
            cm.Parameters.AddWithValue(TXTGener.Text, "@gender");
            cm.Parameters.AddWithValue(TXTSection.Text, " @section");
            cm.Parameters.AddWithValue( TXTMobile.Text, "@mobilenumb");
            cm.Parameters.AddWithValue(TXTProjectName.Text, " @projectname");
            cm.ExecuteNonQuery();
            
           //if(update_check > 0)
           // {
           //     MessageBox.Show("Data Has been Updated Successfully!!", " Updated Data ", MessageBoxButtons.OK, MessageBoxIcon.Information);
           // }
           // else
           // {
           //     MessageBox.Show("Data Has been Updated Failed!!", " Updated Data failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // }
           
            con.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
           
            delte();
            show();
            Empty_Box();
        }

        private void Datagrid_Click(object sender, EventArgs e)
        {
            label13.Text = "00";
            con.Open();
            string queary = "Select from UmerDataBase where Name = '"+ TXTSearch + "'";
            SQLiteCommand cm = new SQLiteCommand(queary,con);
            cm.ExecuteNonQuery();
            DataTable tb = new DataTable();
            SQLiteDataReader reader = cm.ExecuteReader();
            tb.Load(reader);
            dataGridView1.DataSource = tb;
            con.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            con.Open();
            string queary = "Select * From  UmerDataBase delete";
            SQLiteCommand cmdRestore = new SQLiteCommand(queary,con);
            DialogResult dialog =    MessageBox.Show("Are you sure to Delete The Full Data Base !!!","Data Base wana to Delete ! ",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if(dialog == DialogResult.OK)
            {
                MessageBox.Show("SOrry Umer does Not allow me to Make Full Changes at once In my DB", " save from bunch of destruction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                show();
            }
            con.Close();
        }
    }
}
