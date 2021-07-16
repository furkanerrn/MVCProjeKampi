using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail boş bırakılamaz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı minimum 3 karakter uzunluğunda olmalı");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("Mesaj minimum 3 karakter uzunluğunda olmalı");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz");
            RuleFor(x => x.Message).MaximumLength(20).WithMessage("Mesaj en fazla 50 karakter olmalı");
            RuleFor(x=>x.Message).NotEmpty().WithMessage("Mesaj boş bırakılamaz");



        }
    }
}
