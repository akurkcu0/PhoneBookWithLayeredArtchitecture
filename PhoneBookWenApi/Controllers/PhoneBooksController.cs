using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis.Generic;
using ServiceStack.Redis;
using Business.Abstract;
using Entities.Concrete;

namespace PhoneBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBooksController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;
        private readonly IMapper _mapper;

        public PhoneBooksController(IPhoneBookService phoneBookService, IMapper mapper)
        {
            _phoneBookService = phoneBookService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            List<PhoneBook> phoneBooksList = GetCache<List<PhoneBook>>("phoneBooks");
            var result = _phoneBookService.GetAll();
            if (result.IsSuccess)
            {
                SetCache<List<PhoneBook>>("phoneBooks", phoneBooksList);
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(PhoneBook phoneBook)
        {
            if (phoneBook == null) return BadRequest();
            PhoneBook phoneBooks = _mapper.Map<PhoneBook>(phoneBook);

            var result = _phoneBookService.Add(phoneBooks);
            if (result.IsSuccess)
            {
                RemoveCache<List<PhoneBook>>("phoneBooks");
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Put(PhoneBook phoneBook)
        {
            var result = _phoneBookService.Update(phoneBook);
            if (result.IsSuccess)
            {
                RemoveCache<List<PhoneBook>>("phoneBooks");
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(PhoneBook phoneBook)
        {
            var result = _phoneBookService.Delete(phoneBook);
            if (result.IsSuccess)
            {
                RemoveCache<List<PhoneBook>>("phoneBooks");
                return Ok(result);
            }
            return BadRequest(result);
        }



        T GetCache<T>(string key)
        {
            var redisclient = new RedisClient("localhost", 6379);
            IRedisTypedClient<List<PhoneBook>> phoneBooks = redisclient.As<List<PhoneBook>>();

            return redisclient.Get<T>(key);
        }

        void SetCache<T>(string key, T value)
        {
            var redisclient = new RedisClient("localhost", 6379);
            IRedisTypedClient<List<PhoneBook>> phoneBooks = redisclient.As<List<PhoneBook>>();

            redisclient.Set<T>(key, value);
        }

        void RemoveCache<T>(string key)
        {
            var redisclient = new RedisClient("localhost", 6379);
            IRedisTypedClient<T> phoneBooks = redisclient.As<T>();

            redisclient.Remove(key);
        }

    }
}
