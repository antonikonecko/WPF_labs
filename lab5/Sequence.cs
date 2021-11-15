using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Sequence
    {
        private int count = 0;
        
        private String sequence = string.Empty;
        public String pattern = string.Empty;
        
        public Sequence(String seq) 
        {
            sequence = seq;
            count = Get_count();            
        }
        public int Get_count()
        { 
            return count;
        }
        public String Get_sequence()
        { 
            return sequence;
        }

        private String FindPattern() 
        {

            return pattern; 
        }

        public String[] PatternFind(int k)
        {
            string text = sequence;
            int[] Count = new int[text.Length];
            String[] frequent_patterns = new String[] {};
            
            for (int i = 0; i < text.Length - k; i++)
            {
                pattern = text.Substring(i, k);
                Count[i] = PatternCount(text, pattern); // Algorytm 1
            }
            int maxCount = Count.Max();
            for (int i = 0; i < text.Length - k; i++)
            {
                if (Count[i] == maxCount)
                {
                    frequent_patterns = (string[])frequent_patterns.Append(text.Substring(i, k));
                }               
            }

            frequent_patterns = frequent_patterns.Distinct().ToArray();
            //usuń duplikaty z FrequentPatterns

            return frequent_patterns;            
        }

        private int PatternCount(String text, String pattern)
        {
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
