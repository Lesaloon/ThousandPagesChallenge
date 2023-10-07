
namespace ThousandPagesChalenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Recueillir les données depuis la base de données.
            List<Livre> tousLesLivres = Livre.ObtenirLivresDepuisBaseDeDonnees();
            // List des livres qui, ensemble, ont exactement 1000 pages et appartiennent à des lecteurs différents.
            List<Livre> livresAAssembler = Livre.TrouverLivresAAssembler(tousLesLivres);
            //
            Console.WriteLine("Livres à assembler pour faire 1000 pages :");
            foreach (var livre in livresAAssembler)
            {
                Console.WriteLine(livre);
            }
        }
    }
}