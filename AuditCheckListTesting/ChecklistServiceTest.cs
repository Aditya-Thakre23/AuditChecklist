using AuditChecklistModule.Models;
using AuditChecklistModule.Repository;
using AuditChecklistModule.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuditCheckListTesting
{
    class ChecklistServiceTest
    {
        List<Questions> l1 = new List<Questions>();
        List<Questions> l2 = null;
        [SetUp]
        public void setup()
        {

            l1 = new List<Questions>()
            {
                new Questions
                {
                    QuestionNo=1,
                    Question="Have all Change requests followed SDLC before PROD move?"
                },
                new Questions
                {
                    QuestionNo=2,
                    Question="Have all Change requests been approved by the application owner?"
                },
                new Questions
                {
                    QuestionNo=3,
                    Question="Is data deletion from the system done with application owner approval?"
                }


            };
        }

        [TestCase("Internal")]
        [TestCase("SOX")]
        public void GetQuestionList_ValidInput_ReturnsQuestionList(string type)
        {
            Mock<IChecklistRepo> mock = new Mock<IChecklistRepo>();
            mock.Setup(p => p.GetQuestions(type)).Returns(l1);
            ChecklistService cp = new ChecklistService(mock.Object);
            List<Questions> result = cp.GetQuestionList(type);
            Assert.AreEqual(3, result.Count);
        }

        [TestCase("Internalab")]
        [TestCase("SOXab")]
        public void GetQuestions_InvalidInput_ReturnBadRequest(string a)
        {
           
                
                Mock<IChecklistRepo> mock = new Mock<IChecklistRepo>();
                mock.Setup(p => p.GetQuestions(a)).Returns(l2);
                ChecklistService cp = new ChecklistService(mock.Object);
                List<Questions> result = cp.GetQuestionList(a);
                Assert.AreEqual(null, result);
            
            

        }

    }
}
