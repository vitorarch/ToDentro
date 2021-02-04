using API.DataAccess;
using API.Interfaces.Advertisements;
using API.Models.Advertisements;
using API.Validation.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Advertisements
{
    public class AdvertisementRepository : IAdvertisementRepository
    {

        private readonly ToDentroContext _context;
        private readonly AdvertisementValidator _advertisementValidator;

        public AdvertisementRepository(ToDentroContext context)
        {
            _context = context;
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            var advertisementList = _context.Advertisements.Where(a => a.Active.Equals(true)).ToList();
            return advertisementList;
        }

        public IEnumerable<Advertisement> GetAdvertisementsByCompany(string companyId)
        {

            if (companyId == null) return null;
            else
            {
                var advertisement = _context.Advertisements.Where(a => a.CompanyId == companyId).ToList();
                return advertisement;
            }
        }

        public async Task<Advertisement> GetAdvertisementById(string id)
        {
            if (id == null) return null;
            else
            {
                var advertisement = await _context.Advertisements.FindAsync(id);
                return advertisement;
            }
        }

        public async Task<dynamic> AddAdvertisement(Advertisement advertisement, string companyId)
        {
            advertisement.CompanyId = companyId;

            var result = await _advertisementValidator.ValidateAsync(advertisement);
            if (result.IsValid)
            {
                await _context.Advertisements.AddAsync(advertisement);
                await _context.SaveChangesAsync();
                return advertisement;
            }
            else return result.Errors[0].ErrorMessage;
        }

        public async Task<Advertisement> EditAdvertisement(Advertisement advertisement)
        {
            if (advertisement == null) return null;
            else
            {
                var _advertisement = await _context.Advertisements.FindAsync(advertisement.Id);
                _advertisement = advertisement;

                _context.Entry(_advertisement).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return advertisement;
            }
        }

        public async Task<bool> DeleteAdvertisement(Guid id)
        {
            if (id == null) return false;
            else
            {
                var advertisement = await _context.Advertisements.FindAsync(id);
                _context.Advertisements.Remove(advertisement);
                await _context.SaveChangesAsync();
                return true;
            }
        }

    }
}
