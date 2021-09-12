using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //objeto do tipo IUsuarioRepository que recebe os métodos do repositório
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);

            if (usuarioBuscado != null)
            {
                //dados que serão fornecidos no token
                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()), //pq aqui está ToString ? e para que serve o JTI
                    new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString()),
                    new Claim("Claim sla","mais sla"),

                };


                //definição da chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ASUE9APSHF-JPOQWI-FUJ"));

                //define as credenciais do token - signture
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //definindo o PayLoad
                var meuToken = new JwtSecurityToken(

                    issuer: "senai.inlock.webApi",
                    audience: "senai.inlock.webApi",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                    );

                // o token só vai ser criado quando ele foi retornado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });


            }

           return NotFound(
                new
                {
                    mensagem = "Usuario não encontrado !",
                    erro = true
                }
            );
        }
    }
}
