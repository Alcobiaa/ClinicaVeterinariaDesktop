using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class FormEmail : Form
    {
        public FormEmail()
        {
            InitializeComponent();
        }

        #region Botões

        /// <summary>
        /// Evento para enviar o EMAIL 
        /// </summary>
        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaEmail(txt_Para.Text))
                {
                    DialogResult resultado;

                    resultado = MessageBox.Show($"Têm a certeza que pretende enviar o email para {txt_Para.Text}",
                           "Enviar Email", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if(DialogResult.OK == resultado)
                    {
                        MailMessage m = new MailMessage();
                        SmtpClient sc = new SmtpClient();

                        m.From = new MailAddress("aspxtestes@outlook.pt");
                        m.To.Add(new MailAddress(txt_Para.Text));
                        m.Subject = txt_Assunto.Text;
                        m.IsBodyHtml = true;
                        m.Body = txt_Mensagem.Text;

                        sc.Host = "smtp.office365.com";
                        sc.Port = 587;
                        sc.Credentials = new NetworkCredential("aspxtestes@outlook.pt", "Cinel2021");
                        sc.EnableSsl = true;
                        m.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        sc.SendCompleted += new SendCompletedEventHandler(Mensagem);

                        string userstate = "Sending...";

                        sc.SendAsync(m, userstate);
                        Close();
                    }
                    else
                    {
                        LimpaCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento para fechar o Form
        /// </summary>
        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento para cancelar o envio do EMAIL e fecha a FORM
        /// </summary>
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Validações

        /// <summary>
        /// Metodo para validar o campo EMAIL
        /// </summary>
        private bool ValidaEmail(string endereco)      // Metodo para validar o campo EMAIL
        {
            string pattern = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            Match emailAddressMatch = Regex.Match(endereco, pattern);
            return emailAddressMatch.Success;
        }

        /// <summary>
        /// Metodo que valida se os campos estao bem preenchidos e se estão vazios ou não
        /// </summary>
        private bool ValidaDados()                     // Metodo para validar se todos os campos estão preenchidos
        {
            bool output = true;

            if (string.IsNullOrEmpty(txt_Para.Text))        // Validar se o campo esta vazio 
            {
                MessageBox.Show("Insira o email destinátario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Assunto.Text))     // Validar se o campo esta vazio 
            {
                MessageBox.Show("Insira o assunto do email", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (string.IsNullOrEmpty(txt_Mensagem.Text))        // Validar se o campo esta vazio 
            {
                MessageBox.Show("Insira a mensagem do email", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            return output;
        }

        /// <summary>
        /// Metodo que informa o utilizador do estado do EMAIL
        /// </summary>
        private static void Mensagem(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show(string.Format("O envio do email foi cancelado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }

            if (e.Error != null)
            {
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("O seu EMAIL foi enviado com sucesso !", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void FormEmail_Load(object sender, EventArgs e)
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

        #region Limpeza

        /// <summary>
        /// Metodo para efetuar a limpeza dos campos
        /// </summary>
        public void LimpaCampos()
        {
            txt_Para.Text = "";
            txt_Assunto.Text = "";
            txt_Mensagem.Text = "";
        }

        #endregion
    }



}
