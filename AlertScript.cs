using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EasyButtons;

public class AlertScript : MonoBehaviour
{
    public TMP_Text alertTxt;

[Button]    
    public void Alert(string msg)
    {
        alertTxt.gameObject.SetActive(true);
        alertTxt.text = msg;
        StartCoroutine(Hide());
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(3);
        alertTxt.gameObject.SetActive(false);
    }
}
