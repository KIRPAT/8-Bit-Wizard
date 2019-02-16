using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class PlayerControl : MonoBehaviour {

    UduinoManager manager;
    private CharacterController charControl;
    public float walkSpeed;
    float joyXconvert;
    float joyXconvert2;
    float joyYconvert;
    float joyYconvert2;
    void Start() {
        charControl = GetComponent<CharacterController>();
        manager = UduinoManager.Instance;
     
        manager.pinMode(AnalogPin.A4, PinMode.Input); //JoyX
        manager.pinMode(AnalogPin.A5, PinMode.Input); //JoyY
    }

    void Update() {
     

        //Joystick Analog Reader
        int joyX = manager.analogRead(AnalogPin.A4);
        int joyY = manager.analogRead(AnalogPin.A5);



        if (joyX > 509 && joyX < 520)
        { joyXconvert = 0; }
        else if (joyX > 520)
        { joyXconvert = -1; }
        else
        { joyXconvert = 1; }


        if (joyY > 520 && joyY < 530)
        { joyYconvert = 0; }
        else if (joyY > 530)
        { joyYconvert = 1;}
        else
        { joyYconvert = -1;}


        MovePlayer();

    }

    void MovePlayer() {
        //float horizontalKeyboard = Input.GetAxis("Horizontal");
        //float verticalKeyboard = Input.GetAxis("Vertical");

        float horizontal = joyXconvert;
        float vertical = joyYconvert;

        Vector3 moveDirectionHorizontal = transform.right * horizontal * walkSpeed;
        Vector3 moveDirectionVertical = transform.forward * vertical * walkSpeed;

        charControl.SimpleMove(moveDirectionHorizontal);
        charControl.SimpleMove(moveDirectionVertical);

    }
}
