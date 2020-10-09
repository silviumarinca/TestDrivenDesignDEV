using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubst.Covariance
{
    public class Entity
    {
        public Guid ID { get;private set; }
        public string Name { get;private set; }
    }

    public class User : Entity {
        public string EmailAddress { get;private set; }
        public DateTime DateOfBirth { get;private set; }


    }
}
