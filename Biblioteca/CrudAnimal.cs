using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class CrudAnimal
    {
        public static List<Animal> Animais;        // Cria lista "Animais"

        public CrudAnimal()
        {
            Animais = new List<Animal>();       // Inicializar a lista "Animal"
            LerInfo();
        }

        public void LerInfo()
        {
            string ficheiro = @"ListaDeAnimais.txt";

            StreamReader sr;

            if (File.Exists(ficheiro))
            {
                sr = File.OpenText(ficheiro);

                string[] linhas = File.ReadAllLines(ficheiro);

                string linha = string.Empty;

                foreach (string linee in linhas)
                {
                    Animal animal = new Animal();

                    string[] campos = new string[6];

                    campos = linee.Split(';');

                    animal.ID = Convert.ToInt32(campos[0]);
                    animal.Nome = campos[1];
                    animal.Idade = Convert.ToInt32(campos[2]);
                    animal.Especie = campos[3];
                    animal.Peso = Convert.ToInt32(campos[4]);
                    animal.Raca = campos[5];
                    animal.Dono = campos[6];
                    
                    Animais.Add(animal);
                }

                sr.Close();
            }
        }

        public void GravarInfo()
        {
            StreamWriter sw = new StreamWriter("ListaDeAnimais.txt");

            foreach (Animal animalzinho in Animais)
            {
                sw.WriteLine(animalzinho.ToString());
            }

            sw.Close();
        }

        public override string ToString()
        {
            return $"{Animais}";
        }
    }
}
