////////////////////////////////////// Codewars  exercises ///////////////////////////////////////////
/// The first code for each exercise is my own. The following is refactored by checking other solutions.

/////////////////////////////////////         8kyu         ///////////////////////////////////////////

/////////////////////////////////////       30.03.23      ///////////////////////////////////////////

// Create a function that takes an integer as an argument and returns "Even" for even numbers or "Odd" for odd numbers.

using System;
using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

string EvenOrOdd1(int number)
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

string EvenOrOdd2(int number)
{
    return number % 2 == 0 ? "Even" : "Odd";
}

string EvenOrOdd3(int number) => number % 2 == 0 ? "Even" : "Odd";

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

string ToCamelCase1(string str)
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

string ToCamelCase2(string str)
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

string Likes1(string[] name)
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

string Likes2(string[] name)
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

 int GetVowelCount1(string str){
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

int GetVowelCount2(string str)
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

int GetVowelCount3(string str)
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

IEnumerable<string> FriendOrFoe(string[] names)
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

string BreakCamelCase1(string str)
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

string BreakCamelCase2(string str)
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

bool Narcissistic1(int value)
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

/*
    Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.

    Examples
    Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
    Kata.PigIt("Hello world !");     // elloHay orldway !
*/

string PigIt1(string str)
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

string PigIt2(string str)
{
    return string.Join(" ", str.Split(' ').Select(w => w.Any(char.IsPunctuation) ? w : w.Substring(1) + w[0] + "ay"));
}

//Console.WriteLine(PigIt1("Pig latin is cool"));
//Console.WriteLine(PigIt1("This is my string !"));
//Console.WriteLine(PigIt2("Pig latin is cool"));
//Console.WriteLine(PigIt2("This is my string !"));

/////////////////////////////////////       31.03.23      ///////////////////////////////////////////

/*
    In this simple Kata your task is to create a function that turns a string into a Mexican Wave.You will be passed a string and you must return that string in an array where an uppercase letter is a person standing up. 
    Rules
     1.  The input string will always be lower case but maybe empty.

     2.  If the character in the string is whitespace then pass over it as if it was an empty seat
    Example
wave("hello") => {"Hello", "hEllo", "heLlo", "helLo", "hellO"}
*/

List<string> wave1(string str)
{
    var result = new List<string>();

    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] != ' ')
        {
            result.Add(str.Substring(0, i) + char.ToUpper(str[i]) + str.Substring(i + 1));
        }  
    }

    return result;
}

List<string> wave2(string str)
{
    List<string> mexicanWave = new List<string>();
    for (int i = 0; i < str.Length; i++)
    {
        char[] a = str.ToCharArray();

        if (a[i] !=  ' ')
        {
            a[i] = char.ToUpper(a[i]);
            mexicanWave.Add(new string(a));
        }
    }
    return mexicanWave;
}

//foreach (var word in wave1("codewa rs"))
//{
//    Console.WriteLine(word);
//}

//foreach (var word in wave2("codewa rs"))
//{
//    Console.WriteLine(word);
//}

/*
    Write a function that takes a string of braces, and determines if the order of the braces is valid. It should return true if the string is valid, and false if it's invalid.

    This Kata is similar to the Valid Parentheses Kata, but introduces new characters: brackets [], and curly braces {}. Thanks to @arnedag for the idea!

    All input strings will be nonempty, and will only consist of parentheses, brackets and curly braces: ()[]{}.

    What is considered Valid?
    A string of braces is considered valid if all braces are matched with the correct brace.

    Examples
    "(){}[]"   =>  True
    "([{}])"   =>  True
    "(}"       =>  False
    "[(])"     =>  False
    "[({})](]" =>  False
*/

