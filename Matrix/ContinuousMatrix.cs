using static Matrix.Model;

namespace Matrix;

public class ContinuousMatrix
{
    /// <summary>
    /// a continuous matrix that continues with only one letter until the sentence or word has been written 
    /// </summary>
    /// <param name="value">the word or phrase that is displayed at the end</param>
    /// <param name="specialCharacters">whether the matrix also contains special characters</param>
    /// <param name="numbers">whether the matrix also contains numbers</param>
    /// <param name="letters">whether the matrix also contains letters</param>
    /// <param name="spaceInBetween">how many words between each new correct letter standard 1500</param>
    /// <param name="pause">can pause the thread for x amount of ms</param>
    public static void Generate(string value, bool specialCharacters, bool numbers, bool letters,
        int spaceInBetween = 1500, int pause = 0)
    {
        var list = BuildList(specialCharacters, numbers, letters);
        var count = 0;
        var rightCount = 0;
        for (var i = 0; i < value.Length; i++)
        {
            do
            {
                var word = GenerateWord(list, i + 1);
                count++;
                if (rightCount != 0)
                {
                    CorrectWord(value, rightCount, word,pause);
                }
                else
                {
                    Console.WriteLine(word);
                }

                if (count != spaceInBetween)
                {
                    continue;
                }

                rightCount++;
                CorrectWord(value, rightCount, word,pause);
                count = 0;
                break;

            } while (true);
        }
    }


    /// <summary>
    /// a continuous matrix that continues with only one letter until the sentence or word has been written 
    /// </summary>
    /// <param name="value">the word or phrase that is displayed at the end</param>
    /// <param name="specialCharacters">whether the matrix also contains special characters</param>
    /// <param name="numbers">whether the matrix also contains numbers</param>
    /// <param name="letters">whether the matrix also contains letters</param>
    /// <param name="show">is a Action that is executed when the string should display alternative to Console.WriteLine </param>
    /// <param name="spaceInBetween">how many words between each new correct letter standard 1500</param>
    /// <param name="pause">can pause the thread for x amount of ms</param>
    public static void Generate(string value, bool specialCharacters, bool numbers, bool letters,
         Action<string> show,  int spaceInBetween = 1500, int pause = 0)
    {
        var list = BuildList(specialCharacters, numbers, letters);
        var count = 0;
        var rightCount = 0;
        for (var i = 0; i < value.Length; i++)
        {
            do
            {
                var word = GenerateWord(list, i + 1);
                count++;
                if (rightCount != 0)
                {
                    CorrectWord(value, rightCount, word, show);
                }
                else
                {
                    show(word);
                }

                if (count != spaceInBetween)
                {
                    continue;
                }

                rightCount++;
                CorrectWord(value, rightCount, word,pause);
                count = 0;
                break;

            } while (true);
        }
    }

}