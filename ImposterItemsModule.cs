using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemAPI;

namespace ImposterItems
{
    public class ImposterItemsModule : ETGModule
    {
        public override void Init()
        {
        }

        public override void Start()
        {
            ItemBuilder.Init();
            LilCrewmate.Init();
            VotingInterface.Init();
            ImpostersKnife.Init();
            ImpostersSidearm.Init();
        }

        public override void Exit()
        {
        }
    }
}
