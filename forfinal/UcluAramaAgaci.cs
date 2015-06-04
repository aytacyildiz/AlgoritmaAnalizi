using System;

namespace UcluAramaAgaci
{
	public class Node{
		public int? lvalue,rvalue;
		public Node left,right,middle;
	}
	public class TBTree{
		public Node node;
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		//
		// arama algoritması
		//
		public Node search(int key, Node node){
			if (node == null || node.lvalue == key || node.rvalue == key)
				return node;
			if (node.lvalue != null && key < node.lvalue)
				return search (key, node.left);
			else if (node.lvalue != null && node.rvalue != null && key > node.lvalue && key < node.rvalue)
				return search (key, node.middle);
			else if (node.rvalue != null && key > node.rvalue)
				return search (key, node.right);
			else
				return null;
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////////
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			// manuel inserts
			TBTree tbt = new TBTree();
			tbt.node = new Node ();
			tbt.node.lvalue = 3;
			tbt.node.rvalue = 9;
			tbt.node.left = new Node ();
			tbt.node.left.lvalue = 2;
			tbt.node.middle = new Node ();
			tbt.node.middle.lvalue = 6;
			tbt.node.middle.left = new Node ();
			tbt.node.middle.left.lvalue = 5;

			Console.WriteLine (tbt.search(5,tbt.node).lvalue);
			Console.WriteLine (tbt.search(5,tbt.node).rvalue);
		}
	}
	
}
