
namespace ProjetoFinal.Forms
{
    partial class FormTelemovel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTelemovel));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Mensagem = new System.Windows.Forms.TextBox();
            this.btn_Enviar = new System.Windows.Forms.Button();
            this.btn_Fechar = new System.Windows.Forms.Button();
            this.txt_Para = new System.Windows.Forms.MaskedTextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(57, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "PARA:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(16, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "MENSAGEM:";
            // 
            // txt_Mensagem
            // 
            this.txt_Mensagem.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Mensagem.Location = new System.Drawing.Point(119, 105);
            this.txt_Mensagem.Multiline = true;
            this.txt_Mensagem.Name = "txt_Mensagem";
            this.txt_Mensagem.Size = new System.Drawing.Size(227, 202);
            this.txt_Mensagem.TabIndex = 6;
            // 
            // btn_Enviar
            // 
            this.btn_Enviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enviar.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btn_Enviar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Enviar.Image")));
            this.btn_Enviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Enviar.Location = new System.Drawing.Point(26, 333);
            this.btn_Enviar.Name = "btn_Enviar";
            this.btn_Enviar.Size = new System.Drawing.Size(147, 62);
            this.btn_Enviar.TabIndex = 7;
            this.btn_Enviar.Text = "   ENVIAR";
            this.btn_Enviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Enviar.UseVisualStyleBackColor = true;
            this.btn_Enviar.Click += new System.EventHandler(this.btn_Enviar_Click);
            // 
            // btn_Fechar
            // 
            this.btn_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Fechar.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btn_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Fechar.Image")));
            this.btn_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Fechar.Location = new System.Drawing.Point(209, 333);
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.Size = new System.Drawing.Size(147, 62);
            this.btn_Fechar.TabIndex = 8;
            this.btn_Fechar.Text = "   FECHAR";
            this.btn_Fechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Fechar.UseVisualStyleBackColor = true;
            this.btn_Fechar.Click += new System.EventHandler(this.btn_Fechar_Click);
            // 
            // txt_Para
            // 
            this.txt_Para.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Para.Location = new System.Drawing.Point(119, 47);
            this.txt_Para.Mask = "(+351) 900000000";
            this.txt_Para.Name = "txt_Para";
            this.txt_Para.Size = new System.Drawing.Size(145, 23);
            this.txt_Para.TabIndex = 9;
            // 
            // btn_Close
            // 
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Image = global::ProjetoFinal.Resource1.Fechaar;
            this.btn_Close.Location = new System.Drawing.Point(351, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(30, 30);
            this.btn_Close.TabIndex = 10;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // FormTelemovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 413);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.txt_Para);
            this.Controls.Add(this.btn_Fechar);
            this.Controls.Add(this.btn_Enviar);
            this.Controls.Add(this.txt_Mensagem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTelemovel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar Mensagem";
            this.Load += new System.EventHandler(this.FormTelemovel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Mensagem;
        private System.Windows.Forms.Button btn_Enviar;
        private System.Windows.Forms.Button btn_Fechar;
        private System.Windows.Forms.MaskedTextBox txt_Para;
        private System.Windows.Forms.Button btn_Close;
    }
}