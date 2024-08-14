using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.TagClouds.Results
{
    public class TagCloudWithBlogsQueryResult
    {
        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
        public List<string> BlogTitles { get; set; }
    }
}
