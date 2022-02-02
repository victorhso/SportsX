using FluentAssertions;
using SportsX.Entity;
using System;
using Xunit;

namespace SportsX.Tests
{
    public class EnderecoUnitTest1
    {
        [Fact]
        public void CadastrarEndereco_ParametrosValidos()
        {
            Action action = () => new Endereco(1, "36852462", 1, null);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CadastrarEndereco_ParametrosValidos2()
        {
            Action action = () => new Endereco(1, "36852462", null, 1);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CadastrarEndereco_IdInvalido()
        {
            Action action = () => new Endereco(1, "36852462", null, null);
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("ID PF/PJ inválido. ID é obrigatório!");
        }

        [Fact]
        public void CadastrarEndereco_CepVazio()
        {
            Action action = () => new Endereco(1, "", 1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("CEP inválido. CEP é obrigatório!");
        }

        [Fact]
        public void CadastrarEndereco_CepInvalido()
        {
            Action action = () => new Endereco(1, "5897586", 1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("CEP inválido. CEP é obrigatório!");
        }
    }
}
