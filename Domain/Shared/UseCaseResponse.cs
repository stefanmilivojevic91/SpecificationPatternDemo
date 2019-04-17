namespace Domain.Shared
{
    public class UseCaseResponse
    {
        private UseCaseResponse()
        {

        }

        public static UseCaseResponse Null()
        {
            return new UseCaseResponse();
        }
    }
}
