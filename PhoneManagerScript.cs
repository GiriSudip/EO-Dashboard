using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class PhoneManagerScript : MonoBehaviour
    {
        public ActionScriptableObject[] actions;
        public ActionScriptableObject currentAction;
        public PhoneUIRef parameters;
        public UIManager uiman;
        ActionScriptableObject viewaction;
        public ActionScriptableObject defaultAction;
        public AlertScript alert;
        [SerializeField] bool action = false;
        public GamePlayManager gm;
        bool view = false;

        void Start()
        {
        currentAction = defaultAction;
        InvokeRepeating("UpdateDatas",gm.time,gm.time);
        }

        private void Update()
        {
            if (currentAction == null)
            {
                currentAction = defaultAction;
                action = false;
            }
            if (currentAction == defaultAction)
            {
                action = false;
            }
        if (view)
        {
           
            parameters.title.text = viewaction.ActionName;
            parameters.description.text = viewaction.Description;
            parameters.covidim.text = viewaction.covidImpact.ToString();
            parameters.ecoim.text = viewaction.economyImpact.ToString();
            parameters.happyim.text = viewaction.happinessImpact.ToString();
        }
        parameters.current_action.text = currentAction.ActionName;
        if (action && viewaction != defaultAction && currentAction == viewaction)
            {
                parameters.action_btn_txt.text = "Cancel Action";
            }
            else if (action && currentAction != viewaction && viewaction != defaultAction && currentAction != defaultAction)
            {
                parameters.action_btn_txt.text = "Other Action Ongoing";
            }
            else
            {
                parameters.action_btn_txt.text = "Take Action";
            }

        }

        public void ShowAction(ActionScriptableObject a)
        {
            viewaction = a;
            parameters._default.SetActive(false);
            parameters._actionmenu.SetActive(true);
            view = true;

        }

        public void TakeAction()
        {
        if (!action && currentAction != viewaction)
        {
            if (Reference.covid >= viewaction.minvalue || viewaction.minvalue == 0)
            {
                currentAction = viewaction;
                action = true;
            }
            else
            {
                alert.Alert("Covid at least " + viewaction.minvalue.ToString() + " needed.");
            }
        }
        else if (action && currentAction == viewaction)
        {
            currentAction = defaultAction;
            action = false;
        }
        }

        public void Back()
        {
            viewaction = null;
            parameters._actionmenu.SetActive(false);
            parameters._default.SetActive(true);
        view = false;
        }

        public void Close()
        {
            uiman.HideUI("phone");
        }

    public void UpdateDatas()
    {
        Reference.covid += currentAction.covidImpact;

        Reference.economy += currentAction.economyImpact;
        
        if(gm.hincrease)
        {
        Reference.happiness += currentAction.happinessImpact;
        }
        Debug.Log("Updated");
    }

}