namespace ZadatakAPI.Core
{
    public interface IUnitOfWork
    {
        IKupacRepository Kupci { get; }

        IProizvodRepository Proizvodi { get; }

        IRacunRepository Racuni { get; }

        IStavkaRepository Stavke { get; }

        Task CompleteAsync();
    }
}
