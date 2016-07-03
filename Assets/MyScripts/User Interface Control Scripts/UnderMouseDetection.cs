using UnityEngine;
using System.Collections;

public class UnderMouseDetection : MonoBehaviour
{
    private GameObject underMouse;

    public GameObject UnderMouse()                                              // Shoots out ray from mouse position.
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))  
        {
            if (hit.collider != null)                                           // If ray hit's something with collision.
            {
                underMouse = hit.transform.gameObject;                          // underMouse has now collided gameObject information.
            }
        }
        return underMouse;                                                      // Returns gameObject which collider made that collision.
    }
}