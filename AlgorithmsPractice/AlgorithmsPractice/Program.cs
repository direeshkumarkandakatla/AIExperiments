// See https://aka.ms/new-console-template for more information

using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;
using System.IO;
using AlgorithmsPractice.Leet150;
using AlgorithmsPractice.LeetCoding.BackTracking;
using AlgorithmsPractice.LeetCoding.Graphs;
using AlgorithmsPractice.LeetCoding;

namespace AlgorithmsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RemoveAndMerge.RunForMax([-1, 2, 3, 4, -2, 9]);

            //ParanthesisBalance.BalanceString("(a))(bc)");

            //BackTrackingSubSets.Subsets([1, 2, 3]);

            //JumpGame.Execute();
            //ValidPalindrome.Execute();

            //var res = ReorganizeString("aab");

            //string s = "**|**|***|";
            //int[][] queries = [[2, 5], [5, 9]];

            //var res = PlatesCancles.PlatesBetweenCandles(s, queries);

            //int[] array = new int[] { 0, 3, 63, 4, 63, 63 };
            //RandomMaxNumber xy = new RandomMaxNumber(array);

            //Application excel = new Application();
            //Workbook wb = excel.Workbooks.Open("C:\\Users\\direek\\OneDrive - Microsoft\\Desktop\\Ravi Home Estimate.xlsx");
            //wb.SaveAs(@"C:\Users\direek\OneDrive - Microsoft\Desktop\Ravi Home Estimate.csv", XlFileFormat.xlCSVWindows);
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine($"random index: {xy.Get()}");
            //}

            //Dictionary<int, int> x = new Dictionary<int, int>();

            //int[] nums1 = new int[] { 1, 2 };
            //int[] nums2 = new int[] { 3, 4 };
            //var result = FindMedianSortedArrays(nums1, nums2);

            //var result = ZigZagConvert("PAYPALISHIRING", 3);

            //var result = ReverseInt(-2147483648);
            //int[] nums = new int[] { -4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6 };
            //FindTripletSumZero(nums);

            //ParanthasisOrder("()[]{}");

            //Console.WriteLine(result);

            //var result = AddBinary("1", "11");
            //string[] words = new string[] { "This", "is", "an", "example", "of", "text", "justification." };
            //var res = FullJustify(words, 16);
            //long i = 46341;
            //long y = i * i;

            //var res = Sqft(2147483647);

            //var res = NumUniqueEmails(new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" });

            //var res = LicenseKeyFormatting1("5F3Z-2e-9-w", 4);

            //var res = LargestNumber(new int[] { 34323, 3432 });

            //ReverseWords(new char[] { 't', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e' });

            //int[][] sample =
            //{
            //    new int[] { 5, 1, 9, 11 },
            //    new int[] { 2, 4, 8, 10 },
            //    new int[] { 13, 3, 6, 7},
            //    new int[] { 15, 14, 12, 16 }

            //};
            //Rotate(sample);

            //var res = LengthOfLongestSubstringTwoDistinct("eceba");
            //Console.WriteLine(res);

            //Console.WriteLine(GetWrong(3, "ABA"));
            //Console.WriteLine(GetWrong(5, "BBBBB"));

            //var res = GetUniforms(1, 9);


            //unifrom means havign same numbers like 777, 111, 222
            // 75 to 300 --> 77, 88, 99, 111, 222
            // 75 to 300 --> for each number x --> isUniform(x) --> maintain the count
            //  time consuming and may not work on large set

            // 1 - 10 --> 9
            // 10 - 100 --> 9
            // 100 - 1000 --> 9 goes on

            // 5 - 3420
            // 5 - 9, 10-99 (9), 100-999 (9), 1000 - 3420

            // 5/10 ==> 0 ==> 1-9 range => power = 1
            //ex: 75/10 => 7
            //      7/10 ==> 0 --> 99
            // GetPowerRange(5) -> 1
            // 10 - 99 ==> power = 2
            // 100 - 999 ==> power = 3
            // 1000 - 3420 ==> power = 4

            Console.ReadLine();
        }

        static bool CompareFunctionSignatures(string f1, string f2)
        {
            KeyValuePair<string, string> oldFun = new KeyValuePair<string, string>(f1, "KdcCheckClientCertificateAndBuildChainInternal");
            KeyValuePair<string, string> newFun = new KeyValuePair<string, string>(f2, "KdcCheckClientCertificateAndBuildChainInternal");
            return oldFun.Key == newFun.Key || AddParameters(oldFun, newFun) || RemoveParameters(oldFun, newFun);
        }

        private static bool AddParameters(KeyValuePair<string, string> oldFun, KeyValuePair<string, string> newFun)
        {
            var oldFunctionkey = oldFun.Key.Replace(GetFunctionNamePrefix(oldFun.Value), string.Empty);
            var newFunctionkey = newFun.Key.Replace(GetFunctionNamePrefix(newFun.Value), string.Empty);

            return oldFun.Value == newFun.Value &&
                (newFun.Key.StartsWith(oldFun.Key) || //when parameters are added at the end of the function definition
                    newFun.Key.Replace(GetFunctionNamePrefix(newFun.Value), string.Empty)
                        .EndsWith(oldFun.Key.Replace(GetFunctionNamePrefix(oldFun.Value), string.Empty)));//when parameters are added at the start of the function definition
        }

        private static bool RemoveParameters(KeyValuePair<string, string> oldFun, KeyValuePair<string, string> newFun)
        {
            var oldFunctionkey = oldFun.Key.Replace(GetFunctionNamePrefix(oldFun.Value), string.Empty);
            var newFunctionkey = newFun.Key.Replace(GetFunctionNamePrefix(newFun.Value), string.Empty);
            return oldFun.Value == newFun.Value &&
                (oldFun.Key.StartsWith(newFun.Key) || //when parameters are removed at the end of the function definition
                    oldFun.Key.Replace(GetFunctionNamePrefix(oldFun.Value), string.Empty)
                        .EndsWith(newFun.Key.Replace(GetFunctionNamePrefix(newFun.Value), string.Empty)));//when parameters are removed at the start of the function definition
        }


        public static double GetUniforms(long start, long end)
        {
            int retVal = 0;

            long startPoint;
            long endPoint;
            int startPower = Get10thPower(start, false, out startPoint);
            int endPower = Get10thPower(end, true, out endPoint);

            for (long i = start; i <= startPoint; i++)
            {
                retVal += isUniform(i) ? 1 : 0;
            }

            for (long i = endPoint; i <= end; i++)
            {
                retVal += isUniform(i) ? 1 : 0;
            }

            return retVal + 9 * (endPower - startPower);
        }

        static bool isUniform(long number)
        {
            if (number < 10 && number >= 0)
                return true;

            string strNumber = number.ToString();
            for (int i = 0; i < strNumber.Length - 1; i++)
            {
                if (strNumber[i] != strNumber[i + 1])
                    return false;
            }
            return true;
        }

        private static int Get10thPower(long number, bool isPrevious, out long checkPoint)
        {
            checkPoint = 1;
            if (number <= 10)
                return isPrevious ? 0 : 1;

            int retVal = 0;
            while ((isPrevious && number > 10) || (!isPrevious && number > 0))
            {
                number = number / 10;
                retVal++;
                checkPoint *= 10;
            }
            return retVal;              
        }

        public static string GetWrong(int N, string C)
        {
            StringBuilder res = new StringBuilder();

            for (int i = 0; i < C.Length; i++)
            {
                res.Append(C[i] == 'A' ? 'B' : 'A');
            }

            return res.ToString();
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0 && nums2.Length == 0)
                return 0;

            int[] merged = new int[nums1.Length + nums2.Length];

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] <= nums2[j])
                {
                    merged[k] = nums1[i];
                    i++;
                }
                else
                {
                    merged[k] = nums2[j];
                    j++;
                }
                k++;
            }
            for (; i < nums1.Length; i++)
            {
                merged[k] = nums1[i];
                k++;
            }
            for (; j < nums2.Length; j++)
            {
                merged[k] = nums2[j];
                k++;
            }
            return merged.Length % 2 == 0 ?
                ((float)(merged[merged.Length / 2 - 1] + merged[merged.Length / 2])) / (float)2 :
                (float)merged[merged.Length / 2];
            //return (merged[merged.Length/2 - 1] + merged[merged.Length/2]);
        }

        static string ZigZagConvert(string s, int numRows)
        {
            if (numRows == 1)
                return s;

            int next;
            char[] result = new char[s.Length];
            int x = 0;
            for (int i = 0, j = numRows - 1; i < numRows && j >= 0; i++, j--)
            {
                if (i < s.Length)                
                    result[x++] = s[i];                    
                
                for (int k = i; k < s.Length;)
                {
                    next = k + j * 2;
                    if (k != next && next < s.Length)
                        result[x++] = s[next];
                    k = next;

                    next = k + i * 2;
                    if (k != next && next < s.Length)
                        result[x++] = s[next];
                    k = next;
                }
            }
            return new string(result);
        }

        static int ReverseInt(int x)
        {
            long processNumber = x;
            bool isNegetive = x < 0;

            processNumber = isNegetive ? -1 * processNumber : processNumber;
            long modified = 0;
            do
            {
                modified = modified * 10 + (processNumber % 10);
                if ((!isNegetive && modified > int.MaxValue) || (isNegetive && (-1 * modified) < int.MinValue))
                    return 0;
                processNumber = processNumber / 10;
            } while (processNumber > 0);
            return isNegetive ? -1 * (int)modified : (int)modified;
        }

        static IList<IList<int>> FindTripletSumZero(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            nums = nums.OrderBy(n => n).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int target = 0 - nums[i];

                for(int l = i + 1, r = nums.Length - 1; l < r;)
                {   
                    int sum = nums[l] + nums[r];

                    if (sum < target)l++;
                    else if (sum > target) r--;
                    else
                    {                        
                        result.Add(new List<int> { nums[i], nums[l], nums[r] });
                        l++;
                        while (l < r && nums[l] == nums[l - 1])
                            l++;
                    }
                }
            }
            return result;
        }

        static bool ParanthasisOrder(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> keys = new Dictionary<char, char>() { { ')', '(' }, { '}', '{' }, { ']', '[' } };
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                    stack.Push(s[i]);
                else
                {
                    char top;
                    if (stack.TryPop(out top) && keys[s[i]] == top)
                        continue;
                    return false;
                }
            }
            return stack.Count == 0;            
        }

        static string AddBinary(string a, string b)
        {
            char[] sa = new char[a.Length];
            char[] sb = new char[b.Length];

            int rem = 0;
            int sum = 0;
            int fac = 0;
            int i = sa.Length - 1;
            int j = sb.Length - 1;
            for (; i >= 0 && j >= 0; i--, j--)
            {
                sum = Sum(a[i], b[j]);
                rem = (sum + fac) % 2;
                fac = (sum + fac) / 2;

                sa[i] = sb[j] = rem == 0 ? '0' : '1';
            }
            if (j < 0)
            {
                for (; i >= 0; i--)
                {
                    sum = Sum(a[i], '0');
                    rem = (sum + fac) % 2;
                    fac = (sum + fac) / 2;
                    sa[i] = rem == 0 ? '0' : '1';
                }
                return fac > 0 ? fac + new string(sa) : new string(sa);
            }
            else
            {
                for (; j >= 0; j--)
                {
                    sum = Sum(b[j], '0');
                    rem = (sum + fac) % 2;
                    fac = (sum + fac) / 2;                    
                    sb[j] = rem == 0 ? '0' : '1';
                }
                return fac > 0 ? fac + new string(sb) : new string(sb);
            }
        }

        static int Sum(char a, char b)
        {
            return (a - '0') + (b - '0');
        }

        public static IList<string> FullJustify(string[] words, int maxWidth)
        {

            int x = maxWidth; 
            List<RowToDisplay> rows = new List<RowToDisplay>();
            RowToDisplay row = new RowToDisplay(maxWidth);
            rows.Add(row);

            for (int i = 0; i < words.Length; i++)
            {
                if (x - words[i].Length < 0)
                {
                    row = new RowToDisplay(maxWidth);
                    rows.Add(row);
                    x = maxWidth;
                }
                row.AddWord(words[i]);
                x = x - words[i].Length - 1;
            }
            return rows.Where(r => r._words.Count > 0).Select(r => r.GetString()).ToList();
        }

        public static int Sqft(int x)
        {
            if (x == 0 || x == 1)
                return x;
            long i = 1;

            for (; i <= x / 2; i++)
            {
                long res = i * i;
                if (res == x)
                    return (int)i;
                else if (res > x)
                    break;
            }
            Math.Abs(i);
            return (int)(i - 1);
        }

        public static int NumUniqueEmails(string[] emails)
        {

            if (emails == null || emails.Length == 0)
                return 0;

            if (emails.Length == 1)
                return 1;

            Dictionary<string, int> uniqueEmails = new Dictionary<string, int>();

            foreach (string item in emails)
            {
                string m = string.Empty;
                int i = 0;
                for (; i < item.Length; i++)
                {
                    if (item[i] == '@' || item[i] == '+')
                        break;
                    if (item[i] == '.')
                        continue;
                    m += item[i];
                }
                i = item.IndexOf('@');
                for (; i < item.Length; i++)
                    m += item[i];
                if (!uniqueEmails.ContainsKey(m))
                    uniqueEmails.Add(m, 0);
                uniqueEmails[m]++;
            }
            return uniqueEmails.Count;
        }

        public static string LicenseKeyFormatting(string s, int k)
        {
            int tl = s.Replace("-", "").Length;
            if (tl == 0)
                return string.Empty;
            int rem = tl % k;
            int fac = tl / k;
            var res = new char[tl + (rem == 0 ? fac - 1 : fac)];
            int i = 0, j = 0;

            if (rem > 0)
            {
                while(i < rem)
                {
                    if (s[j] == '-')
                        j++;
                    res[i++] = (char)(s[j] >= 97 ? s[j++] - 32 : s[j++]);
                }
                if (i < res.Length - 1) res[i++] = '-';
            }
            int ctr = 0;
            while(i < res.Length)
            {
                if (s[j] == '-')
                    j++;
                else if (ctr < k)
                {
                    res[i++] = (char)(s[j] >= 97 ? s[j++] - 32 : s[j++]);
                    ctr++;
                }
                else if (ctr == k)
                {
                    res[i++] = '-';
                    ctr = 0;
                }
            }
            return new string(res);
        }

        public static string LicenseKeyFormatting1(string s, int k)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            int ct = 0;

            int j = s.Length - 1;
            while(j >= 0)
            {
                if (s[j] == '-')
                    j--;
                else if (ct < k)
                {
                    sb.Append((char)(s[j] >= 97 ? s[j] - 32 : s[j]));
                    j--;
                    ct++;
                }
                else if (ct == k)
                {
                    sb.Append('-');
                    ct = 0;
                }
            }
            return new string(sb.ToString().Reverse().ToArray());
        }

        public static string LargestNumber(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                int max = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    max = IsGreater(nums[j].ToString(), nums[max].ToString()) ? j : max;
                }
                if (max != i)
                {
                    int temp = nums[i];
                    nums[i] = nums[max];
                    nums[max] = temp;
                }
            }

            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < nums.Length; i++)
            {
                if (sb.Length == 0 && nums[i] == 0)
                    continue;

                sb.Append(nums[i].ToString());
            }
            return sb.ToString();
        }

        public static bool IsGreater(string a, string b)
        {
            return string.Compare(a + b, b + a) > 0;
            
        }

        public static void ReverseWords(char[] s)
        {

            if (s == null || s.Length <= 1)
                return;
            ReverseString(0, s.Length - 1, s);

            int left = 0;
            int right = 0;
            while (right < s.Length)
            {
                if (right == s.Length - 1 || s[right + 1] == ' ')
                {
                    ReverseString(left, right, s);
                    right = right + 2;
                    left = right;
                    continue;
                }

                right++;
            }
        }

        public static void ReverseString(int start, int end, char[] s)
        {
            while (start < end)
            {
                char t = s[start];
                s[start] = s[end];
                s[end] = t;
                start++;
                end--;
            }
        }

        public static void Rotate(int[][] matrix)
        {

            bool[][] visited = new bool[matrix.Length][];
            for(int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[matrix.Length];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Update(i, j, matrix[i][j], matrix.Length, matrix, visited);
                }
            }
        }

        public static void Update(int row, int column, int val, int n, int[][] matrix, bool[][] visited)
        {            
            if (visited[row][column])            
                return;

            visited[row][column] = true;
            int nextVal = matrix[column][n - 1 - row];
            matrix[column][n - 1 - row] = val;            
            Update(column, n - 1 - row, nextVal, n, matrix, visited);
        }

        public static int LengthOfLongestSubstringTwoDistinct(string s)
        {

            int start = 0;
            int end = 0;
            Dictionary<char, int> keys = new Dictionary<char, int>();
            int i = 0;
            int j = 0;
            while (j < s.Length)
            {
                if (keys.Keys.Count < 2 || keys.ContainsKey(s[j]))
                {
                    if (!keys.ContainsKey(s[j]))
                        keys.Add(s[j], 0);
                    keys[s[j]]++;
                    if (j - i > end - start)
                    {
                        start = i;
                        end = j;
                    }
                    j++;
                }
                else
                {
                    keys[s[i]]--;
                    if (keys[s[i]] == 0)
                    {
                        keys.Remove(s[i]);
                    }
                    i++;
                }
            }
            return end;// - start + 1;
        }

        public static string GetFunctionNamePrefix(string s)
        {
            return $"_{s}_";
        }

        static void RegExMatch()
        {
            var featrueClassName = "MomentFeature_Notepad";
            string myString1 = "bool enable_AMAETWFix = Feature_Servicing_2109_30983115::IsEnabled() && Feature_Servicing_KDCETW_38564874::IsEnabled();";
            string myString2 = "bool metaData = MomentFeature_Notepad::IsEnabled() || MomentFeature_somethinglese::IsEnabled();";
            string myString3 = "bool Enable___AMAETWFix = Feature_Servicing_2109_30983115::IsEnabled() || Feature_Servicing_KDCETW_38564874::IsEnabled();";
            string myString4 = "bool EnableAMAETWFix = myVariable && (Feature_Servicing_KDCETW_38564874::IsEnabled() || Feature_Servicing_2109_30983115::IsEnabled());";
            string myString5 = "bool EnableAMAETWFix = myVariable &&  Feature_Servicing_KDCETW_38564874::IsEnabled()  && Feature_Servicing_2109_30983115::IsEnabled());";
            string myString6 = "var EnableAMAETWFix = Feature_Servicing_KDCETW_38564874::IsEnabled()  &&\r\n\t Feature_Servicing_2109_30983115::IsEnabled());";



            // Pattern to match "MomentFeature_Notepad::IsEnabled()" with && or || conditions
            string pattern = @"(bool|var)\s+(?<var>\w+\s+)=(?<preCondition>\s\w.+)?(\s+)?{0}(\s+)?(?<postCondition>(&&|\|\|))?(\s+\w.+)?;";
            pattern = string.Format(pattern, "Feature_Servicing_KDCETW_38564874::IsEnabled\\(\\)");
            
            //pattern = string.Format(xxx, featrueClassName);
            Console.WriteLine(IsMatch(myString1, pattern)); // Should print True
            Console.WriteLine(IsMatch(myString2, pattern)); // Should print True
            Console.WriteLine(IsMatch(myString3, pattern)); // Should print False
            Console.WriteLine(IsMatch(myString4, pattern)); // Should print False
            Console.WriteLine(IsMatch(myString5, pattern)); // Should print False
            Console.WriteLine(IsMatch(myString6, pattern)); // Should print False
        }

        static bool IsMatch(string input, string pattern)
        {
            var matches = Regex.Matches(
                        input,
                        pattern,
                        RegexOptions.IgnoreCase,
                        TimeSpan.FromSeconds(10));

            foreach (Match match in matches)
            {
                var variableName = match.Groups["var"].Value;
                var preCondition = match.Groups["preCondition"].Value;
                var postCondition = match.Groups["postCondition"].Value;
            }

            return matches.Any();
        }

        public static string ReorganizeString(string s) 
        {
            PriQueue qu = new PriQueue();
            for (int i = 0; i < s.Length; i++)
                qu.Add(s[i]);

            char? cc = null;
            StringBuilder ret = new StringBuilder();            

            while (!qu.IsEmpty() && qu.TryGetNextChar(cc, out char? nextChar))
            {
                ret.Append(nextChar);
                cc = nextChar;
            }
            return qu.IsEmpty() ? ret.ToString() : string.Empty;
        }
    }    
}

