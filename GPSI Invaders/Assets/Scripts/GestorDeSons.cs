using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDeSons : MonoBehaviour
{
    public static GestorDeSons Instance = null;

    public AudioClip ZoarAlien1;
    public AudioClip ZoarAlien2;
    public AudioClip MorteAlien;
    public AudioClip TiroDisparado;
    public AudioClip ExplosaoNave;

    private AudioSource soundEffectAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource aFonte = GetComponent<AudioSource>();
        soundEffectAudio = aFonte;
    }


    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
