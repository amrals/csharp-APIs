using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebAPI.Domains
{
    public class GenerosDomain
    {
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "O nome do Estilo Musical é obrigatório.")]
        public string Nome { get; set; }
    }
}
