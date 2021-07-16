using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Yazar adı adı boş bırakılamaz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Soyad boş bırakılamaz.");
            RuleFor(x => x.AboutWriter).NotEmpty().WithMessage("Yazar bilgisi boş bırakılamaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail boş bırakılamaz");
            //RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan Boş bırakılamaz");
            RuleFor(x => x.WriterPassword).MinimumLength(4).WithMessage("Şifre minimum 4 haneli olmalıdır");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre kısmı boş bırakılamaz");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Soyad en az 3 karakterden oluşmalı");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olmalıdır");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan kısmı boş bırakılamaz");
        }
      
    }
}
