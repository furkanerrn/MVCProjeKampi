using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.SenderMail).NotEmpty().WithMessage("GÖnderen kısmı boş bırakılamaz");
            //RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu 3 karakterden az olamaz");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı boş bırakılamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj boş bırakılamaz");
            RuleFor(x => x.MessageContent).MaximumLength(500).WithMessage("500 karakterden fazla mesaj yazılamaz");
            RuleFor(x => x.ReceiverMail).MaximumLength(50).WithMessage("50 karakterden fazla mesaj yasak");
            RuleFor(x => x.SenderMail).MaximumLength(50).WithMessage("Sender MAil 50 karakteri geçemez");

        }
    }
}
