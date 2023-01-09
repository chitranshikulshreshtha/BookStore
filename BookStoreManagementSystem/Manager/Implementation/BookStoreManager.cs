using AutoMapper;
using BookManagement.BusinessModels;
using BookManagement.Controllers;
using BookManagement.DBModels;
using BookManagement.Dto;
using BookManagement.Manager.Interfaces;
using BookManagement.Managers.Interfaces;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BookManagement.Manager.Implementation
{
    public class BookStoreManager : IBookStoreManager
    {
        private string _userId;
        private string _farmId;
        private string _token;
        private string _prefferedLanguage;
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;
        // private readonly ILogManager _logger;
        private readonly ApplicationSettings _applicationsettings;
        private object _returnMessage;
        public BookStoreManager(IDbConnectionManager dbConectionManager, IMapper mapper, IOptions<ApplicationSettings> appSetting)
        {
            _database = dbConectionManager.GetDatabase();
            _mapper = mapper;
            _applicationsettings = appSetting.Value;
        }
        public void SetIds(string UserId, string token = null, string prefferedLanguage = null)
        {
            _userId = UserId;
            _token = token;
            _prefferedLanguage = prefferedLanguage;
        }
        public async Task<ResponseModel<string>> AddBook(BookStoreModelDto model)
        {
            {
                ResponseModel<string> responseModel = new ResponseModel<string>();
                bool SuccessFlag = true;
                try
                {
                    //  await AddBook(model.CattleId);
                    IMongoCollection<BookStoreModel> collection = _database.GetCollection<BookStoreModel>("book");
                    var filter = new BsonDocument("UserId", _userId);
                    BookStoreModel existingFodder = await collection.Find(filter).FirstOrDefaultAsync();
                    if (existingFodder == null)
                    {
                        BookStoreModel bookStoreModel = new BookStoreModel();
                        bookStoreModel = _mapper.Map<BookStoreModel>(model);
                        bookStoreModel.ADD(_userId);
                        await collection.InsertOneAsync(bookStoreModel);
                        responseModel.Data = " book Added Successfully";
                    }
                    _returnMessage = responseModel;
                    return responseModel;
                }
                catch (System.Exception ex)
                {
                    SuccessFlag = false;
                    _returnMessage = ex.Message;
                    throw;
                }

            }
        }
        public void SetIds(string UserId, string FarmId, string token, string prefferedLanguage)
        {
            _userId = UserId;
            _token = token;
            _prefferedLanguage = prefferedLanguage;
        }





        Task<ResponseModel<string>> IBookStoreManager.RemoveBook(BookStoreModelDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<string>> RemoveBook(string bookId)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            bool SuccessFlag = true;
            try
            {
                IMongoCollection<BookStoreModel> collection = _database.GetCollection<BookStoreModel>("book");
                var filter = Builders<BookStoreModel>.Filter.Eq(x => x.UserId, _userId);
                var isActiveFilter = Builders<BookStoreModel>.Filter.Eq(x => x.IsActive, true);
                var filters = Builders<BookStoreModel>.Filter.And(filter, isActiveFilter);
                BookStoreModel existingDiet = await collection.Find(filters).FirstOrDefaultAsync();
                if (existingDiet != null)
                {
                    existingDiet.IsActive = false;
                    existingDiet.InActiveDateTime = DateTime.UtcNow.ToString();
                    _ = await collection.ReplaceOneAsync(filters, existingDiet);
                    responseModel.Data = "Book Removed Succesfully";
                }
                _returnMessage = responseModel;
                return responseModel;
            }
            catch (System.Exception ex)
            {
                SuccessFlag = false;
                _returnMessage = ex.Message;
                throw;
            }

        }

        Task<ResponseModel<string>> IBookStoreManager.IssueBook(string BookId)
        {
            throw new NotImplementedException();
        }
    }
}
