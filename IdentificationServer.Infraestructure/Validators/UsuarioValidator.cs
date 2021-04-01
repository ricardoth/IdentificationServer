using FluentValidation;
using IdentificationServer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioValidator()
        {
            RuleFor(perfl => perfl.Nombre)
                .NotNull()
                .WithMessage("El Nombre no puede ser nulo");
            RuleFor(perfl => perfl.Nombre)
                .Length(3, 50)
                .WithMessage("Debe ser entre 3 y 50 caractéres");
        }
    }
}
