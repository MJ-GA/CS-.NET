/*
 Assignment : Lab 1 
 Name : Mohamed Jouini
 Student number : 040994664 
 */
using System.Linq;
using System.Diagnostics;
class Lab1
    {
        private static List<string> words = new List<string>();
        static void Main(string[] args)
        {
            
         char input;
         bool menu = true;
            while (menu)
                {
                Console.WriteLine("Choose an option");
                Console.WriteLine("1 - Import Words From File");
                Console.WriteLine("2 - Bubble Sort Words");
                Console.WriteLine("3 - LINQ/LAMBDA Sort Words");
                Console.WriteLine("4 - Count The Distinct Words");
                Console.WriteLine("5 - Take The first 10 Words");
                Console.WriteLine("6 - Get and display words that start with 'j' and display the count");
                Console.WriteLine("7 - Get and display words that end with 'd' and display the count");
                Console.WriteLine("8 - Get and display words that are greater than 4 characters long, and display the count");
                Console.WriteLine("9 - Get and display words that are less than 3 characters long and starts with the letter 'a', and display the count");
                Console.WriteLine("x - Exit");
                Console.Write("Select an option: ");
            try
            {
                input = Console.ReadLine()[0];
                switch (input)
                {
                    case '1':
                        importWords();
                        break;
                    case '2':
                        bubbleSort(words);
                        break;
                    case '3':
                        lambdaSort(words);
                        break;
                    case '4':
                        distinctWords(words);
                        break;
                    case '5':
                        first10Words(words);
                        break;
                    case '6':
                        starts_with_J(words);
                        break;
                    case '7':
                        ends_With_D(words);
                        break;
                    case '8':
                        moreThan4(words);
                        break;
                    case '9':
                        lessThan3(words);
                        break;
                    case 'x':
                        Console.WriteLine("Exit");
                        menu = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Pleas enter a non empty input");
            }

            }
        }
        private static void importWords()
        {
        StreamReader r = new StreamReader("Words.txt");
            string word;
            int count = 0;
            while ( (word = r.ReadLine()) != null)
            {
                words.Add(word);
                count++;
            }
            Console.WriteLine("The number of words is: "+ count);
        }

        private static List<string> bubbleSort(List<string> words)
        {
        Stopwatch time = Stopwatch.StartNew();
        for (int i = 0; i < (words.Count - 1); i++)
            {
                for (int j = i + 1; j < words.Count; j++)
                {
                    if (string.Compare(words[j], words[i]) < 0)
                    {
                        string temp = words[j];
                        words[j] = words[i];
                        words[i] = temp;
                    }
                }
            }
            time.Stop();
            Console.WriteLine("Execution Time : "+time.ElapsedMilliseconds+" ms");
            return words;
        }

        private static List<string> lambdaSort(List<string> words)
        {
        Stopwatch time = Stopwatch.StartNew();
        var linq = words.OrderBy(str => str).ToList();
            words = linq;
        time.Stop();
        Console.WriteLine("Execution Time : " + time.ElapsedMilliseconds + " ms");
        return words;
        }

        private static void distinctWords(List<string> words)
        {
            int wordCount = (from w in words
                             select w).Distinct().Count();
            Console.WriteLine("Distinct count is: "+ wordCount);
            Console.WriteLine();
        }

        private static void first10Words(List<string> words)
        {
            var temp = words.Take(10).ToList();
            foreach (var word in temp)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }

        private static void starts_with_J(List<string> words)
        {
        var linq = from w in words
                   where w.StartsWith("j") 
                   select w;
        Console.WriteLine("The " + linq.Count() + " words that start with J are : ");
        foreach (var word in linq)
            {
                Console.WriteLine(word);
            }
        }

        private static void ends_With_D(List<string> words)
        {
            var linq = from w in words 
                       where w.EndsWith("d") 
                       select w;
        Console.WriteLine("The " + linq.Count() + " words that end with D are : ");
        foreach (var word in linq)
            {
                Console.WriteLine(word);
            }
        }

        private static void moreThan4(List<string> words)
    {
        var linq = from w in words 
                   where w.Length > 4 
                   select w;
        Console.WriteLine("The " + linq.Count() + "  words that have more than 4 characters are: ");
        foreach (var word in linq)
            {
            Console.WriteLine(word);
            }
        }

        private static void lessThan3(List<string> words)
        {
            
            var linq = from w in words 
                       where w.Length < 3 && w.StartsWith("a") 
                       select w;
        Console.WriteLine("The " + linq.Count() + "  words that have less than 3 characters are: ");
        foreach (var word in linq)
            {
                Console.WriteLine(word);
            }  
        }
    }
