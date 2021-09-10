using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    /// <summary>
    /// Classe representa a entidade (tabela) jogo
    /// </summary>
    public class JogoDomain
    {
        public int idJogo { get; set; }

        [Required(ErrorMessage = "O id do Estúdio do jogo é obrigatório")]
        public int idEstudio { get; set; }

        [Required(ErrorMessage ="O nome do jogo é obrigatório")]
        public string nomeJogo { get; set; }

        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatório")]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "A descrição do jogo é obrigatório")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "O valor do jogo é obrigatório")]
        public float valor { get; set; }

        public EstudioDomain estudio { get; set; }
    }
}
