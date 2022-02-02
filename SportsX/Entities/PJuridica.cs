using SportsX.Validation;
using System;

namespace SportsX.Entity
{
    public class PJuridica : Pessoa
    {
        public string DS_RAZAO_SOCIAL { get; private set; }
        public string DS_EMAIL { get; private set; }
        public bool DS_CLASSIFICACAO { get; private set; }
        public string NR_CNPJ { get; private set; }

        public PJuridica()
        { }
        public PJuridica(int id, string ds_razao_social, string ds_email, bool ds_classificacao, string nr_cnpj)
        {
            DomainExceptionValidation.When(id < 0, "ID inválido!");

            ID = id;
            ValidaDominio(ds_razao_social, ds_email, ds_classificacao, nr_cnpj);
        }

        public void AtualizarPJ(string ds_razao_social, string ds_email, bool ds_classificacao, string nr_cnpj)
        {
            ValidaDominio(ds_razao_social, ds_email, ds_classificacao, nr_cnpj);
        }

        private void ValidaDominio(string ds_razao_social, string ds_email, bool ds_classificacao, string nr_cnpj)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(ds_razao_social), "Razão Social inválido. Razão Social é obrigatório!");
            DomainExceptionValidation.When(String.IsNullOrEmpty(ds_email), "E-mail inválido. E-mail é obrigatório!");
            DomainExceptionValidation.When(nr_cnpj.Length != 14, "CNPJ inválido. CNPJ é obrigatório e deve conter 15 dígitos!");

            DS_RAZAO_SOCIAL = ds_razao_social;
            DS_EMAIL = ds_email;
            DS_CLASSIFICACAO = ds_classificacao;
            NR_CNPJ = nr_cnpj;
        }
    }
}
