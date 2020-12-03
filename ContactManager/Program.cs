using ContactDetails.Actions;
using ContactManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = longestPalindrome("babad");
            LengthOfLongestSubstring("pwwkew");
            
            FindMedianSortedArrays(new int[] { 1, 2 },new int[] { 3, 4 });
            ContactStore contactStore = new ContactStore();
            Actions actions = new Actions(contactStore);
            var repl = new Repl(Console.In, Console.Out, contactStore, actions);
            repl.run();
            Console.ReadLine();
        }

        public void Log() { }
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var listobj = new List<int>();
            listobj.AddRange(nums1);
            listobj.AddRange(nums2);

            listobj.Sort();

            var len = listobj.Count();
            if (len == 0) return 0;
            if (len == 1) return listobj[0];
            double mean = 0;
            int i = len / 2;

            if (len % 2 == 0)
            {
                mean = (listobj[i - 1] + listobj[i])/2 ;
            }
            else
            {
                mean = listobj[i];
            }
            return mean;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            int lon = 0;
            var sList = new List<char>();
            foreach (char c in s)
            {
                if (sList.Contains(c))
                {
                    var ind = sList.FindIndex(a => a == c);
                    for (int i = ind; i >= 0; i--)
                    {
                        sList.RemoveAt(i);
                    }

                }
                sList.Add(c);
                var con = sList.Count();
                if (lon < con)
                {
                    lon = con;
                }
            }
            return lon;
        }

        public static String longestPalindrome(String s)
        {
            if (s == null || s.Length < 1) return "";
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = expandAroundCenter(s, i, i);
                int len2 = expandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end + 1);
        }

        private static int expandAroundCenter(String s, int left, int right)
        {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }
            return R - L - 1;
        }
    }
    
}
