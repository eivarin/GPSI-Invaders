using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroAlien : MonoBehaviour
{

    public float veloc = 10;

    private Rigidbody2D rigidBody;

    public Sprite ImagemExplosaoNave;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.down * veloc;
    }

    void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.tag == "Parede")
        {
            Destroy(gameObject);
        }
        else if (coli.tag == "Player")
        {
            GestorDeSons.Instance.PlayOneShot(GestorDeSons.Instance.ExplosaoNave);
            coli.GetComponent<SpriteRenderer>().sprite = ImagemExplosaoNave;

            Destroy(gameObject);

            Destroy(coli.gameObject, 0.5f);

        }
        else if (coli.tag == "Escudo")
        {
            Destroy(gameObject);
            Destroy(coli.gameObject);
        }
    }

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
