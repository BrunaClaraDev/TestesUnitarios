using AutoFixture;
using Moq;

namespace Agenda.Repos.Test.Construtores
{
    public class BaseConstr<T> where T : class
    {
        protected readonly Fixture _fixture;
        protected readonly Mock<T> _mock;

        protected BaseConstr()
        {
            _fixture = new Fixture();
            _mock = new Mock<T>();
        }

        public T Construir()
        {
            return  _mock.Object;
        }

        public Mock<T> Obter() 
        { 
            return _mock;
        }
    }
}
