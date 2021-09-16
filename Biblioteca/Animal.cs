using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class Animal
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Especie { get; set; }

        public int Peso { get; set; }

        public string Raca { get; set; }

        public string Dono { get; set; }

        public override string ToString()
        {
            return $"{ID};{Nome};{Idade};{Especie};{Peso};{Raca};{Dono}";
        }
    }
}
