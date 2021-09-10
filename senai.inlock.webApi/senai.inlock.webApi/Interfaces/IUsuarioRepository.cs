using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Buscar um usuario por email e senha
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>o usuario buscado</returns>
      public UsuarioDomain Login(string email, string senha);

    }
}
