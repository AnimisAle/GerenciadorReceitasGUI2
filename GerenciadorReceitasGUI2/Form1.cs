using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GerenciadorReceitasGUI2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(240, 240, 240);
            AtualizarGrid();

            btnAdicionar.BackColor = Color.FromArgb(0, 120, 215);
            btnAdicionar.ForeColor = Color.White;
            btnEditar.BackColor = Color.FromArgb(0, 120, 215);
            btnEditar.ForeColor = Color.White;
            btnExcluir.BackColor = Color.FromArgb(220, 53, 69); // Vermelho para "Excluir"
            btnExcluir.ForeColor = Color.White;
            //this.Font = new Font("Segoe UI", 10);
            //dataGridViewReceitas.Font = new Font("Segoe UI", 10);
            //txtBuscar.Font = new Font("Segoe UI", 10);
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