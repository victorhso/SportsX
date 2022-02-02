using FluentAssertions;
using SportsX.Entity;
using System;
using Xunit;

namespace SportsX.Tests
{
    public class PFisicaUnitTest1
    {
        [Fact]
        public void CadastrarPessoaFisica_ParametrosValidos()
        {
            Action action = () => new PFisica(1, "Victor Henrique de Souza Oliveira", "victor.souza.41@hotmail.com", true, "12345678955");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CadastrarPessoaFisica_IdInvalido()
        {
            Action action = () => new PFisica(-1, "Victor Henrique de Souza Oliveira", "victor.souza.41@hotmail.com", true, "12345678955");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("ID inválido!");
        }

        [Fact]
        public void CadastrarPessoaFisica_NomeInvalido()
        {
            Action action = () => new PFisica(1, "", "victor.souza.41@hotmail.com", true, "12345678955");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Nome inválido. Nome é obrigatório!");
        }

        [Fact]
        public void CadastrarPessoaFisica_EmailInvalido()
        {
            Action action = () => new PFisica(1, "Victor Henrique de Souza Oliveira", "", true, "12345678955");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("E-mail inválido. E-mail é obrigatório!");
        }

        [Fact]
        public void CadastrarPessoaFisica_CpfInvalido()
        {
            //Tamanho 10 do CPF
            Action action = () => new PFisica(1, "Victor Henrique de Souza Oliveira", "victor.souza.41@hotmail.com", true, "1234567895");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("CPF inválido. CPF é obrigatório e deve conter 11 dígitos!");
        }
    }
}
