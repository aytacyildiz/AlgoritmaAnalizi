/*
 *
 *      Orijinal kod http://users.cis.fiu.edu/~weiss/dsj4/code/MaxSumTest.java
 *      adresinden alınmıştır. Benim tarafımdan modifiye edilmiştir.
 *
 * */

import java.util.Random;

public final class MaxSumTest
{
    static private int seqStart = 0;
    static private int seqEnd = -1;

    /**
     * Cubic maximum contiguous subsequence sum algorithm.
     * seqStart and seqEnd represent the actual best sequence.
     */
    public static int maxSubSum1( int [ ] a )
    {
        int maxSum = 0;

        for( int i = 0; i < a.length; i++ )
            for( int j = i; j < a.length; j++ )
            {
                int thisSum = 0;

                for( int k = i; k <= j; k++ )
                    thisSum += a[ k ];

                if( thisSum > maxSum )
                {
                    maxSum   = thisSum;
                    seqStart = i;
                    seqEnd   = j;
                }
            }

        return maxSum;
    }

    /**
     * Quadratic maximum contiguous subsequence sum algorithm.
     * seqStart and seqEnd represent the actual best sequence.
     */
    public static int maxSubSum2( int [ ] a )
    {
        int maxSum = 0;

        for( int i = 0; i < a.length; i++ )
        {
            int thisSum = 0;
            for( int j = i; j < a.length; j++ )
            {
                thisSum += a[ j ];

                if( thisSum > maxSum )
                {
                    maxSum = thisSum;
                    seqStart = i;
                    seqEnd   = j;
                }
            }
        }

        return maxSum;
    }

    /**
     * Linear-time maximum contiguous subsequence sum algorithm.
     * seqStart and seqEnd represent the actual best sequence.
     */
    public static int maxSubSum3( int [ ] a )
    {
        int maxSum = 0;
        int thisSum = 0;

        for( int i = 0, j = 0; j < a.length; j++ )
        {
            thisSum += a[ j ];

            if( thisSum > maxSum )
            {
                maxSum = thisSum;
                seqStart = i;
                seqEnd   = j;
            }
            else if( thisSum < 0 )
            {
                i = j + 1;
                thisSum = 0;
            }
        }

        return maxSum;
    }


    public static void getTimingInfo( int n, int alg )
    {
        int [] test = new int[ n ];

        for( int j = 0; j < test.length; j++ )
            test[ j ] = rand.nextInt( 100 ) - 50;

        long startTime = System.currentTimeMillis( );
        long totalTime = 0;

        switch( alg )
        {
          case 1:
            maxSubSum1( test );
            break;
          case 2:
            maxSubSum2( test );
            break;
          case 3:
            maxSubSum3( test );
            break;
        }

        totalTime = System.currentTimeMillis( ) - startTime;

        System.out.println( "Algorithm #" + alg + "\t"
             + "N = " + test.length
             + "\ttime = " + ( totalTime ) + "ms");
    }

    private static Random rand = new Random( );

    /**
     * Simple test program.
     */
    public static void main( String [ ] args )
    {
        int a[ ] = { 4, -3, 5, -2, -1, 2, 6, -2 };
        int maxSum;


        maxSum = maxSubSum1( a );
        System.out.println( "Max sum is " + maxSum + "; it goes"
                       + " from " + seqStart + " to " + seqEnd );
        maxSum = maxSubSum2( a );
        System.out.println( "Max sum is " + maxSum + "; it goes"
                       + " from " + seqStart + " to " + seqEnd );
        maxSum = maxSubSum3( a );
        System.out.println( "Max sum is " + maxSum + "; it goes"
                       + " from " + seqStart + " to " + seqEnd );

          // Get some timing info
        for( int n = 10; n <= 1000000; n *= 10 )
            for( int alg = 3; alg >= 1; alg-- )
            {
                if( alg == 1 && n > 50000 )
                    continue;
                getTimingInfo( n, alg );
            }
    }
}
