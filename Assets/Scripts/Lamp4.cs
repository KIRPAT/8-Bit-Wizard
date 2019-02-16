using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp4 : MonoBehaviour {

    public Material white;
    public Material red;
    public bool lampstate;
    public GameObject Lamp3Access;
    Lamp3 Lamp3Script;
    

    // Use this for initialization
    void Start () {
        Lamp3Script = Lamp3Access.GetComponent<Lamp3>();
        lampstate = false;
	}
	
	// Update is called once per frame
	void Update () {

        

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
        if (Lamp3Script.lampstate == true)
            Lamp3Script.lampstate = false;
        else
            Lamp3Script.lampstate = true;
        
    }
}
