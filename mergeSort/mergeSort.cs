using System;
using System.Collections.Generic;

namespace MergeSort
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			Random r = new Random ();

			// the array
			int[] diziFI = new int[11];
			// fill array with random numbers
			for (int i = 0; i < diziFI.Length; i++) {
				diziFI [i] = r.Next (-1000,1000);
			}
			// print
			Console.WriteLine ("Dizi --------------------------------");
			for (int i = 0; i < diziFI.Length; i++) {
				Console.Write (" " + diziFI[i]);
			}
			Console.WriteLine ();
			Console.WriteLine ("İslemler --------------------------------");
			// merge sort
			FIMergeSort.MergeSort_Recursive (diziFI,0,10); // [begin, end)
			// print
			Console.WriteLine ();
			Console.WriteLine ("Sirali Dizi --------------------------------");
			for (int i = 0; i < diziFI.Length; i++) {
				Console.Write (" " + diziFI[i]);
			}
			Console.WriteLine ();
		}

		/*
	 * Kaynak
	 * http://www.softwareandfinance.com/CSharp/MergeSort_Recursive.html
	*/
		public static class FIMergeSort
		{
			static public void DoMerge (int[] numbers, int left, int mid, int right)
			{

				int[] temp = new int[numbers.Length];
				int i, left_end, num_elements, tmp_pos;

				left_end = (mid - 1);
				tmp_pos = left;
				num_elements = (right - left + 1);

				while ((left <= left_end) && (mid <= right)) {
					Console.Write ("(" + numbers [left] + " " + numbers [mid] + ") ");
					if (numbers [left] <= numbers [mid])
						temp [tmp_pos++] = numbers [left++];
					else
						temp [tmp_pos++] = numbers [mid++];
				}
				while (left <= left_end)
					temp [tmp_pos++] = numbers [left++];
				while (mid <= right)
					temp [tmp_pos++] = numbers [mid++];
				for (i = 0; i < num_elements; i++) { 
					numbers [right] = temp [right];
					right--;
				}

			}

			static public void MergeSort_Recursive (int[] numbers, int left, int right)
			{
				int mid;
				if (right > left) {
					mid = (right + left) / 2;
					Console.Write ("g ");
					MergeSort_Recursive (numbers, left, mid);
					Console.Write ("g ");
					MergeSort_Recursive (numbers, (mid + 1), right);
					Console.Write ("d ");
					DoMerge (numbers, left, (mid + 1), right);
				}
			}
		}
	}
}
