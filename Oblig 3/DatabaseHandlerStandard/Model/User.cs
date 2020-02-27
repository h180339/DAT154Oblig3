using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseHandlerStandard.Model
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}