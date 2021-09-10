using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IJogoRepository
    {
        //CRUD


        /// <summary>
        /// cadastra um novo 
        /// </summary>
        /// <param name="novoJogo">objeto contendo as inforamções do novo jogo</param>
        public void CadastrarJogo(JogoDomain novoJogo);


        /// <summary>
        /// lista todos os jogoso
        /// </summary>
        /// <returns>retorna uma lista de jogos</returns>
        public List<JogoDomain> ListarJogos();
    
        /// <summary>
        /// atualiza um novo jogo
        /// </summary>
        /// <param name="id">id do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">objeto contendo as informações que serão atualizadas</param>
        public void AtualizarJogo(int id, JogoDomain jogoAtualizado);


        /// <summary>
        /// deleta um jogo
        /// </summary>
        /// <param name="id">id do jogo que será deletado</param>
        public void Deletarjogo(int id);


        /// <summary>
        /// retorna um jogo retornado por id
        /// </summary>
        /// <param name="id">id do jogo</param>
        /// <returns> o jogo exigido</returns>
        public JogoDomain BuscarPorId(int id);
        
    }
}
