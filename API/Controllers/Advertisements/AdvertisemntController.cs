using API.Interfaces.Advertisements;
using API.Models.Advertisements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Advertisements
{

    [ApiController]
    [Authorize]
    [Route("/advertisements")]

    public class AdvertisementController : ControllerBase
    {

        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementController(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        [HttpGet("v1/all")]
        public IActionResult GetAdvertisements(string cpf)
        {
            var advertisements = _advertisementRepository.GetAdvertisements();

            if (advertisements == null) return BadRequest(new { error = "Anúncios não encontrados" });
            else return Ok(advertisements);
        }

        [HttpGet("v1/company")]
        public IActionResult GetAdvertisementByCompany(string companyId)
        {
            var advertisement = _advertisementRepository.GetAdvertisementsByCompany(companyId);

            if (advertisement == null) return BadRequest(new { error = "Anúncios não encontrados" });
            else return Ok(advertisement);
        }

        [HttpGet("v1")]
        public IActionResult GetAdvertisementById(string cpf)
        {
            var advertisement = _advertisementRepository.GetAdvertisementById(cpf);

            if (advertisement == null) return BadRequest(new { error = "Anúncio não encontrado" });
            else return Ok(advertisement);
        }

        [HttpPost("v1/add")]
        public async Task<IActionResult> AddAdvertisement([FromBody] Advertisement advertisement, string companyId)
        {
            var _advertisement = await _advertisementRepository.AddAdvertisement(advertisement, companyId);

            if (_advertisement is string) return BadRequest(new { error = "Anúncio não encontrado" });
            else return Ok(_advertisement);
        }

        [HttpPut("v1/edit")]
        public async Task<IActionResult> EditAdvertisement([FromBody] Advertisement advertisement)
        {
            var _advertisement = await _advertisementRepository.EditAdvertisement(advertisement);

            if (_advertisement == null) return BadRequest(new { error = "Anúncio não encontrado" });
            else return Ok(_advertisement);
        }

        [HttpDelete("v1/delete")]
        public async Task<IActionResult> DeleteAdvertisement([FromBody] Guid id)
        {
            var _advertisement = await _advertisementRepository.DeleteAdvertisement(id);

            if (_advertisement == false) return BadRequest(new { error = "Anúncio não encontrado" });
            else return Ok(_advertisement);
        }

    }
}
