using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day18OperationOrder
{
    class Part2
    {
        public long calc(string expression)
        {
            //initial variable needed
            string[] expSplit = Regex.Split(expression, string.Empty);
            List<string> sorted = expSplit.ToList();
            int bracketS, BracketE = 0;
            long Stotal = 0;
            char expTracker = '+';

            // for loop for the initial bracketed equation searches for the end of a bracket then loops backwards to obtain the 
            // distinct fomula needed to be solved 
            for (int i = 0; i <= sorted.Count() - 1; i++)
            {
                if (sorted[i] == ")")
                {
                    BracketE = i;
                    List<string> tracker = new List<string>();
                    for (int k = i; k-- > 0;)
                    {
                        if (sorted[k] != "(")
                        {
                            tracker.Add(sorted[k]);
                        }
                        else
                        {
                            bracketS = k;
                            Stotal = 0;
                            expTracker = '+';
                            tracker.Reverse();
                            //two functions used for addition firslty then multiplication whats left
                            tracker = addition(tracker);
                            tracker = multiplication(tracker);
                            Stotal = long.Parse(tracker.FirstOrDefault());
                            sorted.Insert(bracketS, Stotal.ToString());
                            sorted.RemoveRange(bracketS + 1, (BracketE + 1) - (bracketS));
                            i = 0;
                            break;
                        }
                    }

                }


            }
            
            long tot = 0;

            //call addition and multiplcation functions return the total
            sorted = addition(sorted);
            sorted = multiplication(sorted);
            tot = long.Parse(sorted[1]);

            return tot;
        }
        
        public List<string> addition(List<string> results)
        {
            //initialise variables 
            List<string> ret = new List<string>();
            long Stotal = 0;
            char expTracker = '+';
            int lastNCount = 0;
            int nextNCount, counter = 0;
            long nextN, lastN = 0;
            string AllowedNumber = @"^[0-9]*$";

            // for loop finds the plus sign and proceeds to take the surrounding numbers, sums them and removes the previous values

            for (int i = 0; i <= results.Count() - 1; i++)
            {
                if (results[i] != " " && results[i] != "")
                {
                    if (Regex.IsMatch(results[i], AllowedNumber))
                    {
                        lastNCount = i;
                        lastN = long.Parse(results[i]);
                    }
                    if (results[i] == "+")
                    {
                        for (int k = i; k <= results.Count() - 1; k++)
                        {
                            if (Regex.IsMatch(results[k], AllowedNumber))
                            {
                                nextN = long.Parse(results[k]);
                                Stotal = lastN + nextN;

                                results.Insert(lastNCount, Stotal.ToString());
                                results.RemoveRange(lastNCount + 1, (k + 1) - (lastNCount));
                                i = -1;
                                break;
                            }
                        }
                    }
                }
            }

            return results;
        }
        //this function works the same as the addition function just with multiplication
        public List<string> multiplication(List<string> results)
        {
            List<string> ret = new List<string>();
            long Stotal = 0;
            int lastNCount = 0;
            int nextNCount, counter = 0;
            long nextN, lastN = 0;
            string AllowedNumber = @"^[0-9]*$";


            for (int i = 0; i <= results.Count() - 1; i++)
            {
                if (results[i] != " " && results[i] != "")
                {
                    if (Regex.IsMatch(results[i], AllowedNumber))
                    {
                        lastNCount = i;
                        lastN = long.Parse(results[i]);
                    }
                    if (results[i] == "*")
                    {
                        for (int k = i; k <= results.Count() - 1; k++)
                        {
                            if (Regex.IsMatch(results[k], AllowedNumber))
                            {
                                nextN = long.Parse(results[k]);
                                Stotal = lastN * nextN;

                                results.Insert(lastNCount, Stotal.ToString());
                                results.RemoveRange(lastNCount + 1, (k + 1) - (lastNCount));
                                i = -1;
                                break;
                            }
                        }
                    }
                }
            }

            return results;
        }
    }
}
