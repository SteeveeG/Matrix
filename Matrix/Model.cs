namespace Matrix;

public static class Model
{
    private static Random Random = new Random();

    private static List<string> Alphabet = new()
    {
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
        "W", "X", "Y", "Z"
    };

    private static List<string> SpecialCharacters  = new()
    {
        "\'", "°", "^", "\"", "§", "$", "%", "&", "/", "(", ")", "{", "}", "[", "]", "=", "?", "\\", "`", "´",
        "<", ">", "|", ",", ";", ".", ":", "-", "_", "#", "+", "~", "*", "@", "µ"
    };

    private static List<int> Numbers = new()
    {
        0,1,2,3,4,5,6,7,8,9
    };
    public static List<string> BuildList(bool specialCharacters, bool numbers, bool letters)
    {
        var list = new List<string>();
        if (!letters && !numbers && !specialCharacters)
        {
            letters = true;
        }

        if (letters)
        {
            list.AddRange(Alphabet);
        }

        if (specialCharacters)
        {
            list.AddRange(SpecialCharacters);
        }

        if (numbers)
        {
            list.AddRange(Numbers.ConvertAll(Convert.ToString));
        }

        return list;
    }
    public static string GenerateWord(List<string> list, string value)
    {
        var word = string.Empty;
        for (var i = 0; i < value.Length; i++)
        {
            word += list[Random.Next() % list.Count].ToLower();
        }

        return word;
    }
    public static string GenerateWord(List<string> list, int value)
    {
        var word = string.Empty;
        for (var i = 0; i < value; i++)
        {
            word += list[Random.Next() % list.Count].ToLower();
        }

        return word;
    }

    public static void CorrectWord(string value, int rightCount, string word, Action<string> show)
    {
        for (var i = 0; i < value.Length; i++)
        {
            if (i + 1 <= rightCount)
            {
                word = word.Insert(i, value[i].ToString());
                word = word.Substring(0, word.Length - 1);
            }
            else
            {
                break;
            }
        }

        show(word);
    }

    public static void CorrectWord(string value, int rightCount, string word , int pause)
    {
        for (var i = 0; i < value.Length; i++)
        {
            if (i + 1 <= rightCount)
            {
                word = word.Insert(i, value[i].ToString());
                word = word.Substring(0, word.Length - 1);
            }
            else
            {
                break;
            }
        }
        Thread.Sleep(pause);
        Console.WriteLine(word);
    }

    
}