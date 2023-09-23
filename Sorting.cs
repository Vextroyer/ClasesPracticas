/*
Different sorting algorithms.
*/
static class Sort{
    public static void MergeSort(int[] A){
        MergeSort(0,A.Length,A);
    }
    //[l,r) l is included but r is not.
    static void MergeSort(int l,int r,int[] A){
        if(r - l == 1){//SIngle element array, already sorted
            return;
        }
        int m = (l + r) / 2;
        MergeSort(l,m,A);//Sort left part
        MergeSort(m,r,A);//Sort right part
        //Merge
        int[] aux = new int[r - l];//For storing the values
        int lp = l;//Pointer of the left part
        int rp = m;//Pointer of the right part
        int nextp = 0;//Pointer to the next element at the array aux.
        while(lp < m && rp < r){
            if(A[lp] < A[rp]){
                aux[nextp] = A[lp];
                ++lp;
            }else{
                aux[nextp] = A[rp];
                ++rp;
            }
            ++nextp;
        }
        while(lp < m){
            aux[nextp] = A[lp];
            ++lp;
            ++nextp;
        }
        while(rp < r){
            aux[nextp] = A[rp];
            ++rp;
            ++nextp;
        }

        //Put sorted aux array content onto A array
        for(int i=l;i<r;++i){
            A[i] = aux[i - l];
        }
    }

    public static void QuickSort(int[] A){
        QuickSort(0,A.Length,A);
    }
    //[l,r) l is included but r is not
    static void QuickSort(int l,int r,int[] A){
        if(r - l <= 1)return;

        int pivotValue = A[l];//Select the pivot
        //element on the array A.
        
        int pivotPos = Partition(l,r,pivotValue,A);

        QuickSort(l,pivotPos,A);
        QuickSort(pivotPos+1,r,A);
    }
    //Put all elements lower than or equal to pivot to its left and all the elements grater than
    //pivot to its right, the return its position on the array.
    static int Partition(int l,int r,int pivotValue,int[] A){
        //The pivot is at position l
        int nLess = 0;//The amount of elements less than pivot
        for(int i=l;i<r;++i){
            if(A[i] < pivotValue)++nLess;
        }   
        int nGreaterEqual = r - l - nLess;//The amount of elements greater than pivot

        int[] lessElements = new int[nLess];//The elements less than pivot
        int[] greaterEqualElements = new int[nGreaterEqual];//The elements greater than pivot

        //Put the elements of A on their corresponding arrays
        for(int i=l, posLess = 0,posGreaterEqual = 0;i<r;++i){
            if(A[i] < pivotValue)lessElements[posLess++] = A[i];
            else greaterEqualElements[posGreaterEqual++] = A[i];
        }

        //Reorder A puting the elements less tha pivot to the left and
        //the elements greater than pivot to the right
        for(int i=l, index = 0;i<r;++i,++index){
            if(index < nLess)A[i] = lessElements[index];
            else A[i] = greaterEqualElements[index - nLess];
        }

        //Pivot is the first element of the greaterEqualElements array
        return l + nLess;
    }
}
