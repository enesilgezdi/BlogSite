using BlogSite.Models.Entities;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Repository.Repositories.Abstracts;

public interface ICommentRepository : IRepository<Comment, Guid>
{
  


}
