using ClimaTempo.Dados;
using ClimaTempo.Infra.Dominio;
using System.Globalization;

namespace ClimaTempo.Negocio
{
    public class PrevisaoBLL
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
                return PrevisoesToDTO(listaPrevisao);
            }
        }

        public List<PrevisaoDTO> ListaMaisQuentes(int Qtd)
        {
            using (ClimaTempoContext context = new ClimaTempoContext())
            {
                var listaPrevisao = context.PrevisaoClima.Where(item => item.DataPrevisao.Day == DateTime.Now.Day &&
                item.DataPrevisao.Month == DateTime.Now.Month &&
                item.DataPrevisao.Year == DateTime.Now.Year).OrderByDescending(item => item.TemperaturaMaxima).Skip(0).Take(Qtd).ToList();
                return PrevisoesToDTO(listaPrevisao);
            }
        }

        public List<PrevisaoDTO> ListaMaisFrias(int Qtd)
        {
            using (ClimaTempoContext context = new ClimaTempoContext())
            {
                var listaPrevisao = context.PrevisaoClima.Where(item => item.DataPrevisao.Day == DateTime.Now.Day &&
                item.DataPrevisao.Month == DateTime.Now.Month &&
                item.DataPrevisao.Year == DateTime.Now.Year).OrderBy(item => item.TemperaturaMaxima).Skip(0).Take(Qtd).ToList();
                return PrevisoesToDTO(listaPrevisao);
            }
        }
        public List<CidadeDTO> ListarCidades()
        {
            using (ClimaTempoContext context = new ClimaTempoContext())
            {
                var lista = context.Cidade.OrderBy(item => item.Nome).ToList();
                return CidadesToDTO(lista);
            }
        }
        private List<PrevisaoDTO> PrevisoesToDTO(List<PrevisaoClima> dados)
        {
            return dados.Select(item => new PrevisaoDTO
            {
                Cidade = item.Cidade.Nome,
                UF = item.Cidade.Estado.UF,
                Clima = item.Clima,
                Minima = item.TemperaturaMinima,
                Maxima = item.TemperaturaMaxima,
                Data = item.DataPrevisao.ToString("dd/MM/yyyy"),
                DiaSemana = item.DataPrevisao.ToString("ddd",
                        new CultureInfo("pt-BR")),
            }).ToList();
        }
        private List<CidadeDTO> CidadesToDTO(List<Cidade> dados)
        {
            return dados.Select(item => new CidadeDTO
            {
                Id = item.Id,
                Nome = item.Nome + " - " + item.Estado.UF
            }).ToList();
        }
    }
}