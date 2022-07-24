using AutoMapper;
using BusinessLayer;
using DtoLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rezMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rezMvc.Controllers
{
    public class PlaceController : Controller
    {

        PlaceBL _placeBL;
        UsrBl _userBL;
        IMapper _mapper;
        public PlaceController(PlaceBL PlaceBL, UsrBl userBL, IMapper mapper)
        {
            _placeBL = PlaceBL;
            _userBL = userBL;
            _mapper = mapper;
        }
        
        // GET: UsrController
        public ActionResult Index()
        {
            List<PlaceDto> res = _placeBL.List();
            List<PlaceViewModel> model = _mapper.Map<List<PlaceViewModel>>(res);
            return View(model);
        }

        // GET: UsrController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsrController/Create
        public ActionResult Create()
        {
            PlaceViewModel model = new PlaceViewModel();
            model.Users = _mapper.Map<List<RezUserViewModel>>(_userBL.List());
            return View(model);
        }

        // POST: UsrController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaceViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

           var usrDto = _mapper.Map<PlaceDto>(model);
            _placeBL.Create(usrDto);

            return RedirectToAction(nameof(Index));
           

        }

        // GET: UsrController/Edit/5
        public ActionResult Edit(int id)
        {
            var userDto = _placeBL.Get(id);
            var model= _mapper.Map<PlaceViewModel>(userDto);
            model.Users = _mapper.Map<List<RezUserViewModel>>(_userBL.List());
            return View(model);
        }

        // POST: UsrController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlaceViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usrDto = _mapper.Map<PlaceDto>(model);
            _placeBL.Update(usrDto);

            return RedirectToAction(nameof(Index));
        }

        // GET: UsrController/Delete/5
        public ActionResult Delete(int id)
        {
            var userDto = _placeBL.Get(id);
            var model = _mapper.Map<PlaceViewModel>(userDto);
            return View(model);
        }

        // POST: UsrController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,IFormCollection col)
        {
            _placeBL.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
