using Agenda.Domain.Interfaces;
using System;

namespace Agenda.DAL.Interfaces
{
    public interface IContatos
    {
        IContato Obter(Guid id);

    }
}
