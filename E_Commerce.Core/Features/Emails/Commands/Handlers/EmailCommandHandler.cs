using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Emails.Commands.Models;
using E_Commerce.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Emails.Commands.Handlers
{
    public class EmailCommandHandler : ResponseHandler,
        IRequestHandler<SendEmailCommand, Response<string>>
    {
        #region Fields
        private readonly IEmailServices _emailsService;
        #endregion
        #region Constructors
        public EmailCommandHandler(IEmailServices emailsService)
        {
            _emailsService = emailsService;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _emailsService.SendEmail(request.Email, request.Massege, null);
            if (response == "Success")
                return Success<string>("");
            return BadRequest<string>("Send Email Failed");
        }
        #endregion
    }
}
