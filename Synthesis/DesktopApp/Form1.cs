using DAL;
using LogicLayer.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        private static readonly UserDAL userDAL = new UserDAL(); 
        private UserManager userManager = new UserManager(userDAL);
        Thread thread;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbxUsername.Text.Length == 0 || tbxPassword.Text.Length == 0)
            {
                MessageBox.Show("Please fill all the mandatory fields");
            }
            else if (userManager.CheckLoginAdmin(tbxUsername.Text, tbxPassword.Text) == false)
            {
                MessageBox.Show("Make sure you input the right credentials");
            }
            else
            {
                this.Close();
                ProductForm productForm = new ProductForm();
                thread = new Thread(openNewForm);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private void openNewForm(object obj)
        {
            Application.Run(new ProductForm());
        }
    }
}
