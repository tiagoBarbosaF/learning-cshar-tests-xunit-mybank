﻿using MyBank.Aplicacao.AplicacaoServico;
using MyBank.Aplicacao.DTO;
using MyBank.Dados.Repositorio;
using MyBank.Dominio.Interfaces.Repositorios;
using MyBank.Dominio.Interfaces.Servicos;
using MyBank.Dominio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Apresentacao.Comandos
{
    internal class ContaCorrenteComando
    {
        IContaCorrenteRepositorio _repositorio;
        IContaCorrenteServico _servico;
        ContaCorrenteServicoApp contaCorrenteServicoApp;
        public ContaCorrenteComando()
        {
            _repositorio = new ContaCorrenteRepositorio();
            _servico = new ContaCorrenteServico(_repositorio);
            contaCorrenteServicoApp = new ContaCorrenteServicoApp(_servico);
        }

        public bool Adicionar(ContaCorrenteDTO conta)
        {
            return contaCorrenteServicoApp.Adicionar(conta);
        }
        public bool Atualizar(int id, ContaCorrenteDTO conta)
        {
            return contaCorrenteServicoApp.Atualizar(id,conta);
        }

        public bool Excluir(int id)
        {
            return contaCorrenteServicoApp.Excluir(id);
        }

        public ContaCorrenteDTO ObterPorId(int id)
        {
            return contaCorrenteServicoApp.ObterPorId(id);
        }

        public List<ContaCorrenteDTO> ObterTodos()
        {
           return contaCorrenteServicoApp.ObterTodos();
        }

    }
}
