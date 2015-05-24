using System;

namespace amortizedCost
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MyStack<int> ms = new MyStack<int> ();
			for (int i = 0; i < 50; i++) {
				ms.push (i);
			}
		}
	}

	public class MyStack <T>{

		private T[] data { get; set; }
		private int size;
		private int capacity;

		public MyStack(){
			size = 0;
			capacity = 4;
			data = new T[capacity];
			Console.WriteLine ("const size:{0} capacity:{1}",size,capacity);
		}

		public void push(T p){
			if (size >= capacity) resize ();
			data [size++] = p;
			Console.WriteLine ("push size:{0} capacity:{1}",size,capacity);
		}

		private void resize ()
		{
			capacity *= 2;
			T[] newData = new T[capacity];
			for (int i = 0; i < data.Length; i++) {
				newData [i] = data [i];
			}
			data = newData;
			Console.WriteLine ("resize size:{0} capacity:{1}",size,capacity);
		}

		public T pop(){
			Console.WriteLine ("pop size:{0} capacity:{1}",(size-1),capacity);
			return data [size--];
		}
	}
}
