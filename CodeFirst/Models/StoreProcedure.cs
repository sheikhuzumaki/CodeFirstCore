using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class StoreProcedure
    {
        
            public int Id { get; set; }
            public string Name { get; set; }
            public Guid Guid { get; set; }
        
    }
}
