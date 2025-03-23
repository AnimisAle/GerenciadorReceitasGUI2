using System;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations.Schema;
using GerenciadorReceitasGUI2;

namespace GerenciadorReceitasGUI2
{
    public partial class AdicionarReceitaForm : Form
    {
        [NotMapped]
        public Receita Receita { get; private set; }

        public AdicionarReceitaForm(Receita receita = null)
        {
            InitializeComponent();
            Receita = receita ?? new Receita();

            // Carregar categorias no ComboBox
            using (var context = new ReceitasContext())
            {
                var categorias = context.Categorias.ToList();
                if (categorias.Count == 0)
                {
                    MessageBox.Show("Nenhuma categoria disponível. Adicione categorias ao banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                cmbCategoria.DataSource = categorias;
                cmbCategoria.DisplayMember = "Nome";
                cmbCategoria.ValueMember = "Id";

                // Selecionar a primeira categoria por padrão
                if (categorias.Any())
                {
                    cmbCategoria.SelectedIndex = 0;
                }
            }

            if (receita != null)
            {
                txtNome.Text = receita.Nome;
                txtInstrucoes.Text = receita.Instrucoes;
                nudTempoPreparo.Value = receita.TempoPreparo;
                cmbCategoria.SelectedValue = receita.CategoriaId;
                lstIngredientes.Items.AddRange(receita.Ingredientes.ToArray());
            }
        }

        private void btnAdicionarIngrediente_Click(object sender, EventArgs e)
        {
            var ingrediente = new Ingrediente
            {
                Nome = txtIngrediente.Text,
                Quantidade = txtIngredienteQuantidade.Text
            };
            Receita.Ingredientes.Add(ingrediente);
            lstIngredientes.Items.Add(ingrediente);
            txtIngrediente.Clear();
            txtIngredienteQuantidade.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione uma categoria.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Receita.Nome = txtNome.Text;
            Receita.Instrucoes = txtInstrucoes.Text;
            Receita.TempoPreparo = (int)nudTempoPreparo.Value;
            Receita.CategoriaId = (int)cmbCategoria.SelectedValue;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}