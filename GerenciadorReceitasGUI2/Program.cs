
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
                       new Categoria { Nome = "Massas" },
                       new Categoria { Nome = "Carnes" },
                       new Categoria { Nome = "Peixes e Frutos do Mar" },
                       new Categoria { Nome = "Sobremesas" },
                       new Categoria { Nome = "Lanches e Sandu�ches" },
                       new Categoria { Nome = "Saladas e Molhos" },
                       new Categoria { Nome = "Vegetariano/Vegano" },
                       new Categoria { Nome = "Bebidas e Drinks" },
                       new Categoria { Nome = "Caf� da Manh� e Brunch" },
                       new Categoria { Nome = "Pratos R�pidos" },
                       new Categoria { Nome = "Comida Fit e Saud�vel" },
                       new Categoria { Nome = "Receitas Regionais" }
                    );

                    context.SaveChanges();
                }
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}