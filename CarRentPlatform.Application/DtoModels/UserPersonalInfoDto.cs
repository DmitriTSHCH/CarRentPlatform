using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentPlatform.Application.DtoModels
{
    public class UserPersonalInfoDto
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public RoleNameId RoleNameId { get; set; }
        public DateTime DateTimeCreation { get; private set; } = DateTime.UtcNow;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PassportNumber { get; private set; }
        public string DriverLicenseNumber { get; private set; }
        public DriverLicenseCategoryFlags DriverLicenseCategory { get; private set; }
        public DateOnly LicenseExpirationDate { get; private set; }
        public bool IsVerified { get; private set; }
        public UserStatus UserStatus { get; private set; }
        public decimal Rating { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public UserPersonalInfoDto(Guid userId, RoleNameId roleNameId, DateTime dateTimeCreation, string firstName,
                                   string lastName, string passportNumber, string driverLicenseNumber,
                                   DriverLicenseCategoryFlags driverLicenseCategory, DateOnly licenseExpirationDate,
                                   bool isVerified, UserStatus userStatus, decimal rating, string email,
                                   string phoneNumber)
        {
        }

        public UserPersonalInfoDto(User user, string email, string phoneNumber)
        {
            UserId = user.UserId;
            RoleNameId = user.RoleNameId;
            DateTimeCreation = DateTimeCreation;
            FirstName = user.UserDocumentsData.FirstName;
            LastName = user.UserDocumentsData.LastName;
            PassportNumber = user.UserDocumentsData.PassportNumber;
            DriverLicenseNumber = user.UserDocumentsData.DriverLicenseNumber;
            DriverLicenseCategory = user.UserDocumentsData.DriverLicenseCategory;
            LicenseExpirationDate = user.UserDocumentsData.LicenseExpirationDate;
            IsVerified = user.UserCondition.IsVerified;
            UserStatus = user.UserCondition.UserStatus;
            Rating = user.UserCondition.Rating;
            Email = email;
            PhoneNumber = phoneNumber;

        }
    }
}
