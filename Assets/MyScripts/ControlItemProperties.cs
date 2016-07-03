using UnityEngine;
using System.Collections;

public class ControlItemProperties : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    public void RestoreGameObjectProperties(GameObject item, GameObject slot)
    {
        Destroy(item);

        item.AddComponent<Rigidbody>();
        item.AddComponent<BoxCollider>();
        item.transform.localScale = slot.transform.localScale;
        item.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        item.gameObject.layer = LayerMask.NameToLayer("Default");
        Instantiate(item, player.transform.position, Quaternion.identity);
    }
}