using BaseLib.Utils;
using Godot;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Nodes.Combat;
using MegaCrit.Sts2.Core.ValueProps;
using MoeNegiMod.Manbo.Powers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoeNegiMod.Manbo.Cards;

public class ManboRelly() : ManboCard(1,
	CardType.Skill, CardRarity.Common,
	TargetType.Self)
{
    protected override bool ShouldGlowGoldInternal => (Owner.Creature.GetPower<RellyPower>()?.Amount??0) >= 5m;

	protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("RellyPower",5m), new PowerVar<StrengthPower>(5m)];


	protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
	{
		if(ShouldGlowGoldInternal)
		{
            await PowerCmd.Apply<RellyPower>(Owner.Creature, -DynamicVars["RellyPower"].BaseValue, Owner.Creature, this);
            await PowerCmd.Apply<StrengthPower>(Owner.Creature, DynamicVars.Strength.BaseValue, Owner.Creature, this);
        }
	}

	protected override void OnUpgrade()
	{
		DynamicVars["RellyPower"].UpgradeValueBy(-2m);
	}
}
