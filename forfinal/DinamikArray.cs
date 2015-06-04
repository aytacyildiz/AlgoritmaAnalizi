using System;

namespace DynamicArray
{
	class MainClass
	{
		static int[] array;
		static int capacity,size;

		public static void Main (string[] args)
		{
			
			Console.WriteLine ("number:");
			string input = Console.ReadLine ();
			int n = Convert.ToInt32 (input);
			Random rand = new Random ();
			capacity = 4;
			array = new int[capacity];
			for (size = 0; size < n; size++) {
				if (size > (capacity - 1))
					resize ();
				array [size] = rand.Next();
			}
			print ();
		}

		static void resize ()
		{
			capacity *= 2;
			int[] temp = new int[capacity];
			for (int i = 0; i < size; i++) {
				temp[i]=array[i];
			}
			array = temp;
			Console.WriteLine ("resized:{0}",capacity);
		}

		static void print ()
		{
			for (int i = 0; i < size; i++) {
				Console.Write (array[i] + " ");
			}
			Console.WriteLine ();
		}
	}
}
