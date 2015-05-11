using System;

namespace indexOperatoru
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Liste<int> listem = new Liste<int> ();
			listem.Ekle (1);
			listem.Ekle (2);
			listem.Ekle (3);
			Console.WriteLine (listem[1].deger);
		}

		// isaretciler ile gerceklestirilmis liste
		public class Liste<T>{
			// liste icerisindeki ogeler
			public class Oge{
				public T deger { get; set;}
				public Oge sonraki { get; set;}
			}
			// listedeki en son eleman
			public Oge son { get; set; }
			// listedeki ilk eleman
			public Oge ilk { get; set; }
			// listeye oge ekleme
			public void Ekle(T pDeger){
				// liste bos
				if (son == null) {
					// ogeyi olustur
					son = new Oge ();
					son.deger = pDeger;
					// ilk ve son eleman aynı (sadece 1 eleman var listede)
					ilk = son;
				} else {
					// yeni ogeyi olustur
					Oge oge = new Oge ();
					oge.deger = pDeger;
					// en son ogenin isaretcisini degistir
					son.sonraki = oge;
					// yeni ogeyi artık en son oge yap
					son = oge;
				}
			}
			// [] operatoru
			public Oge this[int key]{
				get{
					// sayac
					int sayac = 0;
					// isaretci
					Oge e = ilk;
					// ilk eleman isteniyorsa
					if (sayac == key)
						return e;
					// listede gezemeye basla
					while (e.sonraki != null) {
						e = e.sonraki;
						sayac++;
						// eger istenilen sayıya sayac erisirse
						if (sayac == key)
							return e;
					}
					// birsey bulunamadiysa
					return null;
				}
//				set{ 
//					this[key].deger = value.deger;
//				}
			}
		}
	}
}
