using JS.Core.DomainObjects;
using System;

namespace JS.Produtos.Domain.Models
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Saida { get; private set; }
        public bool Entrada { get; private set; }

        public Produto() { }

        public Produto(string nome, string descricao, bool ativo, decimal valor, bool saida, bool entrada)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            Saida = saida;
            Entrada = entrada;
        }

        public bool EstaDisponivel(int quantidade)
        {
            return Ativo;
        }

        public void setNome(string nome)
        {
            Nome = nome;
        }
        public void setDescricao(string descricao)
        {
            Descricao = descricao;
        }
        public void setAtivo(bool ativo)
        {
            Ativo = ativo;
        }
        public void setValor(decimal valor)
        {
            Valor = valor;
        }
        public void setSaida(bool saida)
        {
            Saida = saida;
        }
        public void setEntrada(bool entrada)
        {
            Entrada = entrada;
        }
    }
}
