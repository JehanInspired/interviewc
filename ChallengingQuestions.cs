using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace InterviewProject
{
    public class ChallengingQuestions
    {
        [Test]
        public void Challenge4Test()
        {
            //Given a square matrix, calculate the absolute difference between the sums of its diagonals.

            //1   6   3   9
            //8   7   5   7     
            //2   4   5   3
            //6   4   9   0

            int[] row1 = {1,6,3,9};
            int[] row2 = {8,7,5,7};
            int[] row3 = {2,4,5,3};
            int[] row4 = {6,4,9,0};
        }

        [Test]
        public void Challenge5Test()
        {
            //There is a string, s of lowercase English letters that is repeated infinitely many times.
            // Given an integer, n find and print the number of letter a's in the first letters of the infinite string.
            string pattern = "aba";
            int chars = 7;            
            
        }

        [Test]
        public void Challenge6Test()
        {
            //Julius Caesar protected his confidential information by encrypting it using a cipher.
            //Caesar's cipher shifts each letter by a number of letters.
            //If the shift takes you past the end of the alphabet, just rotate back to the front of the alphabet.
            //In the case of a rotation by 3, w, x, y and z would map to z, a, b and c.

            int cipher = 7;

            // Given a Cipher value of 7 Decode the following message:
                // vb zvsclk pa!
            
            // Given a cipher of 11 encode the following message:
                // Im hiding my text

        }
    }
}