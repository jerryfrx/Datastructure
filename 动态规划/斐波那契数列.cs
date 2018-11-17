//斐波那契数列--记忆化搜索
//自顶向下解决问题
using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp2 {
    class Program {
        public static int num = 0;

        public static void Main ( string[] args ) {
            int n = 40;
            Stopwatch watch = new Stopwatch();
            watch.Start ();
            int result = Fib(n);
            watch.Stop ();
            TimeSpan timeSpan = watch.Elapsed;
            Console.WriteLine ( $"Fib {n} = {result}" );
            Console.WriteLine ( $"times : {Program.num}" );
            Console.WriteLine ( $"time : {timeSpan.TotalMilliseconds.ToString ()}" );
        }
        public static int Fib ( int n ) {
            int[] memo = Enumerable.Repeat(-1,n+1).ToArray();
            return Fib ( n,memo );
        }
        public static int Fib ( int n,int[] memo ) {
            Program.num++;
            if ( n == 0 ) {
                return 0;
            }
            if ( n == 1 ) {
                return 1;
            }
            if ( memo[n] == -1 ) {
                memo[n] = Fib ( n - 1,memo ) + Fib ( n - 2,memo );
            }
            return memo[n];
        }
    }
}
