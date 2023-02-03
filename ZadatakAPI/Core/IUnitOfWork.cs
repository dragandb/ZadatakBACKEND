namespace ZadatakAPI.Core
{
    public interface IUnitOfWork
    {
        IKupacRepository Kupci { get; }

        IProizvodRepository Proizvodi { get; }

        Task CompleteAsync();
    }
}
