﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UsersValidator))]
        public IResult Add(User user)
        {
            
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
           return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId == userId));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var user = _userDal.Get(u=> u.Email == email);
            if(user == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaim(user));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
