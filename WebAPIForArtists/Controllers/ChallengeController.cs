using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIForArtists.Data;
using WebAPIForArtists.Interfaces;
using WebAPIForArtists.Models;
using WebAPIForArtists.Repository;
using WebAPIForArtists.Services;
using WebAPIForArtists.ViewModels;

namespace WebAPIForArtists.Controllers
{
    public class ChallengeController : Controller
    {
        private readonly IChallengeRepository _challengeRepository;
        private readonly IPhotoService _photoService;
        public ChallengeController(ApplicationDbContext context, IChallengeRepository challengeRepository, IPhotoService photoService)
        {
            _challengeRepository = challengeRepository;
            _photoService = photoService;
            
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Challenge> challeneges = await _challengeRepository.GetAll();
            return View(challeneges);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Challenge challenege = await _challengeRepository.GetByIdAsync(id);
            return View(challenege);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChallengeViewModel challengeVM)
        {
            
                if (ModelState.IsValid)
                {
                    var result = await _photoService.AddPhotoAsync(challengeVM.Image);

                    var challenge = new Challenge
                    {
                        Title = challengeVM.Title,
                        Description = challengeVM.Description,
                        Image = result.Url.ToString(),

                        
                    };
                    _challengeRepository.Add(challenge);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Photo upload Failed");
                }

                return View(challengeVM);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var challenge = await _challengeRepository.GetByIdAsync(id);
            if (challenge == null) return View("Error");
            var challengeVM = new EditChallengeViewModel
            {
                Title = challenge.Title,
                Description = challenge.Description,
              
                URL = challenge.Image,
                Category = challenge.Category,
            };

            return View(challengeVM);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditChallengeViewModel challengeVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", challengeVM);
            }

            var userChallenge = await _challengeRepository.GetByIdAsyncNoTracking(id);

            if (userChallenge != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userChallenge.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(challengeVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(challengeVM.Image);

                var challenge = new Challenge
                {
                    Id = id,
                    Title = challengeVM.Title,
                    Description = challengeVM.Description,
                    Image = photoResult.Url.ToString(),
                  

                };

                _challengeRepository.Update(challenge);

                return RedirectToAction("Index");
            }
            else
            {
                return View(challengeVM);
            }
        }

    }
}
