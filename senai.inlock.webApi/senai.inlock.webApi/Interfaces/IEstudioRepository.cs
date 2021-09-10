using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// cadastra um novo usuário
        /// </summary>
        /// <param name="estudioDomain">um objeto contendo as informações do novo objeto</param>
        public void CadastrarEstudio(EstudioDomain estudioDomain);

        /// <summary>
        /// lista todos os estudios cadastrados
        /// </summary>
        /// <returns>uma lista de estudio</returns>
        public List<EstudioDomain> ListarEstudios();

    }
}
