﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent
{
    protected enum EventResult
    {
        CONTINUE,
        DONE,
        SKIP
    }

    private GameState.GameStage mPreviousStage;
    private EventResult mEventStatus = EventResult.CONTINUE;

    public void DoEvent()
    {
        //mPreviousStage = GameState.currentStage;
        //GameState.currentStage = GameState.GameStage.GS_EVENT; // pause the simulation
        EventState.currentEvent = this; // set self as the callback for the UI. This also signals to other systems that they may need to pause.

        mEventStatus = EventStart(); // derived classes override this to do whatever, including populating the UI

        if(mEventStatus == EventResult.SKIP)
        {
            // the event decided not to fire at all for whatever reason
            GameState.currentStage = GameState.GameStage.GS_SIMULATION;
            EventState.currentEvent = null;
        }
    }

    public void PlayerDecision(int choice)
    {
        // callback from the UI
        Debug.Log("Player made choice " + choice);

        if(mEventStatus == EventResult.DONE)
        {
            // return to the game (this happens *before* setting it so that events that end have a chance to display their final message
            //GameState.currentStage = mPreviousStage;
            EventEnd(choice);
            EventState.currentEvent = null;
            return;
        }

        mEventStatus = OnPlayerDecision(choice); // derived classes implement whatever they need here. return true to indicate the event is over.
    }

    protected abstract EventResult EventStart();
    protected virtual EventResult OnPlayerDecision(int choice) { return EventResult.DONE; }
    protected virtual void EventEnd(int choice) {}
}
