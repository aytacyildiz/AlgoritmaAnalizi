using System;
using System.Collections.Generic;
using System.Linq;

namespace QueensQuiz{
	class MainClass{

		// ana program
		public static void Main(){

			QueensPuzzle qp = new QueensPuzzle();
			qp.Create();
			qp.printBoard(qp.board);
			Console.WriteLine("Toplam tehtit sayısı: {0}",qp.toplamTehtitSayisi(qp.board));

			bool[,] cozum = qp.Generate (qp.board);
			//qp.printBoard(cozum);

		}



	}

	class QueensPuzzle{

		// sınıf veri elemanları
		public bool [,] board;
		private Random rand;
		private class Gecmis
		{
			public bool[,] gBoard { get; set; }
			public int tehtit { get; set; }
		}

		// yapici
		public QueensPuzzle(){
			// tahtayı oluştur
			board = new bool [8,8];
			// içerisini tamamen false yap
			for (int ii = 0; ii < 8; ii++) {
				for (int jj = 0; jj < 8; jj++) {
					board [ii, jj] = false;
				}
			}
		}

		// içini rastegele doldur
		public void Create(){
			// rand objesini yarat
			rand = new Random();
			// sutunların rastegele satırlarına vezir koy
			for(int i = 0; i < 8; i++){
				board [rand.Next(8),i] = true;
			}
		}

		public bool[,] Generate(bool[,] pBoard){
			// değişken tanımları
			List<Gecmis> gecmis = new List<Gecmis> ();
			int c, r, k, t; // c: column r: row
			// 8 kolonda gez
			for (c = 0; c < 8; c++) {
				// tahtayı klonla
				bool[,] klonBoard = (bool[,])pBoard.Clone ();
				// veziri kolonda bul ve sil
				for (r = 0; r < 8; r++) {
					if (klonBoard [r, c] == true) {
						klonBoard [r, c] = false;
						break;
					}
				}
				// debug
				//printBoard (klonBoard);
				// her satır için döngü
				for (k = 0; k < 8; k++) {
					// eski yeri hariç
					if (k == r) continue;
					// satır sayısı kadar eksik vezirli tahtayı klonla
					bool[,] gecmisBoard = (bool[,])klonBoard.Clone ();
					// her bir satıra bir vezir koy
					gecmisBoard [k, c] = true;
					// debug
					//printBoard (gecmisBoard);
					// tehtit sayısını hesapla
					t = toplamTehtitSayisi (gecmisBoard);
					// eğer tehtit sayısı sıfırsa cevabı bulduk demektir
					if (t == 0) return gecmisBoard;
					// tahtayı ve tehtit sayısını geçmişe ekle
					gecmis.Add (new Gecmis{
						gBoard = gecmisBoard,
						tehtit = t
					});
				}
			}

			// gecmisi tehtit sayısına göre grupla ve sırala
			// https://msdn.microsoft.com/en-us/library/bb397900.aspx
			var sorguSonucu =
				from item in gecmis
				group item by item.tehtit into itemGroup
				orderby itemGroup.Key
				select itemGroup;

			// debug
			foreach (var group in sorguSonucu) {
				Console.Write ("[ ");
				foreach (var item in group) {
					Console.Write (item.tehtit + " ");
				}
				Console.Write ("]");
			}
			Console.Write ("\n");

			// en az tehtit sayısı veren santranç tahtası
			// grubu elemanları için bu fonksiyonu tekrar çağır
			foreach (var item in sorguSonucu.First()) {
				Console.WriteLine ("R.G. for :{0}",item.tehtit);
				Generate (item.gBoard);
			}
			
			return null;
		}

		// tahtadaki toplam tehtit sayısını hesapla
		public int toplamTehtitSayisi(bool[,] pBoard){
			// değişken tanımları
			int sayac = 0, i, j;
			// tüm sutunlar için
			for (i = 0; i < 8; i++) {
				// veziri bul
				for (j = 0; j < 8; j++) {
					if(pBoard[j,i] == true) break;
				}
				// bulunan vezirin yarattığı tehtit sayısını hesapla
				// toplam sonuca ekle
				sayac += tehtitSayisi(pBoard, j, i);
			}
			return sayac;
		}

		// verilen tahta ve vezirin kendi başına tehtitini hesaplar
		public int tehtitSayisi(bool[,] board, int satir, int sutun){

			// değişken tanımlamarı
			int sayac = 0, i, c, r; // c: column r: row i: index

			// yatay
			for (i = 0; i < 8; i++) {
				if (i != satir) {
					if (board [i, sutun] == true) sayac++;
				}
			}

			// dikey
			for (i = 0; i < 8; i++) {
				if (i != sutun) {
					if (board [satir, i] == true) sayac++;
				}
			}

			// güney doğu
			for (i = 0; i < 8; i++) {
				c = sutun + i + 1;
				r = satir + i + 1;
				if (boundaryCheck(c,r) == false) break;
				if (board [r, c] == true) sayac++;
			}

			// kuzey batı
			for (i = 0; i < 8; i++) {
				c = sutun - i - 1;
				r = satir - i - 1;
				if (boundaryCheck(c,r) == false) break;
				if (board [r, c] == true) sayac++;
			}

			// güney batı
			for (i = 0; i < 7; i++) {
				c = sutun + i + 1;
				r = satir - i - 1;
				if (boundaryCheck(c,r) == false) break;
				if (board [r, c] == true) sayac++;
			}

			// kuzey doğu
			for (i = 0; i < 7; i++) {
				c = sutun - i - 1;
				r = satir + i + 1;
				if (boundaryCheck(c,r) == false) break;
				if (board [r, c] == true) sayac++;
			}

			return sayac;
		}

		// döngüde tahta dışına çıkılıyor mu kontrol et
		public bool boundaryCheck(int c, int r){
			if (c > 7 || r > 7 || c < 0 || r < 0) return false;
			return true;
		}

		// o anki santranç tahtası durumunu çıktıya yazar
		public void printBoard(bool[,] board){
			Console.WriteLine ("Tahta----------------------------------------");
			for (int i = 0; i < 8; i++) {
				for (int j = 0; j < 8; j++) {
					if(board[i,j]) Console.Write ("|o");
					else Console.Write ("| ");
				}
				Console.Write ("\n");
			}
			Console.WriteLine ("Tahta----------------------------------------");
		}

	}
}
