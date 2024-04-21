using System;
namespace Articium.Services.Models
{
	public class ArticleRequestModel
	{
        public string Title { get; set; }
        public string Author { get; set; }
        public string ArticleContent { get; set; }
        public int StarCount { get; set; }
    }
}

