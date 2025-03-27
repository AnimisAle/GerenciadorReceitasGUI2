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
            dataGridViewReceitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReceitas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewReceitas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            AtualizarGrid(); 
        }

        private void AtualizarGrid()
        {
            using (var context = new ReceitasContext())
            {
                var receitas = context.Receitas
            .Include(r => r.Categoria)
            .Include(r => r.Ingredientes)
            .Select(r => new ReceitaDTO
            {
                Id = r.Id,
                Nome = r.Nome,
                Categoria = r.Categoria != null ? r.Categoria.Nome : "Sem Categoria",
                Ingredientes = string.Join(", ", r.Ingredientes.Select(i => i.Nome))
            })
            .ToList();

                if (receitas.Count == 0)
                {
                    MessageBox.Show("Nenhuma receita encontrada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dataGridViewReceitas.DataSource = receitas;
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
                var receitaDTO = (ReceitaDTO)dataGridViewReceitas.SelectedRows[0].DataBoundItem;
                using (var context = new ReceitasContext())
                {
                    var receita = context.Receitas
                        .Include(r => r.Ingredientes)
                        .FirstOrDefault(r => r.Id == receitaDTO.Id); // Buscando pelo ID do DTO

                    if (receita != null)
                    {
                        var formAdicionar = new AdicionarReceitaForm(receita);
                        if (formAdicionar.ShowDialog() == DialogResult.OK)
                        {
                            context.SaveChanges();
                            AtualizarGrid();
                        }
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridViewReceitas.SelectedRows.Count > 0)
            {
                var receitaDTO = (ReceitaDTO)dataGridViewReceitas.SelectedRows[0].DataBoundItem;
                using (var context = new ReceitasContext())
                {
                    var receita = context.Receitas.Find(receitaDTO.Id);
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
                var termo = txtBuscar.Text.ToLower();

                var receitas = context.Receitas
            .Include(r => r.Categoria)
            .Include(r => r.Ingredientes)
            .Where(r => r.Nome.ToLower().Contains(termo))
            .Select(r => new ReceitaDTO
            {
                Id = r.Id,
                Nome = r.Nome,
                Categoria = r.Categoria.Nome,
                Ingredientes = string.Join(", ", r.Ingredientes.Select(i => i.Nome)) // Junta os ingredientes em uma string
            })
            .ToList();

                dataGridViewReceitas.DataSource = receitas;
            }
        }
    }
}