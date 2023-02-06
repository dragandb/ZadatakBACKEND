namespace ZadatakAPI.Core
{
    public interface IRepositoryWrapper
    {
        IKupacRepository Kupac { get; }
        IProizvodRepository Proizvod { get; }
        IRacunRepository Racun { get; }
        IStavkaRepository Stavka { get; }
        void Save();
    }
}
