using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PalindromeUnitTests
{
    [TestClass]
    public class TestMethodManachersAlgo
    {
        [TestMethod]
        public void TestSimpleTestString()
        {
            string test1 = "abababa";
            palindrome.InputChecker.setinput(test1);
            palindrome.Palindrome.PalindromeDetails testdata1part1,
                                            testdata1part2, testdata1part3;

            //provide expected output as test data
            testdata1part1.text = "abababa";
            testdata1part1.index = 0;
            testdata1part1.len = 7;

            testdata1part2.text = "ababa";
            testdata1part2.index = 0;
            testdata1part2.len = 5;

            testdata1part3.text = "ababa";
            testdata1part3.index = 2;
            testdata1part3.len = 5;
            

            palindrome.Palindrome testObj = new palindrome.Palindrome();
            testObj.ManachersAlgo(test1);
            Assert.IsTrue(testObj.IsPalindromeDetailEqual(testObj.palindrome1, testdata1part1));
            Assert.IsTrue(testObj.IsPalindromeDetailEqual(testObj.palindrome2, testdata1part2));
            Assert.IsTrue(testObj.IsPalindromeDetailEqual(testObj.palindrome3, testdata1part3));
        }

        [TestMethod]
        public void TestInterviewInput()
        {
            string test1 = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            palindrome.InputChecker.setinput(test1);
            palindrome.Palindrome.PalindromeDetails testdata2part1,
                                            testdata2part2, testdata2part3;

            testdata2part1.text = "hijkllkjih";
            testdata2part1.index = 23;
            testdata2part1.len = 10;

            testdata2part2.text = "defggfed";
            testdata2part2.index = 13;
            testdata2part2.len = 8;

            testdata2part3.text = "abccba";
            testdata2part3.index = 5;
            testdata2part3.len = 6;     

            palindrome.Palindrome testObj = new palindrome.Palindrome();
            testObj.ManachersAlgo(test1);
            Assert.IsTrue(testObj.IsPalindromeDetailEqual(testObj.palindrome1, testdata2part1));
            Assert.IsTrue(testObj.IsPalindromeDetailEqual(testObj.palindrome2, testdata2part2));
            Assert.IsTrue(testObj.IsPalindromeDetailEqual(testObj.palindrome3, testdata2part3));
        }

        [TestMethod]
        public void TestStringGreater256()
        {
            string test3 = "McLaren Applied Technologies is a high-performance technology and design " +
                "company which combines fresh thinking and innovation to deliver quantifiable performance" +
                " advantage from people, processes and systems across four key markets; Motorsport, " +
                "Automotive, Public Transport and Health. Drawing on a 30-year heritage leading the " +
                "digital transformation of motorsport through electronics and data systems, today we " +
                "develop transformative products and solutions across multiple industries that are " +
                "undergoing profound, radical and disruptive change. Whether in the fields of motorsport, " +
                "automotive, public transport or health, we harness our experience in sensor technology, " +
                "telemetry, electronic systems, software, simulation, predictive analytics and design to " +
                "accelerate progress and help our customers and partners perform beyond today’s " +
                "expectations. People join us to do the best work of their lives. We foster a culture of " +
                "brave innovation; a team dedicated to push the boundaries of possibility in the pursuit";

            palindrome.InputChecker.setinput(test3);
            palindrome.Palindrome.PalindromeDetails testdata3part1,
                                            testdata3part2, testdata3part3;
            testdata3part1.text = "tomot";
            testdata3part1.index = 246;
            testdata3part1.len = 5;

            testdata3part2.text = "tomot";
            testdata3part2.index = 584;
            testdata3part2.len = 5;

            testdata3part3.text = "esse";
            testdata3part3.index = 189;
            testdata3part3.len = 4;


            palindrome.Palindrome testObj = new palindrome.Palindrome();
            testObj.ManachersAlgo(test3);
            Assert.IsTrue(testObj.IsPalindromeDetailEqual(testObj.palindrome1, testdata3part1));
            Assert.IsTrue(testObj.IsPalindromeDetailEqual(testObj.palindrome2, testdata3part2));
            Assert.IsTrue(testObj.IsPalindromeDetailEqual(testObj.palindrome3, testdata3part3));
        }
    }
}
