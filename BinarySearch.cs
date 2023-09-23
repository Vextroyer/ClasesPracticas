/*
Given a sorted array of integers A and a integer X, output the position
on A where X is found or -1 is X is not in the array.
*/
static class BinarySearch{
    public static int BinSearch(int[] A,int X){
        return RecursiveBinarySearch(0,A.Length - 1,A,X);
    }
    //Left and right delimit a subarray of A
    static int RecursiveBinarySearch(int left, int right, int[] A, int X){
        if(left > right)return -1;
        if(left == right){
            if(A[left] == X)return left;
            return -1;
        }
        
        int middle = (left + right) / 2;
        
        if(A[middle] < X)return RecursiveBinarySearch(middle + 1,right,A,X);
        
        if(A[middle] > X)return RecursiveBinarySearch(left,middle - 1,A,X);
        
        return middle;
    }
}
/*
On some places i have seen this:
    left + (right - left) / 2;
In order to prevent overflow.

Those are mathematically the same.

left + (right -left) / 2 = (2left + right - left) / 2 = (left + right) / 2
*/