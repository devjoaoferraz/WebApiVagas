using FluentValidation;
using WebApiVagas.Models.Entities;

namespace WebApiVagas.Validation
{
    public class VagaValidator : AbstractValidator<Vaga>
    {
        public VagaValidator()
        {
            RuleFor(v => v.Titulo)
                .NotEmpty().WithMessage("O titulo da vaga nao pode ser vazio.")
                .MinimumLength(10).WithMessage("O titulo da vaga deve ter pelo menos 10 caracteres.")
                .MaximumLength(100).WithMessage("O titulo da vaga deve ter ate 100 caracteres.");

            RuleFor(v => v.Descricao)
                .NotEmpty().WithMessage("A descricao da vaga nao pode ser vazia.")
                .MinimumLength(10).WithMessage("A descricao da vaga deve ter pelo menos 10 caracteres.")
                .MaximumLength(200).WithMessage("A descricao da vaga deve ter ate 200 caracteres.");

            RuleFor(v => v.Empresa)
                .NotEmpty().WithMessage("O nome da empresa nao pode ser vazio.")
                .MinimumLength(3).WithMessage("O nome da empresa deve ter pelo menos 3 caracteres.")
                .MaximumLength(100).WithMessage("O nome da empresa ter ate 50 caracteres.");

            RuleFor(v => v.SalarioInicial)
                .GreaterThan(0).WithMessage("O salario inicial deve ser maior que zero.")
                .LessThan(v => v.SalarioMaximo).WithMessage("O salario inicial deve ser menor que o salario maximo.");

            RuleFor(v => v.SalarioMaximo)
                .GreaterThan(0).WithMessage("O salario maximo deve ser maior que zero.");

            RuleFor(v => v.Requisitos)
                .NotEmpty().WithMessage("Os requisitos da vaga nao podem ficar em branco.")
                .MinimumLength(2).WithMessage("Os requisitos da vaga devem ter pelo menos 10 caracteres.")
                .MaximumLength(200).WithMessage("Os requisitos da vaga devem ter ate 200 caracteres.");

            RuleFor(v => v.EstadoTrabalho)
                .Matches("(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)")
                .WithMessage("O estado de trabalho da vaga e invalido (deve ser a sigla da UF).");

            RuleFor(v => v.CidadeTrabalho)
                .NotEmpty().WithMessage("A cidade de trabalho da vaga nao pode ficar em branco.")
                .MinimumLength(2).WithMessage("A cidade de trabalho da vaga deve ter pelo menos 2 caracteres.")
                .MaximumLength(200).WithMessage("A cidade de trabalho da vaga deve ter ate 100 caracteres.");

            RuleFor(v => v.EmailContato)
                .NotEmpty().WithMessage("O email para contato nao pode ficar em branco.")
                .EmailAddress().WithMessage("Informe um email valido para contato.")
                .MaximumLength(50).WithMessage("O email para contato deve ter ate 50 caracteres.");
        }
    }
}