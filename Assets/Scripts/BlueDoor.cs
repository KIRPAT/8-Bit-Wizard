using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour {

    private Collider doorCollider;
    private Renderer doorRenderer;
    public bool doorColliderState;
    public bool doorRenderState;
    // Use this for initialization
    void Start()
    {
        doorCollider = GetComponent<Collider>();
        doorCollider.enabled = false;
        doorRenderer = GetComponent<Renderer>();
        doorRenderer.enabled = false;

        doorColliderState = false;
        doorColliderState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorColliderState == true && doorRenderState == true)
        {
            doorCollider.enabled = true;
            doorRenderer.enabled = true;
        }
        else if (doorColliderState == false && doorRenderState == true)
        {
            doorCollider.enabled = false;
            doorRenderer.enabled = true;
        }
        else
        {
            doorCollider.enabled = false;
            doorRenderer.enabled = false;
        }



    }

    public void ShowTheDoor()
    {
        doorColliderState = false;
        doorRenderState = true;
    }

    public void OpenTheDoor()
    {
        doorColliderState = false;
        doorRenderState = false;
    }

    public void CloseTheDoor()
    {
        doorColliderState = true;
        doorRenderState = true;
    }
}
