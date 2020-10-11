using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace InterfaceSegregationPrinciple
{
   public interface ICreateUpdate<TEntity>
    {
        void Create(TEntity);
    }

    public interface ISave<TEntity> {

        void Save(TEntity entity);
    
    }

    public class SaveAuditing<TEntity> : ISave<TEntity>
    {
        private readonly ISave<TEntity> decorated;
        private readonly ISave<AuditInfo> auditSave;
        public SaveAuditing(ISave<TEntity> decorated, ISave<AuditInfo> auditSave)
        {
            this.auditSave = auditSave;
            this.decorated = decorated;
        }

        public void Save(TEntity entity)
        {
            decorated.Save(entity);
            var auditInfo = new AuditInfo
            {
                UserName = Thread.CurrentPrincipal.Identity.Name,
                TimeStamp = DateTime.Now

            };
            auditSave.Save(auditInfo);
        }
    }

    public class AuditInfo
    {
        public string UserName { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
