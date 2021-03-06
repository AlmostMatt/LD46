﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PeacockExtraType
{
    ET_MEDICINE,
    ET_PILLOW,
    ET_HORMONES,

    ET_MAX
}

public static class PeacockExtraTypeExtensions
{
    public static int GetPrice(this PeacockExtraType extraType)
    {
        switch(extraType)
        {
            case PeacockExtraType.ET_MEDICINE:
                return 400;
            case PeacockExtraType.ET_PILLOW:
                return 100;
            case PeacockExtraType.ET_HORMONES:
                return 300;
        }
        return 0;
    }

    public static string GetName(this PeacockExtraType extraType)
    {
        switch(extraType)
        {
            case PeacockExtraType.ET_MEDICINE:
                return "medicine";
            case PeacockExtraType.ET_PILLOW:
                return "a blanket";
            case PeacockExtraType.ET_HORMONES:
                return "growth hormones"; // TODO: probably change this to something more fantasy-sounding
        }
        return "????";
    }

    
    public static string GetProperName(this PeacockExtraType extraType)
    {
        switch(extraType)
        {
            case PeacockExtraType.ET_MEDICINE:
                return "Medicine";
            case PeacockExtraType.ET_PILLOW:
                return "Blanket";
            case PeacockExtraType.ET_HORMONES:
                return "Growth Hormones"; // TODO: probably change this to something more fantasy-sounding
        }
        return "Unknown";
    }

    public static string GetLabel(this PeacockExtraType extraType)
    {
        string name = extraType.GetProperName();
        string price = Utilities.FormatMoney(extraType.GetPrice());
        return name + " " + price;
    }
}