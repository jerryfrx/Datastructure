/*
numbers = [2, 7, 11, 15], target = 9
输出: [1,2]
解释: 2 与 7 之和等于目标数 9 。因此 index1 = 1, index2 = 2 
*/
namespace ConsoleApp1 {
    class Program {
        static void Main ( string[] args ) {
            int[] ret = TwoSum(new int[]{2,7,11,15},9);
            foreach ( var item in ret ) {
                Console.WriteLine ( item );
            }
        }
        public static int[] TwoSum ( int[] numbers,int target ) {
            int l = 0;
            int r = numbers.Length-1;
            int[] result = new int[2];
            while ( l < r ) {
                if ( numbers[l] + numbers[r] == target ) {
                    result[0] = l + 1;
                    result[1] = r + 1;
                    return result;
                }
                else if ( numbers[l] + numbers[r] > target ) {
                    r--;
                }
                else {
                    l++;
                }
            }
            return result;
        }
    }
}