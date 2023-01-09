using BookManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    public class ResponseModel<T>
    {
        public ResponseStatus status { get; internal set; }
        public string Data { get; internal set;}
    }
}
