namespace ZadatakAPI.Core
{
    public interface IRepositoryWrapper
    {
        IKupacRepository Kupac { get; }
        IProizvodRepository Proizvod { get; }

        void Save();
    }
}
