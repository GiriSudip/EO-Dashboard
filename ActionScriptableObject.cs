using UnityEngine;

[CreateAssetMenu(fileName ="Action",menuName ="Actions/New Action",order =1)]
public class ActionScriptableObject : ScriptableObject
{
    public string ActionName;
    [Multiline(10)]
    public string Description;
    public float covidImpact;
    public float economyImpact;
    public float happinessImpact;
    public float default_covidImpact,default_economyImpact,default_happinessImpact;
    [Header("Zero For No limit")]
    public int minvalue;

    public void ResetDefault()
    {
        covidImpact = default_covidImpact;
        economyImpact = default_economyImpact;
        happinessImpact = default_happinessImpact;
    }
}
