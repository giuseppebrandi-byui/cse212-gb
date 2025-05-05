public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // MY COMMENTS: 
        // 1 - Create an empty array to store the multiples
        // 2 - Implement a for loop 
        // 3 - Add the multiples to the array the computation of number * i
        // 4  - Return array
        var multiples = new double[length];
        for (var i = 1; i <= length; i++)
        {
            multiples[i - 1] = number * i;
        }
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // MY COMMENTS: 
        // 1 - Create a dataHeadData list with the range of data (e.g. data.GetRange(0, data.Count - amount))
        // 2 - Create a dataTailData list with the slice (e.g. data.Count - amount, amount)
        // 3 - Empty the list by using Clear()
        // 4 - Add the dataTailData and dataHeadData to the data list.
        List<int> dataHeadData = data.GetRange(0, data.Count - amount);
        List<int> dataTailData = data.GetRange(data.Count - amount, amount);
        data.Clear();
        data.AddRange(dataTailData);
        data.AddRange(dataHeadData);
    }
}
