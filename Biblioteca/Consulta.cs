using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Consulta
    {   
        public int ID { get; set; }

        public string Animal { get; set; }

        public string Veterinario { get; set; }

        public int Sala { get; set; }

        public DateTime Data { get; set; }

        public string Hora { get; set; }

        public override string ToString()
        {
            return $"{ID};{Animal};{Veterinario};{Sala};{Data};{Hora}";
        }
    }
}
