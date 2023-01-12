using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLineChanger : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.FindGameObjectWithTag("VoiceLineSettings").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.clip = clip;
            source.Play();
        }
    }
}
