using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using Godot;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Logging;
using MoeNegiMod.Manbo.Character;
using MoeNegiMod.Manbo.Extensions;

namespace MoeNegiMod.Manbo.Cards;

[Pool(typeof(ManboCardPool))]
public abstract class ManboCard(int cost, CardType type, CardRarity rarity, TargetType target) :
	CustomCardModel(cost, type, rarity, target)
{
	//Image size:
	//Normal art: 1000x760 (Using 500x380 should also work, it will simply be scaled.)
	//Full art: 606x852
	public override string CustomPortraitPath
	{
		get
		{
			var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();
			Log.Info(">>>[ManboMod]CardPath=" + path, 2);
			return ResourceLoader.Exists(path) ? path : "card.png".CardImagePath();
		}
	}

	//Smaller variants of card images for efficiency:
	//Smaller variant of fullart: 250x350
	//Smaller variant of normalart: 250x190

	//Uses card_portraits/card_name.png as image path. These should be smaller images.
	public override string PortraitPath
	{
		get
		{
			var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();
			Log.Info(">>>[ManboMod]CardPath=" + path, 2);
			return ResourceLoader.Exists(path) ? path : "card.png".CardImagePath();
		}
	}

	//Optional and I'm not sure it's functional yet.
	public override string BetaPortraitPath
	{
		get
		{
			var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();
			Log.Info(">>>[ManboMod]CardPath=" + path, 2);
			return ResourceLoader.Exists(path) ? path : "card.png".CardImagePath();
		}
	}
}
