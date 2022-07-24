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
    public class UsrController : Controller
    {

        UsrBl _usrBl;
        IMapper _mapper;
        public UsrController(UsrBl usrBl, IMapper mapper)
        {
            _usrBl = usrBl;
            _mapper = mapper;
        }
        
        // GET: UsrController
        public ActionResult Index()
        {
            List<RezUserDto> res = _usrBl.List();
            List<RezUserViewModel> model = _mapper.Map<List<RezUserViewModel>>(res);
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
            RezUserViewModel model = new RezUserViewModel();
            return View(model);
        }

        // POST: UsrController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RezUserViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

           var usrDto = _mapper.Map<RezUserDto>(model);
            _usrBl.Create(usrDto);

            return RedirectToAction(nameof(Index));
           

        }

        // GET: UsrController/Edit/5
        public ActionResult Edit(int id)
        {
            var userDto = _usrBl.Get(id);
            var model= _mapper.Map<RezUserViewModel>(userDto);
            model.PasswordCheck = model.Password;
            return View(model);
        }

        // POST: UsrController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RezUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usrDto = _mapper.Map<RezUserDto>(model);
            _usrBl.Update(usrDto);

            return RedirectToAction(nameof(Index));
        }

        // GET: UsrController/Delete/5
        public ActionResult Delete(int id)
        {
            var userDto = _usrBl.Get(id);
            var model = _mapper.Map<RezUserViewModel>(userDto);
            model.PasswordCheck = model.Password;
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
