using Caelum.Stella.CSharp.Format;
using Caelum.Stella.CSharp.Validation;
using System.ComponentModel.DataAnnotations;

namespace CastraBus.Application.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class CNPJAttributeValidation : ValidationAttribute
    {
        private String CNPJ { get; set; }

        private CNPJFormatter Formatter { get; set; }

        public CNPJAttributeValidation() { this.Formatter = new CNPJFormatter(); }

        public CNPJAttributeValidation(String CNPJ)
        {
            this.CNPJ = CNPJ;
            this.Formatter = new CNPJFormatter();
        }

        public override bool IsValid(object value)
        {
            this.CNPJ = this.Formatter.Unformat(value.ToString());
            return new CNPJValidator().IsValid(this.CNPJ);
        }
    }
}
