using BookManagement.Dto;
using BookManagement.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookStoreController : ControllerBase
    {
        private readonly IBookStoreManager _BookStoreManger;

        public BookStoreController(IBookStoreManager BookStoreManger)
        {
            _BookStoreManger = BookStoreManger;
        }
        private string GetUserIdFromToken()
        {
            string userId = "";
            if (User != null && User.Claims != null && User.Claims.FirstOrDefault(c => c.Type == "userId ") != null)
            {
                userId = User.Claims.FirstOrDefault(c => c.Type == "userId ").Value;
            }
            return userId;
        }
        private string GetBookIdFromToken()
        {
            string userId = "";
            if (User != null && User.Claims != null && User.Claims.FirstOrDefault(c => c.Type == "userId ") != null)
            {
                userId = User.Claims.FirstOrDefault(c => c.Type == "userId ").Value;
            }
            return userId;
        }
       
        [HttpPost("AddBook")]
        public async Task<ResponseModel<string>> AddBook([FromBody] BookStoreModelDto model)
        {
            _BookStoreManger.SetIds(GetUserIdFromToken(), GetBookIdFromToken());
            return await _BookStoreManger.AddBook(model);
        }
        [HttpPost("RemoveBook")]
        public async Task<ResponseModel<string>> RemoveBook(BookStoreModelDto model)
        {
            _BookStoreManger.SetIds(GetUserIdFromToken(), GetBookIdFromToken());
            return await _BookStoreManger.RemoveBook(model);
        }


        [HttpPost("IssueBook")]
        public async Task<ResponseModel<string>> IssueBook(string model)
        {
            _BookStoreManger.SetIds(GetBookIdFromToken(), GetUserIdFromToken());
            return await _BookStoreManger.IssueBook(model);
        }

    }
}
