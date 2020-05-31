﻿using CineMagic.Facade.Models.Seat;
using CineMagic.Facade.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineMagic.Controllers
{
    public class ReservationsController : Controller
    {
        private IMoviesRepository _moviesRepository;
        private IProjectionsRespository _projectionsRepository;
        private IAvailableSeatsRepository _availableSeatsRepository;

        public ReservationsController(IMoviesRepository moviesRepository, IProjectionsRespository projectionsRepository, IAvailableSeatsRepository availableSeatsRepository)
        {
            this._moviesRepository = moviesRepository;
            this._projectionsRepository = projectionsRepository;
            this._availableSeatsRepository = availableSeatsRepository;
        }

        public async Task<IActionResult> MakeReservation(AvailableSeatGetDetailsReq req)
        {
            AvailableSeatGetDetailsRes availableSeatGetDetailsRes = await _availableSeatsRepository.GetAvailableSeatDetails(req);
            return View(availableSeatGetDetailsRes);
        }
    }
}