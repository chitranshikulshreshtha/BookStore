using BookManagement.DBModels;
using FoolProof.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Dto
{
    public class BookStoreModelDto
    {
        //[Required] public string BookId { get; set; }
        //[Required] 
        // public bool IsGroup { get; set; }
        // [RequiredIfFalse("IsGroup" , ErrorMessage="BookId are Required")] 
        // public string CattleId { get; set; }
        // [Range(1, 100, ErrorMessage = "Price must be between $1 and $100")]
        // public int Price { get; set; }

        // public int PublicationDate { get; set; }

        // public bool IsActive { get; set; }
        // public string ActiveDateTime { get; set; }
        // public string InActiveDateTime { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int BookId { get; set; }
        public string BookName { get; set; }
        [Range(1, 100, ErrorMessage = "Price must be between $1 and $100")]
        public int Price { get; set; }
        public int PublicationDate { get; set; }
        //public bool IsActive { get; set; }
        public string ActiveDateTime { get; set; }
        public string InActiveDateTime { get; set; }
    }
}
