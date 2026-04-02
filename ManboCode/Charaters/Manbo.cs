using BaseLib.Abstracts;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.PotionPools;
using MegaCrit.Sts2.Core.Models.RelicPools;
using MoeNegiMod.Manbo.Extensions;
using MoeNegiMod.Manbo.Cards;
using System;

namespace MoeNegiMod.Manbo.Character;

public class Manbo : PlaceholderCharacterModel
{
	public const string CharacterId = "Manbo";

	//public override string CustomCharacterSelectBg => "res://Selphina/Scenes/Char_Select/char_select_bg_selphina.tscn";

	public override string PlaceholderID => "necrobinder";

	public static readonly Color Color = new Color("c4278a");

	public override Color NameColor => Color;
	public override CharacterGender Gender => CharacterGender.Feminine;
	public override int StartingHp => 70;

	public override IEnumerable<CardModel> StartingDeck => [
		ModelDb.Card<ManboAttack>(),
		ModelDb.Card<ManboAttack>(),
		ModelDb.Card<ManboBlock>()
	];

	public override IReadOnlyList<RelicModel> StartingRelics => new List<RelicModel> { ModelDb.GetById<RelicModel>(new ModelId("RELIC", "BURNING_BLOOD")) }.AsReadOnly();

	public override CardPoolModel CardPool => ModelDb.CardPool<ManboCardPool>();
	public override RelicPoolModel RelicPool => ModelDb.RelicPool<SharedRelicPool>();
	public override PotionPoolModel PotionPool => ModelDb.PotionPool<SharedPotionPool>();

	/*  PlaceholderCharacterModel will utilize placeholder basegame assets for most of your character assets until you
		override all the other methods that define those assets.
		These are just some of the simplest assets, given some placeholders to differentiate your character with.
		You don't have to, but you're suggested to rename these images. */
	public override string CustomVisualPath => "res://Manbo/Scenes/ManboVisual.tscn";
	public override string CustomIconTexturePath => "character_icon_char_name.png".CharacterUiPath();
	public override string CustomCharacterSelectIconPath => "char_select_char_name.png".CharacterUiPath();
	public override string CustomCharacterSelectLockedIconPath => "char_select_char_name_locked.png".CharacterUiPath();
	public override string CustomMapMarkerPath => "map_marker_char_name.png".CharacterUiPath();
}
