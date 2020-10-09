using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubst.Covariance
{
    public class EntityRepository
    {
        public virtual Entity GetById(Guid id)
        {
            return new Entity();
        }
    }
}
