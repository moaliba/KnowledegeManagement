﻿using QueryHandling.Abstractions;
using ReadModels.Query.Post;
using ReadModels.ViewModel.Post;
using System.Linq;
using System.Threading.Tasks;
using LinqKit;
using ReadModels.ViewModel;
//using Microsoft.EntityFrameworkCore;

namespace ReadModels.QueryHandler.Post
{
    public class GetPostQueryHandler : IHandleQuery<GetPostQuery, PagedViewModel<PostViewModel>>
    {
        private readonly IReadDbContext readDbContext;
        public GetPostQueryHandler(IReadDbContext readDbContext)
        => this.readDbContext = readDbContext;

        Task<PagedViewModel<PostViewModel>> IHandleQuery<GetPostQuery, PagedViewModel<PostViewModel>>.Handle(GetPostQuery query)
        {
            string[] Tags = (query.Tags ?? string.Empty).Split(new char[',']);
            IQueryable<PostViewModel> TotalItems = readDbContext.PostViewModels.AsQueryable();
            if (!string.IsNullOrEmpty(query.PostTitle))
                TotalItems = TotalItems.Where(c => c.PostContent.Contains(query.PostTitle));
            if (query.CategoryId != null)
                TotalItems = TotalItems.Where(c => c.CategoryID == query.CategoryId);

            var predicate = PredicateBuilder.New<PostViewModel>();
            foreach (string tag in Tags)
                predicate = predicate.Or(x => x.Tags.Contains(tag));

            TotalItems = TotalItems.Where(predicate);
            //var sql = TotalItems.ToQueryString();
            switch (query.SortOrder)
            {
                case "PostTitle":
                    TotalItems = TotalItems.OrderBy(t => t.PostTitle);
                    break;
                case "PostTitle_desc":
                    TotalItems = TotalItems.OrderByDescending(t => t.PostTitle);
                    break;
                default:
                    break;
            }

            var totalRecords = TotalItems.Count();
            var result = PagingUtility.Paginate(query.PageNumber, query.PageSize, TotalItems);
            return Task.FromResult(result);
        }
    }
}
