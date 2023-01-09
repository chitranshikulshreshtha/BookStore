using BookManagement.Controllers;
using BookManagement.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Manager.Interfaces
{
    public interface IBookStoreManager
    {
       public void SetIds(string UserId, string FarmId, string token = null, string prefferedLanguage = null);
        Task<ResponseModel<string>> AddBook(BookStoreModelDto model);
        Task<ResponseModel<string>> RemoveBook(BookStoreModelDto model);

        Task<ResponseModel<string>> IssueBook(string BookId);
        Task<ResponseModel<string>> RemoveBook(string bookId);
    }
}
