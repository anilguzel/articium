using System;
using Microsoft.Extensions.DependencyInjection;

namespace Articium.Services
{
	public static class DependencyRegister
    {
		public static void AddArticleService(this IServiceCollection services)
		{
			services.AddScoped<IArticleService, ArticleService>();
		}
		public static void AddReviewService(this IServiceCollection services)
		{
			services.AddScoped<IReviewService, ReviewService>();
		}
		public static void AddUserService(this IServiceCollection services)
		{
			services.AddScoped<IUserService, UserService>();
		}
	}
}

