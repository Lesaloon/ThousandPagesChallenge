namespace ThousandPagesChalenge;

class Livre
{
    public string? NomLecteur { get; set; }
    public string Titre { get; set; }
    public int NombrePages { get; set; }
        
    public override string ToString() {
        return $"{Titre}, {NombrePages} pages, lu par {NomLecteur}";
    }
        
    public Livre(string? nomLecteur, string titre, int nombrePages) {
        NomLecteur = nomLecteur;
        Titre = titre;
        NombrePages = nombrePages;
    }
        
    public static bool IsAssemblyPossible(Livre livre1, Livre livre2) {
        return livre1.NomLecteur != livre2.NomLecteur &&
               livre1.NombrePages + livre2.NombrePages == 1000;
    }
    public static bool IsAssemblyPossible(Livre livre1, Livre livre2, Livre livre3) {
        return livre1.NomLecteur != livre2.NomLecteur &&
               livre1.NomLecteur != livre3.NomLecteur &&
               livre2.NomLecteur != livre3.NomLecteur &&
               livre1.NombrePages + livre2.NombrePages + livre3.NombrePages == 1000;
    }
    public static List<Livre> ObtenirLivresDepuisBaseDeDonnees() { 
        // the books are in a CSV file.
        // the CSV file is in the same folder as the executable.
        // the CSV file is named "books.csv".
        // the CSV file has 3 columns: reader, title, pages.
            
        // Lire le fichier CSV.
        string[] lignes = File.ReadAllLines("books.csv");
        // Créer une liste vide pour stocker les livres.
        List<Livre> livres = new List<Livre>();
        // Pour chaque ligne du fichier CSV.
        foreach (var ligne in lignes) {
            // Séparer les valeurs de la ligne.
            string[] valeurs = ligne.Split(',');
            // Créer un nouveau livre.
            Livre livre = new Livre(valeurs[0], valeurs[1], int.Parse(valeurs[2]));
            // Ajouter le livre à la liste.
            livres.Add(livre);
        }
        // Retourner la liste de livres.
        return livres;
    }

    public static List<Livre> TrouverLivresAAssembler(List<Livre> tousLesLivres) {
        // Cette fonction doit implémenter la logique pour trouver 2 ou 3 livres qui,
        // ensemble, ont exactement 1000 pages et appartiennent à des lecteurs différents.

        for (int i = 0; i < tousLesLivres.Count; i++) {
            for (int j = i + 1; j < tousLesLivres.Count; j++) { 
                // Vérifier si deux livres satisfont les conditions.
                if ( Livre.IsAssemblyPossible(tousLesLivres[i], tousLesLivres[j]) ) {
                    return new List<Livre> { tousLesLivres[i], tousLesLivres[j] };
                }

                for (int k = j + 1; k < tousLesLivres.Count; k++) { 
                    // Vérifier si trois livres satisfont les conditions.
                    if (Livre.IsAssemblyPossible(tousLesLivres[i], tousLesLivres[j], tousLesLivres[k])) {
                        return new List<Livre> { tousLesLivres[i], tousLesLivres[j], tousLesLivres[k] }; 
                    }
                }
            }
        }

        // Retourner une liste vide si aucun ensemble de livres correspondant n'est trouvé.
        return new List<Livre>();
    }
}