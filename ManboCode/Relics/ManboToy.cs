using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MoeNegiMod.Manbo.Powers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeNegiMod.Manbo.Relics;

public class ManboToy : ManboRelics
{
    public override RelicRarity Rarity => RelicRarity.Starter;

    public override async Task AfterCurrentHpChanged(Creature creature, decimal delta)
    {
        if (creature == Owner.Creature && delta < 0)
        {
            await PowerCmd.Apply<RellyPower>(Owner.Creature, 2m, Owner.Creature, null);
        }
    }
}