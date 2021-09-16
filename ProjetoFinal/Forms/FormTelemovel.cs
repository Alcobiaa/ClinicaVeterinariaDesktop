using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ProjetoFinal.Forms
{
    public partial class FormTelemovel : Form
    {
        public FormTelemovel()
        {
            InitializeComponent();
        }


        #region Botões

        /// <summary>
        /// Evento que ao clicar no botão envia a mensagem para o numero que foi inserido 
        /// </summary>
        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            bool ErrorMessage = false;

            try
            {

                if (ValidaDados())
                {

                    DialogResult resultado;

                     resultado = MessageBox.Show($"Têm a certeza que pretende enviar a mensagem para {txt_Para.Text}",
                            "Enviar SMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if(DialogResult.OK == resultado)
                    {
                        // Processo que faz com que a mensagem seja enviada para o numero selecionado
                        string accountSid = Environment.GetEnvironmentVariable("TwilioSid");
                        string authToken = Environment.GetEnvironmentVariable("TwilioAuth");

                        TwilioClient.Init(accountSid, authToken);

                        var message = MessageResource.Create(
                        body: txt_Mensagem.Text,
                        from: new Twilio.Types.PhoneNumber("+12282850475"),
                        to: new Twilio.Types.PhoneNumber(txt_Para.Text));

                        ErrorMessage = true;

                        if(ErrorMessage == true)
                        {
                            MessageBox.Show("Mensagem enviada com sucesso !", "Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                    else
                    {
                        LimpaCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = false;
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

        /// <summary>
        /// Evento para fechar a FORM
        /// </summary>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Validações

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

            if (string.IsNullOrEmpty(txt_Mensagem.Text))        // Validar se o campo esta vazio 
            {
                MessageBox.Show("Insira a mensagem do email", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            if (!Regex.Match(txt_Para.Text, @"(9[1236]\d) ?(\d{3}) ?(\d{3})").Success)     // Validar se o telemovel esta no formato correto
            {
                MessageBox.Show("Numero de telemóvel errado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                output = false;
            }

            return output;
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
        private void FormTelemovel_Load(object sender, EventArgs e)
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
            txt_Mensagem.Text = "";
        }

        #endregion


    }
}