bool validBraces1(String braces)
{
    // Check if there is the same amount of closing braces as opening braces
    if (braces.Count(x => x == '(') == braces.Count(x => x == ')') 
    &&
    braces.Count(x => x == '[') == braces.Count(x => x == ']')
    &&
    braces.Count(x => x == '{') == braces.Count(x => x == '}'))
    {
        for (int i = 1; i < braces.Length; i++)
        {
            // Check if the directly following braces is possible
            if ((braces[i - 1] == '(' && (braces[i] == '}' || braces[i] == ']'))
            ||
            (braces[i - 1] == '[' && (braces[i] == '}' || braces[i] == ')'))
            ||
            (braces[i - 1] == '{' && (braces[i] == ']' || braces[i] == ')')))
            {
                return false;
            }
            
            // Check if there are not already too many closing braces so far
            if (braces[i] == ')')
            {
                if (braces.Substring(0, i).Count(x => x == '(') - 1 < braces.Substring(0, i).Count(x => x == ')'))
                { return false; }
            }
            else if (braces[i] == ']')
            {
                if (braces.Substring(0, i).Count(x => x == '[') - 1 < braces.Substring(0, i).Count(x => x == ']'))
                { return false; }
            }
            else if (braces[i] == '}')
            {
                if (braces.Substring(0, i).Count(x => x == '{') - 1 < braces.Substring(0, i).Count(x => x == '}'))
                { return false; }
            }
        }
        return true;
    }
    return false;
}

bool validBraces2(String str)
{
    string prev = "";
    while (str.Length != prev.Length)
    {
        prev = str;
        str = str
            .Replace("()", String.Empty)
            .Replace("[]", String.Empty)
            .Replace("{}", String.Empty);
    }
    return (str.Length == 0);
}

bool validBraces3(string braces)
{
    var st = new Stack<char>();
    foreach (var c in braces)
        switch (c)
        {
            case '(':
            case '[':
            case '{':
                st.Push(c);
                continue;
            case ')':
                if (st.Count == 0 || st.Pop() != '(') return false;
                continue;
            case ']':
                if (st.Count == 0 || st.Pop() != '[') return false;
                continue;
            case '}':
                if (st.Count == 0 || st.Pop() != '{') return false;
                continue;
        }
    return st.Count == 0;
}

//Console.WriteLine(validBraces1("()"));
//Console.WriteLine(validBraces1("[(])"));
//Console.WriteLine(validBraces1("({})[({})]"));
//Console.WriteLine(validBraces1("("));
//Console.WriteLine(validBraces1(")"));
//Console.WriteLine(validBraces1("(({{[[]]}}))"));
//Console.WriteLine(validBraces2("()"));
//Console.WriteLine(validBraces2("[(])"));
//Console.WriteLine(validBraces2("({})[({})]"));
//Console.WriteLine(validBraces2("("));
//Console.WriteLine(validBraces2(")"));
//Console.WriteLine(validBraces2("(({{[[]]}}))"));
//Console.WriteLine(validBraces3("()"));
//Console.WriteLine(validBraces3("[(])"));
//Console.WriteLine(validBraces3("({})[({})]"));
//Console.WriteLine(validBraces3("("));
//Console.WriteLine(validBraces3(")"));
//Console.WriteLine(validBraces3("(({{[[]]}}))"));

/////////////////////////////////////       01.04.23      ///////////////////////////////////////////

/*
    My friend John and I are members of the "Fat to Fit Club (FFC)". John is worried because each month a list with the weights of members is published and each month he is the last on the list which means he is the heaviest.

    I am the one who establishes the list so I told him: "Don't worry any more, I will modify the order of the list". It was decided to attribute a "weight" to numbers. The weight of a number will be from now on the sum of its digits.

    For example 99 will have "weight" 18, 100 will have "weight" 1 so in the list 100 will come before 99.

    Given a string with the weights of FFC members in normal order can you give this string ordered by "weights" of these numbers?

    Example:
    "56 65 74 100 99 68 86 180 90" ordered by numbers weights becomes: 

    "100 180 90 56 65 74 68 86 99"
    When two numbers have the same "weight", let us class them as if they were strings (alphabetical ordering) and not numbers:

    180 is before 90 since, having the same "weight" (9), it comes before as a string.

    All numbers in the list are positive numbers and the list can be empty.

    Notes
    it may happen that the input string have leading, trailing whitespaces and more than a unique whitespace between two consecutive numbers
*/

