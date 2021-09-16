using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class FormEditarVeterinario : Form
    {
        // Atributos

        private Veterinario _editado;

        private FormVeternario _form;

        private CrudVeterinario _crudVeterinario;

        public FormEditarVeterinario(FormVeternario form, Veterinario editado)
        {
            InitializeComponent();
            _crudVeterinario = new CrudVeterinario();

            _editado = editado;
            _form = form;

            // Fazer com que quando abre a form os campos ja estejam preenchidos de acordo com o veterinario selecionado
            txt_Nome.Text = editado.Nome.ToString();
            txt_Apelido.Text = editado.Apelido.ToString();
            txt_Telemovel.Text = editado.Telemovel.ToString();
            txt_Idade.Text = editado.Idade.ToString();
            txt_Email.Text = editado.Email.ToString();
            txt_NIF.Text = editado.NIF.ToString();
        }

        #region Botões

        /// <summary>
        /// Evento para guardar o "Dono" que foi selecionado , já editado
        /// </summary>
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaDados())   // Caso todos os campos estejam validados entra
                {
                    if (ValidaEmail(txt_Email.Text) && ValidaNIF(txt_NIF.Text))
                    {
                        foreach (Veterinario veterinario in CrudVeterinario.Veterinarios)
                        {
                            if(veterinario.ID == _editado.ID)
                            {
                                // Substituir os campos de acordo com aquilo que esta a ser escrito nesta FORM
                                veterinario.Nome = txt_Nome.Text;
                                veterinario.Apelido = txt_Apelido.Text;
                                veterinario.Telemovel = txt_Telemovel.Text;
                                veterinario.NIF = txt_NIF.Text;
                                veterinario.Email = txt_Email.Text;
                                veterinario.Idade = Convert.ToInt32(txt_Idade.Text);

                                // Introduzir os novos dados na ListBox
                                _crudVeterinario.GravarInfo();
                                _form.InicializaList();

                                // Fechar a FORM
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email ou NIF incorretos !", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento para fechar a FORM
        /// </summary>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Fecha a FORM
        }

        /// <summary>
        /// Evento para fechar a FORM
        /// </summary>
        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();  // Fecha a FORM
        }

        #endregion

        #region Validações

        /// <summary>
        /// Metodo que valida se os campos estao bem preenchidos e se estão vazios ou não
        /// </summary>
        private bool ValidaDados()
        {
            bool output = true;
            int verifica;

            if (string.IsNullOrEmpty(txt_Nome.Text))        // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o nome do Veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }

            if (!Regex.Match(txt_Nome.Text, "^[a-zA-Z][a-zA-Z]*$").Success)    // Validar se o nome esta no formato correto
            {
                MessageBox.Show("Insira apenas letras!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Apelido.Text))         // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o apelido do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }

            if (!Regex.Match(txt_Apelido.Text, "^[a-zA-Z][a-zA-Z]*$").Success)     // Validar se o apelido esta no formato correto
            {
                MessageBox.Show("Insira apenas letras!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Telemovel.Text))     // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o telemovél do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }

            if (!Regex.Match(txt_Telemovel.Text, @"(9[1236]\d) ?(\d{3}) ?(\d{3})").Success)      // Validar se o telemovel esta no formato correto
            {
                MessageBox.Show("Numero de telemóvel errado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Idade.Text))       // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira a idade do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }

            if(!int.TryParse(txt_Idade.Text, out verifica))
            {
                MessageBox.Show("Preencha corretamente o campo da idade !", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (string.IsNullOrEmpty(txt_Email.Text))       // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o email do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_NIF.Text))         // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o Nif do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = false;
            }

            return output;
        }

        /// <summary>
        /// Metodo para validar o campo EMAIL
        /// </summary>
        private bool ValidaEmail(string endereco)
        {
            string pattern = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            Match emailAddressMatch = Regex.Match(endereco, pattern);
            return emailAddressMatch.Success;
        }

        /// <summary>
        /// Metodo para validar o campo NIF
        /// </summary>
        private static bool ValidaNIF(string nif)
        {
            /*
	            Verifica se NIF/Contribuinte é válido	
	
	            O NIF tem 9 dígitos, sendo o último o digito de controlo. Para ser calculado o digito de controlo:
                1 - Multiplique o 8.º dígito por 2, o 7.º dígito por 3, o 6.º dígito por 4, o 5.º dígito por 5, o 4.º dígito por 6, o 3.º dígito por 7, o 2.º dígito por 8, e o 1.º digito por 9
                2 - Adicione os resultados 
	            3 - Calcule o Módulo 11 do resultado, isto é, o resto da divisão do número por 11.
                4 - Se o resto for 0 ou 1, o dígito de controle será 0
                5 - Se for outro algarismo x, o dígito de controle será o resultado de 11 - x
            */

            if (string.IsNullOrWhiteSpace(nif) || !Regex.IsMatch(nif, "^[0-9]+$") || nif.Length != 9)
                return false;

            char c = nif[0];

            //Perform CheckDigit calculations
            int checkDigit = (Convert.ToInt32(c.ToString()) * 9);
            for (int i = 2; i <= 8; i++)
            {
                checkDigit += Convert.ToInt32(nif[i - 1].ToString()) * (10 - i);
            }
            checkDigit = 11 - (checkDigit % 11);
            if (checkDigit >= 10)
                checkDigit = 0;

            if (checkDigit.ToString() != nif[8].ToString())
                return false;

            return true;
        }

        #endregion

    }
}
