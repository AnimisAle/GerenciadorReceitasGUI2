using System.Collections.Generic;

namespace GerenciadorReceitasGUI2
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Receita> Receitas { get; set; } = new List<Receita>(); // Relacionamento 1:N
    }
}