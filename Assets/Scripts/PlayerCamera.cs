using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;



public class PlayerCamera : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity;
    UduinoManager manager;

    float xAxisClamp = 0.0f;
    
    //For calibrating gravity constants. They are going into if else statements. Not all of them are being used. 
    public int accY_positiveMax;
    public int accY_positiveMin;
    public int accY_negativeMax;
    public int accY_negativeMin;

    public int accZ_positiveMax;
    public int accZ_positiveMin;
    public int accZ_negativeMax;
    public int accZ_negativeMin;

    float accHorizontal;
    float accVertical;
    int joyButton;
    

    //Aawke is called once at the beginning of the game. 
    void Start()
    {
        //This statement hides cursor. 
        //This part is actually not absolute for our project. For example it should change when we access Menu UI. Also we should disable camera movement on top of it. 
        //Othervise the camera will be moving while we are in the Menu UI. So we might consider making it reactive for different situations.
        Cursor.lockState = CursorLockMode.Locked;

        manager = UduinoManager.Instance;
        manager.pinMode(AnalogPin.A3, PinMode.Input); // accel Z, z<370 UP, 400<z<435 DOWN
        manager.pinMode(AnalogPin.A1, PinMode.Input); // accel Y, y<300 LEFT, y>420 RIGHT
        //manager.pinMode(AnalogPin.A6, PinMode.Input);
        joyButton = 1; 


    }

    void Update()
    {

        //joyButton = manager.analogRead(AnalogPin.A6);
        int accZ = manager.analogRead(AnalogPin.A3);
        int accY = manager.analogRead(AnalogPin.A1);
    
         
            //Doesn't Work        
            if (accZ < 310) { accVertical = 1; }
            else if (accZ > 420) { accVertical = -1; }
            else { accVertical = 0; }


            //Works
            if (accY > 420 ) { accHorizontal = 1; }
            else if (accY < 300) { accHorizontal = -1; }
            else { accHorizontal = 0; }
        
        
        
        RotateCamera();
    }

    void RotateCamera()
    {
        //for mouse
        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");

        float mouseX = accHorizontal;
        float mouseY = 0;


        // Degrees, not Radiance
        // Rotation amount is defined here. 
        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        //This part basically rotates camera. Since RotateCamera() function is called in Update() function, this rotation is going to be executed every frame.
        Vector3 targetRotCam = transform.rotation.eulerAngles;

        //Since PlayerCapsuleCamera is a child object of the PlayerCapsule, with this line of code, whenever PlayerCapsule rotates, PlayerCapsuleCamera rotates along with it. (Note "X1")
        Vector3 targetRotBody = playerBody.rotation.eulerAngles; //We already defined "transform" part at the public part of the script. So we are calling the name of that transform, playerBody (Note "X1")


        //When you rotate an objecta around the X and Y axises, the beheavior you see is reversed.
        //So, for example if you wanna rotate around X axis, yo need to use your mouses rotationAmountY
        targetRotCam.x -= rotAmountY;//I have placed "-=" here. Otherwise rotation is reveresed while looking down or up. You can add a global boolean (just like mouseSensitivity), 
                                     //and an if else statement inside the RotateCamera() to change inverted camera later. (if you like to of course) 
        targetRotCam.z = 0; //Prevents lookin too much down or up. Otherwise camera flips.
        targetRotBody.y += rotAmountX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

        print(mouseY);

        //This part transforms rotation information to angle vector
        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);


    }



}