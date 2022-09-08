using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    //serialized fields
    [SerializeField] Health TargetHealth;
    [SerializeField] TextMeshProUGUI ScoreAmount;
    [SerializeField] TextMeshProUGUI HealthAmount;

    //unserialized fields
    private uint _Score = 0;

    //called once per frame
    void Update()
    {
        //update score amount text
        ScoreAmount.text = _Score.ToString("0000000");

        //get current and max health value
        float health = TargetHealth.GetCurrent();
        float max = TargetHealth.GetMax();

        //update health amount text
        HealthAmount.text = health.ToString();

        //update health amount text color
        if (health <= (1.00 * max))
        {
            HealthAmount.color = Color.green;
        }
        if (health <= (0.75 * max))
        {
            HealthAmount.color = Color.yellow;
        }
        if (health <= (0.50 * max))
        {
            HealthAmount.color = Color.red + (Color.yellow / 2f);
        }
        if (health <= (0.25 * max))
        {
            HealthAmount.color = Color.red;
        }

    }

    //called to increment score
    public void IncrementScore()
    {
        _Score += 1;
    }
}
