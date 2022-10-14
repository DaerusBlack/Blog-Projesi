using System;

namespace BLOG_PROJESİ.Models.Abstract
{
    public enum Status { Active=1,Modified, Passive}
    public abstract class BaseEntity
    { public int Id { get; set; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime _createDate = DateTime.Now;
        public DateTime? UptadeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get => _status; set => _status = value; }

        public Status _status = Status.Active;
    }
}
