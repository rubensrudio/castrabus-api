using Caelum.Stella.CSharp.Format;
using Caelum.Stella.CSharp.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class CPFAttributeValidation : ValidationAttribute
    {
        private String CPF { get; set; }

        private CPFFormatter Formatter { get; set; }

        public CPFAttributeValidation() { this.Formatter = new CPFFormatter(); }

        public CPFAttributeValidation(String CPF)
        {
            this.CPF = CPF;
            this.Formatter = new CPFFormatter();
        }

        public override bool IsValid(object value)
        {
            this.CPF = this.Formatter.Unformat(value.ToString());
            return new CPFValidator().IsValid(this.CPF);
        }
    }
}
