using Customer.Application.Shared.Common.Interfaces;
using Customer.Core.Entities;
using Customer.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.EntityFrameworkCore
{
   public class CustomerDBContext:DbContext
    {

        private readonly IDateTime _dateTime;

        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
            : base(options)
        {
        }

        public CustomerDBContext(
            DbContextOptions<CustomerDBContext> options,
            IDateTime dateTime
            )
            : base(options)
        {
            _dateTime = dateTime;
        }


        public DbSet<Test> Tests { get; set; }
        
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Customer.Core.Entities.Customer> Customers { get; set; }
    }
}
