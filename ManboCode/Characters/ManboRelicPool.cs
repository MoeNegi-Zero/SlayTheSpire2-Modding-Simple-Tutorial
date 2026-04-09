using BaseLib.Abstracts;
using Godot;
using MoeNegiMod.Manbo.Character;
using System;

namespace MoeNegiMod.Manbo.Character;

public partial class ManboRelicPool : CustomRelicPoolModel
{
    public override string EnergyColorName => Manbo.CharacterId;

    public override Color LabOutlineColor => Manbo.Color;
}
