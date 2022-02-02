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
    [Route("api/pfisica")]
    [ApiController]
    public class PFisicaController : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public ActionResult<List<PFisica>> GetListPF()
        {
            //Criando instância do nosso contexto.
            using var db = new Data.Context();

            List<PFisica> pessoas = db.PFisica
                            .Where(p => p.ID > 0)
                            .OrderBy(p => p.ID)
                            .ToList();

            if (pessoas.Count == 0)
                return NotFound("Não foram encontrados registros de Pessoas Físicas.");

            List<Telefone> telefones = db.Telefone
                            .Where(p => p.ID_TELEFONE > 0)
                            .ToList();


            //Por falta de tempo pessoal não consegui desenvolver uma melhor lógica para esse retorno da controller, mas atende.
            var query = (from pe in pessoas
                         join te in telefones
                             on pe.ID equals te.ID_PJ
                         select new
                         {
                             pe.ID,
                             pe.DS_NOME,
                             pe.DS_EMAIL,
                             pe.NR_CPF,
                             pe.DS_CLASSIFICACAO,
                             te.NR_TELEFONE
                         }).Distinct();

            return Ok(query.ToList());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id:int}", Name = "GetPFisica")]
        public ActionResult GetPFById(int id)
        {
            using var db = new Data.Context();

            PFisica query = db.PFisica.Where(p => p.ID == id).FirstOrDefault();

            if (query is null)
                return NotFound("Não foram encontrados registros de Pessoas Físicas.");

            return Ok(query);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{ds_nome}")]
        public ActionResult GetPFByName(string ds_nome)
        {
            using var db = new Data.Context();

            PFisica query = db.PFisica.Where(p => p.DS_NOME.ToUpper().Contains(ds_nome.ToUpper())).FirstOrDefault();

            if (query is null)
                return NotFound("Não foram encontrados registros de Pessoas Físicas.");

            return Ok(query);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult PostPF([FromBody] PFisicaDTO pFisicaDTO)
        {
            try
            {
                if (pFisicaDTO == null)
                    return BadRequest("Dados inválidos.");

                using var db = new Data.Context();
                var searchPes = db.PFisica.Where(p => p.NR_CPF == pFisicaDTO.NR_CPF.ToString()).FirstOrDefault();

                if (searchPes != null)
                    return Ok("Pessoa já cadastrada!");

                PFisica pessoa = new PFisica();
                Endereco endereco = new Endereco();

                pessoa.AtualizarPF(pFisicaDTO.DS_NOME, pFisicaDTO.DS_EMAIL, pFisicaDTO.DS_CLASSIFICACAO, pFisicaDTO.NR_CPF.ToString());
                db.PFisica.Add(pessoa);
                db.SaveChanges();

                searchPes = db.PFisica.Where(p => p.NR_CPF.Equals(pFisicaDTO.NR_CPF.ToString())).FirstOrDefault();

                endereco.AtualizarEndereco(pFisicaDTO.ENDERECO.NR_CEP, searchPes.ID, null);
                db.Endereco.Add(endereco);
                db.SaveChanges();

                foreach (var tel in pFisicaDTO.NR_TELEFONES)
                {
                    Telefone telefone = new Telefone(tel, searchPes.ID, null);
                    db.Telefone.Add(telefone);
                    db.SaveChanges();
                }

                return Ok(pFisicaDTO);
            }
            catch (Exception ex) { throw new Exception($"Ocorreu um erro, estamos trabalhando para solucioná-lo. Contate o administrador do sistema. Erro: {ex.Message}"); }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult PutPF(int id, [FromBody] PFisicaDTO pFisicaDTO)
        {
            try
            {
                if (id != pFisicaDTO.ID || pFisicaDTO == null)
                    return BadRequest("Dados inválidos.");

                using var db = new Data.Context();

                PFisica pessoa = db.PFisica.Where(p => p.NR_CPF == pFisicaDTO.NR_CPF.ToString()).FirstOrDefault();
                if (pessoa == null)
                    return NotFound("Não foram encontrados registros de Pessoas Físicas.");

                Endereco endereco = db.Endereco.Where(p => p.ID_PF == pFisicaDTO.ID).FirstOrDefault();
                if (endereco == null)
                    return NotFound("Não foram encontrados registros de Endereço.");

                List<Telefone> lstTelefone = db.Telefone.Where(p => p.ID_PF == pFisicaDTO.ID).ToList();
                if (lstTelefone.Count == 0)
                    return NotFound("Não foram encontrados registros de Telefone.");

                pessoa.AtualizarPF(pFisicaDTO.DS_NOME, pFisicaDTO.DS_EMAIL, pFisicaDTO.DS_CLASSIFICACAO, pFisicaDTO.NR_CPF.ToString());
                db.PFisica.Update(pessoa);
                db.SaveChanges();

                endereco.AtualizarEndereco(pFisicaDTO.ENDERECO.NR_CEP, pFisicaDTO.ID, null);
                db.Endereco.Update(endereco);
                db.SaveChanges();

                foreach (var tel in pFisicaDTO.NR_TELEFONES)
                {
                    Telefone telefone = new Telefone(tel, pFisicaDTO.ID, null);
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
        public ActionResult DeletePF(int id)
        {
            try
            {
                using var db = new Data.Context();

                PFisica pessoa = db.PFisica.Where(p => p.ID == id).FirstOrDefault();

                if (pessoa == null)
                    return NotFound("Registro não encontrado.");

                db.PFisica.Remove(pessoa);
                db.SaveChanges();

                List<Telefone> telefonesPF = db.Telefone.Where(p => p.ID_PF == pessoa.ID).ToList();
                Endereco endereco = db.Endereco.Where(p => p.ID_PF == pessoa.ID).FirstOrDefault();

                //Aqui não utilizei o RemoveRange, pois este método é da versão 6 do EF, como estou utilizando a versão 5, fiz com foreach.
                if (telefonesPF.Count() > 0)
                {
                    foreach(var item in telefonesPF)
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

                return Ok(pessoa);
            }
            catch (Exception ex) { throw new Exception($"Ocorreu um erro, estamos trabalhando para solucioná-lo. Contate o administrador do sistema. Erro: {ex.Message}"); }
        }
    }
}
