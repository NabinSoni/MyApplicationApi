using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Dtos
{
    public class AuthorReadDTO
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
