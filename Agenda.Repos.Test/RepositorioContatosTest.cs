using Agenda.DAL.Interfaces;
using Agenda.Domain;
using Agenda.Domain.Interfaces;
using Agenda.Repos.Test.Construtores;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repos.Test
{
    [TestFixture]
    public class RepositorioContatosTest
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;
        RepositorioContatos _repositorioContatos;

        [SetUp] 
        public void SetUp()
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);
        }

        [Test]
        public void DeveSerPossivelObterContatosComListaTelefone()
        {
            Guid telefoneId = Guid.NewGuid();
            Guid contatoId = Guid.NewGuid();
            List<ITelefone> lstTelefone = new List<ITelefone>();
            //Monta
            Mock<IContato> mockContato = IContatoConstr.Um().ComId(contatoId).ComNome("Bruna").Obter();
            mockContato.SetupSet(o => o.Telefones = It.IsAny<List<ITelefone>>())
                .Callback<List<ITelefone>>(p => lstTelefone = p);
            _contatos.Setup(o => o.Obter(contatoId)).Returns(mockContato.Object);
            ITelefone mockTelefone = ITelefoneConstr.Um().Padrao().ComId(telefoneId)
                .ComContatoId(contatoId).Construir();
            _telefones.Setup(o => o.ObterTodosDoContato(contatoId))
                .Returns(new List<ITelefone> {mockTelefone});
            //Executa
            IContato contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            mockContato.SetupGet(o => o.Telefones).Returns(lstTelefone);
            //Verifica
            Assert.AreEqual(mockContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mockContato.Object.Nome, contatoResultado.Nome);
            Assert.AreEqual(1, contatoResultado.Telefones.Count);
            Assert.AreEqual(mockTelefone.Numero, contatoResultado.Telefones[0].Numero);
            Assert.AreEqual(mockTelefone.Id, contatoResultado.Telefones[0].Id);
            Assert.AreEqual(mockContato.Object.Id, contatoResultado.Telefones[0].ContatoId);
        }

        [TearDown]
        public void TearDown() 
        { 
            _contatos = null;
            _telefones = null;
            _repositorioContatos = null;
        }
    }
}
