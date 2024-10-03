using MusicStore.Domain.Domain;
using MusicStore.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repository.Interface
{
    public interface IUserRepository
    {
        EShopApplicationUser Get(string id);
        IEnumerable<EShopApplicationUser> GetAll();
        void Insert(EShopApplicationUser entity);
        void Update(EShopApplicationUser entity);
        void Delete(EShopApplicationUser entity);
    }
}
