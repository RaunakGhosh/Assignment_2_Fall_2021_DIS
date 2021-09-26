using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignment_2_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:

            Console.WriteLine("Question 1");
            int[] heights = { -5, 1, 5, 0, -7 };
            int max_height = LargestAltitude(heights);
            Console.WriteLine("Maximum altitude gained is {0}", max_height);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3:
            Console.WriteLine("Question 3");
            string[] words1 = { "bella", "label", "roller" };
            List<string> commonWords = CommonChars(words1);
            Console.WriteLine("Common characters in all the strigs are:");
            for (int i = 0; i < commonWords.Count; i++)
            {
                Console.Write(commonWords[i] + "\t");
            }
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            int[] arr1 = { 1, 2, 2, 1, 1, 3 };
            bool unq = UniqueOccurrences(arr1);
            if (unq)
                Console.WriteLine("Number of Occurences of each element are unique");
            else
                Console.WriteLine("Number of Occurences of each element are not unique");

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            List<List<string>> items = new List<List<string>>();
            items.Add(new List<string>() { "phone", "blue", "pixel" });
            items.Add(new List<string>() { "computer", "silver", "lenovo" });
            items.Add(new List<string>() { "phone", "gold", "iphone" });

            string ruleKey = "color";
            string ruleValue = "silver";

            int matches = CountMatches(items, ruleKey, ruleValue);
            Console.WriteLine("Number of matches for the given rule :{0}", matches);

            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7:

            Console.WriteLine("Question 7:");
            string allowed = "ab";
            string[] words = { "ad", "bd", "aaab", "baa", "badab" };
            int count = CountConsistentStrings(allowed, words);
            Console.WriteLine("Number of Consistent strings are : {0}", count);
            Console.WriteLine(" ");

            //Question 8:
            Console.WriteLine("Question 8");
            int[] num1 = { 12, 28, 46, 32, 50 };
            int[] num2 = { 50, 12, 32, 46, 28 };
            int[] indexes = AnagramMappings(num1, num2);
            Console.WriteLine("Mapping of the elements are");
            for (int i = 0; i < indexes.Length; i++)
            {
                Console.Write(indexes[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            int[] arr10 = { 2, 3, 1, 2, 4, 3 };
            int target_subarray_sum = 7;
            int minLen = minSubArrayLen(target_subarray_sum, arr10);
            Console.WriteLine("Minimum length subarray with given sum is {0}", minLen);
            Console.WriteLine();
        }


        /*
        Question 1:

        There is a biker going on a road trip. The road trip consists of n + 1 points at different altitudes. The biker starts his trip on point 0 with altitude equal 0.
        You are given an integer array gain of length n where gain[i] is the net gain in altitude between points i and i + 1  for all (0 <= i < n). Return the highest altitude of a point.
        Example 1:
        Input: gain = [-5,1,5,0,-7]
        Output: 1
        Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.

        */

        public static int LargestAltitude(int[] gain)
        {
            try
            {
                int currAlt = 0;//current altitude
                int maxAlt = 0;//maximum altitude
                for (int i = 0; i < gain.Length; i++)//traversing the gain int array
                {
                    currAlt += gain[i];//current altitude gets added by the elements in the gain array
                    if (currAlt > maxAlt)//if current altitude is greater than max altitude then current altitude will get placed in the max altitude variable 
                    {
                        maxAlt = currAlt;
                    }
                }
                return maxAlt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        
        Question 2:

        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search

        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2

        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1

        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4

        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int start = 0;
                int end = nums.Length - 1;//we are keeping the end variable as num int array's length minus one

                while (start <= end)//we start binary search here as while loop condition is start index is less than equal to end index
                {
                    int mid = (start + end) / 2;//mid is the half way index between the start and end index
                    if (target == nums[mid])//if target is the mid value of nums int array
                    {
                        return mid;
                    }
                    else if (target < nums[mid])//if target is less than mid value of nums int array
                    {
                        end = mid - 1;//we keep end index as mid index minus 1
                    }
                    else
                    {
                        start = mid + 1;//start index as mid index increment 1
                    }
                }
                Console.WriteLine(start + " " + end);
                if (end < 0)//if end index is less than 0
                {
                    return 0;
                }
                if (nums[end] > target)//if end index num array value is greater than target
                {
                    return end;
                }
                else
                {
                    return start;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 3
       
        Given an array words of strings made only from lowercase letters, return a list of all characters that show up in all strings in words (including duplicates).  For example, if a character occurs 3 times in all strings but not 4 times, you need to include that character three times in the final answer.
        You may return the answer in any order.
        Example 1:
        Input: ["bella","label","roller"]
        Output: ["e","l","l"]
        Example 2:
        Input: ["cool","lock","cook"]
        Output: ["c","o"]

        
        */

        public static List<string> CommonChars(string[] words)
        {
            try
            {
                List<string> commonwords = new List<string>();//initializing commonwords string list
                int[,] count = new int[100, 26];//initializing 2D array having 100 rows and 26 columns
                for (int i = 0; i < words.Length; ++i)//traversing the words in the input
                {
                    for (int j = 0; j < words[i].Length; ++j)//traversing the letters in the word
                    {
                        char ch = words[i][j];//provides the respective character in the word
                        // occurence of character in each string
                        count[i, ch - 97]++;//this gives the count value of character which increments everytime per loop. 97 is the ascii code of 'a'
                    }
                }

                for (int i = 0; i < 26; ++i)//traversing through each letter
                {
                    int k = int.MaxValue;//providing max value of int to k i.e. k=2147483647
                    for (int j = 0; j < words.Length; j++)//traversing through the words length
                    {
                        if (count[j, i] == 0)//if the count is 0
                        {
                            k = -1; // doesn't appear in every string
                            break;
                        }
                        k = Math.Min(k, count[j, i]); // the minimal number of the letter
                    }
                    while (k-- > 0)
                    {
                        commonwords.Add(char.ToString((char)(97 + i)));//adding each letter which was counted into the commonwords as a whole string
                    }
                }
                return commonwords;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 4:

        Given an array of integers arr, write a function that returns true if and only if the number of occurrences of each value in the array is unique.

        Example 1:
        Input: arr = [1,2,2,1,1,3]
        Output: true
        Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.

        Example 2:
        Input: arr = [1,2]
        Output: false

       
         */

        public static bool UniqueOccurrences(int[] arr)
        {
            try
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                foreach (int a in arr)//traversing through each term in array arr
                {
                    if (dict.ContainsKey(a))//if dictionary dict contains int a
                        dict[a] += 1;
                    else
                        dict[a] = 1;
                }


                foreach (int v in dict.Values)//traversing through the values in dictionary dict
                {
                    if (dict.Values.Where(val => val == v).Count() > 1)//if dict values contain the specific v value, then place the value in val and if count is greater than 1
                        return false;
                }
                return true;
            }



            catch (Exception)
            {

                throw;
            }

        }

        /*  
        
        Question 5:

        You are given an array items, where each items[i] = [type, color, name]  describes the type, color, and name of the ith item.
        You are also given a rule represented by two strings, ruleKey and ruleValue.
        The ith item is said to match the rule if one of the following is true:
        •	ruleKey == "type" and ruleValue == type.
        •	ruleKey == "color" and ruleValue == color.
        •	ruleKey == "name" and ruleValue == name.

        Return the number of items that match the given rule.

        Example 1:
        Input:  items = [["phone","blue","pixel"],["computer","silver","lenovo"],["phone","gold","iphone"]],  ruleKey = "color",  ruleValue = "silver".
        Output: 1
        Explanation: There is only one item matching the given rule, which is ["computer","silver","lenovo"].

        Example 2:
        Input: items = [["phone","blue","pixel"],["computer","silver","phone"],["phone","gold","iphone"]], ruleKey = "type",  ruleValue = "phone"
        Output: 2
        Explanation: There are only two items matching the given rule, which are ["phone","blue","pixel"]  and ["phone","gold","iphone"]. 

        Note that the item ["computer","silver","phone"] does not match.

        */

        public static int CountMatches(List<List<string>> items, string ruleKey, string ruleValue)
        {
            try
            {
                //write your code here.
                var counter = 0;
                if (ruleKey == "type")// if rulekey is type
                {
                    for (var i = 0; i < items.Count; i++)//traversing the list items
                    {
                        if (items[i][0] == ruleValue)//if item value at row ith, first column equals ruleValue then increase counter
                        {
                            counter++;
                        }
                    }
                }
                if (ruleKey == "color")// if rulekey is color
                {
                    for (var i = 0; i < items.Count; i++)//traversing the list items
                    {
                        if (items[i][1] == ruleValue)//if item value at row ith, second column equals ruleValue then increase counter
                        {
                            counter++;
                        }
                    }
                }
                if (ruleKey == "name")// if rulekey is color
                {
                    for (var i = 0; i < items.Count; i++)//traversing the list items
                    {
                        if (items[i][2] == ruleValue)//if item value at row ith, third column equals ruleValue then increase counter
                        {
                            counter++;
                        }
                    }
                }
                return counter;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        
        Question 6:
        
        Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers. Length.
        You may not use the same element twice, there will be only one solution for a given array.

        Note: Solve it in O(n) and O(1) space complexity.

        Hint: Use the fact that array is sorted in ascending order and there exists only one solution.
        Typically, in these cases it’s useful to use pointers tracking the two ends of the array.

        Example 1:
        Input: numbers = [2,7,11,15], target = 9
        Output: [1,2]
        Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

        Example 2:
        Input: numbers = [2,3,4], target = 6
        Output: [1,3]

        Example 3:
        Input: numbers = [-1,0], target = -1
        Output: [1,2]

        */

        public static void targetSum(int[] nums, int target)
        {
            try
            {
                //write your code here.
                int[] array1;


                for (int i = 0, j = nums.Length - 1; i < j;)//traversing through two locations of the nums array. from start and end index
                {
                    if (nums[i] + nums[j] == target)//if the first index and last index values add up to the target
                    {
                        array1 = new int[] { ++i, ++j };//adding the values to new array

                    }

                    else if (nums[i] + nums[j] < target)//if the first index and last index values add up to less than the target
                    {
                        i++;
                    }

                    else
                    {
                        j--;
                    }

                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 7:

        You are given a string allowed consisting of distinct characters and an array of strings words. A string is consistent if every character in words[i] 
        appears in the string allowed.
        Return the number of consistent strings in the array words.

        Note: The algorithm should have run time complexity of O(n).
        Hint: Use Dictionaries. 

        Example 1:
        Input: allowed = "ab", words = ["ad","bd","aaab","baa","badab"]
        Output: 2
        Explanation: Strings "aaab" and "baa" are consistent since they only contain characters 'a' and 'b'. string “bd” is not consistent since ‘d’ is not in string allowed.

        Example 2:
        Input: allowed = "abc", words = ["a","b","c","ab","ac","bc","abc"]
        Output: 7
        Explanation: All strings are consistent.

        */

        public static int CountConsistentStrings(string allowed, string[] words)
        {
            try
            {
                //write your code here.
                //Used HashSet to store characters from allowed string, Why because fetching character from Hash set is o(1).
                HashSet<char> allowedCharsSet = new HashSet<char>();
                foreach (char val in allowed)
                {
                    allowedCharsSet.Add(val);
                }


                // count variable is used to count number of consistent strings.
                // wordPointer variable is used to move to next word in words array.
                // charPointer variable is used to move to next character in word string.
                int count = 0, wordPointer = 0, charPointer = 0;

                while (wordPointer < words.Length)
                {
                    if (allowedCharsSet.Contains(words[wordPointer][charPointer]))
                    {
                        charPointer++;
                        if (charPointer >= words[wordPointer].Length)
                        {
                            charPointer = 0;
                            count++;
                            wordPointer++; // going to next word if character from word string is present in allowed string by increasing count value.
                        }
                    }
                    else
                    {
                        charPointer = 0;
                        wordPointer++; // going to next word if character from word string is not present in allowed string by resetting char pointer to 0.
                    }
                }
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 8:

        You are given two integer arrays nums1 and nums2 where nums2 is an anagram of nums1. Both arrays may contain duplicates.

        Return an index mapping array mapping from nums1 to nums2 where mapping[i] = j indicates that  the ith element in nums1 appears in nums2 at index j. If there are multiple answers, return any of them.
        An array a is an anagram of array b if b is made by randomizing the order of the elements in a.

 
        Example 1:
        Input: nums1 = [12,28,46,32,50], nums2 = [50,12,32,46,28]
        Output: [1,4,3,2,0]
        Explanation: As mapping[0] = 1 because the 0th element of nums1 appears at nums2[1], and mapping[1] = 4 because the 1st element of nums1 appears at nums2[4], and so on.

        */

        public static int[] AnagramMappings(int[] nums1, int[] nums2)
        {
            try
            {
                //write your code here.
                int[] ans = { };
                Dictionary<int, int> D = new Dictionary<int, int>();
                for (int i = 0; i < nums2.Length; ++i)//traversing through the nums2 array
                    D.Add(nums2[i], i);//adding key and value

                ans = new int[nums1.Length];//initializing new int array
                int t = 0;
                foreach (int x in nums1)//traversing through nums1 array
                    ans[t++] = D.GetValueOrDefault(x);//we place the value of D array with respect to the key 'x' to each new position of ans int array

                return ans;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
        
        Question 9:

        Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

        Note: Time Complexity should be O(n).
        Hint: Keep track of maximum sum as you move forward.
        Example 1:
        Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.
        Example 2:
        Input: nums = [1]
        Output: 1

        */

        public static int MaximumSum(int[] arr)
        {
            try
            {
                //write your code here.
                int sum = 0;
                int maxSum = arr[0];

                for (int i = 0; i < arr.Length; i++)//traversing through array arr
                {
                    sum += arr[i];//adding array values to sum variable
                    if (arr[i] > sum)//arr[i] value is greater than sum
                    {
                        sum = arr[i];//arr[i] value will then be placed in to sum
                    }
                    if (sum > maxSum)// sum is greater than maxSum
                    {
                        maxSum = sum;//sum will then then be placed in to maxSum 
                    }
                }
                return maxSum;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:

        Given an array of positive integers nums and a positive integer target, return the minimal length of a contiguous subarray [nums[l], nums[l+1], ..., nums[r-1], nums[r]] of which the sum is greater than or equal to target. If there is no such subarray, return 0 instead.


        Note: Try to solve it in O(n) time.

        Hint: Try to create a window and track the sum you have in the window.

        Example 1:
        Input: target = 7, nums = [2,3,1,2,4,3]
        Output: 2
        Explanation: The subarray [4,3] has the minimal length under the problem constraint.


        Example 2:
        Input: target = 4, nums = [1,4,4]
        Output: 1

        */

        public static int minSubArrayLen(int target_subarray_sum, int[] arr10)
        {
            try
            {
                //write your code here.
                var minLength = int.MaxValue;//Taking MaxValue of int into minLength
                var total = 0;
                for (int start = 0, end = 0; end < arr10.Count(); end++)//traversing through start and end of arr10 array
                {
                    total += arr10[end];//adding arr10 end index value to total 
                    while (total >= target_subarray_sum && start <= end)//while total is greater than or equal to target_subarray_sum and start index is less than or equal to end
                    {
                        minLength = Math.Min(minLength, end - start + 1);//returns the smaller one between minLength and (end-start+1) and places into minLength
                        total -= arr10[start++];//total equals total value minus arr10 value from start index incremented
                    }
                }
                return minLength == int.MaxValue ? 0 : minLength;//this returns the min length of 0 if minLength is equal to MaxValue else will return minLength


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
