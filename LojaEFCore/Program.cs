﻿using LojaEFCore.Domain;
using LojaEFCore.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LojaEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultarDados();
        }

        private static void ConsultarDados()
        {
            using var db = new Data.ApplicationContext();

            //var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();

            var consultaPorMetodo = db.Clientes
                .Where(p=> p.Id > 0)
                .OrderBy(p => p.Id)
                .ToList();

            foreach (var cliente in consultaPorMetodo)
            {
                Console.WriteLine($"Consultando Cliente: {cliente.Nome}");
                //db.Clientes.Find(cliente.Id);
                db.Clientes.FirstOrDefault(p => p.Id == cliente.Id);
            }
        }

        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();
            //db.Produtos.Add(produto);
            //db.Set<Produto>().Add(produto);
            //db.Entry(produto).State = EntityState.Added;
            db.Add(produto);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total registros: {registros}");
        }

        private static void InserirDadosEmMassa()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var cliente = new Cliente
            {
                Nome = "Caique Burssed",
                CEP = "11111222",
                Cidade = "Bragança Paulista",
                Estado = "SP",
                Telefone = "99000001111"
            };

            var listaClientes = new[]
            {
                new Cliente
                {
                    Nome = "Lucas Garcia",
                CEP = "00000999",
                Cidade = "Bragança Paulista",
                Estado = "SP",
                Telefone = "99000001111"
                },

                new Cliente
                {
                    Nome = "Fabio Ishizu",
                CEP = "99999000",
                Cidade = "Bragança Paulista",
                Estado = "SP",
                Telefone = "99000001111"
                },
            };

            using var db = new Data.ApplicationContext();
            //db.AddRange(produto, cliente);
            //db.Set<Cliente>().AddRange(listaClientes);
            db.Clientes.AddRange(listaClientes);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total registros: {registros}");
        }
    }
}
