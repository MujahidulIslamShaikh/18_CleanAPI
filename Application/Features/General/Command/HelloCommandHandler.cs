using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.General.Command
{
    public class HelloCommandHandler : IRequestHandler<HelloCommand, string>
    {
       
        public Task<string> Handle(HelloCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult($"Assalamu Alaikum   {request.Name}");
        }


    }


}
