using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.SearchBySubjectOrTags
{
    public class SearchNewsBySubjectOrTagsQuery : IRequest<List<SearchNewsViewModel>>
    {
        public string SearchText {  get; set; }

        public SearchNewsBySubjectOrTagsQuery()
        {
        }

        public SearchNewsBySubjectOrTagsQuery(string searchText)
        {
            SearchText = searchText;
        }
    }
}
