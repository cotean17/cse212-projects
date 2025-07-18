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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        //  1. Create a new array of type double with size equal to 'length'.
        //  2. Loop from 0 to length - 1.
        //  3. For each index i, calculate number * (i + 1).
        //  4. Store the result at index i of the array.
        //  5. Return the filled array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
       
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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Get the last 'amount' elements using GetRange.
        // 2. Get the remaining elements from the start up to (Count - amount).
        //  3. Clear the original list.
        //  4. Add the last 'amount' elements first.
        //  5. Add the rest after.
        List<int> rotated = new List<int>();
        int count = data.Count;

        rotated.AddRange(data.GetRange(count - amount, amount));
        rotated.AddRange(data.GetRange(0, count - amount));

        data.Clear();
        data.AddRange(rotated);

    }
}
