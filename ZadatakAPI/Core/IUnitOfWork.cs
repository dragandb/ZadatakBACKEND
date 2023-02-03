namespace ZadatakAPI.Core
{
    public interface IUnitOfWork
    {
        IKupacRepository Kupci { get; }

        Task CompletyAsync();
    }
}
