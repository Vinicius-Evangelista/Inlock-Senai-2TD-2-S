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
        /// lista todos os estudios cadastrados
        /// </summary>
        /// <returns>uma lista de estudio</returns>
        public List<EstudioDomain> ListarEstudios();

    }
}
