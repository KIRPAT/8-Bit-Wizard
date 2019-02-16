using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Uduino;

public class PlayerJoyConCamera : MonoBehaviour {

    UduinoManager manager;
    
    // Use this for initialization
    void Start () {
        var rotationVector = transform.rotation.eulerAngles;
        manager = UduinoManager.Instance;
        manager.pinMode(AnalogPin.A0, PinMode.Input); //z accel
        manager.pinMode(AnalogPin.A1, PinMode.Input); //y accel
        manager.pinMode(AnalogPin.A2, PinMode.Input); //x accel
        manager.pinMode(AnalogPin.A4, PinMode.Input); //JoyX
        manager.pinMode(AnalogPin.A5, PinMode.Input); //JoyY

    }
	
	// Update is called once per frame
	void Update () {
        //Accelerometer Analog Reader
        int accZ = manager.analogRead(AnalogPin.A0);
        int accY = manager.analogRead(AnalogPin.A1);
        int accX = manager.analogRead(AnalogPin.A2);

        //Joystick Analog Reader
        int joyX = manager.analogRead(AnalogPin.A4);
        int joyY = manager.analogRead(AnalogPin.A5);

        
	}

    void pressW()
    {
        
    }

    void pressA()
    {

    }

    void pressS()
    {

    }

    void pressD()
    {

    }
}
