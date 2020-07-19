using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ui.ranks.mvp {
    public interface RanksView {
        void setRanks(List<Rank> ranks, Rank userRank);
    }

    public interface RanksPresenter {
        void getRanks();
    }

}
