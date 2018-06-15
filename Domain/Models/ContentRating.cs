using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ContentRating
    {
        public ContentRating()
        {
            Movie = new HashSet<Movie>();
        }

        public byte ContentRatingId { get; set; }
        public string Symbol { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public ICollection<Movie> Movie { get; set; }
    }
}
