using System;
using Biblioteca;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace ProjetoFinal.Forms
{
    public partial class FormVeternario : Form
    {
        CrudVeterinario _crudVeterinario;

        int contaVeternarios = 1;           // Variavel que ira servir para o ID Veterinario

        public FormVeternario()
        {
            _crudVeterinario = new CrudVeterinario();

            InitializeComponent();
            InicializaList();
            AcrescentaVeterinario();
        }

        #region Botões

        /// <summary>
        /// Evento para guardar o "Veterinário" inserido no FORM
        /// </summary>
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Veterinario novoVeterinario;

            if (ValidaDados())
            {
                if (ValidaEmail(txt_Email.Text) && ValidaNIF(txt_NIF.Text)) // Chama os Metodos de validar o campo email e o campo NIF
                {
                    novoVeterinario = new Veterinario // Cria o novo veterinário que esta a ser inserido no CRUD    
                    {
                        ID = contaVeternarios,
                        Nome = txt_Nome.Text,
                        Apelido = txt_Apelido.Text,
                        Idade = Convert.ToInt32(txt_Idade.Text),
                        Email = txt_Email.Text,
                        Telemovel = txt_MaskedTelemovel.Text,
                        NIF = txt_NIF.Text
                    };

                    DialogResult resultado;

                    resultado = MessageBox.Show($"Têm a certeza que pretende adicionar o/a {novoVeterinario.Nome} {novoVeterinario.Apelido}",
                       "Adicionar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (DialogResult.OK == resultado)
                    {
                        CrudVeterinario.Veterinarios.Add(novoVeterinario);     // Adiciona a LIST o novo veterinario
                        _crudVeterinario.GravarInfo();                          // Grava o novo veterinario no txt

                        AcrescentaVeterinario();                                // Chama o metodo para acrescentar "1" ao ID Veterinario

                        InicializaList();
                        MessageBox.Show("Veterinario criado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpaCampos();
                    }
                    else
                    {
                        LimpaCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Email ou NIF incorretos !", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// Evento para inserir um novo Veterinário
        /// </summary>
        private void btn_Novo_Click(object sender, EventArgs e)
        {
            txt_Nome.Text = "";
            txt_Idade.Text = "";
            txt_Email.Text = "";
            txt_Apelido.Text = "";
            txt_IDFuncionario.Text = "";
            txt_MaskedTelemovel.Text = "";
        }

        /// <summary>
        /// Evento para apagar o Veterinário selecionado
        /// </summary>
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (DGV_Veterinarios.SelectedRows.Count == 1)
            {
                Veterinario veterinarioAApagar = (Veterinario)DGV_Veterinarios.SelectedRows[0].DataBoundItem;  // Vai buscar o campo que foi selecionado na lista
                Veterinario apagado = null;     // Auxiliar sem valor

                // Se a contagem de linhas f-or maior que zero removemos a linha da DATAGRIDVIEW
                if (veterinarioAApagar != null)  // Caso exista algum campo já selecionado
                {
                    foreach (Veterinario veterinario in CrudVeterinario.Veterinarios) // Percorre a lista toda
                    {
                        if (veterinarioAApagar.ID == veterinario.ID)
                        {
                            apagado = veterinario;
                        }
                    }

                    if (apagado != null)     // Se o campo que queremos apagar já foi encontrado entra e pergunta ao utilizador se pretende mesmo apagar o campo, caso a resposta seja "OK" ele apaga
                    {
                        DialogResult resultado;

                        resultado = MessageBox.Show($"Têm a certeza que pretende apagar o/a {apagado.Nome} {apagado.Apelido}",
                            "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (DialogResult.OK == resultado)
                        {
                            CrudVeterinario.Veterinarios.Remove(apagado);
                            _crudVeterinario.GravarInfo();

                            if (contaVeternarios > 1)
                            {
                                contaVeternarios--;
                                txt_IDFuncionario.Text = contaVeternarios.ToString();
                            }

                            InicializaList();   // Inicializamos novamnete a lista para que o campo que apagamos nao seja mostrado 
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
        /// Evento para editar o veterinario selecionado
        /// </summary>
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (DGV_Veterinarios.SelectedRows.Count == 1)
            {
                Veterinario veterinarioAEditar = (Veterinario)DGV_Veterinarios.SelectedRows[0].DataBoundItem;
                Veterinario editado = null;     // depois de ser editado

                if (veterinarioAEditar != null)  // Caso haja alguma coisa selecionada ele entra
                {
                    foreach (Veterinario veterinario in CrudVeterinario.Veterinarios)  // Percorre a Lista
                    {
                        if (veterinarioAEditar.ID == veterinario.ID)
                        {
                            editado = veterinario;
                        }
                    }

                    // Abrir a nova FORM para editar o veterinario selecionado
                    FormEditarVeterinario formEditarVeterinario = new FormEditarVeterinario(this, editado);
                    formEditarVeterinario.Show();
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
        /// Metodo que valida se os campos estao bem preenchidos e se estão vazios ou não
        /// </summary>
        private bool ValidaDados()
        {
            bool output = true;
            int verifica;

            if (string.IsNullOrEmpty(txt_Nome.Text))        // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o nome do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_Nome.Text, "^[a-zA-Z][a-zA-Z]*$").Success)    // Validar se o nome esta no formato correto
            {
                MessageBox.Show("Insira apenas letras no nome do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Apelido.Text))     // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o apelido do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_Apelido.Text, "^[a-zA-Z][a-zA-Z]*$").Success)     // Validar se o apelido esta no formato correto
            {
                MessageBox.Show("Insira apenas letras no apelido do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_MaskedTelemovel.Text))     // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o telemovél do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_MaskedTelemovel.Text, @"(9[1236]\d) ?(\d{3}) ?(\d{3})").Success)     // Validar se o telemovel esta no formato correto
            {
                MessageBox.Show("Numero de telemóvel errado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Idade.Text))       // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira a idade do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!int.TryParse(txt_Idade.Text, out verifica))     // Validar se o campo idade esta bem preenchido
            {
                MessageBox.Show("Preencha corretamente o campo da idade do veterinário !", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_NIF.Text))          // Validar se o campo esta vazio       
            {
                MessageBox.Show("Insira o nif do veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Email.Text))       // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o email do Veterinário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            return output;
        }

        /// <summary>
        /// Metodo para validar o campo EMAIL
        /// </summary>
        public bool ValidaEmail(string endereco)
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

        /// <summary>
        /// Metodo para acrescentar o numero do ID de Veterinarios
        /// </summary>
        public void AcrescentaVeterinario()
        {
            int numeroVeterinarios = CrudVeterinario.Veterinarios.Count();

            contaVeternarios = numeroVeterinarios + 1;

            txt_IDFuncionario.Text = contaVeternarios.ToString();
        }

        #endregion

        #region InicializaçãoList

        public void InicializaList()
        {
            _crudVeterinario = new CrudVeterinario();
            DGV_Veterinarios.DataSource = null;                                 // Serve para dar refresh a Lista
            DGV_Veterinarios.DataSource = CrudVeterinario.Veterinarios;        // Associar a Lista ao DataSource da List Box
        }

        #endregion

        #region Limpeza

        /// <summary>
        /// Metodo para limpar os campos da form
        /// </summary>
        public void LimpaCampos()
        {
            txt_Idade.Text = "";
            txt_Nome.Text = "";
            txt_Apelido.Text = "";
            txt_Email.Text = "";
            txt_MaskedTelemovel.Text = "";
            txt_NIF.Text = "";
        }

        #endregion


    }
}
