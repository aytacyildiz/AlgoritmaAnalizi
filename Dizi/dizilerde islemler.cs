using System;
namespace DizilerdeIslem
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] dizi = { 5, -2, 15, 5, -4, 1, 0, 20, -30 };

			// EnBuyuk için deneme
			Console.WriteLine("En buyuk: {0}", EnBuyuk(dizi));

			// ElemanBul için deneme
			Console.WriteLine("Dizideki k. eleman için k:");
			int k = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Dizideki {0}. eleman: {1}",k,ElemanBul(dizi, k));

			// Analizler:
			System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
			for (int i = 0; i < 2; i++) {
				for (int n = 10; n < 1000000000; n = n * 10) {
					stopwatch.Restart();
					Analiz(n,Convert.ToByte(i));
					stopwatch.Stop();
					Console.WriteLine("N: {0} \t Zaman: {1}",n,stopwatch.Elapsed);
				}
			}
		}

		// dizideki en büyük elemanı bul
		static public int EnBuyuk(int[] dizi){
			int max = dizi[0];
			for(int i = 1; i < dizi.Length; i++){
				if (dizi [i] > max)
					max = dizi [i];
			}
			return max;
		}
		// dizideki k. elemanı bul
		static public int ElemanBul(int[] dizi, int k){
			int eleman = 0;
			for (int i = 1; i <= k; i++) {
				eleman = dizi[i - 1];
			}
			return eleman;
		}

		// Analiz için n uzunluklu dizide denemeler
		static public void Analiz(int n, byte fonk){
			// n uzunlukta rastegele sayılar ile doldurulmuş dizi
			Random rand = new Random();
			int[] dizi = new int[n];
			for (int i = 0; i < dizi.Length; i++) {
				dizi [i] = rand.Next(5000); // 0 - 5000 arası
			}
			// denenecek fonksiyonu çalıştır
			if (fonk == 0) {
				EnBuyuk(dizi);
			} else {
				ElemanBul(dizi, rand.Next(n));
			}
		}
	}
}
