using System;

namespace MaxSubSumOdev
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// ornek dizi
			Sonuc sonuc = maxSubSum (new int[]{ 3, 5, 7, -7, 9 });
			// toplami ekrana yazdir
			Console.WriteLine (sonuc.toplam);
			// indisleri ekrana yazdir (alt alta)
			for (int i = 0; i < sonuc.indisler.Length; i++) {
				Console.WriteLine (sonuc.indisler[i]);
			}
		}

		public static Sonuc maxSubSum( int [ ] a )
		{
			// degiskenler
			int maxSum = 0;
			int[] t_indisler = null; // gecici indis listesi
			int[] r_indisler = null;

			for( int i = 0; i < a.Length; i++ )
				for( int j = i; j < a.Length; j++ )
				{
					int thisSum = 0;               // hesablanan o anki alt dizi eleman toplami
					t_indisler = new int[(j-i)+1]; // indislerin gecici olarak tutulmasi 

					// alt dizide dolas
					for (int k = i; k <= j; k++) { 
						thisSum += a[ k ];
						t_indisler[k-i] = k;
					}

					// bulunan sonuc daha oncakinden iyi
					if( thisSum > maxSum )
					{
						maxSum   = thisSum;      // artık bu sonuc en iyisi
						r_indisler = t_indisler; // geri dondurulecek indisler
					}
				}
			// sonucu Sonuc turunde geri dondur
			return new Sonuc(){toplam = maxSum, indisler = r_indisler};
		}

		public struct Sonuc{
			public int[] indisler;
			public int toplam;
		}
	}
}
