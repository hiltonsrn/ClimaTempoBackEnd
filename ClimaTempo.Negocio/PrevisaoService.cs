using ClimaTempo.Dados;
using ClimaTempo.Infra;
using ClimaTempo.Infra.Dominio;
using System.Globalization;

namespace ClimaTempo.Negocio
{
    public class PrevisaoService
    {
        public List<PrevisaoDTO> ListaPrevisao(int Qtd, int IdCidade)
        {
            using (ClimaTempoContext context = new ClimaTempoContext())
            {
                var listaPrevisao = context.PrevisaoClima.Where(item => item.Cidade.Id == IdCidade &&
                item.DataPrevisao.Day > (DateTime.Now.Day) &&
                item.DataPrevisao.Month == DateTime.Now.Month &&
                item.DataPrevisao.Year == DateTime.Now.Year
                ).Skip(0).Take(Qtd).OrderBy(item => item.DataPrevisao).ToList();
                return FabricaDominio.PrevisoesToDTO(listaPrevisao);
            }
        }

        public List<PrevisaoDTO> ListaMaisQuentes(int Qtd)
        {
            using (ClimaTempoContext context = new ClimaTempoContext())
            {
                var listaPrevisao = context.PrevisaoClima.Where(item => item.DataPrevisao.Day == DateTime.Now.Day &&
                item.DataPrevisao.Month == DateTime.Now.Month &&
                item.DataPrevisao.Year == DateTime.Now.Year).OrderByDescending(item => item.TemperaturaMaxima).Skip(0).Take(Qtd).ToList();
                return FabricaDominio.PrevisoesToDTO(listaPrevisao);
            }
        }

        public List<PrevisaoDTO> ListaMaisFrias(int Qtd)
        {
            using (ClimaTempoContext context = new ClimaTempoContext())
            {
                var listaPrevisao = context.PrevisaoClima.Where(item => item.DataPrevisao.Day == DateTime.Now.Day &&
                item.DataPrevisao.Month == DateTime.Now.Month &&
                item.DataPrevisao.Year == DateTime.Now.Year).OrderBy(item => item.TemperaturaMaxima).Skip(0).Take(Qtd).ToList();
                return FabricaDominio.PrevisoesToDTO(listaPrevisao);
            }
        }
        public List<CidadeDTO> ListarCidades()
        {
            using (ClimaTempoContext context = new ClimaTempoContext())
            {
                var lista = context.Cidade.OrderBy(item => item.Nome).ToList();
                return FabricaDominio.CidadesToDTO(lista);
            }
        }
        
    }
}