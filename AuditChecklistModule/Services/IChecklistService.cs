using AuditChecklistModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Service
{
    public interface IChecklistService
    {
        public List<Questions> GetQuestionList(string auditType);
    }
}
