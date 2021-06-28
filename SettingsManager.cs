using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private static SettingsManager instance;

    public static SettingsManager Instance { get { return instance; } }

    public static float vsen = 30, hsen =30;
    public static bool invert = false;

    float dvsen =30, dhsen =30;
    bool dinvert =false;
    public Slider vslider, hslider;
    public Toggle invertToggle;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void SensitivityV()
    {
        vsen = vslider.value;
    }

    public void SensitivityH()
    {
        hsen = hslider.value;
    }

    public void Invert()
    {
        invert = invertToggle.isOn;
    }

    public void defaultSettings()
    {
        vslider.value = dvsen;
        vsen = dvsen;

        hslider.value = dhsen;
        hsen = dhsen;

        invertToggle.isOn = dinvert;
        invert = dinvert;
    }
}
