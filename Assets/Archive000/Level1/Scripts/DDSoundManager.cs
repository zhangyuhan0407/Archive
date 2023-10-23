using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDSoundManager : MonoBehaviour
{

    public static DDSoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    AudioSource audioSource;

    public AudioClip clipPickUp;
    public AudioClip clipOpenDoor;
    public AudioClip clipClickTrigger;
    public AudioClip clipLayInBed;
    public AudioClip clipSucceed;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }


}
