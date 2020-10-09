using System;
using System.Collections.Generic;
using System.Text;
using TradeProcessorWithAbstraction.Abstraction;

namespace InterfaceSegregationPrinciple
{
    public class CrudLogging<TEntity> : ICreateReadUpdateDelete<TEntity>
    {
        private readonly ICreateReadUpdateDelete<TEntity> decoratedCrud;
        private readonly ILog log;

        public CrudLogging(ICreateReadUpdateDelete<TEntity> decoratedCrud , ILog log)
        {
            this.log = log;
            this.decoratedCrud = decoratedCrud;

        }
        public void Create(TEntity entity)
        {
          //  this.log.InfoFormat("Creating entity of type {0}", typeof(TEntity).Name);
            decoratedCrud.Create(entity);
        }
        //logginhg functions
        public void Delete(TEntity entity)
        {
              decoratedCrud.Delete(entity);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            throw new NotImplementedException();
        }

        public TEntity ReadOne(Guid identity)
        {
          return  decoratedCrud.ReadOne(identity);
        }

        public void Update(TEntity entity)
        {
              decoratedCrud.Update(entity);
        }
    }
}
