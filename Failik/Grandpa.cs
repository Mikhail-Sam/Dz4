namespace LabWork;

public struct Grandpa
{
    public string Name;
    public GrumpinessLevel Grumpiness { get; }
    public string[] GrumpyPhrases;
    public int BruisesCount { get; }

    public Grandpa(string name, GrumpinessLevel grumpiness, params string[] phrases)
    {
        Name = name;                       
        Grumpiness = grumpiness;          
        GrumpyPhrases = phrases;          
        BruisesCount = 0;                
    }
    public static int CheckBadWords(Grandpa grandpa, params string[] badWords)
    {
        int blackEyes = 0;                 // Счетчик фингалов
        
        foreach (string phrase in grandpa.GrumpyPhrases)
        {
            foreach (string badWord in badWords)
            {
                // Если фраза содержит плохое слово (без учета регистра)
                if (phrase.Contains(badWord, StringComparison.OrdinalIgnoreCase))
                {
                    blackEyes++;         
                }
            }
        }

        return blackEyes;            
    }
}
