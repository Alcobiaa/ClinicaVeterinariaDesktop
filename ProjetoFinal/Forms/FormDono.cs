using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class FormDono : Form
    {
        private CrudDono _crudDono;
        private CrudAnimal _crudAnimal;

        int contaDonos = 1;     // Variavel que ira servir para o ID Dono

        public FormDono()
        {
            _crudDono = new CrudDono();
            _crudAnimal = new CrudAnimal();

            InitializeComponent();
            InicializaList();
            AcrescentaDono();
        }

        #region Botões

        /// <summary>
        /// Evento para guardar os "Donos" inseridos no form
        /// </summary>
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Dono novoDono;

            if (ValidaDados())
            {
                if (ValidaEmail(txt_Email.Text) && ValidaNIF(txt_Nif.Text))    // Chama o Metodo de validar o campo email e Nif
                {
                    novoDono = new Dono()   // Cria o novo dono que esta a ser inserido no CRUD
                    {
                        ID = contaDonos,
                        Nome = txt_Nome.Text,
                        Apelido = txt_Apelido.Text,
                        Telemovel = txt_Telemovel.Text,
                        NIF = txt_Nif.Text,
                        Email = txt_Email.Text,
                    };

                    DialogResult resultado;

                    resultado = MessageBox.Show($"Têm a certeza que pretende adicionar o/a {novoDono.Nome} {novoDono.Apelido}",
                        "Adicionar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (DialogResult.OK == resultado)
                    {
                        _crudDono.Donos.Add(novoDono);      // Adiciona a Lista o novo Dono
                        _crudDono.GravarInfo();             // Grava a informação que foi inserida no TXT

                        AcrescentaDono();

                        InicializaList();
                        MessageBox.Show("Dono criado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Evento para inserir um novo dono
        /// </summary>
        private void btn_Novo_Click(object sender, EventArgs e)
        {
            txt_Nome.Text = "";
            txt_Apelido.Text = "";
            txt_IdDono.Text = "";
            txt_Nif.Text = "";
            txt_Telemovel.Text = "";
            txt_Email.Text = "";
        }

        /// <summary>
        /// Evento para eliminar o dono pretendido
        /// </summary>
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (DGV_Dono.SelectedRows.Count == 1)
            {
                Dono donoAApagar = (Dono)DGV_Dono.SelectedRows[0].DataBoundItem;
                Dono apagado = null;     // Auxiliar sem valor

                if (donoAApagar != null)  // Caso exista algum campo já selecionado
                {
                    foreach (Dono dono in _crudDono.Donos) // Percorre a lista toda
                    {
                        if (donoAApagar.ID == dono.ID)
                        {
                            apagado = dono;
                        }
                    }

                    if (apagado != null)     // Se o campo que queremos apagar já foi encontrado entra e pergunta ao utilizador se pretende mesmo apagar o campo, caso a resposta seja "OK" ele apaga
                    {
                        DialogResult resultado;

                        resultado = MessageBox.Show($"Têm a certeza que pretende apagar o/a {apagado.Nome} {apagado.Apelido}",
                            "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (DialogResult.OK == resultado)
                        {
                            _crudDono.Donos.Remove(apagado);
                            _crudDono.GravarInfo();

                            if(contaDonos > 1)
                            {
                                contaDonos--;
                                txt_IdDono.Text = contaDonos.ToString();
                            }


                            InicializaList();   // Inicializamos novamennte a lista para que o campo que apagamos nao seja mostrado 
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
        /// Evento para editar o "Dono" selecionado no form
        /// </summary>
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if(DGV_Dono.SelectedRows.Count == 1)
            {
                Dono donoAEditar = (Dono)DGV_Dono.SelectedRows[0].DataBoundItem;
                Dono editado = null;

                if (donoAEditar != null)  // Caso haja alguma coisa selecionada ele entra
                {
                    foreach (Dono dono in _crudDono.Donos)  // Percorre a Lista
                    {
                        if (donoAEditar.ID == dono.ID)
                        {
                            editado = dono;
                        }
                    }

                    // Abrir a nova FORM para editar o veterinario selecionado
                    FormEditarDono formEditarDono = new FormEditarDono(this, editado);
                    formEditarDono.Show();
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
        /// Metodo para validar o campo EMAIL
        /// </summary>
        public bool ValidaEmail(string endereco)
        {
            string pattern = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            Match emailAddressMatch = Regex.Match(endereco, pattern);
            return emailAddressMatch.Success;
        }

        /// <summary>
        /// Metodo que valida se os campos estao bem preenchidos e se estão vazios ou não
        /// </summary>
        private bool ValidaDados()
        {
            bool output = true;

            if (string.IsNullOrEmpty(txt_Nome.Text))        // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o nome do Dono do Animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_Nome.Text, "^[a-zA-Z][a-zA-Z]*$").Success)    // Validar se o nome esta no formato correto
            {
                MessageBox.Show("Insira apenas letras!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Apelido.Text))     // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o apelido do Dono", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_Apelido.Text, "^[a-zA-Z][a-zA-Z]*$").Success)     // Validar se o apelido esta no formato correto
            {
                MessageBox.Show("Insira apenas letras!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Telemovel.Text))       // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o telemovél do Dono", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_Telemovel.Text, @"(9[1236]\d) ?(\d{3}) ?(\d{3})").Success)     // Validar se o telemovel esta no formato correto
            {
                MessageBox.Show("Numero de telemóvel errado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Nif.Text))         // Validar se o campo esta vazio     
            {
                MessageBox.Show("Insira o Nif do Dono", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Email.Text))       // Validar se o campo esta vazio
            {
                MessageBox.Show("Insira o email do Dono", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            return output;
        }

        /// <summary>
        /// Metodo para acrescentar o numero do ID de Donos
        /// </summary>
        public void AcrescentaDono()
        {
            int numeroDonos = _crudDono.Donos.Count();

            contaDonos = numeroDonos + 1;

            txt_IdDono.Text = contaDonos.ToString();
        }

        #endregion

        #region LimpezaCampos

        /// <summary>
        /// Metodo para limpar os campos da form
        /// </summary>
        public void LimpaCampos()
        {
            txt_Nome.Text = "";
            txt_Apelido.Text = "";
            txt_IdDono.Text = "";
            txt_Nif.Text = "";
            txt_Telemovel.Text = "";
            txt_Email.Text = "";
        }

        #endregion

        #region InicializaLista

        public void InicializaList()
        {
            try
            {
                _crudDono = new CrudDono();
                DGV_Dono.DataSource = null;               // Serve para dar refresh a Lista
                DGV_Dono.DataSource = _crudDono.Donos;    // Associar a Lista ao DataSource da Data Grid View
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
