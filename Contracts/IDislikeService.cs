using Models.Dislike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDislikeService
    {
        void CreateDislike(CreateDislikeModel dislike);
        IEnumerable<ListDislikeModel> ListDislikes();
        void DeleteDislike(DeleteDislikeModel dislike);
    }
}
