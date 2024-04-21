using System;
namespace Articium.Services.Models
{
	public class ReviewRequestModel
	{
        public Guid ArticleId { get; set; }
        public string Reviewer { get; set; }
        public string ReviewContent { get; set; }
    }
}

