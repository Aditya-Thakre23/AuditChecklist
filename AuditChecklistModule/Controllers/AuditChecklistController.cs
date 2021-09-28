using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditChecklistModule.Models;
using AuditChecklistModule.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditChecklistModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditChecklistController : ControllerBase
    {

        private IChecklistService checklistServiceObj;
        private readonly log4net.ILog logs;

        public AuditChecklistController(IChecklistService checklistServiceObj)
        {
            logs = log4net.LogManager.GetLogger(typeof(AuditChecklistController));
            this.checklistServiceObj = checklistServiceObj;
        }

        [HttpGet]
        public IActionResult GetAuditCheckListQuestions([FromBody]string auditType)
        {
            logs.Info("AuditChecklistController Http GET request called" + nameof(AuditChecklistController));

            if (string.IsNullOrEmpty(auditType))
                return BadRequest("No Input");
            else if ((auditType != "Internal") && (auditType != "SOX"))
                return Ok("Wrong Input");
            else
            {
                try
                {
                    List<Questions> list = checklistServiceObj.GetQuestionList(auditType);
                    return Ok(list);
                }
                catch (Exception e)
                {
                    logs.Error("Exception " + e.Message + nameof(AuditChecklistController));

                    return StatusCode(500);
                }
            }
        }
    }
}
