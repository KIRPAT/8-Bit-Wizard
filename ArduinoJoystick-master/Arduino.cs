using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Arduino : MonoBehaviour {
	SerialPort sp;

	void Start () {  
		sp = new SerialPort("COM6", 9600);
		sp.Open ();
		sp.ReadTimeout = 10;
	}

	void Update () 
	{
		try{
			Debug.Log ("<size=25>" + sp.ReadLine() + "</size>");
		}
		catch(System.Exception){
		}
	}
}
