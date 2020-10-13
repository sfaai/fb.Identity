using IdentityLibrary.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace IdentityLibrary
{
    internal class UserRolesRepository
    {
        private readonly IdentityModels _databaseContext;
        

        public UserRolesRepository(IdentityModels database)
        {
            _databaseContext = database;
        }

        /// <summary>
        /// Returns a list of user's roles
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public IList<string> FindByUserId(string userId)
        {
            var roles = _databaseContext.ASPNETUSERS.
                Where(u => u.ID == userId).SelectMany(r => r.ASPNETROLES);
            return roles.Select(r => r.NAME).ToList();
        }

        internal int Insert(string User, string Role)
        {
            // ASPNETUSERROLES is not map correctly hence unable to save without touch database
            // hence the current hack
            //ASPNETROLE cRec = new ASPNETROLE();
            //{

            //};
            //_databaseContext.ASPNETROLES.Add(cRec);

            //return _databaseContext.SaveChanges();
            return 0;
        }
    }
}