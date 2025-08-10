public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
      // Reject duplicates to keep values unique
    if (value == Data) return;

    if (value < Data)
    {
        if (Left is null) Left = new Node(value);
        else Left.Insert(value);
    }
    else // value > Data
    {
        if (Right is null) Right = new Node(value);
        else Right.Insert(value);
    }
    }

   public bool Contains(int value)
{
    if (value == Data) return true;

    if (value < Data)
        return Left is not null && Left.Contains(value);
    else // value > Data
        return Right is not null && Right.Contains(value);
}


    public int GetHeight()
    {
        int left  = Left  is null ? 0 : Left.GetHeight();
        int right = Right is null ? 0 : Right.GetHeight();
        return 1 + Math.Max(left, right);
    }
}