using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeManagementAPI
{
    public delegate IUnitOfWork ServiceResolver(string key);
}
