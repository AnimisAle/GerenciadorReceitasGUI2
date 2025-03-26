namespace GerenciadorReceitasGUI2
{
    public class Ingrediente : ItemReceita 
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // Inicializa como vazio
        public string Quantidade { get; set; } = string.Empty; // Inicializa como vazio
        public int ReceitaId { get; set; }
        public Receita? Receita { get; set; } // Permite nulo

        public override string ToString()
        {
            return $"{Nome} - {Quantidade}";
        }
        public override string Descricao()
        {
            return $"{Nome} - {Quantidade}";
        }
    }
}