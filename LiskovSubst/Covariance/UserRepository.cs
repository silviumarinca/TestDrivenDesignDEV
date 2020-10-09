using System;
using System.Collections.Generic;
using System.Text;

namespace LiskovSubst.Covariance
{
   public  class UserRepository: IEntityRepository<User>
    {
        public   User GetById(Guid id)
        {
            return new User();
        }
    }

    public interface IEntityRepository<TEntity> where TEntity : Entity {

        TEntity GetById(Guid id);

    }


    public interface IEqualityComparer<in TEntity> where TEntity : Entity
    {
        bool Equals(TEntity left, TEntity right);


    }
    public class EntityEqualityComparer : IEqualityComparer<Entity>
    {
        public bool Equals(Entity left, Entity right) {

            return left.ID == right.ID;
        }

    }
}
