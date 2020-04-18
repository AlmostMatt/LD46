﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessSystem : MonoBehaviour
{
    private float mPaymentTimer = 0;
    private float mPaymentTime = 0;
    private float QUARTER_TIME = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If in any other state (including random event), simulation will be paused
        if(GameState.currentStage == GameState.GameStage.GS_SIMULATION)
        {
            if(CustomerState.totalQuarterlyCustomers == 0)
            {
                Debug.Log("All customers served this quarter.");
                GameState.currentStage = GameState.GameStage.GS_RESOURCE_ALLOCATION;
                mPaymentTime = 0;
                return;
            }

            // yeah like it's slightly gross to do this here in this way...
            // running code on state changes really does want an event-driven style thing, I guess
            if(mPaymentTime == 0)
            {
                mPaymentTime = QUARTER_TIME / CustomerState.totalQuarterlyCustomers;
                mPaymentTimer = mPaymentTime;
            }

            mPaymentTimer -= Time.deltaTime;
            if(mPaymentTimer <= 0)
            {
                int product = Random.Range(0, (int)ProductType.PT_MAX);
                while(CustomerState.customers[product] == 0)
                {
                    product = (product + 1) % (int)ProductType.PT_MAX;
                }

                if(BusinessState.inventory[product] > 0)
                {
                    BusinessState.money += BusinessState.prices[product];
                    BusinessState.inventory[product] -= 1;
                    Debug.Log("Sold a " + (ProductType)product + "! money: " + BusinessState.money);
                }
                else
                {
                    Debug.Log("A customer wanted " + (ProductType)product + " but we were out of stock");
                }

                mPaymentTimer = Random.Range(mPaymentTime * 0.9f, mPaymentTime * 1.1f);
                --CustomerState.totalQuarterlyCustomers;
            }
        }
    }

}
