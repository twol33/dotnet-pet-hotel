using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetAll() 
        {
            return _context.PetOwners;
        }

        [HttpGet("{id}")]
        public PetOwner GetById(int id )
        {
            return _context.PetOwners
                .SingleOrDefault(petowner => petowner.id == id );
        }

        [HttpPost]
        public PetOwner Post(PetOwner petOwners)
        {
            _context.Add(petOwners);
            _context.SaveChanges();

            return petOwners;
        }
        

        [HttpPut("{id}")]
        public PetOwner Put( int id, PetOwner petOwners)
        {
            petOwners.id = id;
            _context.Add(petOwners);
            _context.SaveChanges();

            return petOwners;
        }

        [HttpDelete("{id}")]
        public void Delete( int id )
        {
            PetOwner petOwners = _context.PetOwners.Find(id);
            _context.PetOwners.Remove(petOwners);
            _context.SaveChanges();
        }

    }
}
