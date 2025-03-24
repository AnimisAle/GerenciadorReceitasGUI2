using GerenciadorReceitasGUI2;

public class Receita
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty; // Inicializa como vazio
    public string Instrucoes { get; set; } = string.Empty; // Inicializa como vazio
    public int TempoPreparo { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; } // Permite nulo
    public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

    public byte[]? Foto { get; set; }
}