using System;
using FluentValidation;
using JS.Core.Messages;

namespace JS.Produtos.API.Application.Commands
{
    public class RegistrarProdutoCommand : Command
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public decimal Valor { get; set; }
        public bool Entrada { get; set; }
        public bool Saida { get; set; }

        public RegistrarProdutoCommand(string nome, string descricao, bool ativo, decimal valor, bool entrada, bool saida)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            Entrada = entrada;
            Saida = saida;
        }
        public override bool EhValido()
        {
            ValidationResult = new RegistrarProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegistrarProdutoValidation : AbstractValidator<RegistrarProdutoCommand>
        {
            public RegistrarProdutoValidation()
            {
                RuleFor(c => c.Nome)
                   .NotEmpty()
                   .WithMessage("O status do produto deve ser informado");

                RuleFor(c => c.Ativo)
                    .NotEmpty()
                    .WithMessage("O status do produto deve ser informado");

                RuleFor(c => c.Valor)
                    .NotEmpty()
                    .WithMessage("O valor do produto deve ser infomado");
                               
            }
        }
    }

}
