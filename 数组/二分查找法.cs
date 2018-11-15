public static int BinarySearch ( int[] array,int target ) {
    List<int> list = array.ToList();
    list.Sort ();
    array = list.ToArray ();
    int l = 0;
    int r = array.Length - 1;//在[l...r]的范围里寻找target
    while ( l <= r ) {//当l == r 时，区间[l...r]依然是有效的
        int mid = l + (r-l)/2;
        if ( array[mid] == target ) {
            return mid;
        }
        if ( array[mid] < target ) {
            l = mid + 1;
        }
        else {
            r = mid - 1;
        }
    }
    return -1;
}