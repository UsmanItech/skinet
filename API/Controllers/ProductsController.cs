using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public StoreContext _context { get; }
        public ProductsController(StoreContext context)
        {
            _context = context;            
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>>  GET(){
            return await _context.Products.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GET(int id){
            return  await _context.Products.SingleOrDefaultAsync(p=>p.Id==id);
        }
    }
}