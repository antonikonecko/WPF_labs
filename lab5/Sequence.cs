using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Sequence
    {
        //private int count = 0;

        private String sequence = String.Empty;        
        private Dictionary<String, int> pattern_dict = new();

        public Sequence(String seq)
        {
            sequence = seq;                     
        }

        public String Get_sequence()
        {
            return sequence;
        }
                    
        public Dictionary<String, int> PatternFind(int k)
        {

            int[] Count = new int[ sequence.Length - k ];
                       
            for (int i = 0; i < sequence.Length - k; i++)
            {
                String pattern = sequence.Substring(i, k);
                Count[i] = PatternCount(sequence, pattern); // Algorytm 1
                pattern_dict[pattern] = Count[i];                
            }     
            return pattern_dict;            
        }

       //count how often patterns occurs in sequence
       private int PatternCount(String text, String pattern)
        {
            int count = 0;
            for (int i = 0; i < (text.Length - pattern.Length); i++)
            {
                if (text.Substring(i, pattern.Length) == pattern)
                {
                    count++;
                }
            }
            return count;
        }

    }
}
