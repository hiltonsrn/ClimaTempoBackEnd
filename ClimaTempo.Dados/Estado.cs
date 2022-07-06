using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaTempo.Dados
{
    public  class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public virtual ICollection<Cidade> Cidade { get; set; }
    }
}
