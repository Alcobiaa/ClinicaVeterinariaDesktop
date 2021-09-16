using Biblioteca;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class FormConsultas : Form
    {
        private CrudConsulta _crudConsulta;
        private CrudVeterinario _crudVeterinario;
        private CrudAnimal _crudAnimal;

        int contaConsultas = 1;             // Variavel que ira servir para o ID COnsulta

        public FormConsultas()
        {
            _crudConsulta = new CrudConsulta();
            _crudVeterinario = new CrudVeterinario();
            _crudAnimal = new CrudAnimal();

            InitializeComponent();
            InicializaList();
            AcrescentaConsulta();
        }

        #region Botões

        /// <summary>
        /// Evento para guardar as consultas que foram inseridas no FORM
        /// </summary>
        private void btn_Guardar_Click(object sender, EventArgs e)      // Metodo para guardar as consultas
        {
            Consulta novaConsulta;

            if (ValidaDados())                      // Chama o metodo que valida se os dados estão em branco ou preenchidos
            {
                novaConsulta = new Consulta()       // Cria a nova consulta que  esta a ser inserida no CRUD
                {
                    ID = contaConsultas,
                    Animal = cb_Animais.Text,
                    Veterinario = cb_Veterinario.Text,
                    Sala = Convert.ToInt32(cb_Sala.Text),
                    Hora = cb_Hora.Text,
                    Data = Convert.ToDateTime(Dt_Data.Value.ToString("yyyy-MM-dd")),
                };


                if (_crudConsulta.Consultas.Count == 0)
                {
                    _crudConsulta.Consultas.Add(novaConsulta);        // Adiciona a LIST a nova Consulta
                    _crudConsulta.GravarInfo();                       // Grava a nova Consulta

                    AcrescentaConsulta();

                    InicializaList();
                    MessageBox.Show("Consulta criada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpaCampos();
                }
                else
                {

                    bool verifica = false;

                    foreach (Consulta consulta in _crudConsulta.Consultas.ToList())
                    {

                        if (novaConsulta.Veterinario == consulta.Veterinario && novaConsulta.Hora == consulta.Hora && novaConsulta.Data == consulta.Data)
                        {
                            MessageBox.Show("Não pode marcar esta consulta, escolha uma hora diferente, outra data ou outro veterinario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            verifica = true;
                        }
                        else if (novaConsulta.Animal == consulta.Animal && novaConsulta.Hora == consulta.Hora && novaConsulta.Data == consulta.Data)
                        {
                            MessageBox.Show("Não pode marcar esta consulta, escolha uma hora diferente, outra data ou outro Animal", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            verifica = true;
                        }
                        else if (novaConsulta.Hora == consulta.Hora && novaConsulta.Data == consulta.Data && novaConsulta.Sala == consulta.Sala)
                        {
                            MessageBox.Show("Não pode marcar esta consulta, escolha uma sala diferente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            verifica = true;
                        }
                    }

                    if (verifica == false)
                    {
                        _crudConsulta.Consultas.Add(novaConsulta);        // Adiciona a LIST a nova Consulta
                        _crudConsulta.GravarInfo();                       // Grava a nova Consulta

                        AcrescentaConsulta();

                        InicializaList();
                        MessageBox.Show("Consulta criada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpaCampos();
                    }
                }
            }
        }

        /// <summary>
        /// Evento para inserir uma nova consulta
        /// </summary>
        private void btn_Novo_Click(object sender, EventArgs e)
        {
            cb_Animais.Text = null;
            cb_Hora.Text = null;
            cb_Sala.Text = null;
            cb_Veterinario.Text = null;
        }

        /// <summary>
        /// Evento para eliminar a consulta que foi Selecionada
        /// </summary>
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (DGV_Consultas.SelectedRows.Count == 1)
            {
                Consulta consultaAApagar = (Consulta)DGV_Consultas.SelectedRows[0].DataBoundItem;       // Vai buscar o campo que foi selecionado na DataGridView
                Consulta apagado = null;                                                                // Auxiliar sem valor

                // Se a contagem de linhas for maior que zero removemos a linha selecionada
                if (consultaAApagar != null)
                {
                    foreach (Consulta consulta in _crudConsulta.Consultas)    // Percorre a lista
                    {
                        if (consultaAApagar.ID == consulta.ID)
                        {
                            apagado = consulta;
                        }
                    }

                    if (apagado != null)    // Se o campo que queremos apagar já foi encontrado entra e pergunta ao utilizador se pretende mesmo apagar o campo, caso a resposta seja "OK" ele apaga
                    {
                        DialogResult resultado;

                        resultado = MessageBox.Show($"Têm a certeza que pretende apagar a consulta do animal {apagado.Animal}"
                            , "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (DialogResult.OK == resultado)
                        {
                            _crudConsulta.Consultas.Remove(apagado);
                            _crudConsulta.GravarInfo();

                            if (contaConsultas > 1)
                            {
                                contaConsultas--;
                                txt_IDConsulta.Text = contaConsultas.ToString();
                            }

                            InicializaList();       // Inicializamos novamente a lista para que o campo que apagamos nao seja mostrado
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
        /// Evento para editar a consulta pretendida
        /// </summary>
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (DGV_Consultas.SelectedRows.Count == 1)
            {
                Consulta consultaAEditar = (Consulta)DGV_Consultas.SelectedRows[0].DataBoundItem;           // Vai buscar o campo que foi selecionado na DataGridView
                Consulta editado = null;                                                                    // Auxiliar sem valor

                if (consultaAEditar != null)     // Caso haja algum registo selecionado entra
                {
                    foreach (Consulta consulta in _crudConsulta.Consultas)
                    {
                        if (consultaAEditar.ID == consulta.ID)
                        {
                            editado = consulta;
                        }
                    }

                    // Abrir a nova FORM para editar a consulta que foi selecionada
                    FormEditarConsulta formEditarConsulta = new FormEditarConsulta(this, editado);
                    formEditarConsulta.Show();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que exporta os dados para o PDF
        /// </summary>
        private void btn_PDF_Click(object sender, EventArgs e)
        {
            if (DGV_Consultas.Rows.Count > 0)
            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "Consultas.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {

                        try
                        {

                            File.Delete(save.FileName);

                        }
                        catch (Exception ex)
                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)
                    {

                        try
                        {
                            PdfPTable pTable = new PdfPTable(DGV_Consultas.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in DGV_Consultas.Columns)
                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in DGV_Consultas.Rows)
                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {

                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();

                                document.Add(pTable);

                                document.Close();

                                fileStream.Close();

                            }

                            MessageBox.Show("PDF guardado com sucesso", "Informação");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao exportar os dados para o PDF" + ex.Message);
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Não foram encontrados dados para exportar", "Info");
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

            if (string.IsNullOrEmpty(cb_Hora.Text))
            {
                MessageBox.Show("Têm de escolher uma hora", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            return output;
        }

        /// <summary>
        /// Metodo para acrescentar o numero do ID de Consultas
        /// </summary>
        public void AcrescentaConsulta()
        {
            int numeroConsultas = _crudConsulta.Consultas.Count();

            contaConsultas = numeroConsultas + 1;

            txt_IDConsulta.Text = contaConsultas.ToString();
        }

        #endregion

        #region InicializaçãoList

        /// <summary>
        /// Serve para dar refresh na DataGridView
        /// </summary>
        public void InicializaList()
        {
            _crudConsulta = new CrudConsulta();
            DGV_Consultas.DataSource = null;                          // Serve para dar Refresh a Lista
            DGV_Consultas.DataSource = _crudConsulta.Consultas;       // Associar a Lista ao DataSource da List Box
        }

        #endregion

        #region Limpeza

        /// <summary>
        /// Metodo para efetuar a limpeza dos campos
        /// </summary>
        public void LimpaCampos()
        {
            cb_Animais.SelectedItem = "";
            cb_Sala.SelectedItem = "";
            cb_Veterinario.SelectedItem = "";
            Dt_Data.Value = DateTime.Now;
        }

        #endregion

        #region Load

        private void FormConsultas_Load(object sender, EventArgs e)
        {
            cb_Animais.DataSource = CrudAnimal.Animais;
            cb_Animais.DisplayMember = "Nome";
            cb_Veterinario.DataSource = CrudVeterinario.Veterinarios;
            cb_Veterinario.DisplayMember = "Nome";
            Dt_Data.MinDate = DateTime.Now;
        }

        #endregion
    }
}
