using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Savya;

public class PlayerInteraction : MonoBehaviour
{
    public float distance;
    public UIManager ui;

    void Update()
    {
        RaycastHit hit;
        if (Reference.canMove && Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
            {
                Debug.DrawRay(Camera.main.transform.position, Vector3.forward, Color.red);
                Debug.Log("hit");
                InteractableObject obj = hit.collider.gameObject.GetComponent<InteractableObject>();
                if (obj != null)
                {
                    switch (obj.objectType)
                    {
                        case Interaction.interactions.laptop:
                            ui.ShowUI("laptop");
                            break;

                        case Interaction.interactions.phone:
                            ui.ShowUI("phone");
                            break;

                        case Interaction.interactions.microscope:
                            ui.ShowUI("microscope");
                            break;
                        case Interaction.interactions.console:
                            ui.ShowUI("console");
                            break;
                    }
                }
            }
        }
    }
}
