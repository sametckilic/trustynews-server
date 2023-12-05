using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.RequestModels.News.Create
{
    public class CreateNewsCommand : IRequest<Guid>
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string CreatedById { get; set; }

    }
}
