using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mapers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
       // private readonly ApplicationDBContext _context;//con esta variable interactuamos con la base de datos
        private readonly IStockRepository _stockRepo;//con esta variables accedemos a los metodos que tiene la interfaz
        //constructor recibe un contexto de la base de datos
        public  StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
          ///  _context = context;
        }
        //PUSIMOS TODA LAS ACCIONES QUE INTERACTUEN CON LA BASE DE DATOS EN STOCKREPOSITOTY
        //acciones https

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //accedemos al modelo y nos traemos todos los datos, el codigo esta IStockRepository
            var stocks = await _stockRepo.GetAllAsync(query);
            var stockDto = stocks.Select(s=>s.ToStockDto());
             return Ok(stocks);
        }

         //metodo para obtener un solo registro, le decimos que el parametro lo va a tomar desde la url
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await  _stockRepo.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }   

        //crear un nuevo elemento, la informacion la toma desde el cuerpo de la solicitus
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = stockDto.ToStockFromCreateDTO();
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById),new{id = stockModel.Id},stockModel.ToStockDto());
        }    

        //actualizar elemento, toma desde la url y desde el cuerpo los datosn que necesita
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id , [FromBody] UpdateStockRequestDto updateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await  _stockRepo.UpdateAsync(id, updateDto);
            if (stockModel == null)
            {
                return NotFound();
            }
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _stockRepo.DeteleAsync(id);
            if(stockModel == null)
            {
                return NotFound();
            }
            return NoContent();

        }

    }
}