using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day18OperationOrder
{
    class Calculator
    {

        public long calc (string expression)
        {
            //initial variable needed
            string[] expSplit = Regex.Split(expression, string.Empty);
            List<string> sorted = expSplit.ToList();
            int bracketS, BracketE = 0;
            long Stotal = 0;
            char expTracker = '+';

            // for loop for the initial bracketed equation searches for the end of a bracket then loops backwards to obtain the 
            // distinct fomula needed to be solved 
            for (int i = 0; i <= sorted.Count()-1; i++)
            {
                if (sorted[i] == ")")
                {
                    BracketE = i;
                    List<string> tracker = new List<string>();
                    for (int k = i; k-- > 0;)
                    {
                        if(sorted[k] != "(")
                        {
                            tracker.Add(sorted[k]);
                        }
                        else
                        {
                            bracketS = k;
                            Stotal = 0;
                            expTracker = '+';
                            tracker.Reverse();
                            foreach (var item in tracker)
                            {
                                
                                if(item != " ")
                                {
                                    if (item != "+" && item != "*")
                                    {
                                        
                                        if (expTracker == '+')
                                        {
                                            Stotal += long.Parse(item.ToString());
                                        }
                                        else
                                        {
                                            Stotal *= long.Parse(item.ToString());
                                        }
                                    }
                                    else
                                    {
                                        if(item == "+")
                                        {
                                            expTracker = '+';
                                        }
                                        else
                                        {
                                            expTracker = '*';
                                        }
                                    }
                                }
                            }

                            sorted.Insert(bracketS, Stotal.ToString());
                            sorted.RemoveRange(bracketS + 1,(BracketE+1)-(bracketS));
                            i = 0;
                            break;
                        }
                    }
                }              
            }
            //for loop searches for plus or minus symbol and take values on either side to calculate the equation
            long tot = 0;
            Stotal = 0;
            expTracker = '+';
            foreach (var item in sorted)
            {
                if (item != " " && item != "")
                {
                    if (item != "+" && item != "*")
                    {

                        if (expTracker == '+')
                        {
                            tot += long.Parse(item.ToString());
                        }
                        else
                        {
                            tot *= long.Parse(item.ToString());
                        }
                    }
                    else
                    {
                        if (item == "+")
                        {
                            expTracker = '+';
                        }
                        else
                        {
                            expTracker = '*';
                        }
                    }
                }
            }


            return tot;
        }
    }
}
