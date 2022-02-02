using SportsX.Validation;
using System;

namespace SportsX.Entities
{
    public class Telefone
    {
        public int ID_TELEFONE { get; private set; }
        public string NR_TELEFONE { get; private set; }

        public Nullable<int> ID_PF { get; private set; }
        public Nullable<int> ID_PJ { get; private set; }

        public Telefone()
        { }

        public Telefone(string nr_telefone, int? id_pf, int? id_pj)
        {
            AtualizarTelefone(nr_telefone, id_pf, id_pj);
        }

        private void AtualizarTelefone(string nr_telefone, int? id_pf, int? id_pj)
        {
            DomainExceptionValidation.When((id_pf is null && id_pj is null), "ID PF/PJ inválido. ID é obrigatório!");

            ID_PF = id_pf;
            ID_PJ = id_pj;
            NR_TELEFONE = nr_telefone;
        }
    }
}
