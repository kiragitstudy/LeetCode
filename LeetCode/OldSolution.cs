using System.Text;

namespace LeetCode;

public class OldSolution
{
    public int LengthOfLongestSubstring(string s)
    {
        int max = 1;
        int count = 0;
        int point = 0;
        if (s.Length == 1) return 1;
        List<char> chars = new List<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if(!chars.Contains(s[i]))
            {
                chars.Add(s[i]);
                count++;
            }
            else
            {
                i = point++;
                if (max < count) max = count;
                count = 0;
                chars.Clear();
            }
        }
        if (max < count) max = count;
        return max;
    }





    //https://leetcode.com/problems/text-justification/description/
    
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        int temp_max = maxWidth;
        List<string> tempList = new List<string>();
        List<string> result = new List<string>();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length <= temp_max)
            {
                temp_max = temp_max - words[i].Length - 1;
                tempList.Add(words[i]);
            }
            else if (tempList.Count == 1)
            {
                var space = maxWidth - tempList.First().Length;
                result.Add(tempList.First() + new string(' ', space));
                temp_max = maxWidth;
                tempList.Clear();
                i--;
            }
            else
            {
                var sum = tempList.Sum(w => w.Length);
                var spaces = maxWidth - sum;
                for (var index = 0; index < tempList.Count; index++)
                {
                    if (index == tempList.Count - 1)
                    {
                        sb.Append(tempList[index]);
                        break;
                    }
                    var space = (int)Math.Ceiling((double)spaces / (tempList.Count - 1 - index));
                    spaces -= space;
                    if (spaces + sb.Length + tempList[index].Length + tempList[index+1].Length > maxWidth) space--;
                    sb.Append(tempList[index] + new string(' ', space));
                }

                result.Add(sb.ToString());
                sb.Clear();
                temp_max = maxWidth;
                tempList.Clear();
                i--;
            }

            if (i != words.Length - 1) continue;
            for (var index = 0; index < tempList.Count; index++)
            {
                if (index == tempList.Count - 1)
                {
                    sb.Append(tempList[index] + new string(' ', maxWidth - tempList.Sum(w => w.Length) - (tempList.Count - 1)));
                    break;
                }
                sb.Append(tempList[index] + ' ');
            }
            result.Add(sb.ToString());
        }

        return result;
    }
}
