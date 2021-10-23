using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Won : MonoBehaviour
{
    public Text stats_action_text;
    public Text stats_horror_text;
    public Text stats_reasoning_text;
    public Text stats_romance_text;
    public Text stats_strength_text;
    public Text stats_fantasy_text;

    public PlayerStats playerStats;

    void Update()
    {
        //playerStats = GetComponent<PlayerStats>();

        stats_action_text.text = "Action : " + playerStats.stats_action.ToString();
        stats_horror_text.text = "Horror : " + playerStats.stats_horror.ToString();
        stats_reasoning_text.text = "Reasoning : " + playerStats.stats_reasoning.ToString();
        stats_romance_text.text = "Romance : " + playerStats.stats_romance.ToString();
        stats_strength_text.text = "Strength : " + playerStats.stats_strength.ToString();
        stats_fantasy_text.text = "Fantasy : " + playerStats.stats_fantasy.ToString();
    }
    
}
