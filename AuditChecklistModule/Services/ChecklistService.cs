using AuditChecklistModule.Models;
using AuditChecklistModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Service
{
    public class ChecklistService : IChecklistService
    {
        private IChecklistRepo checklistRepoObj;
        private log4net.ILog logs;
        public ChecklistService(IChecklistRepo checklistRepoObj)
        {
            this.checklistRepoObj = checklistRepoObj;
            logs = log4net.LogManager.GetLogger(typeof(ChecklistService));
        }
        List<Questions> ListOfQuestions = new List<Questions>();

        public List<Questions> GetQuestionList(string auditType)
        {
            logs.Info(" Http GET request called" + nameof(ChecklistService));
            ListOfQuestions = checklistRepoObj.GetQuestions(auditType);
            return ListOfQuestions;
        }
    }
}
