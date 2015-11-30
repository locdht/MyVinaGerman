﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business
{
    public interface IArticleBL
    {
        List<ArticleEntity> SearchArticle(ArticleSearchEntity searchObject);
        ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject);
        bool DeleteArticle(ArticleEntity entityObject);
    }
}
