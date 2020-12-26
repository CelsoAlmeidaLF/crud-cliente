using Almeida.Core.Entities;
using Almeida.Infrastructure.Repository;
using System.Collections.Generic;

namespace Almeida.Application.Business
{
    public class BusinessCliente : rCliente
    {
        public override IEnumerable<Cliente> Get()
        {
            return base.Get();
        }

        public override Cliente GetById(int id)
        {
            return base.GetById(id);
        }

        public override int Set(Cliente obj)
        {
            return base.Set(obj);
        }

        public override int Delete(Cliente obj)
        {
            return base.Delete(obj);
        }
    }
}
