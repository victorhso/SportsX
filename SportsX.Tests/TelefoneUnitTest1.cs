using FluentAssertions;
using SportsX.Entities;
using SportsX.Entity;
using System;
using Xunit;

namespace SportsX.Tests
{
    public class TelefoneUnitTest1
    {
        [Fact]
        public void CadastrarTelefone_ParametrosValidos()
        {
            Action action = () => new Telefone("3177777777", 1, null);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CadastrarTelefone_ParametrosValidos2()
        {
            Action action = () => new Telefone("3177777777", null, 1);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CadastrarTelefone_IdInvalido()
        {
            Action action = () => new Telefone("3177777777", null, null);
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("ID PF/PJ inválido. ID é obrigatório!");
        }
    }
}
