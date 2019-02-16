using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class Raycasting : MonoBehaviour {
    public int keyState;
    public float distanceToSee;
    RaycastHit whatIHit;
    UduinoManager manager;

    public bool picRotCheck1;
    public bool picRotCheck2;
    public bool picRotCheck3;
    public bool Lock1;
    public bool Lock2;
    public int yAngleOfWhatISee;

    public GameObject Lamp1Access;
    public GameObject Lamp2Access;
    public GameObject Lamp3Access;
    public GameObject Lamp4Access;
    Lamp1 Lamp1Script;
    Lamp2 Lamp2Script;
    Lamp3 Lamp3Script;
    Lamp4 Lamp4Script;

    public GameObject BlueDoorAccess;
    public GameObject RedDoorAccess;
    BlueDoor BlueDoorScript;
    RedDoor RedDoorScript;


    // Use this for initialization
    void Start () {
        manager = UduinoManager.Instance;
        manager.pinMode(AnalogPin.A2, PinMode.Input);
        Lock1 = false;
        Lock2 = false;
        picRotCheck1 = false;
        picRotCheck2 = false;
        picRotCheck3 = false;

        Lamp1Script = Lamp1Access.GetComponent<Lamp1>();
        Lamp2Script = Lamp2Access.GetComponent<Lamp2>();
        Lamp3Script = Lamp3Access.GetComponent<Lamp3>();
        Lamp4Script = Lamp4Access.GetComponent<Lamp4>();

        BlueDoorScript = BlueDoorAccess.GetComponent<BlueDoor>();
        RedDoorScript = RedDoorAccess.GetComponent<RedDoor>();
    }
	
	// Update is called once per frame
	void Update () {

        keyState = manager.analogRead(AnalogPin.A2);


        //Lamp Keyboard State Changer
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Lamp1Script.ColorChangeSelf();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Lamp2Script.ColorChangeSelf();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Lamp3Script.ColorChangeSelf();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Lamp4Script.ColorChangeSelf();
        }


        //Picture Lock Checker
        if (picRotCheck1 == true && picRotCheck2 == true && picRotCheck3 == true)
        {
            Lock1 = true;
        }
        else
        {
            Lock1 = false;
        }

        //Lamp Lock Chacker
        if (Lamp1Script.lampstate == true && Lamp2Script.lampstate == true && Lamp3Script.lampstate == true && Lamp4Script.lampstate == true)
        {
            Lock2 = true;
        }
        else
        {
            Lock2 = false;
        }



        //Door Unlocker
        if (Lock1 == true && Lock2 == true)
        {
            RedDoorScript.OpenTheDoor();
            BlueDoorScript.ShowTheDoor();
        }
        

        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);
        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
        {
            //Stores Picture Angle
            yAngleOfWhatISee = (int) whatIHit.collider.gameObject.transform.eulerAngles.y;


            //Lamp Action Button Keyboard State Changer
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (whatIHit.collider.gameObject.GetComponent<Lamp>().whatLampAmI == Lamp.Lamps.Lamp1)
                {
                    Lamp1Script.ColorChangeSelf();
                }
                if (whatIHit.collider.gameObject.GetComponent<Lamp>().whatLampAmI == Lamp.Lamps.Lamp2)
                {
                    Lamp2Script.ColorChangeSelf();
                }
                if (whatIHit.collider.gameObject.GetComponent<Lamp>().whatLampAmI == Lamp.Lamps.Lamp3)
                {
                    Lamp3Script.ColorChangeSelf();
                }
                if (whatIHit.collider.gameObject.GetComponent<Lamp>().whatLampAmI == Lamp.Lamps.Lamp4)
                {
                    Lamp4Script.ColorChangeSelf();
                }
            }



            if (keyState == 0 || Input.GetKeyDown(KeyCode.Space) )
            {
                
                Debug.Log("I hit " + whatIHit.collider.gameObject.name);
               
                
                //Picture Turners
                if (whatIHit.collider.gameObject.GetComponent<Picture>().whatPicAmI == Picture.Pictures.pic1)
                {
                    whatIHit.collider.gameObject.transform.Rotate(new Vector3(0, 90, 0));

                    if (yAngleOfWhatISee == 180)
                    {picRotCheck1 = true;}
                    else
                    {picRotCheck1 = false;}
                }
                
                if (whatIHit.collider.gameObject.GetComponent<Picture>().whatPicAmI == Picture.Pictures.pic2)
                {
                    whatIHit.collider.gameObject.transform.Rotate(new Vector3(0, 90, 0));

                    if (yAngleOfWhatISee == 180)
                    {picRotCheck2 = true;}
                    else
                    {picRotCheck2 = false;}
                }

                if (whatIHit.collider.gameObject.GetComponent<Picture>().whatPicAmI == Picture.Pictures.pic3)
                {
                    whatIHit.collider.gameObject.transform.Rotate(new Vector3(0, 90, 0));

                    if (yAngleOfWhatISee == 180)
                    {picRotCheck3 = true;}
                    else
                    {picRotCheck3 = false;}
                }
                

                //Color Switcher
                if (whatIHit.collider.gameObject.GetComponent<Lamp>().whatLampAmI == Lamp.Lamps.Lamp1)
                {
                    Lamp1Script.lampstate = true;

                }


                


            }

            
            




        }
	}

   
}

