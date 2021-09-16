using Biblioteca;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class FormAnimais : Form
    {
        private CrudAnimal _crudAnimal;
        private CrudDono _crudDono;

        int contaAnimais = 1;       // Variavel que ira servir para o ID Animais

        public FormAnimais()
        {
            _crudAnimal = new CrudAnimal();
            _crudDono = new CrudDono();

            InitializeComponent();
            InicializaList();
            AcrescentaAnimal();
        }

        #region Botões

        /// <summary>
        /// Evento para guardar os animais inseridos no form
        /// </summary>
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Animal novoAnimal;

            if (ValidaDados())       // Chama o Método que valida se os dados estão em branco ou preenchidos
            {
                novoAnimal = new Animal()  // Cria o novo animal que esta a ser inserido no CRUD
                {
                    ID = contaAnimais,
                    Nome = txt_Nome.Text,
                    Especie = txt_Especie.Text,
                    Raca = txt_Raca.Text,
                    Idade = Convert.ToInt32(txt_Idade.Text),
                    Peso = Convert.ToInt32(txt_Peso.Text),
                    Dono = CB_Dono.Text
                };

                DialogResult resultado;

                resultado = MessageBox.Show($"Têm a certeza que pretende adicionar o/a {novoAnimal.Nome}",
                       "Adicionar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (DialogResult.OK == resultado)
                {
                    CrudAnimal.Animais.Add(novoAnimal);    // Adiciona a LIST o novo Animal
                    _crudAnimal.GravarInfo();               // Grava o novo animal no txt

                    AcrescentaAnimal();

                    InicializaList();
                    MessageBox.Show("Animal criado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpaCampos();
                }
                else
                {
                    LimpaCampos();
                }
            }
        }

        /// <summary>
        /// Evento para inserir um novo animal
        /// </summary>
        private void btn_Novo_Click(object sender, EventArgs e)
        {
            txt_Idade.Text = "";
            txt_Nome.Text = "";
            txt_Peso.Text = "";
            txt_Raca.Text = "";
            txt_Especie.Text = "";
            CB_Dono.Text = null;
        }

        /// <summary>
        /// Evento para eliminar o animal pretendido
        /// </summary>
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (DGV_Animais.SelectedRows.Count == 1)
            {
                Animal animalAApagar = (Animal)DGV_Animais.SelectedRows[0].DataBoundItem;   // Vai buscar o campo que foi selecionado na lista
                Animal apagado = null;     // Auxiliar sem valor 

                // Se a contagem de linhas f-or maior que zero removemos a linha da DATAGRIDVIEW
                if (animalAApagar != null)
                {
                    foreach (Animal animal in CrudAnimal.Animais) // Percorre a lista toda
                    {
                        if (animalAApagar.ID == animal.ID)
                        {
                            apagado = animal;
                        }
                    }

                    if (apagado != null)    // Se o campo que queremos apagar já foi encontrado entra e pergunta ao utilizador se pretende mesmo apagar o campo, caso a resposta seja "OK" ele apaga
                    {
                        DialogResult resultado;

                        resultado = MessageBox.Show($"Têm a certeza que pretende apagar o/a {apagado.Nome} ",
                            "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (DialogResult.OK == resultado)
                        {
                            CrudAnimal.Animais.Remove(apagado);
                            _crudAnimal.GravarInfo();

                            if(contaAnimais > 1)
                            {
                                contaAnimais--;
                                txt_IdAnimal.Text = contaAnimais.ToString();
                            }

                            InicializaList();   // Inicializamos novamente a lista para que o campo que apagamos nao seja mostrado
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento para editar o animal pretendido
        /// </summary>
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (DGV_Animais.SelectedRows.Count == 1)
            {
                Animal animalAEditar = (Animal)DGV_Animais.SelectedRows[0].DataBoundItem;
                Animal editado = null;

                if (animalAEditar != null)       // Caso haja alguma coisa selecionada entra
                {
                    foreach (Animal animal in CrudAnimal.Animais) // Percorre a Lista
                    {
                        if (animalAEditar.ID == animal.ID)
                        {
                            editado = animal;
                        }
                    }

                    // Abrir a nova FORM para editar o animal selecionado
                    FormEditarAnimal formEditarAnimal = new FormEditarAnimal(this, editado);
                    formEditarAnimal.Show();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show("Insira a idade do seu Animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!int.TryParse(txt_Idade.Text, out verifica))
            {
                MessageBox.Show("Insira apenas numeros na idade do animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Raca.Text))        // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira a Raca do Animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_Raca.Text, "^[a-zA-Z][a-zA-Z]*$").Success)    // Validar se a raca esta no formato correto
            {
                MessageBox.Show("Insira apenas letras na raça do animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Peso.Text))        // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o peso do animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!int.TryParse(txt_Peso.Text, out verifica))
            {
                MessageBox.Show("Insira apenas numeros no peso do animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            if (string.IsNullOrEmpty(CB_Dono.Text))
            {
                MessageBox.Show("Têm de associar um dono ao Animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            return output;
        }

        /// <summary>
        /// Metodo para acrescentar o numero do ID de Animais
        /// </summary>
        public void AcrescentaAnimal()
        {
            int numeroAnimais = CrudAnimal.Animais.Count();

            contaAnimais = numeroAnimais + 1;

            txt_IdAnimal.Text = contaAnimais.ToString();
        }

        #endregion

        #region InicializaçãoList

        public void InicializaList()
        {
            _crudAnimal = new CrudAnimal();
            DGV_Animais.DataSource = null;                          // Serve para dar refresh a Lista
            DGV_Animais.DataSource = CrudAnimal.Animais;           // Associar a Lista ao DataSource da List Box
        }

        #endregion

        #region Limpeza

        /// <summary>
        /// Metodo para efetuar a limpeza dos campos
        /// </summary>
        public void LimpaCampos()
        {
            txt_Idade.Text = "";
            txt_Nome.Text = "";
            txt_Peso.Text = "";
            txt_Raca.Text = "";
            txt_Especie.Text = "";
        }

        #endregion

        #region Load

        private void FormAnimais_Load(object sender, EventArgs e)
        {
            CB_Dono.DataSource = _crudDono.Donos;
            CB_Dono.DisplayMember = "Nome";
        }

        #endregion
    }
}
