using System;
using System.Data.Entity;
using System.Linq;

namespace AutoClassLibrary
{
    namespace AutoClassLibrary
    {
        public class Model1 : DbContext
        {
            public Model1()
                : base("name=Model1")
            {

            }

            public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<Car> Cars { get; set; }
        }
    }
}