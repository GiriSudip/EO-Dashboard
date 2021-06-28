using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public float decreasevalue;
    public PhoneManagerScript pm;
    public CovidManager covidManager;
    public GameObject looseMenu;
    public GameObject pauseUI;
    bool paused = false;
    public bool hincrease;
    public float time;

    void Start()
    {
        hincrease = true;
        InvokeRepeating("GameDataHandler", time, time);
        InvokeRepeating("RefillFood", time, time);
        InvokeRepeating("HappinessBalancer",time,time);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else if (paused)
            {
                UnPause();
            }
        } 
    }


    void GameDataHandler()
    {
        if(Reference.economy<= 30)
        {
            Reference.food -= decreasevalue ;
        }
        if(Reference.food <= 0 || Reference.covid >= 50)
        {
            Reference.death += covidManager.deathIncreaseamnt;
            Debug.Log("Death");
        }
        if(Reference.food <= 30)
        {
            Reference.happiness -= 3;
            Reference.death += covidManager.deathIncreaseamnt;
        }
        if (Reference.happiness <= 0)
        {
            Loose();
            Debug.Log("SadLoose");
        }
        if (Reference.death >= 100)
        {
            Loose();
            Debug.Log("HappyLoose");
        }
    }

    void Loose()
    {
        looseMenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("You Lost");
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        paused = true;
    }

    public void UnPause()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        paused = false;
    }

    void RefillFood()
    {
        if(Reference.economy > 30)
        {
            Reference.food += 1;
        }
    }

    void HappinessBalancer()
    {
        if(pm.currentAction.name == pm.defaultAction.name)
        {
          if(Reference.covid >= 50)
          {
           hincrease = false;
           Reference.happiness -= 2;
           Reference.death +=1;
          }
          else if (Reference.covid >=70)
          {
              hincrease = false;
             Reference.death +=2;
              Reference.happiness -=3;
          }
          else
          {
              hincrease = true;
          }
        }
    }
}
