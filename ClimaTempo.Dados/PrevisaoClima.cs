using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Dados
{
    public class PrevisaoClima
    {
        public int Id { get; set; }
        public virtual Cidade Cidade { get; set; }
        public DateTime DataPrevisao { get; set; }

        public string Clima { get; set; }

        public decimal TemperaturaMinima { get; set; }
        public decimal TemperaturaMaxima { get; set; }
    }
}
