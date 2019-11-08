using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_UWP.Entity;

namespace Assignment_UWP.Service
{
    interface IMemberService
    {
        Member Register(Member member);

        MemberCredential Login(MemberLogin memberLogin);

        Member GetInformation(string token);
    }
}
