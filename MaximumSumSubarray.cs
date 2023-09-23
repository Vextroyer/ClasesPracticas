/*
Let S(X) be the sum of the elements on the array of integers X.
Given an integer array A return the maximum value S(X) where X is a
subarray of A.
In other words, return the sum of the elements of the subarray of A whose
has the greatest sum..
*/
static class MaximumSumSubarray{

    public static int MaximumSumSubarrayLog(int[] A){
        return MaximumSumSubarrayLog(0,A.Length,A);
    }
    //[l,r)
    static int MaximumSumSubarrayLog(int l,int r, int[] A){
        if(r - l == 1)return A[l];//Size 1
        int middle = (l + r) / 2;
        
        int sumMiddle = A[middle] + SumFromMiddleToLeft(l,middle,A) + SumFromMiddleToRight(middle,r,A);

        int L = MaximumSumSubarrayLog(l,middle,A);
        int R = MaximumSumSubarrayLog(middle,r,A);

        return Math.Max(Math.Max(L,R),sumMiddle);
    }

    //Calculate the maximum sum from the middle position to the left position on A.
    static int SumFromMiddleToLeft(int l,int middle,int[] A){
        //l <= middle
        int MaxSum = 0;
        int CumulativeSum = 0;
        for(int i=middle-1;i>=l;--i){
            CumulativeSum += A[i];
            MaxSum = Math.Max(MaxSum,CumulativeSum);
        }
        return MaxSum;
    }
    //Calculate the maximum sum from the middle position to the right position on A.
    static int SumFromMiddleToRight(int middle,int r,int[] A){
        //middle <= r
        int MaxSum = 0;
        int CumulativeSum = 0;
        for(int i=middle+1;i<r;++i){
            CumulativeSum += A[i];
            MaxSum = Math.Max(MaxSum,CumulativeSum);
        }
        return MaxSum;
    }

    /*
    Let A be an array of N elements.
    For N = 1: The maximum sum subarray is the element itself.

    For N > 1, indexes of A range from 0 to n-1.
    Let L be the subarray of A that ranges from 0 to n-2. It has n - 1 elements because
    n - 2 - 0 + 1 = n - 1.
    Let R be the subarray of A that ranges from 1 to n - 1. It has n - 1 elements because
    n - 1 - 1 + 1 = n - 1.

    The sum on the maximum sum subarray of A is the maximum between the sum of all its elements, 
    the sum on the maximum sum subarray L of A or the sum on the maximum sum  R of A.
    */
    public static int MaximumSumSubarrayExp(int[] A){
        int sumOverA = 0;
        foreach(int x in A)sumOverA += x;
        return MaximumSumSubarrayExp(0,A.Length-1,A,sumOverA);
    }
    //Time complexity O(2 ^ n), can be improved to n^2 by memoization on l and r.
    static int MaximumSumSubarrayExp(int l,int r,int[] A,int currentSum){
        if(l == r)return A[l];//Sigle element
        int SumL = MaximumSumSubarrayExp(l,r-1,A,currentSum - A[r]);//All elements except the last
        int SumR = MaximumSumSubarrayExp(l+1,r,A,currentSum - A[l]);//All elements except the first
        return Math.Max(Math.Max(SumL,SumR),currentSum);
    }
}