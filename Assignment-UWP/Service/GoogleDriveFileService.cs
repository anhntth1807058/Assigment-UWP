using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_UWP.Entity;

namespace Assignment_UWP.Service
{
    class GoogleDriveFileService: IFileService
    {
        public Task<bool> SaveMemberCredentialToFile(MemberCredential memberCredential)
        {
            throw new NotImplementedException();
        }

        public Task<MemberCredential> ReadMemberCredentialFromFile()
        {
            throw new NotImplementedException();
        }
    }
}
