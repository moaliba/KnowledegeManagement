namespace ReadModels
{
    public class PageCounter
    {
        public int Number { get; set; }
        public int Size { get; set; }
        public int TotalCount { get; set; }

        public PageCounter(int number,int size,int totalCount)
        {
            Number = number;
            Size = size;
            TotalCount = totalCount;
        }
    }
}