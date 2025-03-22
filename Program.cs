using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_zarządzania_planem_pieczenia_ciast_v2
{

    public class Ciasto //Tworzy klasę ciasto
    {
        public string Nazwa { get; set; }
        public string Rodzaj { get; set; }
        public List<string> Skladniki { get; set; }

        public Ciasto(string nazwa, string rodzaj, List<string> skladniki)
        {
            Nazwa = nazwa;
            Rodzaj = rodzaj;
            Skladniki = skladniki;
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"Ciasto: {Nazwa}, Rodzaj: {Rodzaj}, Składniki: {string.Join(", ", Skladniki)}");
        }
    }
    public interface IFabrykaCiasta //Tworzy interfejs fabryki ciasta
    {
        Ciasto StworzCiasto(); //Metoda tworzenia ciasta
    }
    public class FabrykaCiastaCzekoladowego : IFabrykaCiasta //Klasa fabryki ciasta czekoladowego
    {
        public Ciasto StworzCiasto()
        {
            return new Ciasto("Czekoladowe", "Kruche", new List<string> { "Czekolada", "Mąka", "Jajka", "Masło" });
        }
    }
    public class FabrykaCiastaJablkowego : IFabrykaCiasta //Klasa fabryki ciasta jabłkowego
    {
        public Ciasto StworzCiasto()
        {
            return new Ciasto("Jabłkowe", "Drożdżowe", new List<string> { "Jabłka", "Cynamon", "Mąka", "Cukier" });
        }
    }
    public class PlanPieczenia : IEnumerable<Ciasto> //Klasa plan pieczenia
    {
        private List<Ciasto> listaCiast = new List<Ciasto>(); //Zapisuje co dodajemy

        public void DodajCiasto(IFabrykaCiasta fabryka)
        {
            listaCiast.Add(fabryka.StworzCiasto());
        }

        public void WyswietlPlan()  //Wyświetla listę
        {
            foreach (var ciasto in listaCiast)
            {
                ciasto.WyswietlInformacje();
            }
        }

        public IEnumerator<Ciasto> GetEnumerator()
        {
            return listaCiast.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() //Przechodzi po pętli
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main()
        {
            var planPieczenia = new PlanPieczenia(); //Tworzy plan pieczenia

            planPieczenia.DodajCiasto(new FabrykaCiastaCzekoladowego());
            planPieczenia.DodajCiasto(new FabrykaCiastaJablkowego());

            planPieczenia.WyswietlPlan();

            Console.ReadKey();
        }
    }
}
