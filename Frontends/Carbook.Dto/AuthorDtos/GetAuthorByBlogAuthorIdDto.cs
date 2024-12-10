﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Dto.AuthorDtos
{
  public class GetAuthorByBlogAuthorIdDto
    {
        public int BlogId { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
    }
}
