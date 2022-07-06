using ClimaTempo.API.Dominio;
using ClimaTempo.Dados;
using ClimaTempo.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace ClimaTempo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("ListarPrevisoes")]
        public ResultBag ListarPrevisoes(int Qtd, int IdCidade)
        {
            PrevisaoBLL bll = new PrevisaoBLL();
            var dados = bll.ListaPrevisao(Qtd, IdCidade);            
            return new ResultBag { Success = true, Data = dados };
        }
        [HttpGet]
        [Route("ListarMaisQuentes")]
        public ResultBag ListarMaisQuentes(int Qtd)
        {
            PrevisaoBLL bll = new PrevisaoBLL();
            var dados = bll.ListaMaisQuentes(Qtd);
            return new ResultBag { Success = true, Data = dados };
        }
        [HttpGet]
        [Route("ListarMaisFrias")]
        public ResultBag ListarMaisFrias(int Qtd)
        {
            PrevisaoBLL bll = new PrevisaoBLL();
            var dados = bll.ListaMaisFrias(Qtd);
            return new ResultBag { Success = true, Data = dados };
        }
        [HttpGet]
        [Route("ListarCidades")]
        public ResultBag ListarCidades()
        {
            PrevisaoBLL bll = new PrevisaoBLL();
            var dados = bll.ListarCidades();
            return new ResultBag { Success = true, Data = dados };
        }
    }
}
