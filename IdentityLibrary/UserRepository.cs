using IdentityLibrary.DataModel;
using System;
using System.Linq;

namespace IdentityLibrary
{
    public class UserRepository<T> where T : IdentityUser
    {
        private readonly IdentityModels _databaseContext;

        public UserRepository(IdentityModels databaseContext)
        {
            _databaseContext = databaseContext;
        }

        internal T GeTByName(string userName)
        {
            var user = _databaseContext.ASPNETUSERS.SingleOrDefault(u => u.USERNAME == userName);
            if (user != null)
            {
                T result = (T)Activator.CreateInstance(typeof(T));
                result.Id = user.ID;
                result.UserName = user.USERNAME;
                result.PasswordHash = user.PASSWORDHASH;
                result.SecurityStamp = user.SECURITYSTAMP;
                result.Email = user.EMAIL;
                result.EmailConfirmed = user.EMAILCONFIRMED == "Y";
                result.PhoneNumber = user.PHONENUMBER;
                result.PhoneNumberConfirmed = user.PHONENUMBERCONFIRMED == "Y";
                result.LockoutEnabled = user.LOCKOUTENABLED == "Y";
                result.LockoutEndDateUtc = user.LOCKOUTENDDATEUTC;
                result.AccessFailedCount = user.ACCESSFAILEDCOUNT;
                return result;
            }
            return null;
        }

        internal T GeTByEmail(string email)
        {
            var user = _databaseContext.ASPNETUSERS.SingleOrDefault(u => u.EMAIL == email);
            if (user != null)
            {
                T result = (T)Activator.CreateInstance(typeof(T));

                result.Id = user.ID;
                result.UserName = user.USERNAME;
                result.PasswordHash = user.PASSWORDHASH;
                result.SecurityStamp = user.SECURITYSTAMP;
                result.Email = user.EMAIL;
                result.EmailConfirmed = user.EMAILCONFIRMED == "Y";
                result.PhoneNumber = user.PHONENUMBER;
                result.PhoneNumberConfirmed = user.PHONENUMBERCONFIRMED == "Y";
                result.LockoutEnabled = user.LOCKOUTENABLED == "Y";
                result.LockoutEndDateUtc = user.LOCKOUTENDDATEUTC;
                result.AccessFailedCount = user.ACCESSFAILEDCOUNT;
                return result;
            }
            return null;
        }

        internal int Insert(T user)
        {
            ASPNETUSER cRec = new ASPNETUSER
            {
                ID = user.Id,
                USERNAME = user.UserName,
                PASSWORDHASH = user.PasswordHash,
                SECURITYSTAMP = user.SecurityStamp,
                EMAIL = user.Email,
                EMAILCONFIRMED = user.EmailConfirmed ? "Y" : "N",
                PHONENUMBER = user.PhoneNumber,
                PHONENUMBERCONFIRMED = user.PhoneNumberConfirmed ? "Y" : "N",
                LOCKOUTENABLED = user.LockoutEnabled ? "Y" : "N",
                LOCKOUTENDDATEUTC = user.LockoutEndDateUtc,
                ACCESSFAILEDCOUNT = user.AccessFailedCount,
                TWOFACTORENABLED = user.TwoFactorEnabled ? "Y" : "N"
            };
            _databaseContext.ASPNETUSERS.Add(cRec);

            return _databaseContext.SaveChanges();
        }

        /// <summary>
        /// Returns an T given the user's id
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public T GeTById(string userId)
        {
            var user = _databaseContext.ASPNETUSERS.Find(userId);
            T result = (T)Activator.CreateInstance(typeof(T));

            result.Id = user.ID;
            result.UserName = user.USERNAME;
            result.PasswordHash = user.PASSWORDHASH;
            result.SecurityStamp = user.SECURITYSTAMP;
            result.Email = user.EMAIL;
            result.EmailConfirmed = user.EMAILCONFIRMED == "Y";
            result.PhoneNumber = user.PHONENUMBER;
            result.PhoneNumberConfirmed = user.PHONENUMBERCONFIRMED == "Y";
            result.LockoutEnabled = user.LOCKOUTENABLED == "Y";
            result.LockoutEndDateUtc = user.LOCKOUTENDDATEUTC;
            result.AccessFailedCount = user.ACCESSFAILEDCOUNT;
            return result;
        }

        /// <summary>
        /// Return the user's password hash
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public string GetPasswordHash(string userId)
        {
            var user = _databaseContext.ASPNETUSERS.FirstOrDefault(u => u.ID == userId);
            var passHash = user != null ? user.PASSWORDHASH : null;
            return passHash;
        }

        /// <summary>
        /// Updates a user in the Users table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Update(T user)
        {
            var result = _databaseContext.ASPNETUSERS.FirstOrDefault(u => u.ID == user.Id);
            if (result != null)
            {
                result.USERNAME = user.UserName;
                result.PASSWORDHASH = user.PasswordHash;
                result.SECURITYSTAMP = user.SecurityStamp;
                result.EMAIL = user.Email;
                result.EMAILCONFIRMED = user.EmailConfirmed ? "Y":"N";
                result.PHONENUMBER = user.PhoneNumber;
                result.PHONENUMBERCONFIRMED = user.PhoneNumberConfirmed ? "Y":"N";
                result.LOCKOUTENABLED = user.LockoutEnabled? "Y":"N";
                result.LOCKOUTENDDATEUTC = user.LockoutEndDateUtc;
                result.ACCESSFAILEDCOUNT = user.AccessFailedCount;
                return _databaseContext.SaveChanges();
            }
            return 0;
        }

        public int Delete(T user)
        {
            var result = _databaseContext.ASPNETUSERS.FirstOrDefault(u => u.ID == user.Id);
            if (result != null)
            {
                _databaseContext.ASPNETUSERS.Remove(result);
                return _databaseContext.SaveChanges();
            }
            return 0;
        }
    }
}