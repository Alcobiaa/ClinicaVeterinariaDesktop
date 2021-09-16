using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class FormEditarConsulta : Form
    {
        private Consulta _editado;

        private FormConsultas _form;

        private CrudConsulta _crudConsulta;
        
        public FormEditarConsulta(FormConsultas form, Consulta editado)
        {
            InitializeComponent();
            _crudConsulta = new CrudConsulta();

            _editado = editado;
            _form = form;

            // Fazer com que quando abre a form os campos ja estejam preenchidos de acordo com a Consulta selecionado
            cb_Animais.Text = editado.Animal.ToString();
            cb_Veterinario.Text = editado.Veterinario.ToString();
            DT_Data.Value = editado.Data;
            cb_Hora.Text = editado.Hora.ToString();
            cb_Sala.Text = editado.Sala.ToString();
        }

        #region Botões

        /// <summary>
        /// Evento para guardar o animal já editado
        /// </summary>
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaDados())
                {
                    bool verifica = false;

                    foreach (Consulta consulta in _crudConsulta.Consultas)
                    {
                        if(consulta.ID != _editado.ID)
                        {

                            if (consulta.Animal == cb_Animais.Text)
                            {
                                if (consulta.Hora == cb_Hora.Text)
                                {
                                    if (consulta.Data == DT_Data.Value)
                                    {
                                        MessageBox.Show("Não pode marcar esta consulta, escolha uma hora diferente, outra data ou outro animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        verifica = true;
                                    }
                                }
                            }

                            if (consulta.Veterinario == cb_Veterinario.Text)
                            {
                                if (consulta.Hora == cb_Hora.Text)
                                {
                                    if (consulta.Data == DT_Data.Value)
                                    {
                                        MessageBox.Show("Não pode marcar esta consulta, escolha uma hora diferente, outra data ou outro veterinario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        verifica = true;
                                    }
                                }
                            }
                        }
                    }

                    if (verifica == false)
                    {
                        foreach (Consulta consultas in _crudConsulta.Consultas)
                        {
                            if(consultas.ID == _editado.ID)
                            {
                                // Substituir os campos de acordo com aquilo que esta a ser escrito nesta FORM
                                consultas.Animal = cb_Animais.Text;
                                consultas.Veterinario = cb_Veterinario.Text;
                                consultas.Data = DT_Data.Value;
                                consultas.Hora = cb_Hora.Text;
                                consultas.Sala = Convert.ToInt32(cb_Sala.Text);

                                // Introduzir os novos dados na DataGridView
                                _crudConsulta.GravarInfo();
                                _form.InicializaList();

                                //Fechar Form
                                this.Close();
                            }
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
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (string.IsNullOrEmpty(cb_Animais.Text))
            {
                MessageBox.Show("Têm de inserir um animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(cb_Veterinario.Text))
            {
                MessageBox.Show("Têm de inserir um veterinario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(cb_Sala.Text))
            {
                MessageBox.Show("Têm de escolher uma sala", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            return output;
        }

        #endregion

        #region Load

        private void FormEditarConsulta_Load(object sender, EventArgs e)
        {
            cb_Animais.DataSource = CrudAnimal.Animais;
            cb_Animais.DisplayMember = "Nome";
            cb_Veterinario.DataSource = CrudVeterinario.Veterinarios;
            cb_Veterinario.DisplayMember = "Nome";
            DT_Data.MinDate = DateTime.Now;
        }

        #endregion
    }
}
