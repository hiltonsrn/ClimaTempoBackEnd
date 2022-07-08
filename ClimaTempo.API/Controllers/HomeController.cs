
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
            PrevisaoService  _service = new PrevisaoService();
            var dados =  _service.ListaPrevisao(Qtd, IdCidade);            
            return new ResultBag { Success = true, Data = dados };
        }
        [HttpGet]
        [Route("ListarMaisQuentes")]
        public ResultBag ListarMaisQuentes(int Qtd)
        {
            PrevisaoService  _service = new PrevisaoService();
            var dados =  _service.ListaMaisQuentes(Qtd);
            return new ResultBag { Success = true, Data = dados };
        }
        [HttpGet]
        [Route("ListarMaisFrias")]
        public ResultBag ListarMaisFrias(int Qtd)
        {
            PrevisaoService  _service = new PrevisaoService();
            var dados =  _service.ListaMaisFrias(Qtd);
            return new ResultBag { Success = true, Data = dados };
        }
        [HttpGet]
        [Route("ListarCidades")]
        public ResultBag ListarCidades()
        {
            PrevisaoService  _service = new PrevisaoService();
            var dados =  _service.ListarCidades();
            return new ResultBag { Success = true, Data = dados };
        }
    }
}
