using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamestore.Forms
{
    public partial class SignInForm : Form
    {
        Classes.Connection connection;
        public SignInForm()
        {
            InitializeComponent();
        }
        private void SignInForm_Load(object sender, EventArgs e)
        {
            connection = new Classes.Connection();
            textBoxLogin.MaxLength = 25;
            textBoxLogin.MaxLength = 25;
            textBoxPassword.PasswordChar = '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;

            connection.OpenCon();
            string signinquery = $"Select ClientLogin, ClientPassword from Client where ClientLogin = '{login}' and ClientPassword = '{password}'";
            SqlCommand command1 = new SqlCommand(signinquery);
            command1.Connection = connection.GetCon();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command1);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Молодец", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.hellolabel.Text = "Добро пожаловать, " + table.Rows[0][0];
                mainForm.ShowDialog();

            }
            else
                MessageBox.Show("Данные введены неправильно или такого пользователя не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            connection.CloseCon();
        }
    }
}
