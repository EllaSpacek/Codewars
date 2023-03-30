////////////////////////////////////// Codewars  exercises ///////////////////////////////////////////

/////////////////////////////////////         8kyu         ///////////////////////////////////////////

/////////////////////////////////////       30.03.23      ///////////////////////////////////////////

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

/////////////////////////////////////         7kyu         ///////////////////////////////////////////

/////////////////////////////////////       30.03.23      ///////////////////////////////////////////

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

//Console.WriteLine(GetVowelCount1("abracadabra"));
//Console.WriteLine(GetVowelCount2("abracadabra"));
//Console.WriteLine(GetVowelCount3("abracadabra"));

/*
    Make a program that filters a list of strings and returns a list with only your friends name in it.

    If a name has exactly 4 letters in it, you can be sure that it has to be a friend of yours! Otherwise, you can be sure he's not...

    Ex: Input = ["Ryan", "Kieran", "Jason", "Yous"], Output = ["Ryan", "Yous"]

    i.e.

    friend ["Ryan", "Kieran", "Mark"] `shouldBe` ["Ryan", "Mark"]
    Note: keep the original order of the names in the output.
*/

static IEnumerable<string> FriendOrFoe(string[] names)
{
    return names.Where(x => x.Length == 4);
}

//string[] names = { "Ryan", "Kieran", "Mark", "Jimmy" };
//foreach (var friend in FriendOrFoe(names))
//{
//    Console.WriteLine(friend);
//}

/*
    Given two integers a and b, which can be positive or negative, find the sum of all the integers between and including them and return it. If the two numbers are equal return a or b.

    Note: a and b are not ordered!

    Examples (a, b) --> output (explanation)
    (1, 0) --> 1 (1 + 0 = 1)
    (1, 2) --> 3 (1 + 2 = 3)
    (0, 1) --> 1 (0 + 1 = 1)
    (1, 1) --> 1 (1 since both are same)
    (-1, 0) --> -1 (-1 + 0 = -1)
    (-1, 2) --> 2 (-1 + 0 + 1 + 2 = 2)
*/

int GetSum1(int a, int b)
{
    if (b < a)
    {
        (a, b) = (b, a);
    }

    for (int i = a + 1; i <= b; i++)
    {
        a += i;
    }

    return a;
}

int GetSum2(int a, int b)
{
    return Enumerable.Range(Math.Min(a, b), Math.Max(b, a) - Math.Min(b, a) + 1).Sum();
}

//Console.WriteLine(GetSum1(0, 1));
//Console.WriteLine(GetSum1(0, -1));
//Console.WriteLine(GetSum1(1, 1));
//Console.WriteLine(GetSum2(0, 1));
//Console.WriteLine(GetSum2(0, -1));
//Console.WriteLine(GetSum2(1, 1));

/////////////////////////////////////         6kyu         ///////////////////////////////////////////

/////////////////////////////////////       30.03.23      ///////////////////////////////////////////

/*
    Complete the solution so that the function will break up camel casing, using a space between words.

    Example
    "camelCasing"  =>  "camel Casing"
    "identifier"   =>  "identifier"
    ""             =>  ""
*/

static string BreakCamelCase1(string str)
{
    var result = new StringBuilder();

    foreach (char c in str) 
    {
        if (c == char.ToLower(c))
        {
            result.Append(c);
        }
        else
        {
            result.Append(" " + c);
        }
    }

    return result.ToString();
}

static string BreakCamelCase2(string str)
{
    return string.Concat(str.Select(c => Char.IsUpper(c) ? " " + c : c.ToString()));
}

//Console.WriteLine(BreakCamelCase1("camelCasing"));
//Console.WriteLine(BreakCamelCase1("camelCasingTest"));
//Console.WriteLine(BreakCamelCase2("camelCasing"));
//Console.WriteLine(BreakCamelCase2("camelCasingTest"));

/*
    A Narcissistic Number (or Armstrong Number) is a positive number which is the sum of its own digits, each raised to the power of the number of digits in a given base. In this Kata, we will restrict ourselves to decimal (base 10).

    For example, take 153 (3 digits), which is narcissistic:

        1^3 + 5^3 + 3^3 = 1 + 125 + 27 = 153
    and 1652 (4 digits), which isn't:

        1^4 + 6^4 + 5^4 + 2^4 = 1 + 1296 + 625 + 16 = 1938
    The Challenge:

    Your code must return true or false (not 'true' and 'false') depending upon whether the given number is a Narcissistic number in base 10.
*/

static bool Narcissistic1(int value)
{
    int power = value.ToString().Length;
    int result = 0;

    foreach (var c in value.ToString())
    {   
        result += (int) Math.Pow(int.Parse(c.ToString()), power);
    }

    return result == value;
}

static bool Narcissistic2(int value)
{
    var str = value.ToString();
    return str.Sum(c => Math.Pow(Convert.ToInt32(c.ToString()), str.Length)) == value;
}

//Console.WriteLine(Narcissistic1(1));
//Console.WriteLine(Narcissistic1(153));
//Console.WriteLine(Narcissistic1(371));
//Console.WriteLine(Narcissistic2(1));
//Console.WriteLine(Narcissistic2(153));
//Console.WriteLine(Narcissistic2(371));

/////////////////////////////////////         5kyu         ///////////////////////////////////////////

/////////////////////////////////////       30.03.23      ///////////////////////////////////////////

/*
    Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.

    Examples
    Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
    Kata.PigIt("Hello world !");     // elloHay orldway !
*/

static string PigIt1(string str)
{
    var wordsOriginal = str.Split(' ');
    var wordsPigged = new List<string>();

    foreach (var word in wordsOriginal)
    {
        if (word.Length == 1 && !Char.IsLetter(word[0]))
        {
            wordsPigged.Add(word);
        }
        else if (word.Length == 1)
        {
            wordsPigged.Add(word + "ay");
        }
        else
        {
            wordsPigged.Add(word.Substring(1) + word[0] + "ay");
        }
    }

    return string.Join(' ', wordsPigged);
}

static string PigIt2(string str)
{
    return string.Join(" ", str.Split(' ').Select(w => w.Any(char.IsPunctuation) ? w : w.Substring(1) + w[0] + "ay"));
}

//Console.WriteLine(PigIt1("Pig latin is cool"));
//Console.WriteLine(PigIt1("This is my string !"));
//Console.WriteLine(PigIt2("Pig latin is cool"));
//Console.WriteLine(PigIt2("This is my string !"));