using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Domain.Commons.Entity
{
    [Serializable]
    public abstract class BaseEntity<TPrimaryKey> : IBaseEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
        public virtual DateTime? CreationTime { get; set; }
        public virtual int? CreatorUserId { get; set; }
        public virtual DateTime? ModificationTime { get; set; }
        public virtual int? ModifierUserId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
        public virtual int? DeletorUserId { get; set; }
        public virtual bool? IsDeleted { get; set; }

        protected BaseEntity()
        {
            this.CreationTime = DateTime.Now;
        }

    }
}
