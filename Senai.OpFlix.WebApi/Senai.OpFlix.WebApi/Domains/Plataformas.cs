using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Plataformas
    {
        public Plataformas()
        {
            Midias = new HashSet<Midias>();
        }

        public int IdPlataforma { get; set; }
        public string Nome { get; set; }

        public ICollection<Midias> Midias { get; set; }
    }
}
