namespace _932220.titarenko.nikita.lab11.Services
{
    public class CalcService: ICalcService
    {
        public int add(int a, int b)
        {
            return a + b;
        }
        public int sub(int a, int b)
        {
            return a - b;
        }
        public int mult(int a, int b)
        {
            return a * b;
        }
        public string div(int a, int b)
        {
            if (b != 0)
            {
                int temp = a / b;
                return temp.ToString();
            }
            else return "Нельзя делить на 0!";
        }
    }
}
