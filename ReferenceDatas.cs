using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EasyButtons;
public class ReferenceDatas : MonoBehaviour
{
    public float covid,death,economy,food,happiness;
    public ActionScriptableObject[] actions;
    void Start()
    {
        Reference.d_covid = covid;
        Reference.d_death = death;
        Reference.d_economy = economy;
        Reference.d_food = food;
        Reference.d_happiness = happiness;

        Reference.covid = covid;
        Reference.death = death;
        Reference.economy = economy;
        Reference.food = food;
        Reference.happiness = happiness;

        foreach (ActionScriptableObject a in actions)
        {
            a.ResetDefault();
        }
    }

  void Update()
  {
  Reference.covid = Limiter(Reference.covid,0,100);
  Reference.death = Limiter(Reference.death,0,100);
  Reference.economy = Limiter(Reference.economy,0,100);
  Reference.food = Limiter(Reference.food,0,100);
  Reference.happiness = Limiter(Reference.happiness,0,100);
  }

    [Button]
    public void CheckData()
    {
        Debug.Log(Reference.covid.ToString());
    }

    public float Limiter(float num, float min , float max)
    {
      if(num > max)
      {
          num = max;
      }
      if(num<min)
      {
          num = min;
      }
      return num;
    }
}
