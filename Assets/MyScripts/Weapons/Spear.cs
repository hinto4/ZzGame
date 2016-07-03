using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private Quaternion currentRotation;

    public AudioClip[] strikeSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        OnSpearHit();
        //ItemSmoothFollow(15f);
    }

    void OnSpearHit()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("prepareHit");
        }
    }

    public void OnStrikePlayAudio()
    {
        int randomizeClip = Random.Range(0, 2);
        audioSource.clip = strikeSound[randomizeClip];
        audioSource.Play();
        Debug.Log(randomizeClip);
    }
    /* item smooth follow
    void ItemSmoothFollow(float speed)
    {
        
        Quaternion cameraRotation = Camera.main.transform.parent.rotation;

        currentRotation = Quaternion.Lerp(currentRotation,
            cameraRotation, speed * Time.deltaTime);

        transform.rotation = currentRotation;
    }*/

}