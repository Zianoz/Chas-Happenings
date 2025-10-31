using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilitys_Helpers
{
    internal class VerifierUtility
    {
        public static bool VerifyResponse(int response)
        {
            if(response>0)
            {
                return true;
            }
            return false;
        }
        public static T VerifyObject<T>(T? databaseObject) where T: class
        {
            if(databaseObject==null)
            {
                throw new InvalidDataException($"Database operation failed, repo returned: {databaseObject} ");
            }
            return databaseObject;
        }
        public static int VerifyResponeReturnId((int response, int id)repoResponse)
        {
            if(repoResponse.response>0)
            {
                return repoResponse.id;
            }
            throw new InvalidDataException($"Database operation failed, no user was changed");
        }
    }
}
