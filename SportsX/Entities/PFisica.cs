using SportsX.Validation;
using System;

namespace SportsX.Entity
{
    public class PFisica : Pessoa
    {
        public string DS_NOME { get; private set; }
        public string DS_EMAIL { get; private set; }
        public bool DS_CLASSIFICACAO { get; private set; }
        public string NR_CPF { get; private set; }

        public PFisica()
        { }

        public PFisica(int id, string ds_nome, string ds_email, bool ds_classificacao, string nr_cpf)
        {
            DomainExceptionValidation.When(id < 0, "ID inválido!");

            ID = id;
            ValidaDominio(ds_nome, ds_email, ds_classificacao, nr_cpf);
        }

        public void AtualizarPF(string ds_nome, string ds_email, bool ds_classificacao, string nr_cpf)
        {
            ValidaDominio(ds_nome, ds_email, ds_classificacao, nr_cpf);
        }

        private void ValidaDominio(string ds_nome, string ds_email, bool ds_classificacao, string nr_cpf)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(ds_nome), "Nome inválido. Nome é obrigatório!");
            DomainExceptionValidation.When(String.IsNullOrEmpty(ds_email), "E-mail inválido. E-mail é obrigatório!");
            DomainExceptionValidation.When(nr_cpf.Length != 11, "CPF inválido. CPF é obrigatório e deve conter 11 dígitos!");

            DS_NOME = ds_nome;
            DS_EMAIL = ds_email;
            DS_CLASSIFICACAO = ds_classificacao;
            NR_CPF = nr_cpf;
        }
    }
}
