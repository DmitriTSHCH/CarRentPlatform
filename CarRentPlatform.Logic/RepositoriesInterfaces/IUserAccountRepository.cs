using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserAccountRepository
    {
        public Task<bool> AddAsync(UserAccount userAccount, CancellationToken cancellationToken = default);
        public Task<bool> UpdatePasswordAsync(Guid userId, string hashedPassword, CancellationToken cancellationToken = default);
        public Task<string?> UpdatePhoneNumberAsync(Guid userId, string phoneNumber, CancellationToken cancellationToken = default);
        public Task<string?> UpdateEmailAsync(Guid userId, string email, CancellationToken cancellationToken = default);
        public Task<string?> GetPhoneNumberByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<string?> GetEmailByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<Guid?> GetIdByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default);
        public Task<Guid?> GetIdByEmailAsync(string email, CancellationToken cancellationToken = default);
        public Task<string?> GetHashedPasswordAsync(string? phoneNumber, string? email, CancellationToken cancellationToken = default);
    }
}
