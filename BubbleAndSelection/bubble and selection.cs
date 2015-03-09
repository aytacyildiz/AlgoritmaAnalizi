using System;
public class MainClass{
    public static void Main(){
        
        //int[] dizi1 = {5,-1,6,32,-2,41};
        //int[] dizi2 = {5,-1,6,32,-2,41};
        
        //Bubble(dizi1);
        //Selection(dizi2);
        
        Random rand = new Random();
        for(int i = 10; i <= 500; i = i + 10){
            int[] dizi = new int[i];
            for(int j = 0; j < i; j++) dizi[j] = rand.Next(-500,500);
            int[] diziForBubble = (int[]) dizi.Clone();
            Bubble(diziForBubble);
            Selection(dizi);
        }
        
        
    }
    public static void Bubble(int[] dizi){
        int n = dizi.Length, swap = 0, numberOfcomparetion = 0, numberOfswap = 0;
        for(int c = 0; c < n - 1; c++){
            for(int d = 0; d < n - c - 1; d++){
                numberOfcomparetion++;
                if(dizi[d] > dizi[d+1]){
                    numberOfswap++;
                    swap = dizi[d];
                    dizi[d] = dizi[d+1];
                    dizi[d+1] = swap;
                }
            }
        }
        // output
        Console.Write("Bubble N: {0} ", n);
        //for(int i = 0; i < dizi.Length; i++) Console.Write(dizi[i] + " ");
        //Console.Write("\n");
        Console.WriteLine("numberOfcomparetion: {0}\t numberOfswap:{1} \n",numberOfcomparetion,numberOfswap);
    }
    public static void Selection(int[] dizi){
        int n = dizi.Length, min, swap, numberOfcomparetion = 0, numberOfswap = 0;
        for(int c = 0; c < n - 1; c++){
            min = c;
            for(int d = c + 1; d < n; d++){
                numberOfcomparetion++;
                if(dizi[d] < dizi[min]) min = d;
            }
            if(min!=c){
                numberOfswap++;
                swap = dizi[c];
                dizi[c] = dizi[min];
                dizi[min] = swap;
            }
        }
        // output
        Console.Write("Selection \t N: {0} ", n);
        //for(int ii = 0; ii < dizi.Length; ii++) Console.Write(dizi[ii] + " ");
        //Console.Write("\n");
        Console.Write("numberOfcomparetion: {0}\t numberOfswap:{1} \n",numberOfcomparetion,numberOfswap);
    }
}