using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class CrudConsulta
    {
        public List<Consulta> Consultas;        // Cria lista "Consultas"

        Veterinario veterinario = new Veterinario();

        public CrudConsulta()
        {
            Consultas = new List<Consulta>();
            LerInfo();
        }

        public void LerInfo()
        {
            string ficheiro = @"ListaDeConsultas.txt";

            StreamReader sr;

            if (File.Exists(ficheiro))
            {
                sr = File.OpenText(ficheiro);

                string[] linhas = File.ReadAllLines(ficheiro);

                string linha = string.Empty;

                foreach (string linee in linhas)
                {
                    Consulta consulta = new Consulta();

                    string[] campos = new string[5];

                    campos = linee.Split(';');

                    consulta.ID = Convert.ToInt32(campos[0]);
                    consulta.Animal = campos[1];
                    consulta.Veterinario = campos[2];
                    consulta.Sala = Convert.ToInt32(campos[3]);
                    consulta.Data = Convert.ToDateTime(campos[4]);
                    consulta.Hora = campos[5];

                    Consultas.Add(consulta);
                }

                sr.Close();
            }
        }

        public void GravarInfo()
        {
            StreamWriter sw = new StreamWriter("ListaDeConsultas.txt");

            foreach (Consulta consultazinha in Consultas)
            {
                sw.WriteLine(consultazinha.ToString());
            }
            
            sw.Close();
        }

        public override string ToString()
        {
            return $"{veterinario.Nome}";
        }
    }
}
