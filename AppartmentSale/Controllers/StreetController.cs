﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Data;
using PagedList;
using PagedList.Mvc;

namespace AppartmentSale.Controllers
{
    /// <summary>
    /// Контроллер для работы с сущностью "Улица"
    /// </summary>
    public class StreetController : Controller
    {
        private static int _pageSize = 6;
        private readonly IStreetRepository streetRepository;
        private readonly IAreaRepository areaRepository;
        public StreetController(IStreetRepository streetRepository)
        {
            this.streetRepository = streetRepository;
        }

        /// <summary>
        /// Генерация индексной страницы с улицей
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var listAreas = areaRepository.GetAll().ToList().ToPagedList(pageNumber, _pageSize);
            return View(listAreas);
        }
    }
}