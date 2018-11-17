//用动态规划优化斐波那契数列--动态规划
//自底向上解决问题
using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp2 {
    class Program {
        public static void Main ( string[] args ) {
            int n = 10;
            Stopwatch watch = new Stopwatch();
            watch.Start ();
            int result = Fib(n);
            watch.Stop ();
            TimeSpan timeSpan = watch.Elapsed;
            Console.WriteLine ( $"Fib {n} = {result}" );
            Console.WriteLine ( $"time : {timeSpan.TotalMilliseconds.ToString ()}" );
        }
        public static int Fib ( int n ) {
            int[] memo = Enumerable.Repeat(-1,n+1).ToArray();
            memo[0] = 0;
            memo[1] = 1;
            for ( int i = 2 ;i <= n ;i++ ) {
                memo[i] = memo[i - 1] + memo[i - 2];
            }
            return memo[n];
        }
    }
}
