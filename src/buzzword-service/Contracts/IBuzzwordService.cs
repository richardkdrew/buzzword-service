namespace BuzzwordService.Contracts
{
    public interface IBuzzwordService
    {
        BuzzwordServiceResponse GetBuzzwords(BuzzwordServiceRequest request);
    }    
}