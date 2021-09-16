using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class CrudDono
    {
        public List<Dono> Donos;        // Cria lista "Donos"

        public CrudDono()
        {
            Donos = new List<Dono>();       // Inicializar a lista "Dono"
            LerInfo();
        }

        public void LerInfo()
        {
            string ficheiro = @"ListaDeDonos.txt";

            StreamReader sr;

            if(File.Exists(ficheiro))
            {
                sr = File.OpenText(ficheiro);

                string[] linhas = File.ReadAllLines(ficheiro);

                string linha = string.Empty;

                foreach (string linee in linhas)
                {
                    Dono dono = new Dono();

                    string[] campos = new string[6];

                    campos = linee.Split(';');

                    dono.ID = Convert.ToInt32(campos[0]);
                    dono.Nome = campos[1];
                    dono.Apelido = campos[2];
                    dono.Telemovel = campos[3];
                    dono.NIF = campos[4];
                    dono.Email = campos[5];

                    Donos.Add(dono);
                }

                sr.Close();
            }
        }

        public void GravarInfo()
        {
            StreamWriter sw = new StreamWriter("ListaDeDonos.txt");

            foreach (Dono donozinho in Donos)
            {
                sw.WriteLine(donozinho.ToString());
            }

            sw.Close();
        }
    }
}
