﻿using ZadatakAPI.Data;
using ZadatakAPI.Models;

namespace ZadatakAPI.Core.Repositories
{
    public class ProizvodRepository : RepositoryBase<Proizvod>, IProizvodRepository
    {
        public ProizvodRepository(ZadatakAPIDBContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Proizvod> GetAllProizvod()
        {
            return FindAll().OrderBy(x => x.Id).ToList();
        }

        public Proizvod GetProizvodById(int Id)
        {
            return FindByCondition(x => x.Id.Equals(Id))
            .FirstOrDefault();
        }
        public Proizvod GetProizvodBySifra(string Sifra)
        {
            return FindByCondition(x => x.Sifra.Equals(Sifra))
            .FirstOrDefault();
        }

        public Proizvod GetProizvodByNaziv(string Naziv)
        {
            return FindByCondition(x => x.Naziv.Equals(Naziv))
            .FirstOrDefault();
        }

        public void CreateProizvod(Proizvod proizvod)
        {
            Create(proizvod);
        }

        public void UpdateProizvod(Proizvod proizvod)
        {
            Update(proizvod);
        }
        public void DeleteProizvod(Proizvod proizvod)
        {
            Delete(proizvod);
        }
    }
}
