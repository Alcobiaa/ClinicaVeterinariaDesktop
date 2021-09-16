using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ProjetoFinal.Forms
{
    public partial class FormComunicações : Form
    {
        public FormComunicações()
        {
            InitializeComponent();
        }

        #region Botões

        /// <summary>
        /// Ao clicar no botao abre a FORM do Email para que seja enviado o email 
        /// </summary>
        private void btn_Email_Click(object sender, EventArgs e)
        {
            try
            {
                // Ao clicar no botao email ira abrir a "FormEmail"
                FormEmail Email = new FormEmail();
                Email.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ao clicar no botao abre a FORM do Telemovel para que seja enviado a mensagem
        /// </summary>
        private void btn_Telemovel_Click(object sender, EventArgs e)
        {
            try
            {
                // Ao clicar no botao email ira abrir a "FormTelemovel"
                FormTelemovel Telemovel = new FormTelemovel();
                Telemovel.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Tema

        /// <summary>
        /// Metodo que carrega o tema que esta na FORM Principal
        /// </summary>
        private void LoadTheme()
        {
            try
            {
                foreach (Control btns in this.Controls)
                {
                    if (btns.GetType() == typeof(Button))
                    {
                        Button btn = (Button)btns;

                        // Mudar a cor do background do Botao
                        btn.BackColor = ThemeColor.SecondaryColor;

                        // Mudar a cor da Letra
                        btn.ForeColor = Color.White;

                        // Mudar a Fonte da Letra
                        btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo para implementar o "LoadTheme()" na Page Load da FORM
        /// </summary>
        private void FormComunicações_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTheme();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