string orderWeight1(string strng)
{
    string[] weightsWhitespaceRemoved = strng.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
    var listOfWeights = new List<Weight>();

    foreach (var weight in weightsWhitespaceRemoved)
    {
        int weightDigit = 0;

        weight.ToList().ForEach(character => weightDigit += int.Parse(character.ToString()));

        listOfWeights.Add(new Weight()
        {
            weightStr = weight,

            weightDigitSum = weightDigit
        });
    }

    return String.Join(' ', listOfWeights.OrderBy(x => x.weightDigitSum)
                                         .ThenBy(x => x.weightStr)
                                         .Select(x => x.weightStr));
}

string orderWeight2(string strng)
{
    return string.Join(" ", strng.Split(' ')
        .OrderBy(n => n.ToCharArray()
        .Select(c => (int)char.GetNumericValue(c)).Sum())
        .ThenBy(n => n));
}

//Console.WriteLine(orderWeight1("103 123 4444 99 2000"));
//Console.WriteLine(orderWeight1("2000 10003 1234000 44444444 9999 11 11 22 123"));
//Console.WriteLine(orderWeight2("103 123 4444 99 2000"));
//Console.WriteLine(orderWeight2("2000 10003 1234000 44444444 9999 11 11 22 123"));

/////////////////////////////////////         5kyu         ///////////////////////////////////////////

/////////////////////////////////////       05.04.23      ///////////////////////////////////////////

/*
    For this exercise you will be strengthening your page-fu mastery. You will complete the PaginationHelper class, which is a utility class helpful for querying paging information related to an array.

    The class is designed to take in an array of values and an integer indicating how many items will be allowed per each page. The types of values contained within the collection/array are not relevant.

    The following are some examples of how this class is used:

    var helper = new PaginationHelper<char>(new List<char>{'a', 'b', 'c', 'd', 'e', 'f'}, 4);
    helper.PageCount(); //should == 2
    helper.ItemCount(); //should == 6
    helper.PageItemCount(0); //should == 4
    helper.PageItemCount(1); // last page - should == 2
    helper.PageItemCount(2); // should == -1 since the page is invalid

    // pageIndex takes an item index and returns the page that it belongs on
    helper.PageIndex(5); //should == 1 (zero based index)
    helper.PageIndex(2); //should == 0
    helper.PageIndex(20); //should == -1
    helper.PageIndex(-10); //should == -1
*/

//List<char> collection = new() { 'a', 'b', 'c', 'd', 'e', 'f' };
//PagnationHelper<char> helper = new(collection, 4);
//Console.WriteLine(helper.PageCount);
//Console.WriteLine(helper.ItemCount);
//Console.WriteLine(helper.PageItemCount(0));
//Console.WriteLine(helper.PageItemCount(1));
//Console.WriteLine(helper.PageItemCount(2));

/////////////////////////////////////       05.04.23      ///////////////////////////////////////////

/*
    You are given a node that is the beginning of a linked list. This list contains a dangling piece and a loop. Your objective is to determine the length of the loop.

    For example in the following picture the size of the dangling piece is 3 and the loop size is 12:


    # Use the `next' method to get the following node.
    node.next
    Notes:

    do NOT mutate the nodes!
    in some cases there may be only a loop, with no dangling piece
*/
/*
int getLoopSize(LoopDetector.Node startNode)
{
    // Too Slow!
    
    //List<LoopDetector.Node> allNodes = new();
    
    //while (true)
    //{
    //  if (allNodes.Contains(startNode)) return allNodes.Count - allNodes.IndexOf(startNode);
      
    //  allNodes.Add(startNode);
    //  startNode = startNode.next;
    //}
    
    int index = 0;
    Hashtable nodeAndIndex = new();

    while (true)
    {
        if (nodeAndIndex.Contains(startNode)) return nodeAndIndex.Count - (int)nodeAndIndex[startNode];

        nodeAndIndex.Add(startNode, index);
        index++;
        startNode = startNode.next;
    }
}
*/

/////////////////////////////////////       23.05.23      ///////////////////////////////////////////
/*
    Write Number in Expanded Form
    You will be given a number and you will need to return it as a string in Expanded Form. For example:

    Kata.ExpandedForm(12); # Should return "10 + 2"
    Kata.ExpandedForm(42); # Should return "40 + 2"
    Kata.ExpandedForm(70304); # Should return "70000 + 300 + 4"
    NOTE: All numbers will be whole numbers greater than 0.
*/

