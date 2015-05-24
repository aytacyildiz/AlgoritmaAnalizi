using System;

namespace linearRecursiveSearch
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] ara = new int[]{3,5,-2,9,6,10};
			Console.WriteLine(recLinearSearch(ara,0,9));
		}

		public static int recLinearSearch(int[] dizi, int index, int search){
			if(dizi.Length < index) return -1;
			else if(dizi[index] == search) return index;
			else return recLinearSearch(dizi, ++index, search);
		}
	}
}
