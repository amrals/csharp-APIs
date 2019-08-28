using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Permissoes
    {
        public Permissoes()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdPermissao { get; set; }
        public string Descricao { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
