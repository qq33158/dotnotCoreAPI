namespace Api.Service
{
    public class SingletonService
    {
        public int count = 0;

        public void CountAddOne()
        {
            count = count + 1;
        }
    }
}
