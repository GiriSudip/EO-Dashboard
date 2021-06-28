using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reference : MonoBehaviour
{
    private static Reference instance;

    public static Reference Instance { get { return instance; } }

    public static bool canMove = true;
    public static float covid, death, food, happiness, economy;
    public static float d_covid, d_death, d_food, d_happiness, d_economy;

    private void Awake()
    {
        ResetDefault();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public static void ResetDefault()
    {
        covid = d_covid;
        death = d_death;
        food = d_food;
        economy = d_economy;
    }
}
