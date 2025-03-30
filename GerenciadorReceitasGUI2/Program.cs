
namespace GerenciadorReceitasGUI2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var context = new ReceitasContext())
            {
                context.Database.EnsureCreated();
                if (!context.Categorias.Any())
                {
                    context.Categorias.AddRange(
                        new Categoria { Nome = "Sobremesa" },
                        new Categoria { Nome = "Prato Principal" },
                        new Categoria { Nome = "Café da Manhã" },
                        new Categoria { Nome = "Massa"},
                        new Categoria { Nome = "Salada"}
                    );
                    context.SaveChanges();
                }
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}