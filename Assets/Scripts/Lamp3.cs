using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp3 : MonoBehaviour {

    public Material white;
    public Material red;
    public bool lampstate;
    public GameObject Lamp2Access;
    public GameObject Lamp4Access;
    Lamp2 Lamp2Script;
    Lamp4 Lamp4Script;

    // Use this for initialization
    void Start()
    {
        Lamp2Script = Lamp2Access.GetComponent<Lamp2>();
        Lamp4Script = Lamp4Access.GetComponent<Lamp4>();
        lampstate = false;
    }

    // Update is called once per frame
    void Update()
    {



        if (lampstate == false)
        {
            GetComponent<Renderer>().material = white;
        }
        else
        {
            GetComponent<Renderer>().material = red;
        }
    }

    public void ColorChangeSelf()
    {
        if (lampstate == true)
            lampstate = false;
        else
            lampstate = true;
        ColorChangeAround();
    }
    public void ColorChangeAround()
    {
        if (Lamp2Script.lampstate == true)
            Lamp2Script.lampstate = false;
        else
            Lamp2Script.lampstate = true;

        if (Lamp4Script.lampstate == true)
            Lamp4Script.lampstate = false;
        else
            Lamp4Script.lampstate = true;
    }
}
