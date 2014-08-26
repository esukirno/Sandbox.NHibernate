using System;

namespace MyInventory.Model
{
    public abstract class BaseModel
    {
        public virtual Guid Id { get; set; }
    }
}