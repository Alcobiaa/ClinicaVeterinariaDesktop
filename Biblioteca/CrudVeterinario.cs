using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class CrudVeterinario
    {
        public static List<Veterinario> Veterinarios;           // Cria lista "Veterinario"

        public CrudVeterinario()
        {
            Veterinarios = new List<Veterinario>();     // Inicializar a lista "Veterinario"
            LerInfo();
        }

        private void LerInfo()
        {
            string ficheiro = @"ListaDeVeterinarios.txt";

            StreamReader sr;

            if(File.Exists(ficheiro))
            {
                sr = File.OpenText(ficheiro);

                string[] linhas = File.ReadAllLines(ficheiro);

                string linha = string.Empty;

                foreach (string linee in linhas)
                {
                    Veterinario veterinario = new Veterinario();

                    string[] campos = new string[6];

                    campos = linee.Split(';');

                    veterinario.ID = Convert.ToInt32(campos[0]);
                    veterinario.Nome = campos[1];
                    veterinario.Apelido = campos[2];
                    veterinario.Idade = Convert.ToInt32(campos[3]);
                    veterinario.Telemovel = campos[4];
                    veterinario.Email = campos[5];
                    veterinario.NIF = campos[6];

                    Veterinarios.Add(veterinario);
                }

                sr.Close();
            }

        }

        public void GravarInfo()
        {
            StreamWriter sw = new StreamWriter("ListaDeVeterinarios.txt");

            foreach (Veterinario veterinariozinho in Veterinarios)
            {
                sw.WriteLine(veterinariozinho.ToString());
            }

            sw.Close();
        }
    }
}
