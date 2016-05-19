using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

    [SerializeField]private int _playerNumber;
    void Start()
    {
       
    }

	void Update () {
        XboxControllerInput();
    }


    void XboxControllerInput()
    {
        string _playerNumberString = _playerNumber.ToString();
        //DPAD
        float dpadX = Input.GetAxis(InputAxesXbox.DPADX + _playerNumberString); //DPAD X AXIS

        if (dpadX > 0)
        {

        }
        else if (dpadX < 0)
        {

        }

        float dpadY = Input.GetAxis(InputAxesXbox.DPADY); //DPAD Y AXIS

        if (dpadY > 0)
        {

        }
        else if (dpadY < 0)
        {

        }

        //ANALOG STICKS
        float leftX = Input.GetAxis(InputAxesXbox.LEFTX); //LEFT ANALOG X AXIS
        float leftY = Input.GetAxis(InputAxesXbox.LEFTY); //LEFT ANALOG Y AXIS

        Vector3 inputVector = new Vector3(Input.GetAxis(InputAxesXbox.LEFTX), 0, -Input.GetAxis(InputAxesXbox.LEFTY));

        if (leftX != 0 || leftY != 0)
        {
            
        }

        float rightX = Input.GetAxis(InputAxesXbox.RIGHTX); //RIGHT ANALOG X AXIS
        float rightY = Input.GetAxis(InputAxesXbox.RIGHTY); //RIGHT ANALOG X AXIS
        
        if (rightX != 0)
        {

        }

        if (rightY != 0)
        {

        }

        if (Input.GetButtonDown(InputAxesXbox.L3))
        {

        }

        if (Input.GetButtonDown(InputAxesXbox.R3))
        {

        }

        //FACE BUTTONS
        if (Input.GetButtonDown(InputAxesXbox.A))
        {

        }

        if (Input.GetButtonDown(InputAxesXbox.B))
        {

        }

        if (Input.GetButtonDown(InputAxesXbox.X))
        {
         
        }

        if (Input.GetButtonDown(InputAxesXbox.Y))
        {

        }

        //BUMPERS & TRIGGERS

        //BUMPERS
        if (Input.GetButton(InputAxesXbox.LB))
        {

        }
        if (Input.GetButtonDown(InputAxesXbox.RB))
        {

        }

        //TRIGGERS
        float leftTrigger = Input.GetAxis(InputAxesXbox.LT);
        float rightTrigger = Input.GetAxis(InputAxesXbox.RT);

        if (leftTrigger > 0)
        {

        }
        if (rightTrigger > 0)
        {

        }

        //START & BACK
        if (Input.GetButtonDown(InputAxesXbox.START))
        {

        }

        if (Input.GetButtonDown(InputAxesXbox.BACK))
        {

        }

        //Idle
        if (!Input.anyKeyDown && leftY == 0 && leftX == 0)
        {

        }
    }
}
