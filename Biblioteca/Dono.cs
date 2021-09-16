using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class Dono
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public string Telemovel { get; set; }

        public string NIF { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return $"{ID};{Nome};{Apelido};{Telemovel};{NIF};{Email}";
        }
    }
}
