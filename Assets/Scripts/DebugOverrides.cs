﻿/**
 * Values in this file can be used to change default behaviour for debugging
 */
public class DebugOverrides
{
    /**
     * Can be used to override the starting state.
     * default: null
     * 
     * Warning: this is very likely to result in undefined behaviour
     */
    public static GameStage? StartState = null;

    /**
     * Whether or not to load save data at the start of the game
     * default: true
     */
    public const bool ShouldLoadSaveData = true;

    /**
     * Whether or not to start the game with music enabled
     * default: true
     */
    public const bool MusicEnabled = true;

    /**
     * The duration of quarter simulation in seconds.
     * default: null
     * 
     * By default the game will use BusinessSystem.QUARTER_TIME, which is 7s
     */
    public static float? QuarterDuration = null;

    /**
     * The quarter to start in. Won't skip events.
     */
    public static int StartingQuarter = 0;

    /**
     * Player's starting money
     */
    public static int StartingMoney = 1000;

    /**
     * Possible additions:
     * - a boolean that disables all debug overrides
     * - starting money, feathers, potions
     * - current event
     * 
     * Possibly gitignore changes to this file (or make it read from a gitignored file)
     */
}
