using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Midias
    {
        public int IdMidia { get; set; }
        public string Nome { get; set; }
        public string DataLancamento { get; set; }
        public int? IdCategoria { get; set; }
        public string Sinopse { get; set; }
        public string Duracao { get; set; }
        public int? IdTipoMidia { get; set; }
        public int? IdPlataforma { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public Plataformas IdPlataformaNavigation { get; set; }
        public TiposMidias IdTipoMidiaNavigation { get; set; }
    }
}
