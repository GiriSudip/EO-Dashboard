using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CovidManager : MonoBehaviour
{
    public AlertScript alert;
    [HideInInspector] public float covidIncreaseamnt;
    public float deathIncreaseamnt = 1;
    public int mind, maxd;
    public int minc, maxc;
    public TMP_Text covid, death;
    public ActionScriptableObject[] actions;
    public GamePlayManager gm;
    PhoneManagerScript pm;

    private void Start()
    {
        pm = GetComponent<PhoneManagerScript>();
        InvokeRepeating("Mutate", gm.time, gm.time);
    }

    void Update()
    {
        covid.text = covidIncreaseamnt.ToString();
        death.text = deathIncreaseamnt.ToString();
    }

    public void Mutate()
    {
        if (Reference.covid <= 30 && Random.value<=0.30f)
        {
            //removing old mutation value for new values
                demutate();
                int covidamnt = Random.Range(minc, maxc);
                covidIncreaseamnt = covidamnt;
                actions[0].covidImpact += covidIncreaseamnt;
                actions[1].covidImpact += covidIncreaseamnt;
                actions[2].covidImpact += covidIncreaseamnt;
                actions[3].covidImpact += covidIncreaseamnt;
                actions[4].covidImpact += covidIncreaseamnt;

            int deathamnt = Random.Range(mind, maxd);
                deathIncreaseamnt = deathamnt;
            
                alert.Alert("Mutated");
        }
    }


    void demutate()
    {
        actions[0].covidImpact -= covidIncreaseamnt;
        actions[1].covidImpact -= covidIncreaseamnt;
        actions[2].covidImpact -= covidIncreaseamnt;
        actions[3].covidImpact -= covidIncreaseamnt;
        actions[4].covidImpact -= covidIncreaseamnt;
    }
}