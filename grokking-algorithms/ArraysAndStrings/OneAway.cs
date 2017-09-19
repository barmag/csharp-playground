using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    internal class OneAway
    {
        enum Mode { Add, Remove }
        /// <summary>
        /// Given that an edit is adding or removing a character
        /// checks if two strings are at most one edit away
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        internal static bool Check(string s1, string s2)
        {
            if (Math.Abs(s1.Length - s2.Length) > 1)
            {
                return false;
            }
            int diff = 0;
            var src = s1.Length >= s2.Length ? s1 : s2;
            var dest = s1.Length < s2.Length ? s1 : s2;
            
            for (int i = 0; i < src.Length; i++)
            {
                if(i < dest.Length)
                {
                    if(src[i] != dest[i])
                    {
                        for (int j = i; j < dest.Length-i; j++)
                        {
                            if (src[j + src.Length - dest.Length] != dest[j])
                                return false;
                        }
                        return true;
                    }
                }
                
            }
            return true;
        }
    }
}
