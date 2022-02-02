using SportsX.Validation;
using System;

namespace SportsX.Entity
{
    public class Endereco
    {
        public int ID_ENDERECO { get; private set; }
        public string NR_CEP { get; private set; }

        public Nullable<int> ID_PF { get; set; }
        public Nullable<int> ID_PJ { get; set; }

        public Endereco()
        { }
        public Endereco(int id_endereco, string nr_cep, int? id_pf, int? id_pj)
        {
            DomainExceptionValidation.When(id_endereco < 0, "ID inválido!");

            ID_ENDERECO = id_endereco;
            ValidaDominio(nr_cep, id_pf, id_pj);
        }

        public void AtualizarEndereco(string nr_cep, int? id_pf, int? id_pj)
        {
            ValidaDominio(nr_cep, id_pf, id_pj);
        }

        private void ValidaDominio(string nr_cep, int? id_pf, int? id_pj)
        {
            DomainExceptionValidation.When((String.IsNullOrEmpty(nr_cep) || nr_cep.Length != 8), "CEP inválido. CEP é obrigatório!");
            DomainExceptionValidation.When((id_pf is null && id_pj is null), "ID PF/PJ inválido. ID é obrigatório!");

            ID_PF = id_pf;
            ID_PJ = id_pj;
            NR_CEP = nr_cep;
        }
    }
}
