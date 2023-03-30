// Codewars  exercises

// 8kyu

// 30.03.23

// Create a function that takes an integer as an argument and returns "Even" for even numbers or "Odd" for odd numbers.

using System.Text;

static string EvenOrOdd1(int number)
{
    if (number % 2 == 0)
    {
        return "Even";
    }
    else
    {
        return "Odd";
    }
}

static string EvenOrOdd2(int number)
{
    return number % 2 == 0 ? "Even" : "Odd";
}

static string EvenOrOdd3(int number) => number % 2 == 0 ? "Even" : "Odd";

//Console.WriteLine(EvenOrOdd1(3));
//Console.WriteLine(EvenOrOdd1(2));
//Console.WriteLine(EvenOrOdd2(3));
//Console.WriteLine(EvenOrOdd2(2));
//Console.WriteLine(EvenOrOdd3(3));
//Console.WriteLine(EvenOrOdd3(2));

// 6 kyu

// 30.03.23

/*
 * Complete the method/function so that it converts dash/underscore delimited words into camel casing. The first word within the output should be capitalized only if the original word was capitalized (known as Upper Camel Case, also often referred to as Pascal case). The next words should be always capitalized.

   Examples
   "the-stealth-warrior" gets converted to "theStealthWarrior"

   "The_Stealth_Warrior" gets converted to "TheStealthWarrior"

   "The_Stealth-Warrior" gets converted to "TheStealthWarrior"
*/

static string ToCamelCase1(string str)
{
    var result = new StringBuilder();
    bool capitalize = false;

    foreach (char letter in str)
    {
        if (letter == '-' || letter == '_')
        {
            capitalize = true;
        }
        else if (!capitalize)
        {
            result.Append(letter);
        }
        else
        {
            result.Append(char.ToUpper(letter));
            capitalize = false;
        }
    }

    return result.ToString();
}

static string ToCamelCase2(string str)
{
    var result = new StringBuilder();

    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] != '-' && str[i] != '_')
        {
            result.Append(str[i]);
        }
        else
        {
            result.Append(char.ToUpper(str[++i]));
        }
    }

    return result.ToString();
}

//Console.WriteLine(ToCamelCase1("the_stealth_warrior"));
//Console.WriteLine(ToCamelCase1("The-Stealth-Warrior"));
//Console.WriteLine(ToCamelCase2("the_stealth_warrior"));
//Console.WriteLine(ToCamelCase2("The-Stealth-Warrior"));


/*
    You probably know the "like" system from Facebook and other pages. People can "like" blog posts, pictures or other items. We want to create the text that should be displayed next to such an item.

    Implement the function which takes an array containing the names of people that like an item. It must return the display text as shown in the examples:
[]                                -->  "no one likes this"
["Peter"]                         -->  "Peter likes this"
["Jacob", "Alex"]                 -->  "Jacob and Alex like this"
["Max", "John", "Mark"]           -->  "Max, John and Mark like this"
["Alex", "Jacob", "Mark", "Max"]  -->  "Alex, Jacob and 2 others like this"
*/

static string Likes1(string[] name)
{
    switch (name.Length)
    {
       case 0:
            return "no one likes this";
       case 1:
            return $"{name[0]} likes this";
       case 2:
            return $"{name[0]} and {name[1]} like this";
       case 3:
            return $"{name[0]}, {name[1]} and {name[2]} like this";
       default:
            return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
    }
}

static string Likes2(string[] name)
    => name.Length switch
    {
        0 => "no one likes this",
        1 => $"{name[0]} likes this",
        2 => $"{name[0]} and {name[1]} like this",
        3 => $"{name[0]}, {name[1]} and {name[2]} like this",
        _ => $"{name[0]}, {name[1]} and {name.Length - 2} others like this"
    };


//Console.WriteLine(Likes1(new string[0]));
//Console.WriteLine(Likes1(new string[] { "Peter" }));
//Console.WriteLine(Likes1(new string[] { "Jacob", "Alex" }));
//Console.WriteLine(Likes1(new string[] { "Max", "John", "Mark" }));
//Console.WriteLine(Likes1(new string[] { "Alex", "Jacob", "Mark", "Max" }));
//Console.WriteLine(Likes2(new string[0]));
//Console.WriteLine(Likes2(new string[] { "Peter" }));
//Console.WriteLine(Likes2(new string[] { "Jacob", "Alex" }));
//Console.WriteLine(Likes2(new string[] { "Max", "John", "Mark" }));
//Console.WriteLine(Likes2(new string[] { "Alex", "Jacob", "Mark", "Max" }));

/*
    Return the number (count) of vowels in the given string.

    We will consider a, e, i, o, u as vowels for this Kata (but not y).

    The input string will only consist of lower case letters and/or spaces.
*/

 static int GetVowelCount1(string str){
    int vowelCount = 0;
    var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
    
    foreach (var letter in str)
    {
        if (vowels.FirstOrDefault(x => x == letter, 'ö') != 'ö')
        {
            vowelCount++;
        }
    }

    return vowelCount;
}

static int GetVowelCount2(string str)
{
    int vowelCount = 0;
    var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

    foreach (var letter in str)
    {
        if (vowels.Any(x => x == letter))
        {
            vowelCount++;
        }
    }

    return vowelCount;
}

static int GetVowelCount3(string str)
{
    return str.Count(i => "aeiou".Contains(i));
}

Console.WriteLine(GetVowelCount1("abracadabra"));
Console.WriteLine(GetVowelCount2("abracadabra"));
Console.WriteLine(GetVowelCount3("abracadabra"));