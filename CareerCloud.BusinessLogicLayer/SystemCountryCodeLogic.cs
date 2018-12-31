using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic :SystemCountryCodePoco    {
        protected IDataRepository<SystemCountryCodePoco> _repository;
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
        {
            _repository = repository;
        }
        public void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }
        public void Update(SystemCountryCodePoco[] pocos)
        {
             Verify(pocos);
            _repository.Update(pocos);
        }
        public void GetAll()
        {

        }
        public void Get()
        {

        }
        public void Delete()
        {

        }
        protected void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(SystemCountryCodePoco item in pocos)
            {
                if (string.IsNullOrEmpty(item.Code))
                {
                    exceptions.Add(new ValidationException(900,$"SystemCountryCodePoco {item.Code} can not be empty."));
                }
                if (string.IsNullOrEmpty(item.Code))
                {
                    exceptions.Add(new ValidationException(901, $"Name for SystemCountryCodePoco {item.Code} can not be empty."));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
