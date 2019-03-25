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
    public class System : ISystem
    {
        #region SystemCountryCode
        public void AddSystemCountryCode(SystemCountryCodePoco[] item)
        {
            var _logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            _logic.Add(item);
        }
        public List<SystemCountryCodePoco> GetAllSystemCountryCode()
        {
            var _logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            return _logic.GetAll();
        }
        public SystemCountryCodePoco GetSingleSystemCountryCode(string code)
        {
            var _logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            return  _logic.Get(code);
        }
        
        public void RemoveSystemCountryCode(SystemCountryCodePoco[] items)
        {
            var _logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            _logic.Delete(items);
        }
        public void UpdateSystemCountryCode(SystemCountryCodePoco[] items)
        {
            var _logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region SystemLanguageCode
        public void AddSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            var _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            _logic.Add(items);
        }
        public List<SystemLanguageCodePoco> GetAllSystemLanguageCode()
        {
            var _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            return _logic.GetAll();
        }
        public SystemLanguageCodePoco GetSingleSystemLanguageCode(string lanugageId)
        {
            var _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            return _logic.Get(lanugageId);
        }
        public void RemoveSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            var _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
             _logic.Delete(items);
        }
        public void UpdateSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            var _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
             _logic.Update(items);
        }
        #endregion
    }
}
