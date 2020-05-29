using Models.Band;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBandServices
    {
        void CreateBand(BandCreateModel band);
        IEnumerable<BandListModel> GetAllBands();
        BandDetailModel GetBandById(int bandId);
        void UpdateBand(BandUpdateModel band);
        void DeleteBand(int bandId);
    }
}
