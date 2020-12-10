namespace DemoCode
{
    public class Calculator
    {
        public int Value { get; private set; }

        public void Add(in int number)
        {
            Value += number;
        }
    }
}
