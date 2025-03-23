using Microsoft.EntityFrameworkCore;


namespace GerenciadorReceitasGUI2
{
    using MaterialSkin;
    using MaterialSkin.Controls;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkinManager _materialSkinManager;

        public Form1()
        {
            InitializeComponent();

            // Configuração do MaterialSkin
            _materialSkinManager = MaterialSkinManager.Instance;
            _materialSkinManager.AddFormToManage(this);
            _materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            _materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue500, Primary.Blue700, Primary.Blue100,
                Accent.LightBlue200, TextShade.WHITE
            );
        }

        private void AtualizarGrid()
        {
            using (var context = new ReceitasContext())
            {
                dataGridViewReceitas.DataSource = context.Receitas
                    .Include(r => r.Categoria)
                    .Include(r => r.Ingredientes)
                    .ToList();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var context = new ReceitasContext())
            {
                var formAdicionar = new AdicionarReceitaForm();
                if (formAdicionar.ShowDialog() == DialogResult.OK)
                {
                    context.Receitas.Add(formAdicionar.Receita);
                    context.SaveChanges();
                    AtualizarGrid();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewReceitas.SelectedRows.Count > 0)
            {
                var receitaSelecionada = (Receita)dataGridViewReceitas.SelectedRows[0].DataBoundItem;
                using (var context = new ReceitasContext())
                {
                    var receita = context.Receitas
                        .Include(r => r.Ingredientes)
                        .FirstOrDefault(r => r.Id == receitaSelecionada.Id);

                    var formAdicionar = new AdicionarReceitaForm(receita);
                    if (formAdicionar.ShowDialog() == DialogResult.OK)
                    {
                        context.SaveChanges();
                        AtualizarGrid();
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridViewReceitas.SelectedRows.Count > 0)
            {
                var receitaSelecionada = (Receita)dataGridViewReceitas.SelectedRows[0].DataBoundItem;
                using (var context = new ReceitasContext())
                {
                    var receita = context.Receitas.Find(receitaSelecionada.Id);
                    context.Receitas.Remove(receita);
                    context.SaveChanges();
                    AtualizarGrid();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var context = new ReceitasContext())
            {
                var termo = txtBuscar.Text;
                dataGridViewReceitas.DataSource = context.Receitas
                    .Include(r => r.Categoria)
                    .Include(r => r.Ingredientes)
                    .Where(r => r.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
    }
}