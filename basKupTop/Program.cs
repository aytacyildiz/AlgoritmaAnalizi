﻿using System;

namespace basamakKuplareTop
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			for (int i = 1; i <= 9; i++) {
				for (int j = 0; j <= 9; j++) {
					for (int k = 0; k <= 9; k++) {
						if ((i * i * i) + (j * j * j) + (k * k * k) == ((100 * i) + (10 * j) + (k)))
							Console.WriteLine (i+""+j+""+k);
					}
				}
			}
		}
	}
}
