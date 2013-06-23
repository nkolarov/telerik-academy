using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers
{
    public static class JudgeSystem
    {
        public static List<int> CheckResult(List<int> problem, List<int> guess)
        {
            // 0 - Bull
            // 1 - Cow
            // -1 - Nothing
            List<int> result = new List<int>();

            if (guess.Count == 0 || guess.Count != problem.Count)
            {
                return result;
            }

            for (int i = 0; i < guess.Count; i++)
            {
                bool bull = false;

                if (guess[i] == problem[i])
                {
                    result.Add(0);
                    bull = true;
                }

                for (int j = 0; j < problem.Count; j++)
                {
                    if (bull == true && i == j)
                    {
                        continue;
                    }
                    else
                    {
                        if (guess[i] == problem[j])
                        {
                            result.Add(1);
                        }
                    }
                }
            }
            
            return result;
        }
    }
}