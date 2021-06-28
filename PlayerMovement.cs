using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region variables
    [Header("Movement")]
    Rigidbody rb;
    public float speed;
    Vector2 movex, movez, move;

    //animation values
    Animator animator;

    [Header("Rotation")]
    public float ysensitivity;

    [Header("Camera Look")]
    public float xsensitivity;
    float xRot;
    public float min;
    public float max;
    public bool invert;

    #endregion
    #region builtin functions
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Reference.canMove)
        {
            CamLook();
            Animation();
        }
        UpdateSettings();
    }

    void FixedUpdate()
    {
        if (Reference.canMove)
        {
            Move();
            Rotate();
        }
    }
    #endregion

    #region custom methods
    void Move()
    {
        movex = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, Input.GetAxisRaw("Horizontal") * transform.right.z);
        movez = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, Input.GetAxisRaw("Vertical") * transform.forward.z);
        move = (movex + movez).normalized *speed * Time.deltaTime;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.y);
    }
    

    void Animation()
    {
        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
    }

    void Rotate()
    {
        rb.rotation *= Quaternion.Euler(0,Input.GetAxis("Mouse X") * ysensitivity * Time.deltaTime,0);
    }

    void CamLook()
    {
        xRot += -Input.GetAxis("Mouse Y") * xsensitivity *Time.deltaTime;
      
        xRot = Mathf.Clamp(xRot, -min, max);
        if (invert)
        {
            Camera.main.transform.localRotation = Quaternion.Euler(-xRot, 0, 0);
        }
        else
        {
            Camera.main.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        }
        
    }

    void UpdateSettings()
    {
        xsensitivity = SettingsManager.vsen;
        ysensitivity = SettingsManager.hsen;
        invert = SettingsManager.invert;
    }
    #endregion
}
