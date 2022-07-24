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
    public class RghtController : Controller
    {

        RezRightBL _usrBl;
        IMapper _mapper;
        public RghtController(RezRightBL usrBl, IMapper mapper)
        {
            _usrBl = usrBl;
            _mapper = mapper;
        }
        
        // GET: UsrController
        public ActionResult Index()
        {
            List<RezRightDto> res = _usrBl.List();
            List<RezRightViewModel> model = _mapper.Map<List<RezRightViewModel>>(res);
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
            RezRightViewModel model = new RezRightViewModel();
            return View(model);
        }

        // POST: UsrController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RezRightViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

           var usrDto = _mapper.Map<RezRightDto>(model);
            _usrBl.Create(usrDto);

            return RedirectToAction(nameof(Index));
           

        }

        // GET: UsrController/Edit/5
        public ActionResult Edit(int id)
        {
            var userDto = _usrBl.Get(id);
            var model= _mapper.Map<RezRightViewModel>(userDto);
            return View(model);
        }

        // POST: UsrController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RezRightViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usrDto = _mapper.Map<RezRightDto>(model);
            _usrBl.Update(usrDto);

            return RedirectToAction(nameof(Index));
        }

        // GET: UsrController/Delete/5
        public ActionResult Delete(int id)
        {
            var userDto = _usrBl.Get(id);
            var model = _mapper.Map<RezRightViewModel>(userDto);
            return View(model);
        }

        // POST: UsrController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,IFormCollection col)
        {
            _usrBl.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
