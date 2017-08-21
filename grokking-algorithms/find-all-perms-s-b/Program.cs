using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_all_perms_s_b
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "xacxzaa";
            var b = "fxaazxacaaxzoecazxaxaz";
            var perms = new HashSet<string>();
            var all = new List<string>();
            getPermutations(s, perms, all);
        }

        static void getPermutations(string s, HashSet<string> input, List<string> all)
        {
            if (s == "")
                return;
            char a = s[0];
            if (s.Length > 1)
            {
                s = s.Substring(1);
                getPermutations(s, input, all);
                var subperms = new HashSet<string>();
                var suball = new List<String>();
                foreach (var perm in all)
                {
                    for (int i = 0; i < perm.Length; i++)
                    {
                        //input.Add(perm.Substring(0, i) + a + perm.Substring(i));
                        subperms.Add(perm.Substring(0, i) + a + perm.Substring(i));
                        suball.Add(perm.Substring(0, i) + a + perm.Substring(i));
                    }
                }
                foreach (var item in subperms)
                {
                    input.Add(item);
                }
                foreach (var item in suball)
                {
                    all.Add(item);
                }
            }
            else
            {
                input.Add(a + "");
                all.Add(a + "");
            }
        }
    }
}
