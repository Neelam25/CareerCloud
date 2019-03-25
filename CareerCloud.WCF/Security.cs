using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Security : ISecurity
    {
        #region SecurityLogin
        public void AddSecurityLogin(SecurityLoginPoco[] items)
        {
            var _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            _logic.Add(items);
        }
        public List<SecurityLoginPoco> GetAllSecurityLogin()
        {
            var _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            return _logic.GetAll();
        }
        public SecurityLoginPoco GetSingleSecurityLogin(string id)
        {
            var _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveSecurityLogin(SecurityLoginPoco[] items)
        {
            var _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateSecurityLogin(SecurityLoginPoco[] items)
        {
            var _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region SecurityLoginsLog
        public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            _logic.Add(items);
        }
        public List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog()
        {
            var _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            return _logic.GetAll();
        }
        public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string id)
        {
            var _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            _logic.Delete(items);
        }
        public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region SecurityLoginsRole
        public void AddSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var _logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            _logic.Add(items);

        }
        public List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole()
        {
            var _logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            return _logic.GetAll();
        }
        public SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string id)
        {
            var _logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var _logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            _logic.Delete(items);
        }
        public void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var _logic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            _logic.Update(items);
        }
        #endregion

        #region SecurityRole
        public void AddSecurityRole(SecurityRolePoco[] items)
        {
            var _logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            _logic.Add(items);
        }
        public List<SecurityRolePoco> GetAllSecurityRole()
        {
            var _logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
           return _logic.GetAll();
        }
        public SecurityRolePoco GetSingleSecurityRole(string id)
        {
            var _logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            return _logic.Get(Guid.Parse(id));
        }
        public void RemoveSecurityRole(SecurityRolePoco[] items)
        {
            var _logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            _logic.Delete(items);

        }
        public void UpdateSecurityRole(SecurityRolePoco[] items)
        {
            var _logic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            _logic.Update(items);
        }
        #endregion



















    }
}
