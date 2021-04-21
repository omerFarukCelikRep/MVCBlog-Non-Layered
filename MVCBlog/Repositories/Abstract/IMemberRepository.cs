using MVCBlog.Models.DataAccess.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Repositories.Abstract
{
    public interface IMemberRepository
    {
        bool MemberExists(string email);
        MemberDetail GetMemberWithArticles(int memberID);
        MemberDetailsWithArticlesAndTopics GetMemberDetails(int memberID);
    }
}
