﻿using Microsoft.EntityFrameworkCore;


namespace GerenciadorReceitasGUI2
{
    using MaterialSkin;
    using MaterialSkin.Controls;
    using System.Drawing;
    using System.Text;
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

        // Carrega a grid com informações
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

        // Botão para chamar o form de adicionar uma nova receita
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

        // Botão para editar a receita
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

        // Botão para excluir a receita
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

        // Botão para buscar a receita
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
        // Botão de exportar a receita
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dataGridViewReceitas.SelectedRows.Count > 0)
            {
                var receitaDTO = (ReceitaDTO)dataGridViewReceitas.SelectedRows[0].DataBoundItem;
                ExportarReceitaParaTxt(receitaDTO);
            }
            else
            {
                MessageBox.Show("Selecione uma receita para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ExportarReceitaParaTxt(ReceitaDTO receitaDTO)
        {
            using (var context = new ReceitasContext())
            {
                var receita = context.Receitas
                    .Include(r => r.Categoria)
                    .Include(r => r.Ingredientes)
                    .FirstOrDefault(r => r.Id == receitaDTO.Id);

                if (receita == null)
                {
                    MessageBox.Show("Receita não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(receita.Descricao()); // Usa o método da classe abstrata
                sb.AppendLine($"Categoria: {receita.Categoria?.Nome ?? "Sem Categoria"}");
                sb.AppendLine($"Tempo de Preparo: {receita.TempoPreparo} minutos");
                sb.AppendLine(new string('-', 40));

                sb.AppendLine("\n🥕 Ingredientes:\n");
                foreach (var ingrediente in receita.Ingredientes)
                {
                    sb.AppendLine($"   ➜ {ingrediente.Descricao()}"); // Usa o método da classe abstrata
                }

                sb.AppendLine("\n📖 Modo de Preparo:\n");
                sb.AppendLine(receita.Instrucoes);
                sb.AppendLine("\n" + new string('=', 40));

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Arquivo de Texto|*.txt";
                    saveFileDialog.Title = "Salvar Receita";
                    saveFileDialog.FileName = $"{receita.Nome}.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                        MessageBox.Show("Receita exportada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

    }
}