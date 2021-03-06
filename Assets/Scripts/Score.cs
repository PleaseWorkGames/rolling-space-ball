﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : TextAbstract
{
    [System.Serializable]
    public class Multiplier
    {
        public float fractionalPositionFromLeftOfScreen;
        public float multiplier = 1.0f;
    }

    public Multiplier[] Multipliers;

    public bool showMultiplier = false;
    
    private float score = 0;
    
    private float defaultMultiplier = 1.0f;
    
    private float multiplier = 1.0f;
    
    public Player player;

    protected new void Start()
    {
        // TODO - ensure Multipliers array is ordered by fractionalPositionFromLeftOfScreen ascending 
        base.Start();
    }

    public float getMultiplier()
    {
        return multiplier;
    }
    
    void FixedUpdate()
    {
        multiplier = defaultMultiplier; 
        
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(player.transform.position);

        float currentFractionalPositionFromLeftOfScreen = playerPosition.x / Screen.width;
        float previousMultiplierConfigFractionalPosition = 0.0f;
        
        for (int i = 0; i < Multipliers.Length; i += 1) {
            var currentMultiplierConfigInstance = Multipliers[i];
            
            bool isInMultiplierRange = ( 
                (currentFractionalPositionFromLeftOfScreen >= previousMultiplierConfigFractionalPosition) &&
                (currentFractionalPositionFromLeftOfScreen < currentMultiplierConfigInstance.fractionalPositionFromLeftOfScreen)
            );

            if (isInMultiplierRange) {
                multiplier = currentMultiplierConfigInstance.multiplier;
                
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("multiplier", multiplier);
                EventBus.trigger("multiplierChange", parameters);
                EventBus.trigger("multiplierChange2", parameters);
            }

            previousMultiplierConfigFractionalPosition = currentMultiplierConfigInstance.fractionalPositionFromLeftOfScreen;
        }
        
        score += (Time.deltaTime * multiplier);
        text.text = /*"Score: " +*/ Mathf.Floor(score) + "";// + (showMultiplier ? "  Multiplier: " + multiplier : "");
    }
}