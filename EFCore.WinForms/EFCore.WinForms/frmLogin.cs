using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFCore.Dominio;
using EFCore.WinForms.BLL;

namespace WF_ModerUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private  async void Logar()
        {  
            try
            {
                Usuarios usuario = new Usuarios()
                {
                    login = txtLogin.Text,
                    Senha = txtSenha.Text
                };

                if (await new UsuarioBLL().EfetuarLogin(Program.UrlApi, usuario))
                {
                    frmMenu menu = new frmMenu();
                    menu.Show();

                    Hide();
                }
                else
                {
                    MessageBox.Show("Usuário e/ou senha inválidos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
