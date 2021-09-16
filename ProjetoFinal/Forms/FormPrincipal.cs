using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class FormPrincipal : Form
    {
        //Campos
        private Button currentButton;
        private Random random;
        private int tempIndex;
        public Form activeForm;
        
        //Construtores
        public FormPrincipal()
        {
            InitializeComponent();
            random = new Random();
            
            // O Botao de fechar a Form nao esta visivel quando o programa corre
            btn_CloseChildForm.Visible = false;
            
            // Alterar o aspeto da FORM Principal
            this.Text = string.Empty;
            this.ControlBox = false;

            // Alterar os limites da Form Principal
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }


        // E utilizado para se poder arrastar o FORM
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #region Botões

        /// <summary>
        /// Evento que ao clicar na opção Veterinario abre o FORM Veterinario na FORM principal
        /// </summary>
        private void btn_Veternarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormVeternario(), sender);
        }

        /// <summary>
        /// Evento que abre o FORM Animais na FORM principal
        /// </summary>
        private void btn_Animais_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormAnimais(), sender);
        }

        /// <summary>
        /// Evento que abre o FORM Dono na FORM principal 
        /// </summary>
        private void btn_Dono_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDono(), sender);
        }

        /// <summary>
        /// Evento que ao clicar na opção Consultas abre o FORM Consultas na FORM principal
        /// </summary>
        private void btn_Consultas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormConsultas(), sender);
        }

        /// <summary>
        /// Evento que ao clicar na opção Comunicações abre o FORM Comunicações na FORM principal
        /// </summary>
        private void btn_Comunicações_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormComunicações(), sender);
        }

        /// <summary>
        /// Evento que ao clicar na opção Sobrte abre o FORM Sobre na FORM principal
        /// </summary>
        private void btn_Sobre_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSobre(), sender);
        }

        /// <summary>
        /// Evento que vai ser utilizado para fechar o form que esta aberto na Form Principal
        /// </summary>
        private void btn_CloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }

        /// <summary>
        /// Evento que permite fechar a form
        /// </summary>
        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evento para Minimizar o FORM
        /// </summary>
        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Tema

        /// <summary>
        /// Metodo que vai buscar uma cor a lista de cores que esta na classe "ThemeColor"
        /// </summary>
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);

            while (tempIndex == index) // Se a cor já tiver sido selecionada , ele vai a procura de outra cor 
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }

            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        /// <summary>
        /// Este metodo vai ser utilizado para mudar as cores dos Botoes , o background do botão, a fonte e o tamanho
        /// </summary>
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;

                    // Mudar a cor do background do Botao
                    currentButton.BackColor = color;

                    // Mudar a cor da Letra
                    currentButton.ForeColor = Color.White;

                    // Mudar a Fonte do Botao
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

                    // Mudar a cor do Background do painel do Titulo
                    panel_Titlo.BackColor = color;

                    // Mudar a cor do Background do painel do Logo
                    panel_Logo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                    // Activa o botão de fechar a FORM
                    btn_CloseChildForm.Visible = true;
                }
            }
        }

        /// <summary>
        /// Este metodo vai servir para mudar os aspetos do botao quando ja foi ativo
        /// </summary>
        private void DisableButton()
        {
            foreach (Control previousBtn in panel_Menu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    // Mudar a cor do background do Botao
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);

                    // Mudar a cor da Letra
                    previousBtn.ForeColor = Color.Gainsboro; // Gainsboro foi a cor selecionada no form inicial para a cor da letra

                    // Mudar a Fonte da Letra
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }

        /// <summary>
        /// Faz com que quando se fecha um form dentro do FORM Principal apareca as propriedades iniciais 
        /// </summary>
        private void Reset()
        {
            DisableButton();

            // Voltar a escrever na lbl Titulo = HOME
            lbl_Titulo.Text = "HOME";

            // O Panel Titulo volta para a cor original
            panel_Titlo.BackColor = Color.FromArgb(0, 150, 136);

            // O Panel Logo volta para a cor original
            panel_Logo.BackColor = Color.FromArgb(39, 39, 58);

            currentButton = null;

            btn_CloseChildForm.Visible = false;

        }

        #endregion

        #region Form

        /// <summary>
        /// Metodo que vai fazer com que os restantes forms sejam abertos no Form Principal
        /// </summary>
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(btnSender);

            activeForm = childForm;

            // Mexer nas propriedades da nova Form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;


            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lbl_Titulo.Text = childForm.Text;  // O titulo do Form passa a ser igual ao Botão selecionado
        }

        #endregion

        #region Timer

        /// <summary>
        /// Relogio que aparece no Form Principal
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Tempo
            label2.Text = DateTime.Now.ToLongTimeString();

            // Data
            label3.Text = DateTime.Now.ToShortDateString();
        }

        #endregion


        private void panel_Titlo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
