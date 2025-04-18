﻿using GerenciadorReceitasGUI2;

public class Receita : ItemReceita
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Instrucoes { get; set; } = string.Empty; 
    public int TempoPreparo { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; } 
    public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

    public byte[]? Foto { get; set; }

    public override string ToString()
    {
        return $"{Nome} - {Instrucoes}";
    }

    public override string Descricao()
    {
        return $"🍽️ {Nome} - ⏳ {TempoPreparo} min";
    }
}