using System;
using System.Collections.Generic;
using System.Linq;

namespace app
{
    class Program
    {
        const int E = 999;

        public static int filter(string c)
        {
            string[] abc = new string[] {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"}; //26
            int[] numbs = new int[] {0,1,2,3,4,5,6,7,8,9}; //10
            //,space,+,-,=,',"""",;

            if (Array.IndexOf(abc, c) > 0){
                return Array.IndexOf(abc, c);
            }
            else if(Array.IndexOf(numbs, c) > 0){
                return Array.IndexOf(numbs, c) + abc.Length + 1;
            }
            else if(c == " "){
                return 26;
            }
            else if(c == "+" || c == "-"){
                return 37;
            }
            else if(c == "="){
                return 39;
            }
            else if(c == "'"){
                return 40;
            }
            else if(c == "\""){
                return 41;
            }
            else if(c == ";"){
                return 42;
            }
            else {
                return 43;
            }
            
        }

        static void lex(string input)
        {
            int[,] transitionMatrix = new int[,] {
            {E,1,8,E,E,30,E,E,5,E,E,E,E,E,E,E,E,E,12,26,E,E,E,E,E,E,E,25,25,25,25,25,25,25,25,25,25,19,19,18,22,20,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,2,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,3,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,4,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,101,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,6,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,7,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,102,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,9,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {10,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,11,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,103,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,13,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,14,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,15,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,16,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,17,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,104,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,202,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,201,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,21,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,301,E},
            {23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,24,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,302,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,25,25,25,25,25,25,25,25,25,25,E,E,E,E,E,303,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,27,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,28,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,29,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,105,E},
            {31,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,32,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,33,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,34,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,106,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E},
            {E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E,E}
        };

            int index = 0;
            while(index < input.Length) {
                int state = 0;
                List<string> word = new List<string>();

                while(index < input.Length && state < 35) {
                    string c = input[index].ToString();
                    index++;
                    state = transitionMatrix[state, filter(c)];
                    if(state == E) break;
                    if(state != 0) word.Add(c);
                }
                foreach(var i in word)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Main(string[] args)
        {
            lex("bool papa = true;");
        }
    }
}