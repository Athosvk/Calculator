namespace CalculatorInternals
{
    public static class Operations
    {
        public static int Add(int a_First, int a_Second)
        {
            return a_First + a_Second;
        }

        public static decimal Add(decimal a_First, decimal a_Second)
        {
            return a_First + a_Second;
        }

        public static int Subtract(int a_SubtractedFrom, int a_ToSubtract)
        {
            return a_SubtractedFrom - a_ToSubtract;
        }

        public static decimal Subtract(decimal a_First, decimal a_Second)
        {
            return a_First - a_Second;
        }
    }
}