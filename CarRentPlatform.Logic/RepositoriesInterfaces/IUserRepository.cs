using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        public void Add(User user);
        public void Update(Guid userId, UserDocumentsData? UserDocumentsData, string? hashedPassword, string? phoneNumber, string? email, bool? isVerified, UserStatus? userStatus, decimal? rating);
        public void UpdatePassword(Guid userId, string hashedPassword);
        public void UpdatePhoneNumber(Guid userId, string phoneNumber);
        public void UpdateEmail(Guid userId, string email);
        public void UpdateRating(Guid userId, decimal rating);
        public void UpdateStatus(Guid userId, UserStatus userStatus);
        public User GetById (Guid userId);

    }
}
