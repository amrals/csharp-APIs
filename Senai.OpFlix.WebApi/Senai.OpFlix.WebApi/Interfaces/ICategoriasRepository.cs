﻿using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ICategoriasRepository
    {
        List<Categorias> Listar();
        Categorias BuscarPorId(int id);
        void Cadastrar(Categorias categoria);
        void Atualizar(Categorias categoria);
        void Deletar(int id);
    }
}
