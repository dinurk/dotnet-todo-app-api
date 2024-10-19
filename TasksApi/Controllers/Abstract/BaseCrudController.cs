using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Exceptions;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Controllers.Abstract
{
    public class BaseCrudController<TEntity, TDto, TCreateDto, TUpdateDto, TQueryParams>
        : ControllerBase
        where TEntity : BaseEntity
        where TUpdateDto : BaseEntity
    {
        protected readonly ICrudService<TEntity> _service;
        protected readonly IMapper _mapper;

        public BaseCrudController(ICrudService<TEntity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public virtual async Task<IActionResult> GetAll([FromQuery] TQueryParams queryParams)
        {
            var entries = await _service.GetAllAsync();
            return Ok(
                entries.Select(entry => _mapper.Map<TDto>(entry))
            );
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entry = await _service.GetByIdAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TDto>(entry));
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TCreateDto newEntryDto)
        {
            var newEntry = await _service.CreateAsync(_mapper.Map<TEntity>(newEntryDto));

            return CreatedAtAction(
                nameof(Post),
                new { id = newEntry.Id },
                _mapper.Map<TDto>(newEntry)
            );
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TUpdateDto entryDto)
        {
            if (id != entryDto.Id)
            {
                return BadRequest();
            }

            try
            {
                var entry = _mapper.Map<TEntity>(entryDto);
                var updatedEntry = await _service.UpdateAsync(entry);
                return Ok(_mapper.Map<TDto>(updatedEntry));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }

        public TService GetService<TService>()
            where TService : BaseCrudService<TEntity>
        {
            return _service as TService;
        }
    }
}
