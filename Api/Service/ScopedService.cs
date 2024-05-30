namespace Api.Service
{
    public class ScopedService
    {
        public int count = 0;

        public void CountAddOne()
        {
            count = count + 1;
        }
    }
}
