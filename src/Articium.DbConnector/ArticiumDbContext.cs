using Articium.DbConnector.Models;
using Articium.EventServices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Articium.DbConnector
{
    public class ArticiumDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public ArticiumDbContext(DbContextOptions<ArticiumDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public async Task<bool> SaveChangesAndInvalidateCacheAsync<T>(CancellationToken cancellationToken = default) where T : TEntity
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    var tEntity = entry.Entity as TEntity;
                    if (tEntity is not null)
                        _ = _mediator.Publish(new CacheInvalidationEvent(tEntity.Id.ToString()));
                }
            }

            return result > 0;
        }
    }
}

