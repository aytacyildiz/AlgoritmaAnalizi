// Hello World! : hello.cs

using System;

class Hello {
	static void Main() {
		
		System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

		for(int n = 10; n <= 70; n = n+10){
		
			Console.Write("Sayi: {0}\t",n);

			stopwatch.Restart();

			long toplam = fib(n);

			stopwatch.Stop();

			Console.Write("Sonuc: {0} \tGecen Sure: {1}\n", toplam, stopwatch.Elapsed);
		
		}

	}

	private static long fib(int n){
		if( n == 1 || n == 2 ) return 1;
		else return fib( n - 1 ) + fib( n - 2 );
	}
}