public class PlatesCancles
{
    public static int[] PlatesBetweenCandles(string s, int[][] queries)
    {
        if (string.IsNullOrEmpty(s) || s.Length <= 2)
            return queries.Select(q => 0).ToArray();

        var allcands = s.Select((c, i) => new { c, i })
            .Where(item => item.c == '|')
            .Select(item => item.i).ToList();

        return queries.Select(item =>
        {
            var lc = GetNearCandleIndex(allcands, 0, allcands.Count - 1, item[0], true);
            var uc = GetNearCandleIndex(allcands, 0, allcands.Count - 1, item[1], false);

            var candles = (uc - lc);

            return candles < 0 ? 0 : allcands[uc] - allcands[lc] - candles;
        }).ToArray();
    }

    static int GetNearCandleIndex(List<int> allCand, int low, int high, int target, bool lower)
    {
        if (high < low)
            return lower ? low : high;

        int m = (low + high) / 2;

        if (allCand[m] == target)
            return m;

        return allCand[m] > target ? GetNearCandleIndex(allCand, low, m - 1, target, lower) :
            GetNearCandleIndex(allCand, m + 1, high, target, lower);
    }
}

public class RowToDisplay
{
    public RowToDisplay(int maxWidth)
    {
        SpacesToFill = maxWidth;
    }
    public List<string> _words = new List<string>();
    public int SpacesToFill;
    public int Gaps;

