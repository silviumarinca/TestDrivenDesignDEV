using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace InterfaceSegregationPrinciple
{
    public class DeleteConfirmation<TEntity>: ICreateReadUpdateDelete<TEntity>
    {
        private readonly ICreateReadUpdateDelete<TEntity> decratedCrud;


        public DeleteConfirmation(ICreateReadUpdateDelete<TEntity> decoratedCrud)
        {
            this.decratedCrud = decoratedCrud;
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

            Console.WriteLine("Are you sure you want to delete items");
            var keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Y)
            {

                using (var transaction = new TransactionScope())
                {
                    decratedCrud.Delete(entity);
                    transaction.Complete();

                }
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



    public interface IDelete<TEntity> {

        void Delete(TEntity entity);
    }

    public class DeleteConfirmationSafe<TEntity> : IDelete<TEntity>
    {
        private readonly   IDelete<TEntity> decoratedDeleteOperation;

        public DeleteConfirmationSafe(IDelete<TEntity> decoratedDeleteOperation)
        {
            this.decoratedDeleteOperation = decoratedDeleteOperation;
        }
        public void Delete(TEntity entity)
        {
            Console.WriteLine("Are you sure you want to delete items");
            var keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Y)
            {

                using (var transaction = new TransactionScope())
                {
                    decoratedDeleteOperation.Delete(entity);
                    transaction.Complete();

                }
            }
        }
    }

    public interface IUserInteraction
    {

        bool Confirm(string message);

    }

    public class CrudCaching<TEntity> : ICreateReadUpdateDelete<TEntity>
    {
        private TEntity cachedEntity;
        private IEnumerable<TEntity> allcachedEntities;
        private readonly ICreateReadUpdateDelete<TEntity> decorated;

        public CrudCaching(ICreateReadUpdateDelete<TEntity> decorated)
        {
            this.decorated = decorated;

        }
        public void Create(TEntity entity)
        {
            decorated.Create(entity);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> ReadAll()
        {
            if (allcachedEntities == null)
            {


                allcachedEntities = decorated.ReadAll();
            }
            return allcachedEntities;
        }

        public TEntity ReadOne(Guid identity)
        {
            if (cachedEntity == null)
            {
                cachedEntity = decorated.ReadOne(identity);

            }
            return cachedEntity;
        }

        public void Update(TEntity entity)
        {
            decorated.Update(entity);
        }
    }

    public interface IRead<TEntity> {
        TEntity ReadOne(Guid identity);
        IEnumerable<TEntity> ReadAll();


    }
    public class ReadCaching<TEntity> : IRead<TEntity>
    {
        private Dictionary<Guid, TEntity> cachedEntities;
        private IEnumerable<TEntity> allCachedEntities;
        private readonly IRead<TEntity> decorated;


        public ReadCaching(IRead<TEntity> decorated) 
        {
            this.decorated = decorated;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            if (allCachedEntities == null)
            {
                allCachedEntities = decorated.ReadAll();
            
            }
            return allCachedEntities;
        }

        public TEntity ReadOne(Guid identity)
        {
            var foundEntity = cachedEntities[identity];
            if (foundEntity == null) {
                decorated.ReadOne(identity);

                if (foundEntity != null)
                {

                    cachedEntities[identity] = foundEntity;
                }

            }
            return foundEntity;
        }
    }
}
