using System;
using System.Collections.Generic;
using System.Text;

namespace modulo1.Dto
{
    public class Oportunidade : Domain
    {

        public string Salario { get; set; }
        public List<Candidato> Candidatos { get; set; }
    }
}
