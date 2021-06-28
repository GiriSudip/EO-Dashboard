    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UpgradeScript : MonoBehaviour
{
    float covidValue,economyValue, happinessValue,amount;
    public TMP_Text covid_txt, economy_txt, happy_txt;
    public TMP_InputField amount_txt;
    public enum type{limited,unlimited};
    public float OneTimecost,cost,time,covid,happiness;
    public type Type;

    void Start()
    {
        InvokeRepeating("Effect", time , time);
    }

    void Update()
    {
        UpdateUI();
    }
    public void add()
    {
        if(Reference.economy >= OneTimecost)
        {
        Reference.economy -= OneTimecost;
        covidValue -= covid;
        economyValue -= cost;
        happinessValue += happiness;
        amount +=1;
        }
    }

    public void minus()
    {
     if(amount>0)
     {
      Reference.economy +=OneTimecost;
       covidValue += covid;
       economyValue += cost;
       happinessValue -= happiness;
      amount -= 1;
     }
    }

    void Effect()
    {
        Reference.covid += covidValue;
        Reference.economy += economyValue;
        Reference.happiness += happinessValue;
        switch(Type)
        {
         case type.limited:
            if(amount>0)
            { 
            covidValue += covid;
            economyValue += cost;
            happinessValue -= happiness;
            amount -= 1;  
            }
         break;
        }
    }

    void UpdateUI()
    {
        amount_txt.text = amount.ToString();
        covid_txt.text = covidValue.ToString();
        economy_txt.text = economyValue.ToString();
        happy_txt.text = happinessValue.ToString();
    }
}
