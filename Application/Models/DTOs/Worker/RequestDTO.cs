using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.Worker
{
    public class RequestDTO
    {
        public string Id { get; set; }
        public string UserMail { get; set; }
        public string Message { get; set; }
    }
}
