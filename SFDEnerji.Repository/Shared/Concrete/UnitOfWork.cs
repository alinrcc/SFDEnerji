using SFDEnerji.Data;
using SFDEnerji.Models;
using SFDEnerji.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFDEnerji.Repository.Shared.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<AppUser> Users { get; private set; }

        public IRepository<Page> Pages { get; private set; }

        public IRepository<ContactForm> ContactForms { get; private set; }

        public IRepository<Meta> Metas { get; private set; }

        public IRepository<Picture> Pictures { get; private set; }

        public IRepository<Project> Projects { get; private set; }

        public IRepository<Service> Services { get; private set; }

        public IRepository<Setting> Settings { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users= new Repository<AppUser>(_context);
            Pages= new Repository<Page>(_context);
            ContactForms= new Repository<ContactForm>(_context);
            Metas= new Repository<Meta>(_context);
            Pictures= new Repository<Picture>(_context);
            Projects= new Repository<Project>(_context);
            Services= new Repository<Service>(_context);
            Settings= new Repository<Setting>(_context);
        }




        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
