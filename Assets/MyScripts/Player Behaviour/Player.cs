using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Transform playerSpawnPoints;
    public GameObject LandingArea;
    public Vector3 landingAreaPosition;

    private bool reSpawn = false;
    private Transform[] spawnPoints;
    private bool lastToggle = false;                                                // last respawn toggle.
    

    void Start()
    {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if(lastToggle != reSpawn)
        {
            ReSpawn();
            reSpawn = false;   
        }
        else
        {
            lastToggle = reSpawn;
        }
    }

	private void ReSpawn()
    {
        int i = Random.Range(1, spawnPoints.Length);

        transform.position = spawnPoints[i].transform.position;
    }
    
    void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
    }

    void DropFlare()
    {
        Instantiate(LandingArea, this.transform.position, this.transform.rotation);

        landingAreaPosition = this.transform.position;
    }
}
