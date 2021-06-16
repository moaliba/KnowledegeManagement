using Microsoft.EntityFrameworkCore;
using ReadModels.DomainModel.Document;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Post;
using ReadModels.ViewModel.PostAttachment;
using ReadModels.ViewModel.Tag;
using ReadModels.ViewModel.Team;

namespace ReadModels
{
    public interface IReadDbContext
    {
        public DbSet<TeamViewModel> TeamViewModels { get; set; }
        public DbSet<TagViewModel> TagViewModels { get; set; }
        public DbSet<CategoryViewModel> CategoryViewModels { get; set; }
        public DbSet<PostViewModel> PostViewModels { get; set; }
        public DbSet<PostAttachmentViewModel> PostAttachmentViewModels { get; set; }
        public DbSet<DocumentView> DocumentView { get; set; }
    }
}