    public void AddWord(string word)
    {
        _words.Add(word);
        SpacesToFill = SpacesToFill - word.Length;
        Gaps = _words.Count - 1;
    }

    public string GetString()
    {
        if (_words.Count == 1)
            return _words[0].PadRight(_words[0].Length + SpacesToFill);
        else
        {
            List<string> words = new List<string>();
            var rem = SpacesToFill % Gaps;
            int i = 1;
            for (int j = 0; j < _words.Count; j++)
            {
                string wrd = j < _words.Count - 1 ? _words[j].PadRight(_words[j].Length + SpacesToFill / Gaps) : _words[j];               
                if (i <= rem)
                {
                    wrd = wrd + ' ';
                    i++;
                }
                words.Add(wrd);
            }
            return string.Join("", words.ToArray());
        }
        
    }

    

}

public class PriQueue
{
    Dictionary<char, int> store = new Dictionary<char, int>();

    public void Add(char c)
    {
        if (!store.ContainsKey(c))
            store.Add(c, 0);
        store[c]++;
    }

    public bool TryGetNextChar(char? prevChar, out char? nextChar)
    {

        var nextItem = store.ToList().Where(item => prevChar == null || item.Key != prevChar).OrderByDescending(i => i.Value).FirstOrDefault();
        if (nextItem.Value == 0)
        {
            nextChar = null;
            return false;
        }

        nextChar = nextItem.Key;
        store[nextChar.Value]--;

        return true;
    }

    public bool IsEmpty()
    {
        return !store.Any(item => item.Value != 0);
    }
}

