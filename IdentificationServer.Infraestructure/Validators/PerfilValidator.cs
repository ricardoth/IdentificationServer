using FluentValidation;
using IdentificationServer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentificationServer.Infraestructure.Validators
{
    public class PerfilValidator : AbstractValidator<PerfilDto>
    {
        public PerfilValidator()
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
