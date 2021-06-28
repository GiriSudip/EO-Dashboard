using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
    public UserInterfaceClass[] UIReferences;
    public float animationTime;
    public float loadTime;
    public Slider covidslider, deathslider, economyslider, foodslider, happyslider;
    public TMP_Text covidText, deathText, economyText, foodText, happyText;
    public VideoPlayer video;

    void Start()
    {
    
    }

    private void Update()
    {
        UpdateData();
    }

    [Button]
    public void ShowUI(string uiname)
    {
        foreach(UserInterfaceClass u in UIReferences)
        {
            if(u.UIName == uiname)
            {
                u.UIObject.SetActive(true);
                ShowStyle(u.style, u);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Reference.canMove = false;
            }
        }
    }

    [Button]
    public void HideUI(string uiname)
    {
        foreach (UserInterfaceClass u in UIReferences)
        {
            if (u.UIName == uiname)
            {
                if (u.style == UserInterfaceClass.Showstyle.SlideUp)
                {
                    u.UIObject.transform.LeanMoveLocalY(u.dposy, animationTime);
                    StartCoroutine(hideCoroutine(animationTime, u));
                    Reference.canMove = true;
                }

                else
                {
                    u.UIObject.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Reference.canMove = true;
                }
            }
        }
    }

    public void ShowStyle(UserInterfaceClass.Showstyle style, UserInterfaceClass u)
    {
        if(style == UserInterfaceClass.Showstyle.Transition)
        {
            u.transitionObject.SetActive(true);
            StartCoroutine(transitionCoroutine(loadTime,u));
        }
        else if(style == UserInterfaceClass.Showstyle.SlideUp)
        {
            u.UIObject.transform.LeanMoveLocalY(u.posy,animationTime);
        }
        else if(style == UserInterfaceClass.Showstyle.Video)
        {
            video.Prepare();
            video.Play();
        }
        else if(style == UserInterfaceClass.Showstyle.Normal)
        {
            return;
        }
    }

    IEnumerator transitionCoroutine(float time, UserInterfaceClass u)
    {
        yield return new WaitForSeconds(time);
        u.transitionObject.SetActive(false);
    }

    IEnumerator hideCoroutine(float time , UserInterfaceClass u)
    {
        yield return new WaitForSeconds(time);
        u.UIObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void UpdateData()
    {
        covidslider.value = Reference.covid;
        covidText.text = Reference.covid.ToString();

        deathslider.value = Reference.death;
        deathText.text = Reference.death.ToString();

        economyslider.value = Reference.economy;
        economyText.text = Reference.economy.ToString();

        foodslider.value = Reference.food;
        foodText.text = Reference.food.ToString();

        happyslider.value = Reference.happiness;
        happyText.text = Reference.happiness.ToString();
    }
}
