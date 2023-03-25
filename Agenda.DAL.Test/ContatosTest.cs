using Agenda.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;
        [SetUp] public void SetUp() 
        {
            _contatos = new Contatos();
        }

        [Test]
        public void AdicionarContatoTest()
        {
            //Monta
            Contato contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Bruna"
            };
            //Executa
            _contatos.Adicionar(contato);
            //Verifica
            Assert.True(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            //Monta
            Contato contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Clara"
            };
            //Executa
            _contatos.Adicionar(contato);
            Contato contatoResultado = _contatos.Obter(contato.Id);
            //Verifica
            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

        [Test]
        public void ObterTodosContatosTest()
        {
            //Monta
            Contato contato1 = new Contato() { Id = Guid.NewGuid(), Nome = "Clara" };
            Contato contato2 = new Contato() { Id = Guid.NewGuid(), Nome = "João" };
            //Executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            List<Contato> todosContatos = _contatos.ObterTodos();
            var contatoResultado1 = todosContatos.Where(x => x.Id == contato1.Id).FirstOrDefault();
            var contatoResultado2 = todosContatos.Where(x => x.Id == contato2.Id).FirstOrDefault();
            //Verifica
            Assert.IsTrue(todosContatos.Count > 1);
            Assert.AreEqual(contato1.Id, contatoResultado1.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado1.Nome);
            Assert.AreEqual(contato2.Id, contatoResultado2.Id);
            Assert.AreEqual(contato2.Nome, contatoResultado2.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }
    }
}
