using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.General.Command
{
    public class HelloCommand : IRequest<string>
    {
        public string Name { get; set; } = null!;

    }
}