string ExpandedForm(long num)
{
    var result = "";
    var numAsString = num.ToString();
    bool lastDigitIsZero = numAsString[numAsString.Length - 1] == '0';

    if (numAsString.Length == 1) return numAsString;

    for (int i = 0; i < numAsString.Length - 1; i++)
    {
        if (numAsString[i] == '0') continue;

        if (!String.IsNullOrEmpty(result)) result += " + ";

        result += numAsString[i];

        for (int j = 1; j <= numAsString.Length - 1 - i; j++)
        {
            result += "0";
        }

    }    
    
    if (!lastDigitIsZero) result += " + " + numAsString[numAsString.Length - 1];

    return result;
}

string ExpandedForm2(long num)
{
    var result = new List<string>();
    var numAsString = num.ToString();
    string number;

    for (int i = 0; i < numAsString.Length; i++)
    {
        if (numAsString[i] == '0') continue;

        number = numAsString[i].ToString();

        for (int j = 1; j <= numAsString.Length - 1 - i; j++)
        {
            number += "0";
        }

        result.Add(number);
    }

    return String.Join(" + ", result);
}

//Console.WriteLine(ExpandedForm(12));
//Console.WriteLine(ExpandedForm(42));
//Console.WriteLine(ExpandedForm(70304));
//Console.WriteLine(ExpandedForm(7030));
//Console.WriteLine(ExpandedForm(7000));
//Console.WriteLine(ExpandedForm2(1));
//Console.WriteLine(ExpandedForm2(12));
//Console.WriteLine(ExpandedForm2(42));
//Console.WriteLine(ExpandedForm2(70304));
//Console.WriteLine(ExpandedForm2(7030));
//Console.WriteLine(ExpandedForm2(7000));

/*
    Complete the function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false.
    Notes:
    Only lower case letters will be used (a-z). No punctuation or digits will be included.
    Performance needs to be considered.
    Examples
    scramble('rkqodlw', 'world') ==> True
    scramble('cedewaraaossoqqyt', 'codewars') ==> True
    scramble('katas', 'steak') ==> False
*/

bool Scramble(string str1, string str2)
{
    if (str1.Length >= str2.Length)
    {
        foreach (char letter in str2)
        {
            if (!(str2.ToList().Count(x => x == letter) <= str1.ToList().Count(x => x == letter))) return false;
        }

        return true;
    }

    return false;
}

bool Scramble2(string str1, string str2)
{
    return str2.All(x => str1.Count(y => y == x) >= str2.Count(y => y == x));
}

//Console.WriteLine(Scramble("rkqodlw", "world"));
//Console.WriteLine(Scramble("cedewaraaossoqqyt", "codewars"));
//Console.WriteLine(Scramble("katas", "steak"));
//Console.WriteLine(Scramble("scriptjavx", "javascript"));
//Console.WriteLine(Scramble("scriptingjava", "javascript"));
//Console.WriteLine(Scramble("scriptsjava", "javascripts"));
//Console.WriteLine(Scramble2("rkqodlw", "world"));
//Console.WriteLine(Scramble2("cedewaraaossoqqyt", "codewars"));
//Console.WriteLine(Scramble2("katas", "steak"));
//Console.WriteLine(Scramble2("scriptjavx", "javascript"));
//Console.WriteLine(Scramble2("scriptingjava", "javascript"));
//Console.WriteLine(Scramble2("scriptsjava", "javascripts"));

/*
    In this Kata you will encode strings using a Soundex variation called "American Soundex" using the following (case insensitive) steps:

    Save the first letter. Remove all occurrences of h and w except first letter.
    Replace all consonants (include the first letter) with digits as follows:
    b, f, p, v = 1
    c, g, j, k, q, s, x, z = 2
    d, t = 3
    l = 4
    m, n = 5
    r = 6
    Replace all adjacent same digits with one digit.
    Remove all occurrences of a, e, i, o, u, y except first letter.
    If first symbol is a digit replace it with letter saved on step 1.
    Append 3 zeros if result contains less than 3 digits. Remove all except first letter and 3 digits after it
    Input
    A space separated string of one or more names. E.g.
    Sarah Connor
    Output
    Space separated string of equivalent Soundex codes (the first character of each code must be uppercase). E.g.
    S600 C560
*/

