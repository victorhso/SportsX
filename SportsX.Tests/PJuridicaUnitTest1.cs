using FluentAssertions;
using SportsX.Entity;
using System;
using Xunit;

namespace SportsX.Tests
{
    public class PJuridicaUnitTest1
    {
        [Fact]
        public void CadastrarPessoaJuridica_ParametrosValidos()
        {
            Action action = () => new PJuridica(1, "Ação Social SA", "acao.social@teste.com", true, "16319633000105");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CadastrarPessoaJuridica_IdInvalido()
        {
            Action action = () => new PJuridica(-1, "Ação Social SA", "acao.social@teste.com", true, "16319633000105");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("ID inválido!");
        }

        [Fact]
        public void CadastrarPessoaFisica_NomeInvalido()
        {
            Action action = () => new PJuridica(1, "", "acao.social@teste.com", true, "16319633000105");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Razão Social inválido. Razão Social é obrigatório!");
        }

        [Fact]
        public void CadastrarPessoaFisica_EmailInvalido()
        {
            Action action = () => new PJuridica(1, "Ação Social SA", "", true, "16319633000105");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("E-mail inválido. E-mail é obrigatório!");
        }

        [Fact]
        public void CadastrarPessoaFisica_CnpjInvalido()
        {
            //Tamanho 13 do CNPJ
            Action action = () => new PJuridica(1, "Victor Henrique de Souza Oliveira", "victor.souza.41@hotmail.com", true, "1631963300010");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("CNPJ inválido. CNPJ é obrigatório e deve conter 15 dígitos!");
        }
    }
}
