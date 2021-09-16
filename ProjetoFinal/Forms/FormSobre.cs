using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class FormSobre : Form
    {
        public FormSobre()
        {
            InitializeComponent();
            LoadTheme();
        }

        /// <summary>
        /// Evento que carrega o tema que esta na FORM Principal
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
                        btn.BackColor = ThemeColor.PrimaryColor;

                        // Mudar a cor da Letra
                        btn.ForeColor = Color.White;


                        btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

                    }
                }

                label1.ForeColor = ThemeColor.PrimaryColor;
                label3.ForeColor = ThemeColor.SecondaryColor;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
