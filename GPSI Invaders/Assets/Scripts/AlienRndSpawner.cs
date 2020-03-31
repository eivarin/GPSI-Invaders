using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRndSpawner : MonoBehaviour
{
    public Sprite[] Sprite_Lista;

    private int rnd;

    // Start is called before the first frame update
    void Start()
    {
        rnd = Random.Range(0, Sprite_Lista.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Lista[rnd];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
