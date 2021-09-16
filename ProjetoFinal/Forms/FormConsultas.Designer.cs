
namespace ProjetoFinal.Forms
{
    partial class FormConsultas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Animais = new System.Windows.Forms.ComboBox();
            this.DGV_Consultas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Veterinario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Dt_Data = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_Sala = new System.Windows.Forms.ComboBox();
            this.btn_Novo = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_IDConsulta = new System.Windows.Forms.TextBox();
            this.btn_PDF = new System.Windows.Forms.Button();
            this.cb_Hora = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Consultas)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(259, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Animal:";
            // 
            // cb_Animais
            // 
            this.cb_Animais.DisplayMember = "Nome";
            this.cb_Animais.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_Animais.FormattingEnabled = true;
            this.cb_Animais.Location = new System.Drawing.Point(323, 38);
            this.cb_Animais.Name = "cb_Animais";
            this.cb_Animais.Size = new System.Drawing.Size(111, 25);
            this.cb_Animais.TabIndex = 1;
            this.cb_Animais.ValueMember = "Nome";
            // 
            // DGV_Consultas
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DGV_Consultas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Consultas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DGV_Consultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Consultas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Consultas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Consultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Consultas.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Consultas.Location = new System.Drawing.Point(30, 170);
            this.DGV_Consultas.Name = "DGV_Consultas";
            this.DGV_Consultas.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Consultas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_Consultas.RowTemplate.Height = 25;
            this.DGV_Consultas.Size = new System.Drawing.Size(701, 153);
            this.DGV_Consultas.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(461, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Veterinário:";
            // 
            // cb_Veterinario
            // 
            this.cb_Veterinario.DisplayMember = "Nome";
            this.cb_Veterinario.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_Veterinario.FormattingEnabled = true;
            this.cb_Veterinario.Location = new System.Drawing.Point(549, 37);
            this.cb_Veterinario.Name = "cb_Veterinario";
            this.cb_Veterinario.Size = new System.Drawing.Size(121, 25);
            this.cb_Veterinario.TabIndex = 2;
            this.cb_Veterinario.ValueMember = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(60, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Data:";
            // 
            // Dt_Data
            // 
            this.Dt_Data.CustomFormat = "dd-MM-yyyy";
            this.Dt_Data.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Dt_Data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dt_Data.Location = new System.Drawing.Point(125, 103);
            this.Dt_Data.MaxDate = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            this.Dt_Data.MinDate = new System.DateTime(2021, 6, 11, 0, 0, 0, 0);
            this.Dt_Data.Name = "Dt_Data";
            this.Dt_Data.Size = new System.Drawing.Size(111, 22);
            this.Dt_Data.TabIndex = 3;
            this.Dt_Data.Value = new System.DateTime(2021, 6, 11, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(273, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Hora:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(504, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Sala:";
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
            this.cb_Sala.Location = new System.Drawing.Point(549, 100);
            this.cb_Sala.Name = "cb_Sala";
            this.cb_Sala.Size = new System.Drawing.Size(121, 25);
            this.cb_Sala.TabIndex = 5;
            // 
            // btn_Novo
            // 
            this.btn_Novo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Novo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Novo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Novo.Image = global::ProjetoFinal.Resource1.NovoAnimais;
            this.btn_Novo.Location = new System.Drawing.Point(224, 350);
            this.btn_Novo.Name = "btn_Novo";
            this.btn_Novo.Size = new System.Drawing.Size(66, 69);
            this.btn_Novo.TabIndex = 7;
            this.btn_Novo.UseVisualStyleBackColor = true;
            this.btn_Novo.Click += new System.EventHandler(this.btn_Novo_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Image = global::ProjetoFinal.Resource1.guardar;
            this.btn_Guardar.Location = new System.Drawing.Point(344, 350);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(66, 69);
            this.btn_Guardar.TabIndex = 8;
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Editar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Editar.Image = global::ProjetoFinal.Resource1.EditarAnimais;
            this.btn_Editar.Location = new System.Drawing.Point(464, 350);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(66, 69);
            this.btn_Editar.TabIndex = 9;
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Eliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eliminar.Image = global::ProjetoFinal.Resource1.Delete;
            this.btn_Eliminar.Location = new System.Drawing.Point(584, 350);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(66, 69);
            this.btn_Eliminar.TabIndex = 10;
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(60, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "ID Animal:";
            // 
            // txt_IDConsulta
            // 
            this.txt_IDConsulta.Enabled = false;
            this.txt_IDConsulta.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_IDConsulta.Location = new System.Drawing.Point(140, 39);
            this.txt_IDConsulta.Name = "txt_IDConsulta";
            this.txt_IDConsulta.Size = new System.Drawing.Size(29, 22);
            this.txt_IDConsulta.TabIndex = 26;
            // 
            // btn_PDF
            // 
            this.btn_PDF.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_PDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_PDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PDF.Image = global::ProjetoFinal.Resource1.pdf;
            this.btn_PDF.Location = new System.Drawing.Point(104, 350);
            this.btn_PDF.Name = "btn_PDF";
            this.btn_PDF.Size = new System.Drawing.Size(66, 69);
            this.btn_PDF.TabIndex = 6;
            this.btn_PDF.UseVisualStyleBackColor = true;
            this.btn_PDF.Click += new System.EventHandler(this.btn_PDF_Click);
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
            this.cb_Hora.Location = new System.Drawing.Point(322, 103);
            this.cb_Hora.Name = "cb_Hora";
            this.cb_Hora.Size = new System.Drawing.Size(108, 25);
            this.cb_Hora.TabIndex = 4;
            // 
            // FormConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 426);
            this.Controls.Add(this.cb_Hora);
            this.Controls.Add(this.btn_PDF);
            this.Controls.Add(this.txt_IDConsulta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.btn_Novo);
            this.Controls.Add(this.cb_Sala);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Dt_Data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_Veterinario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV_Consultas);
            this.Controls.Add(this.cb_Animais);
            this.Controls.Add(this.label5);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "FormConsultas";
            this.Text = "MARCAR CONSULTAS";
            this.Load += new System.EventHandler(this.FormConsultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Consultas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_Animais;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Veterinario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_Sala;
        private System.Windows.Forms.Button btn_Novo;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Eliminar;
        public System.Windows.Forms.DateTimePicker Dt_Data;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_IDConsulta;
        private System.Windows.Forms.Button btn_PDF;
        private System.Windows.Forms.ComboBox cb_Hora;
        public System.Windows.Forms.DataGridView DGV_Consultas;
    }
}