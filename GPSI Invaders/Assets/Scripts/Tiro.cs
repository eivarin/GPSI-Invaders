using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tiro : MonoBehaviour
{
    public float veloc = 30;

    private Rigidbody2D rigidBody;

    public Sprite ImagemExplosaoAlien;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.up * veloc;
    }

    void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.tag == "Parede")
        {
            Destroy(gameObject);
        }
        else if (coli.tag == "Alien")
        {
            GestorDeSons.Instance.PlayOneShot(GestorDeSons.Instance.MorteAlien);
            IncreaseTextUIScore();
            coli.GetComponent<SpriteRenderer>().sprite = ImagemExplosaoAlien;

            Destroy(gameObject);

            Destroy(coli.gameObject, 0.5f);

        }
        else if (coli.tag == "Escudo") 
        {
            Destroy(gameObject);
            Destroy(coli.gameObject);
        }
    }

    void IncreaseTextUIScore()
    {
        var textUIComp = GameObject.Find("Pontuacao").GetComponent<TextMeshProUGUI>();

        int pontos = int.Parse(textUIComp.text.Remove(0, 11));

        pontos-=-5;

        textUIComp.text = "Pontuação: " + pontos.ToString();
    }

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
}
