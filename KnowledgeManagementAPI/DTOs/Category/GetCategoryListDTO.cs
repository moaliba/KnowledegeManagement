﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeManagementAPI.DTOs.Category
{
    public class GetCategoryListDTO : FilterModelBase
    {
        public string TeamTitle { get; set; }

        public GetCategoryListDTO() : base()
        => PageSize = 10;
    }
}