﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestmentEventChain
{
    
    public static void Init()
    {
        EventState.PushEvent(new InvestmentEventStart(), 3);
    }

    private class InvestmentEventStart : GameEvent
    {
        private enum Stage
        {
            OPENING,
            DECIDE
        }
        private Stage mStage = Stage.OPENING;

        protected override void EventStart()
        {
            EventState.currentEventText = "Someone approaches you at the counter. \"I have a proposition for you.\"";
            EventState.currentEventOptions = new string[] { "Go on..." };
        }

        protected override bool OnPlayerDecision(int choice)
        {
            switch(mStage)
            {
                case Stage.OPENING:
                    EventState.currentEventText = "I've got an investment opportunity. Lend me $1000, and I'll pay you back double.";
                    EventState.currentEventOptions = new string[]
                    {
                        "Accept the deal",
                        "Refuse"
                    };
                    mStage = Stage.DECIDE;
                    break;
                case Stage.DECIDE:
                    {
                        switch(choice)
                        {
                            case 0:
                                EventState.currentEventText = "\"You won't regret this!\", he says. He takes your $1000 and leaves.";
                                EventState.PushEvent(new InvestmentReturnEvent(), GameState.quarter + 4);
                                BusinessState.money -= 1000;
                                break;
                            case 1:
                                EventState.currentEventText = "\"Suit yourself...\", he says. He leaves without another word.";
                                break;
                        }
                    }
                    EventState.currentEventOptions = EventState.OK_OPTION;
                    return true;
            }

            return false;
        }
    }

    private class InvestmentReturnEvent : GameEvent
    {
        private enum Stage
        {
            OPENING
        }
        private Stage mStage = Stage.OPENING;

        protected override void EventStart()
        {
            EventState.currentEventText = "A man approaches you at the counter. He looks familiar. \"I'm back from my business venture!\"";
            EventState.currentEventOptions = new string[] { "Continue" };
        }

        protected override bool OnPlayerDecision(int choice)
        {
            EventState.currentEventText = "\"Didn't I tell you you wouldn't regret it?\" He hands you $2000, then goes on his way.";
            EventState.currentEventOptions = EventState.OK_OPTION;
            BusinessState.money += 2000;
            return true;
        }
    }

}