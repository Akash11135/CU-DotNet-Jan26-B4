using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// virtual method , 
namespace EveryDayCodes
{
    class Solution

    {
        public string name = "";
        public Solution()
        {
            this.name = "Akash";
        }
        public Solution(string name)
        {
            this.name = name;
        }
        public void SecondLargest(int[] nums)
        {
            Array.Sort(nums);
            Console.WriteLine("second largest element : " + nums[nums.Length - 2]);
        }

    

        public static void ReverseString(string s)

        {
            s.ToLower();
            string news = s[0].ToString().ToUpper() + s.Substring(1);
            news.Trim();
            s = news;
            char[] ch = s.ToCharArray();
            Array.Reverse(ch);
            string sub = "";
            int length = ch.Length;
            for (int i = 0; i < length; i++)
            {

                sub += ch[i];
            }
            Console.WriteLine(sub);
        }

        public void freq(string s)
        {
            string seq = s;
            seq = seq.ToLower();
            Dictionary<char, int> mp = new Dictionary<char, int>();

            for(int i=0; i< seq.Length; i++)
            {
                if (seq[i]<=' ' || seq[i] > 'z')
                {
                    continue;
                }
                if(mp.ContainsKey(seq[i]))
                {
                    mp[seq[i]]++;
                }
                else
                {
                    mp[seq[i]] = 1;
                }
            }
            foreach(var item in mp)
            {
                Console.WriteLine(item.Key + "--- " + item.Value);
            }
        }

        public void funct(int [] arr )
        {
            int ans = arr.Where(x => x % 2 == 1).Count();
            Console.WriteLine("ans : "+ans);
        }

    }


    

    internal class Program
    {
      //static void Main(string[] args)
      //  {
      //      Solution s = new Solution();
      //      int[] arr = { 1, 2, 3, 4, 5 };
      //      s.funct(arr);
      //  }


    }
}
