using UnityEngine;
using System.Collections;

public class TextBehaviour : MonoBehaviour
{
    private Player player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Quaternion.Lerp(player.transform.rotation, this.transform.rotation, Time.deltaTime * 5);
        
    }

    // draws pickupable item 3d text
    /*void DrawGameObjectText() 
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= 16)
        {
            textMesh.text = this.transform.parent.name;
            
        }
        else
        {
            textMesh.text = string.Empty;
        }
    }*/
}
