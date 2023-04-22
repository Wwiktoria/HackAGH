using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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