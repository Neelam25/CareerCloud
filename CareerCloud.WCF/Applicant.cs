﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    public class Applicant : IApplicant
    {
        #region ApplicantEducation
        public void AddApplicantEducation(ApplicantEducationPoco[] items)
        {
            var _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            _logic.Add(items);
        }
        public List<ApplicantEducationPoco> GetAllApplicantEducation()
        {
            var _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            return _logic.GetAll();
        }
        public ApplicantEducationPoco GetSingleApplicantEducation(string id)
        {
            var _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }

        public void RemoveApplicantEducation(ApplicantEducationPoco[] items)
        {
            var _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateApplicantEducation(ApplicantEducationPoco[] items)
        {
            var _logic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            _logic.Update(items);
        }

        #endregion

        #region ApplicantJobApplication
        public void AddApplicantJobApplication(ApplicantJobApplicationPoco[] items)
        {
            var _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            _logic.Add(items);
        }
        public List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication()
        {
            var _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            return _logic.GetAll();
        }

        public ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string id)
        {
            var _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
       
        public void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] items)
        {
            var _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items)
        {
            var _logic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region ApplicantProfile
        public void AddApplicantProfile(ApplicantProfilePoco[] items)
        {
            var _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            _logic.Add(items);
        }
        public List<ApplicantProfilePoco> GetAllApplicantProfile()
        {
            var _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            return _logic.GetAll();
        }

        public ApplicantProfilePoco GetSingleApplicantProfile(string id)
        {
            var _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveApplicantProfile(ApplicantProfilePoco[] items)
        {
            var _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            _logic.Delete(items);
        }
        public void UpdateApplicantProfile(ApplicantProfilePoco[] items)
        {
            var _logic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region ApplicantResume
        public void AddApplicantResume(ApplicantResumePoco[] items)
        {
            var _logic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
            _logic.Add(items);
        }
        public List<ApplicantResumePoco> GetAllApplicantResume()
        {
            var _logic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
            return _logic.GetAll();
        }

        public ApplicantResumePoco GetSingleApplicantResume(string id)
        {
            var _logic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
           return _logic.Get(Guid.Parse(id));
        }
        public void RemoveApplicantResume(ApplicantResumePoco[] items)
        {
            var _logic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
            _logic.Delete(items);
        }
        public void UpdateApplicantResume(ApplicantResumePoco[] items)
        {
            var _logic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region ApplicantSkill
        public void AddApplicantSkill(ApplicantSkillPoco[] items)
        {
            var _logic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            _logic.Add(items);
        }
        public List<ApplicantSkillPoco> GetAllApplicantSkill()
        {
            var _logic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            return _logic.GetAll();
        }
        public ApplicantSkillPoco GetSingleApplicantSkill(string id)
        {
            var _logic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveApplicantSkill(ApplicantSkillPoco[] items)
        {
            var _logic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateApplicantSkill(ApplicantSkillPoco[] items)
        {
            var _logic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region AplicantWorkHistory
        public void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
        {
            var _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
            _logic.Add(items);
        }
        public List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory()
        {
            var _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
             return _logic.GetAll();
        }

        public ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string id)
        {
            var _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }

        public void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
        {
            var _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
            _logic.Delete(items);
        }

        public void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
        {
            var _logic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
            _logic.Update(items);
        }
        #endregion
    }
}
