using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabShell : MonoBehaviour
{
    private bool hasShell = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Shell")
        {
            TakeShell(hit.transform);
        }
    }

    private void TakeShell(Transform shellTransform)
    {
        if (hasShell)
        {
            //Drop shell
        }
        shellTransform.parent = this.transform;
        hasShell = true;
    }
}
