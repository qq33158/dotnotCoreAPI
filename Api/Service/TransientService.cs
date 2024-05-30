namespace Api.Service
{
    public class TransientService
    {
        public int count = 0;

        public void CountAddOne()
        {
            count = count + 1;
        }
    }
}
