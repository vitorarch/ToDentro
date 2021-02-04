using API.Models.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Advertisements
{
    public interface IAdvertisementRepository
    {
        public IEnumerable<Advertisement> GetAdvertisements();
        public IEnumerable<Advertisement> GetAdvertisementsByCompany(string companyId);
        public Task<Advertisement> GetAdvertisementById(string id);
        public Task<dynamic> AddAdvertisement(Advertisement advertisement, string companyId);
        public Task<Advertisement> EditAdvertisement(Advertisement advertisement);
        public Task<bool> DeleteAdvertisement(Guid id);
    }
}
