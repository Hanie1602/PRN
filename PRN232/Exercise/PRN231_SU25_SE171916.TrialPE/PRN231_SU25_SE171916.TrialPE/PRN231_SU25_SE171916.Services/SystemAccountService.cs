﻿using PRN231_SU25_SE171916.Repositories.Models;

namespace PRN231_SU25_SE171916.Services
{
    public class SystemAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SystemAccountService() => _unitOfWork ??= new UnitOfWork();

        public async Task<SystemAccount> GetUserAccount(string email, string password)
        {
            return await _unitOfWork.SystemAccountRepository.GetUserAccount(email, password);
        }
    }
}
