using System;
using System.IO;

namespace palindrome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //set input buffer size in bytes
            int bufferSize = 1024;
            Stream inStream = Console.OpenStandardInput(bufferSize);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufferSize));

            string input;
            Console.Write("Please enter a string: ");
            input = Console.ReadLine();
            Palindrome p = new Palindrome();
            var checkedInput = InputChecker.setinput(input);
            p.ManachersAlgo(InputChecker.setinput(checkedInput));
        }
    }

    public static class InputChecker
    {
        //interface for Unit Testing only
        public static string setinput(string input)
        {
            return input;
        }
    }

    public class Palindrome
    {
        public struct PalindromeDetails
        {
            public string text;
            public int index;
            public int len;

            public PalindromeDetails(string m , int i, int p)
            {
                text = m;
                index = i;
                len = p;
            }
        };

        public bool IsPalindromeDetailEqual(PalindromeDetails inp1, PalindromeDetails inp2)
        {
            //this function is used in Unit Testing only
            bool flag = false;
            if (inp1.index == inp2.index && inp1.len == inp2.len
                && inp1.text.Equals(inp2.text))
            { flag = true; }
            return flag;
        }

        struct PalinArrayIndexer
        {
           public  int index;
           public int value;
           public  PalinArrayIndexer(int i, int v)
           {
                index = i;
                value = v;
            }
        };

        public PalindromeDetails palindrome1 = new PalindromeDetails("", 0, 0);
        public PalindromeDetails palindrome2 = new PalindromeDetails("", 0, 0);
        public PalindromeDetails palindrome3 = new PalindromeDetails("", 0, 0);
        PalinArrayIndexer first = new  PalinArrayIndexer(0, 0);
        PalinArrayIndexer second = new  PalinArrayIndexer(0, 0);
        PalinArrayIndexer third = new  PalinArrayIndexer(0, 0);

        // Transform given string S to get it ManachersAlgo ready string newFormattedStr .
        // For example, S = "abba", newFormattedStr = "^#a#b#b#a#$".
        // ^ and $ are book-marks for start/end of the string
        string GetStringReady(string s)
        {
            int n = s.Length;
            if (n == 0) return "^$";
            string newstring = "^";
            for (int i = 0; i < n; i++)
                newstring += "#" + s.Substring(i, 1);

            newstring += "#$";
            //Console.WriteLine(newstring);
            return newstring;
        }

        void get3Largest(int[] arr,int arr_size)
        {
            int i;
            //Console.WriteLine("The array size=" + arr_size);

            for (i = 0; i < arr_size; i++)
            {
                if (arr[i] > first.value)
                {
                    third.value = second.value;
                    third.index = second.index;
                    second.value = first.value;
                    second.index = first.index;
                    first.value = arr[i];
                    first.index = i;
                }
                else if (arr[i] > second.value)
                {
                    third.value = second.value;
                    third.index = second.index;
                    second.value = arr[i];
                    second.index = i;
                }
                else if (arr[i] > third.value)
                {
                    third.value = arr[i];
                    third.index = i;
                }
            }

            palindrome1.index = (first.index - 1 - first.value) / 2;
            palindrome1.len = first.value;
            palindrome2.index = (second.index - 1 - second.value) / 2;
            palindrome2.len = second.value;
            palindrome3.index = (third.index - 1 - third.value) / 2;
            palindrome3.len = third.value;
        }


        public void ManachersAlgo(string orgString)
        {
            string newFormattedStr = GetStringReady(orgString);
            int newStrLen = newFormattedStr.Length;
            int[] palindromeArr = new int[newStrLen];
            int center = 0, rightBoundry = 0;
            for (int i = 1; i < newStrLen - 1; i++)
            {
                int i_mirror = 2 * center - i; 

                if (rightBoundry > i)
                    palindromeArr[i] = Math.Min(rightBoundry - i, palindromeArr[i_mirror]);

                // expand the palindrome with center as i
                while (newFormattedStr[i + 1 + palindromeArr[i]] == 
                                                    newFormattedStr[i - 1 - palindromeArr[i]])
                {
                    //Console.Write(newFormattedStr[i + 1 + palindromeArr[i]]+"==");
                    //Console.WriteLine(newFormattedStr[i - 1 - palindromeArr[i]]);
                    palindromeArr[i]++;
                }
                // If palindrome centered at i expands past Right boundary,
                // adjust center based on expanded palindrome.
                if (i + palindromeArr[i] > rightBoundry)
                {
                    center = i;
                    rightBoundry = i + palindromeArr[i];
                }
            }

            get3Largest(palindromeArr, newStrLen - 1);

            Console.WriteLine();
            palindrome1.text = orgString.Substring(palindrome1.index, palindrome1.len);
            Console.WriteLine("Text: " + palindrome1.text + "," + " Index: " + 
                                    palindrome1.index + " Length: " + palindrome1.len);
            Console.WriteLine();

            palindrome2.text = orgString.Substring(palindrome2.index, palindrome2.len);
            Console.WriteLine("Text: " + palindrome2.text + "," + " Index: " + 
                                     palindrome2.index + " Length: " + palindrome2.len);
            Console.WriteLine();

            palindrome3.text = orgString.Substring(palindrome3.index, palindrome3.len);
            Console.WriteLine("Text: " + palindrome3.text + "," + " Index: " + 
                                     palindrome3.index + " Length: " + palindrome3.len);
            Console.WriteLine();
        }
    }
}