//string Soundex(string names) 
//{
//    var namesAsList = names.Split(' ');
//    var encodedNames = new List<string>();
//    var firstLetter = "";

//    foreach (var originalName in namesAsList)
//    {
//        firstLetter = originalName[0].ToString();

//        // remove h, w
//        var forbiddenLetters = new Regex("[hw]");
//        var name = string.Join("", originalName.Substring(1).Where(x => !forbiddenLetters.Match(x.ToString()).Success));

//        if (name.Length > 0)
//        {
//            // convert to digits
//            var patternFor1 = "[bfpv]";
//            var patternFor2 = "[cgjkqsxz]";
//            var patternFor3 = "[dt]";
//            var patternFor5 = "[mn]";
//            name = Regex.Replace(name, patternFor1, "1");
//            name = Regex.Replace(name, patternFor2, "2");
//            name = Regex.Replace(name, patternFor3, "3");
//            name = Regex.Replace(name, patternFor5, "5");
//            name = name.Replace("l", "4");
//            name = name.Replace("r", "6");

//            // remove doubles
//            if (name.Length > 1)
//            {
//                var name2 = name[1].ToString();

//                for (int i = 1; i < name.Length; i++)
//                {
//                    if (name[i] == name2[name2.Length - 1]) continue;

//                    name2 += name[i];
//                }

//                name = name2;
//            }

//            // remove a, e, i, o, u, y
//            var forbiddenLetters2 = new Regex("[aeiouy]");
//            var name = String.Join("", originalName.Substring(1).Where(x => !forbiddenLetters2.Match(x.ToString()).Success));

//            // Remove first digit
//            if (char.IsDigit(name[0]) && name.Length > 1)
//            {
//                name = firstLetter + name.Substring(1);
//            }
//        }
//        else
//        {
//            name = firstLetter;
//        }
        
//        // Check length
//        if (name.Length < 4)
//        {
//            for (int i = name.Length; i < 4; i++)
//            {
//                name += "0";
//            }
//        }
//        else if (name.Length > 4) 
//        {
//            name = name.Substring(0, 4);
//        }

//        encodedNames.Add(name.ToUpper());
//    }

//    return string.Join(" ", encodedNames);
//}

string Soundex(string names)
{
    names = names.ToUpper();
    var namesEncoded = new List<string>();

    // Input couuld be more than 1 name.
    foreach (var name in names.Split(" "))
    {
        // 1. Save the first letter.
        var firstLetter = name[0];

        // 2. Remove h and w (excl 1st letter)
        var forbiddenLetters = new Regex("[HW]");
        var nameEncoded = name[0] + string.Join("", name[1..].Where(x => !forbiddenLetters.Match(x.ToString()).Success));

        // 3. Replace consonants (incl 1st letter)
        var patternFor1 = "[BFPV]";
        var patternFor2 = "[CGJKQSXZ]";
        var patternFor3 = "[DT]";
        var patternFor5 = "[MN]";
        nameEncoded = Regex.Replace(nameEncoded, patternFor1, "1");
        nameEncoded = Regex.Replace(nameEncoded, patternFor2, "2");
        nameEncoded = Regex.Replace(nameEncoded, patternFor3, "3");
        nameEncoded = Regex.Replace(nameEncoded, patternFor5, "5");
        nameEncoded = nameEncoded.Replace("L", "4");
        nameEncoded = nameEncoded.Replace("R", "6");

        // 4. Replace all adjacent same digits (incl 1st letter)
        var nameEncodedTemp = nameEncoded[0].ToString();

        for (int i = 1; i < nameEncoded.Length; i++)
        {
            if (nameEncoded[i] == nameEncodedTemp[^1]) continue;

            nameEncodedTemp += nameEncoded[i];
        }

        nameEncoded = nameEncodedTemp;

        // 5. Remove vowels and y (excl 1st letter)
        var forbiddenLetters2 = new Regex("[AEIOUY]");
        nameEncoded = nameEncoded[0] + String.Join("", nameEncoded[1..].Where(x => !forbiddenLetters2.Match(x.ToString()).Success));

        // 6. If 1st symbol is a digit -> replace with first letter
        if (char.IsDigit(nameEncoded[0])) nameEncoded = firstLetter + nameEncoded[1..];

        // 7. Check length
        int digits = nameEncoded.Count(x => char.IsDigit(x));
        if (digits < 3)
        {
            for (int i = digits; i <= 3; i++)
            {
                nameEncoded += "0";
            }
        }
        

        if (!char.IsDigit(nameEncoded[0]))
        {
            nameEncoded = nameEncoded[..4];
        }
        else
        {
            nameEncoded = nameEncoded[..3];
        }

        namesEncoded.Add(nameEncoded);
        
    }

    return string.Join(" ", namesEncoded);
}

