using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            txt_PalavraPasse.PasswordChar = '*';
        }

        /// <summary>
        /// Evento para efetuar o Login
        /// </summary>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_Utilizador.Text == "admin" && txt_PalavraPasse.Text == "123")  // Caso o utilizador e a Palavra Passe estejam corretos entra
            {
                new FormPrincipal().Show();     // Mostra o Form1
                this.Hide();            // Esconde este FORM
            }
            else
            {
                MessageBox.Show("Utilizador ou Palavra Passe incorretos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_PalavraPasse.Clear();       // Limpa o campo Palavra Passe
                txt_Utilizador.Clear();         // Limpa o campo Utilizado
                txt_Utilizador.Focus();         // Meto o FOCUS no Utilizador
            }
        }

        /// <summary>
        /// Label que ao clicar fecha a nossa aplicação
        /// </summary>
        private void lbl_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
