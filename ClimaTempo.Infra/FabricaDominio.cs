using ClimaTempo.Dados;
using ClimaTempo.Infra.Dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Infra
{
    public class FabricaDominio
    {
        public static List<PrevisaoDTO> PrevisoesToDTO(List<PrevisaoClima> dados)
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
        public static List<CidadeDTO> CidadesToDTO(List<Cidade> dados)
        {
            return dados.Select(item => new CidadeDTO
            {
                Id = item.Id,
                Nome = item.Nome + " - " + item.Estado.UF
            }).ToList();
        }
    }
}
