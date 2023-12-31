using Enitiy_framework_with_Swagger_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enitiy_framework_with_Swagger_API.Context
{
    public class CRUDContext : DbContext 
    {


        public  CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {



        
        }
            
            
            


        public DbSet<Student> students { get; set; }

            
            
     }
}
