namespace PlainClasses.Domain.Utils.Extensions
{
    public static class PersonalNumberExtension
    {
        public static bool IsPersonalNumberValid(this string input)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            
            if (input.Length != 11) 
                return false;
            
            var controlSum = CalculateControlSum(input, weights);
            var controlNum = controlSum % 10;
            controlNum = 10 - controlNum;
            
            if (controlNum == 10)
            {
                controlNum = 0;
            }
            
            var lastDigit = int.Parse(input[^1].ToString());
            return controlNum == lastDigit;
        }

        private static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            var controlSum = 0;
            
            for (var i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            
            return controlSum;
        }
    }
}