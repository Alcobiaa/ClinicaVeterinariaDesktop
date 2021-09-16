
namespace ProjetoFinal.Forms
{
    partial class FormEditarConsulta
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
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Animais = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Veterinario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DT_Data = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Sala = new System.Windows.Forms.ComboBox();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Fechar = new System.Windows.Forms.Button();
            this.cb_Hora = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(37, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Animal:";
            // 
            // cb_Animais
            // 
            this.cb_Animais.DisplayMember = "ID - Nome";
            this.cb_Animais.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_Animais.FormattingEnabled = true;
            this.cb_Animais.Location = new System.Drawing.Point(100, 43);
            this.cb_Animais.Name = "cb_Animais";
            this.cb_Animais.Size = new System.Drawing.Size(132, 25);
            this.cb_Animais.TabIndex = 1;
            this.cb_Animais.ValueMember = "ID - Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Veterinario:";
            // 
            // cb_Veterinario
            // 
            this.cb_Veterinario.DisplayMember = "Nome";
            this.cb_Veterinario.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_Veterinario.FormattingEnabled = true;
            this.cb_Veterinario.Location = new System.Drawing.Point(100, 89);
            this.cb_Veterinario.Name = "cb_Veterinario";
            this.cb_Veterinario.Size = new System.Drawing.Size(132, 25);
            this.cb_Veterinario.TabIndex = 2;
            this.cb_Veterinario.ValueMember = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(49, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Data:";
            // 
            // DT_Data
            // 
            this.DT_Data.CustomFormat = "dd-MM-yyyy";
            this.DT_Data.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DT_Data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_Data.Location = new System.Drawing.Point(100, 134);
            this.DT_Data.Name = "DT_Data";
            this.DT_Data.Size = new System.Drawing.Size(132, 22);
            this.DT_Data.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(51, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Hora:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(55, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Sala:";
            // 
            // cb_Sala
            // 
            this.cb_Sala.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_Sala.FormattingEnabled = true;
            this.cb_Sala.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cb_Sala.Location = new System.Drawing.Point(100, 226);
            this.cb_Sala.Name = "cb_Sala";
            this.cb_Sala.Size = new System.Drawing.Size(132, 25);
            this.cb_Sala.TabIndex = 5;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Image = global::ProjetoFinal.Resource1.guardar;
            this.btn_Guardar.Location = new System.Drawing.Point(65, 283);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(66, 69);
            this.btn_Guardar.TabIndex = 6;
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Image = global::ProjetoFinal.Resource1.Delete;
            this.btn_Cancelar.Location = new System.Drawing.Point(180, 283);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(66, 69);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Fechar
            // 
            this.btn_Fechar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Fechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Fechar.Image = global::ProjetoFinal.Resource1.Fechaar;
            this.btn_Fechar.Location = new System.Drawing.Point(251, 1);
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.Size = new System.Drawing.Size(30, 30);
            this.btn_Fechar.TabIndex = 23;
            this.btn_Fechar.UseVisualStyleBackColor = true;
            this.btn_Fechar.Click += new System.EventHandler(this.btn_Fechar_Click);
            // 
            // cb_Hora
            // 
            this.cb_Hora.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_Hora.FormattingEnabled = true;
            this.cb_Hora.Items.AddRange(new object[] {
            "9:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00"});
            this.cb_Hora.Location = new System.Drawing.Point(100, 179);
            this.cb_Hora.Name = "cb_Hora";
            this.cb_Hora.Size = new System.Drawing.Size(132, 25);
            this.cb_Hora.TabIndex = 4;
            // 
            // FormEditarConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(283, 364);
            this.Controls.Add(this.cb_Hora);
            this.Controls.Add(this.btn_Fechar);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.cb_Sala);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DT_Data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_Veterinario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Animais);
            this.Controls.Add(this.label3);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEditarConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditarConsulta";
            this.Load += new System.EventHandler(this.FormEditarConsulta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Animais;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Veterinario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DT_Data;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_Sala;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Fechar;
        private System.Windows.Forms.ComboBox cb_Hora;
    }
}