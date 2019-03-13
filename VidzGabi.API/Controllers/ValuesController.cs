using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidzGabi.API.Data;
using VidzGabi.API.Models;

namespace VidzGabi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
         {
            _context = context;
        }
        // GET http://localhost:5000/api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
          //var sArray = new string[] { "Gabriela", "Lourenco","OI" };
            //return sArray;
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET http://localhost:5000/api/values
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
           // var sArray = new string[]{ "Gabriela", "Lourenco","OI" };
           // if (id > (sArray.Length - 1))
           // return "O valor digitado é maior do que o disponivel";

          //  return sArray[id];
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostValue(Value value)
        {
            _context.Values.Add(value);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
