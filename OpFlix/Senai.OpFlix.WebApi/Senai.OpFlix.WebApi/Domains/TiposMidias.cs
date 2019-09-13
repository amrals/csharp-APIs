using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class TiposMidias
    {
        public TiposMidias()
        {
            Midias = new HashSet<Midias>();
        }

        public int IdTipoMidia { get; set; }
        public string Descricao { get; set; }

        public ICollection<Midias> Midias { get; set; }
    }
}
