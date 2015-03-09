// Hello World! : hello.cs

using System;

class Hello {
	static void Main() {
		
		System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

		for(int n = 10; n <= 80; n = n+10){
		
			Console.Write("Sayi: {0}\t",n);

			int sayac = 1;
			long toplam = 1, a = 0, b = 1;

			stopwatch.Restart();

			while(sayac < n){
				toplam = a + b;
				a = b;
				b = toplam;
				sayac++;
			}

			stopwatch.Stop();

			Console.Write("Sonuc: {0} \tGecen Sure: {1}\n", toplam, stopwatch.Elapsed);
		
		}

	}
}
