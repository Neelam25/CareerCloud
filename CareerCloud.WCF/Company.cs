using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    public class Company : ICompany
    {
        #region CompanyDescription
        public void AddCompanyDescription(CompanyDescriptionPoco[] items)
        {
            var _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            _logic.Add(items);
        }
        public List<CompanyDescriptionPoco> GetAllCompanyDescription()
        {
            var _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            return _logic.GetAll();
        }
        public CompanyDescriptionPoco GetSingleCompanyDescription(string id)
        {
            var _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveCompanyDescription(CompanyDescriptionPoco[] items)
        {
            var _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateCompanyDescription(CompanyDescriptionPoco[] items)
        {
            var _logic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region CompanyJob
        public void AddCompanyJob(CompanyJobPoco[] items)
        {
            var _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            _logic.Add(items);
        }
        public List<CompanyJobPoco> GetAllCompanyJob()
        {
            var _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            return _logic.GetAll();
        }
        public CompanyJobPoco GetSingleCompanyJob(string id)
        {
            var _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveCompanyJob(CompanyJobPoco[] items)
        {
            var _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateCompanyJob(CompanyJobPoco[] items)
        {
            var _logic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region CompanyJobEducation
        public void AddCompanyJobEducation(CompanyJobEducationPoco[] items)
        {
            var _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            _logic.Add(items);
        }
        public List<CompanyJobEducationPoco> GetAllCompanyJobEducation()
        {
            var _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            return _logic.GetAll();
        }
        public CompanyJobEducationPoco GetSingleCompanyJobEducation(string id)
        {
            var _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveCompanyJobEducation(CompanyJobEducationPoco[] items)
        {
            var _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items)
        {
            var _logic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region CompanyJobSkill
        public void AddCompanyJobSkill(CompanyJobSkillPoco[] items)
        {
            var _logic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            _logic.Add(items);
        }
        public List<CompanyJobSkillPoco> GetAllCompanyJobSkill()
        {
            var _logic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            return _logic.GetAll();
        }
        public CompanyJobSkillPoco GetSingleCompanyJobSkill(string id)
        {
            var _logic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveCompanyJobSkill(CompanyJobSkillPoco[] items)
        {
            var _logic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateCompanyJobSkill(CompanyJobSkillPoco[] items)
        {
            var _logic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region CompanyJobDescription
        public void AddCompanyJobDescription(CompanyJobDescriptionPoco[] items)
        {
            var _logic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            _logic.Add(items);
        }
        public List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription()
        {
            var _logic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            return _logic.GetAll();
        }
        public CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string id)
        {
            var _logic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] items)
        {
            var _logic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] items)
        {
            var _logic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region CompanyLocation
        public void AddCompanyLocation(CompanyLocationPoco[] items)
        {
            var _logic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            _logic.Add(items);
        }
        public List<CompanyLocationPoco> GetAllCompanyLocation()
        {
            var _logic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            return _logic.GetAll();
        }
        public CompanyLocationPoco GetSingleCompanyLocation(string id)
        {
            var _logic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveCompanyLocation(CompanyLocationPoco[] items)
        {
            var _logic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateCompanyLocation(CompanyLocationPoco[] items)
        {
            var _logic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region CompanyProfile
        public void AddCompanyProfile(CompanyProfilePoco[] items)
        {
            var _logic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
            _logic.Add(items);
        }
        public List<CompanyProfilePoco> GetAllCompanyProfile()
        {
            var _logic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
            return _logic.GetAll();
        }

        public CompanyProfilePoco GetSingleCompanyProfile(string id)
        {
            var _logic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveCompanyProfile(CompanyProfilePoco[] items)
        {
            var _logic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
            _logic.Delete(items);
        }
        public void UpdateCompanyProfile(CompanyProfilePoco[] items)
        {
            var _logic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
            _logic.Update(items);
        }
        #endregion
    }
}