string Soundex2(string names)
{
    return string.Join(" ", names.ToUpper().Split(' ').Select(str =>
    {
        string hw = Regex.Replace(str, "(?!^)[HW]", "");
        string bfp = Regex.Replace(hw, "[BFPV]+", "1");
        string cgj = Regex.Replace(bfp, "[CGJKQSXZ]+", "2");
        string dt = Regex.Replace(cgj, "[DT]+", "3");
        string l = Regex.Replace(dt, "L+", "4");
        string mn = Regex.Replace(l, "[MN]+", "5");
        string r = Regex.Replace(mn, "R+", "6");
        string aei = Regex.Replace(r, "(?!^)[AEIOUY]", "");
        string dig = Regex.Replace(aei, "^\\d", str.Substring(0, 1));
        string result = Regex.Replace(dig, "$", "00000");
        return result.Substring(0, 4);
    }));
}

//Console.WriteLine(Soundex("Sarah Connor"));
//Console.WriteLine(Soundex("zxqurlwbx"));
//Console.WriteLine(Soundex("Joe"));
//Console.WriteLine(Soundex2("Sarah Connor"));
//Console.WriteLine(Soundex2("zxqurlwbx"));
//Console.WriteLine(Soundex2("Joe"));

public class PagnationHelper<T>
{
    private IList<T> collection;
    private int itemsPerPage;

    /// <summary>
    /// Constructor, takes in a list of items and the number of items that fit within a single page
    /// </summary>
    /// <param name="collection">A list of items</param>
    /// <param name="itemsPerPage">The number of items that fit within a single page</param>
    public PagnationHelper(IList<T> collection, int itemsPerPage)
    {
        this.collection = collection;
        this.itemsPerPage = itemsPerPage;
    }

    /// <summary>
    /// The number of items within the collection
    /// </summary>
    public int ItemCount
    {
        get
        {
            return this.collection.Count;
        }
    }

    /// <summary>
    /// The number of pages
    /// </summary>
    public int PageCount
    {
        get
        {
            return this.ItemCount % this.itemsPerPage == 0 ? this.ItemCount / this.itemsPerPage : this.ItemCount / this.itemsPerPage + 1;
        }
    }

    /// <summary>
    /// Returns the number of items in the page at the given page index 
    /// </summary>
    /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
    /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
    public int PageItemCount(int pageIndex)
    {
        if (pageIndex > this.PageCount - 1 || pageIndex < 0)
        {
            return -1;
        }
        else if (this.ItemCount % this.itemsPerPage == 0 || pageIndex != PageCount - 1)
        {
            return this.itemsPerPage;
        }
        else
        {
            return this.ItemCount - (this.itemsPerPage * (this.PageCount - 1));
            // or this.ItemCount % this.itemsPerPage;
        }
    }

    /// <summary>
    /// Returns the page index of the page containing the item at the given item index.
    /// </summary>
    /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
    /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
    public int PageIndex(int itemIndex)
    {
        if (itemIndex > this.ItemCount - 1 || itemIndex < 0)
        {
            return -1;
        }
        else
        {
            return itemIndex / this.itemsPerPage;
        }
    }
}

class Weight
{
    public string weightStr { get; set; }
    public int weightDigitSum { get; set; }
}

