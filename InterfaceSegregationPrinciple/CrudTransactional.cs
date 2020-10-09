using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace InterfaceSegregationPrinciple
{
    public class CrudTransactional<TEntity> : ICreateReadUpdateDelete<TEntity>
    {
        private readonly ICreateReadUpdateDelete<TEntity> decratedCrud;

        public CrudTransactional(ICreateReadUpdateDelete<TEntity> decratedCrud)
        {
            this.decratedCrud = decratedCrud;
        }
        public void Create(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decratedCrud.Create(entity);

                transaction.Complete();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decratedCrud.Delete(entity);
                transaction.Complete();

            }
        }

        public IEnumerable<TEntity> ReadAll()
        {
            IEnumerable<TEntity> allEntries;
            using (var transaction = new TransactionScope())
            {
                allEntries = decratedCrud.ReadAll();

                transaction.Complete();
            }
            return allEntries;
        }

        public TEntity ReadOne(Guid identity)
        {
            TEntity entry;
            using (var transaction = new TransactionScope())
            {
                entry = decratedCrud.ReadOne(identity);
                transaction.Complete();

            }
            return entry;
        }

        public void Update(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                 decratedCrud.Update(entity);
                transaction.Complete();

            }
        }
    }
}
