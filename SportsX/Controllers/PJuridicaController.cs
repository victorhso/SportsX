using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsX.DTOs;
using SportsX.Entities;
using SportsX.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsX.Controllers
{
    [Route("api/pjuridica")]
    [ApiController]
    public class PJuridicaController : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id:int}", Name = "GetPJuridica")]
        public ActionResult GetPJById(int id)
        {
            using var db = new Data.Context();

            PJuridica query = db.PJuridica.Where(p => p.ID == id).FirstOrDefault();

            if (query is null)
                return NotFound("Não foram encontrados registros de Pessoas Físicas.");

            return Ok(query);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{ds_razao_social}")]
        public ActionResult GetPJByName(string ds_razao_social)
        {
            using var db = new Data.Context();

            PJuridica query = db.PJuridica.Where(p => p.DS_RAZAO_SOCIAL.ToUpper().Contains(ds_razao_social.ToUpper())).FirstOrDefault();

            if (query is null)
                return NotFound("Não foram encontrados registros de Pessoas Jurídicas.");

            return Ok(query);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public ActionResult<List<PJuridica>> GetListPJ()
        {
            //Criando instância do nosso contexto.
            using var db = new Data.Context();

            List<PJuridica> pessoas = db.PJuridica
                            .Where(p => p.ID > 0)
                            .OrderBy(p => p.ID)
                            .ToList();

            List<Telefone> telefones = db.Telefone
                            .Where(p => p.ID_TELEFONE > 0)
                            .ToList();

            if (pessoas.Count == 0)
                return NotFound("Não foram encontrados registros de Pessoas Jurídicas.");

            //Por falta de tempo pessoal não consegui desenvolver uma melhor lógica para esse retorno da controller, mas atende.
            var query = (from pe in pessoas
                         join te in telefones
                             on pe.ID equals te.ID_PJ
                         select new
                         {
                             pe.ID,
                             pe.DS_RAZAO_SOCIAL,
                             pe.DS_EMAIL,
                             pe.NR_CNPJ,
                             pe.DS_CLASSIFICACAO,
                             te.NR_TELEFONE
                         }).Distinct();

            return Ok(query.ToList());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult PostPJ([FromBody] PJuridicaDTO pJuridicaDTO)
        {
            int count = pJuridicaDTO.DS_RAZAO_SOCIAL.Length;
            try
            {
                if (pJuridicaDTO == null)
                    return BadRequest("Dados inválidos.");

                using var db = new Data.Context();
                var searchPes = db.PJuridica.Where(p => p.NR_CNPJ == pJuridicaDTO.NR_CNPJ.ToString()).FirstOrDefault();

                if (searchPes != null)
                    return Ok("Pessoa Jurídica já cadastrada!");

                PJuridica pessoa = new PJuridica();
                Endereco endereco = new Endereco();

                pessoa.AtualizarPJ(pJuridicaDTO.DS_RAZAO_SOCIAL, pJuridicaDTO.DS_EMAIL, pJuridicaDTO.DS_CLASSIFICACAO, pJuridicaDTO.NR_CNPJ.ToString());
                db.PJuridica.Add(pessoa);
                db.SaveChanges();

                searchPes = db.PJuridica.Where(p => p.NR_CNPJ.Equals(pJuridicaDTO.NR_CNPJ.ToString())).FirstOrDefault();

                endereco.AtualizarEndereco(pJuridicaDTO.ENDERECO.NR_CEP, null, searchPes.ID);
                db.Endereco.Add(endereco);
                db.SaveChanges();

                foreach (var tel in pJuridicaDTO.NR_TELEFONES)
                {
                    Telefone telefone = new Telefone(tel, null, searchPes.ID);
                    db.Telefone.Add(telefone);
                    db.SaveChanges();
                }

                return Ok(pJuridicaDTO);
            }
            catch (Exception ex) { throw new Exception($"Ocorreu um erro, estamos trabalhando para solucioná-lo. Contate o administrador do sistema. Erro: {ex.Message}"); }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult PutPJ(int id, [FromBody] PJuridicaDTO pJuridicaDTO)
        {
            try
            {
                if (pJuridicaDTO == null)
                    return BadRequest("Dados inválidos.");

                using var db = new Data.Context();

                PJuridica pessoa = db.PJuridica.Where(p => p.ID == id).FirstOrDefault();
                if (pessoa == null)
                    return NotFound("Não foram encontrados registros de Pessoas Físicas.");

                Endereco endereco = db.Endereco.Where(p => p.ID_PJ == id).FirstOrDefault();
                if (endereco == null)
                    return NotFound("Não foram encontrados registros de Endereço.");

                List<Telefone> lstTelefone = db.Telefone.Where(p => p.ID_PJ == id).ToList();
                if (lstTelefone.Count == 0)
                    return NotFound("Não foram encontrados registros de Telefone.");

                pessoa.AtualizarPJ(pJuridicaDTO.DS_RAZAO_SOCIAL, pJuridicaDTO.DS_EMAIL, pJuridicaDTO.DS_CLASSIFICACAO, pJuridicaDTO.NR_CNPJ.ToString());
                db.PJuridica.Update(pessoa);
                db.SaveChanges();

                endereco.AtualizarEndereco(pJuridicaDTO.ENDERECO.NR_CEP, null, pJuridicaDTO.ID);
                db.Endereco.Update(endereco);
                db.SaveChanges();

                foreach (var tel in pJuridicaDTO.NR_TELEFONES)
                {
                    Telefone telefone = new Telefone(tel, null, pJuridicaDTO.ID);
                    db.Telefone.Update(telefone);
                    db.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex) { throw new Exception($"Ocorreu um erro, estamos trabalhando para solucioná-lo. Contate o administrador do sistema. Erro: {ex.Message}"); }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public ActionResult DeletePJ(int id)
        {
            try
            {
                using var db = new Data.Context();

                PJuridica pessoa = db.PJuridica.Where(p => p.ID == id).FirstOrDefault();

                if (pessoa == null)
                    return NotFound("Registro não encontrado.");

                List<Telefone> telefonesPJ = db.Telefone.Where(p => p.ID_PJ == pessoa.ID).ToList();
                Endereco endereco = db.Endereco.Where(p => p.ID_PJ == pessoa.ID).FirstOrDefault();

                db.PJuridica.Remove(pessoa);
                db.SaveChanges();

                //Aqui não utilizei o RemoveRange, pois este método é da versão 6 do EF, como estou utilizando a versão 5, fiz com foreach.
                if (telefonesPJ.Count() > 0)
                {
                    foreach (var item in telefonesPJ)
                    {
                        db.Telefone.Remove(item);
                        db.SaveChanges();
                    }
                }

                if (endereco != null)
                {
                    db.Endereco.Remove(endereco);
                    db.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex) { throw new Exception($"Ocorreu um erro, estamos trabalhando para solucioná-lo. Contate o administrador do sistema. Erro: {ex.Message}"); }
        }
    }
}
