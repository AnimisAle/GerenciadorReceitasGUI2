using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorReceitasGUI2
{
    public abstract class ItemReceita
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        // Método abstrato que será sobrescrito nas classes derivadas
        public abstract string Descricao();
    }
}
