﻿using SoruxBot.SDK.Model.Message.Entity;

namespace SoruxBot.SDK.QQ.Entity;

public class PokeMessage (int type) : CommonMessage("poke")
{
    public int PokeType { get; } = type;   

    public string ToPreviewString() => $"[{nameof(PokeMessage)}: {PokeType}]";
}