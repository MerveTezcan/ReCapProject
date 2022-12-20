﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(1995);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Description).Must(StartWithA).WithMessage("Ürünler C harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("C");
        }
    }
}
