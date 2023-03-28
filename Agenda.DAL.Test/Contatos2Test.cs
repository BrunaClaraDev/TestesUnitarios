using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class Contatos2Test : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;
        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        [Test]
        public void ObterTodosContatosTest()
        {
            //Monta
            Contato contato1 = _fixture.Create<Contato>();
            Contato contato2 = _fixture.Create<Contato>();
            //Executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            List<Contato> todosContatos = _contatos.ObterTodos();
            var contatoResultado1 = todosContatos.Where(x => x.Id == contato1.Id).FirstOrDefault();
            var contatoResultado2 = todosContatos.Where(x => x.Id == contato2.Id).FirstOrDefault();
            //Verifica
            Assert.AreEqual(2, todosContatos.Count);
            Assert.AreEqual(contato1.Id, contatoResultado1.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado1.Nome);
            Assert.AreEqual(contato2.Id, contatoResultado2.Id);
            Assert.AreEqual(contato2.Nome, contatoResultado2.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
