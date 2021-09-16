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
    public partial class FormEditarAnimal : Form
    {
        private Animal _editado;

        private FormAnimais _form;

        private CrudAnimal _crudAnimal;

        private CrudDono _crudDono;

        public FormEditarAnimal(FormAnimais form, Animal editado)
        {
            InitializeComponent();
            _crudAnimal = new CrudAnimal();
            _crudDono = new CrudDono();

            _editado = editado;
            _form = form;

            // Fazer com que quando abre a form os campos ja estejam preenchidos de acordo com o Animal selecionado
            txt_Nome.Text = editado.Nome.ToString();
            txt_Idade.Text = editado.Idade.ToString();
            txt_Peso.Text = editado.Peso.ToString();
            txt_Raca.Text = editado.Raca.ToString();
            txt_Especie.Text = editado.Especie.ToString();
            cb_Dono.Text = editado.Dono.ToString();
        }

        #region Botões

        /// <summary>
        /// Evento para fechar a FORM
        /// </summary>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Fecha a FORM
        }

        /// <summary>
        /// Evento para guardar o animal já editado
        /// </summary>
        private void btn_Guardar_Click(object sender, EventArgs e)
        {   
            try
            {
                if (ValidaDados())  // Caso todos os campos estejam validados entra
                {
                    foreach (Animal animal in CrudAnimal.Animais)
                    {
                        if (animal.ID == _editado.ID)
                        {
                            // Substituir os campos de acordo com aquilo que esta a ser escrito nesta FORM
                            animal.Nome = txt_Nome.Text;
                            animal.Raca = txt_Raca.Text;
                            animal.Idade = Convert.ToInt32(txt_Idade.Text);
                            animal.Especie = txt_Especie.Text;
                            animal.Peso = Convert.ToInt32(txt_Peso.Text);
                            animal.Dono = cb_Dono.Text;

                            // Introduzir os novos dados na ListBox
                            _crudAnimal.GravarInfo();
                            _form.InicializaList();

                            // Fechar a FORM
                            this.Close();
                        }
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
        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Validações

        /// <summary>
        /// Metodo que valida se os campos foram preenchidos e se estao bem preenchidos
        /// </summary>
        private bool ValidaDados()
        {
            bool output = true;
            int verifica;

            if (string.IsNullOrEmpty(txt_Nome.Text))        // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o nome do animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_Nome.Text, "^[a-zA-Z][a-zA-Z]*$").Success)        // Validar se o nome esta no formato correto
            {
                MessageBox.Show("Insira apenas letras no nome do animal!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Idade.Text))       // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira a idade do seu animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!int.TryParse(txt_Idade.Text, out verifica))
            {
                MessageBox.Show("Preencha corretamente a idade do animal!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Raca.Text))        // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira a raça do animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_Raca.Text, "^[a-zA-Z][a-zA-Z]*$").Success)    // Validar se a raca esta no formato correto
            {
                MessageBox.Show("Insira apenas letras na raca do animal!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Peso.Text))        // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o peso do animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!int.TryParse(txt_Peso.Text, out verifica))
            {
                MessageBox.Show("Preencha corretamente o peso do animal!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Especie.Text))        // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira a especie do animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_Especie.Text, "^[a-zA-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("Insira apenas letras na especie do animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            return output;
        }

        #endregion

        #region Load

        private void FormEditarAnimal_Load(object sender, EventArgs e)
        {
            cb_Dono.DataSource = _crudDono.Donos;
            cb_Dono.DisplayMember = "Nome";
        }

        #endregion
    }
}
