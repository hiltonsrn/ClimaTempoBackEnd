namespace ClimaTempo.Infra.Dominio
{
    public class PrevisaoDTO
    {
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Clima { get; set; }
        public Decimal Maxima { get; set; }
        public Decimal Minima { get; set; }
        public string Data { get; set; }
        public string DiaSemana { get; set; }
    }
}
