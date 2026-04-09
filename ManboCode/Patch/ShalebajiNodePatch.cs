using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Context;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Nodes.Combat;
using System;
using System.Reflection.Metadata;

[HarmonyPatch(typeof(NCombatUi), "_Ready")]

public static class ShalebajiNodePatch
{
	private static Control _cachedShalebajiNode;
	public static void Postfix(NCombatUi __instance)
	{
		var old = __instance.GetNodeOrNull<Control>("ShalebajiNode");
		if (old == null)
		{
			_cachedShalebajiNode = GD.Load<PackedScene>("res://Manbo/Scenes/ShalebajiNode.tscn").Instantiate<Control>();
			_cachedShalebajiNode.Name = "ShalebajiNode";
			__instance.EnergyCounterContainer.AddChild(_cachedShalebajiNode, false);
		}
	}
	public static Control GetCachedShalebajiNode() => _cachedShalebajiNode;
}

[HarmonyPatch(typeof(NCombatUi), "Activate")]

public static class ShalebajiNodeActivatePatch
{
    public static void Postfix(CombatState state)
    {
		Player player = LocalContext.GetMe(state);
        Log.Info(">>>[ManboMod]Character.Id is " + player.Character.Id.ToString());
        if (player.Character.Id.ToString() == "CHARACTER.MOENEGIMOD-MANBO")
        {
            ShalebajiNodePatch.GetCachedShalebajiNode().Visible = true;
        }
    }
}