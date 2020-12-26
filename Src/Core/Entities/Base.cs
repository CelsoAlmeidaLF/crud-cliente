using System;

namespace Almeida.Core.Entities
{
    public class Base
    {
        public virtual int? Id { get; set; }
        public DateTime dateCriacao { get; set; }
        public DateTime dataAlteracao { get; set;  }
        public virtual bool? Excluido { get; set; }
    }
}
