namespace GerenciadorReceitasGUI2
{
    partial class AdicionarReceitaForm
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
            label1 = new Label();
            txtNome = new TextBox();
            label2 = new Label();
            txtInstrucoes = new TextBox();
            label3 = new Label();
            nudTempoPreparo = new NumericUpDown();
            label4 = new Label();
            cmbCategoria = new ComboBox();
            label5 = new Label();
            lstIngredientes = new ListBox();
            label6 = new Label();
            txtIngrediente = new TextBox();
            txtIngredienteQuantidade = new TextBox();
            btnAdicionarIngrediente = new Button();
            btnSalvar = new Button();
            btnCancelar = new Button();
            label8 = new Label();
            pictureBoxFoto = new PictureBox();
            button1 = new Button();
            label7 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudTempoPreparo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 97);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(93, 89);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 140);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 2;
            label2.Text = "Instruções";
            // 
            // txtInstrucoes
            // 
            txtInstrucoes.Location = new Point(98, 132);
            txtInstrucoes.Name = "txtInstrucoes";
            txtInstrucoes.Size = new Size(384, 23);
            txtInstrucoes.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 175);
            label3.Name = "label3";
            label3.Size = new Size(139, 15);
            label3.TabIndex = 4;
            label3.Text = "Tempo de preparo (min.)";
            // 
            // nudTempoPreparo
            // 
            nudTempoPreparo.Location = new Point(181, 173);
            nudTempoPreparo.Name = "nudTempoPreparo";
            nudTempoPreparo.Size = new Size(120, 23);
            nudTempoPreparo.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 219);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 6;
            label4.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(107, 216);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(121, 23);
            cmbCategoria.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 257);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 8;
            label5.Text = "Ingredientes";
            // 
            // lstIngredientes
            // 
            lstIngredientes.FormattingEnabled = true;
            lstIngredientes.Location = new Point(107, 257);
            lstIngredientes.Name = "lstIngredientes";
            lstIngredientes.Size = new Size(317, 94);
            lstIngredientes.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 378);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 10;
            label6.Text = "Ingrediente";
            // 
            // txtIngrediente
            // 
            txtIngrediente.Location = new Point(93, 370);
            txtIngrediente.Name = "txtIngrediente";
            txtIngrediente.Size = new Size(100, 23);
            txtIngrediente.TabIndex = 11;
            // 
            // txtIngredienteQuantidade
            // 
            txtIngredienteQuantidade.Location = new Point(303, 375);
            txtIngredienteQuantidade.Name = "txtIngredienteQuantidade";
            txtIngredienteQuantidade.Size = new Size(100, 23);
            txtIngredienteQuantidade.TabIndex = 13;
            // 
            // btnAdicionarIngrediente
            // 
            btnAdicionarIngrediente.Location = new Point(430, 374);
            btnAdicionarIngrediente.Name = "btnAdicionarIngrediente";
            btnAdicionarIngrediente.Size = new Size(180, 23);
            btnAdicionarIngrediente.TabIndex = 14;
            btnAdicionarIngrediente.Text = "Adicionar Ingrediente";
            btnAdicionarIngrediente.UseVisualStyleBackColor = true;
            btnAdicionarIngrediente.Click += btnAdicionarIngrediente_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(20, 415);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(180, 23);
            btnSalvar.TabIndex = 15;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(223, 415);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(180, 23);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(218, 378);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 18;
            label8.Text = "Quantidade";
            // 
            // pictureBoxFoto
            // 
            pictureBoxFoto.Location = new Point(558, 132);
            pictureBoxFoto.Name = "pictureBoxFoto";
            pictureBoxFoto.Size = new Size(175, 176);
            pictureBoxFoto.TabIndex = 19;
            pictureBoxFoto.TabStop = false;
            pictureBoxFoto.Click += btnSelecionarFoto_Click;
            // 
            // button1
            // 
            button1.Location = new Point(558, 328);
            button1.Name = "button1";
            button1.Size = new Size(175, 23);
            button1.TabIndex = 20;
            button1.Text = "Selecione a Foto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSelecionarFoto_Click;
            // 
            // label7
            // 
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(558, 97);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 21;
            label9.Text = "Foto:";
            // 
            // AdicionarReceitaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(pictureBoxFoto);
            Controls.Add(label8);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(btnAdicionarIngrediente);
            Controls.Add(txtIngredienteQuantidade);
            Controls.Add(txtIngrediente);
            Controls.Add(label6);
            Controls.Add(lstIngredientes);
            Controls.Add(label5);
            Controls.Add(cmbCategoria);
            Controls.Add(label4);
            Controls.Add(nudTempoPreparo);
            Controls.Add(label3);
            Controls.Add(txtInstrucoes);
            Controls.Add(label2);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Name = "AdicionarReceitaForm";
            Text = "AdicionarReceitaForm";
            ((System.ComponentModel.ISupportInitialize)nudTempoPreparo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNome;
        private Label label2;
        private TextBox txtInstrucoes;
        private Label label3;
        private NumericUpDown nudTempoPreparo;
        private Label label4;
        private ComboBox cmbCategoria;
        private Label label5;
        private ListBox lstIngredientes;
        private Label label6;
        private TextBox txtIngrediente;
        private TextBox txtIngredienteQuantidade;
        private Button btnAdicionarIngrediente;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label label8;
        private PictureBox pictureBoxFoto;
        private Button button1;
        private Label label7;
        private Label label9;
    }
}