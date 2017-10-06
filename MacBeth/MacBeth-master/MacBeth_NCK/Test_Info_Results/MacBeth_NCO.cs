/*Niema Orakwusi, MacBeth Test and Results, October 6, 2017
ensure the macbeth.txt is located in the bin for excutable files*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Test_Info_Results
{
	class MacBeth_NCO
	{
		static void Main (string[] args)
		{
            try
            {

                //declared a dictionary 
                Dictionary<string, int> dict = new Dictionary<string, int>();

                //define the file and read all the text in the file into  string
                string mcbFile = "Macbeth.txt";
                string ig = File.ReadAllText(mcbFile);

                //created a string array of all the special characters to remove
                string[] uh = { ";", ",", ".", "-", "_", "^","?","'","!",":","(", ")", "[", "]",
                        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "\n", "\t", "\r" };

                //loop thru the file to replace the characters with whitespace and change text to lower case and assign back to a string
                foreach (string character in uh)
                {
                    ig = ig.Replace(character, " ").ToLower();
                }

                //create a string list of the results and split into words 
                List<string> aList = ig.Split(' ').ToList();

                //Create an array of words
                foreach (string word in aList)
                {
                    //if the length of the words are 5 characters or more 
                    if (word.Length >= 5)
                    {
                        //check if its in the string
                        if (dict.ContainsKey(word))
                            dict[word] = dict[word] + 1; //Increment the count
                        else
                            dict[word] = 1; //put it in the dictionary with a count 1
                    }
                }

                //create a var sort in descending order to get the max results of the dictionary and display the top two
                var stDict = (from entry in dict
                              orderby entry.Value descending
                              select entry).ToDictionary(pair => pair.Key, pair => pair.Value).Take(2);

                foreach (KeyValuePair<string, int> pair in stDict) //loop through the dictionary for the results of the sort and display the key and value
                {
                    //Display the key and value
                    Console.WriteLine(string.Format("{0}, Count: {1} \n", pair.Key, pair.Value));

                }
                //reader of the keys to view all the results
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
		}//end main
	}//end program
}//end namespace
