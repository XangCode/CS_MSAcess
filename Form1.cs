using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ConnectToAcces
{
    public partial class Form1 : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        

        public Form1()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Xang.DESKTOP-TEJJS9U\Documents\ComandoTeam\Novos_Dados.accdb;Persist Security Info=False;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
             conn.Open();

             ConnectStatuslb.Text = "Connected";

             conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro " + ex);
            }

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            conn.Open();

            OleDbCommand oleDbCommand = new OleDbCommand();
            OleDbCommand com = oleDbCommand;
            com.Connection = conn;
            com.CommandText = "select * from tbl_coordenadores where Username='" + UsernameTxt.Text + "' and Pass = '" + PasswordTxt.Text+ "'";

            OleDbDataReader reader=com.ExecuteReader();                
            int count = 0;
            
            while (reader.Read())
            {        
                count++;                
            }
            if (count==1)
            {                              
                MessageBox.Show("Username and password are correct");
                conn.Close();
                conn.Dispose();
                this.Hide();
                DadosComando FDadosComando = new DadosComando();
                FDadosComando.ShowDialog();
            }

            else if (count >1)
            {
                MessageBox.Show("Duplicate Username and Password");
            }
            else
            {
                MessageBox.Show("Username or Password are incorrect");
            }            
            conn.Close();
        }
    }
}
