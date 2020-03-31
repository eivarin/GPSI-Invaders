using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienActions : MonoBehaviour
{

    public float veloc = 10;
    private Rigidbody2D rigidBody;

    public GameObject TiroAlien;

    private float TimingDeSonsAliens = 0.5f;
    private bool SomAnterior;

    private float CadenciaMinimaTiroAlien;
    private float CadenciaMinimaTiroAlien1 = 1f;
    public float CadenciaMinimaTiroAlien2 = 15.0f;
    
    private float CadenciaMaximaTiroAlien;
    private float CadenciaMaximaTiroAlien1 = 3.0f;
    public float CadenciaMaximaTiroAlien2 = 10.0f;

    public float CadenciaBaseTiroAlien = 0f;
    public Sprite ImagemExplosaoNave;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = new Vector2(1, 0) * veloc;
        

        StartCoroutine (TocarZurroAlien ());

        CadenciaMinimaTiroAlien = CadenciaMinimaTiroAlien1;
        CadenciaMaximaTiroAlien = CadenciaMaximaTiroAlien1;
        CadenciaBaseTiroAlien = CalculoCadencia();
        CadenciaMinimaTiroAlien = CadenciaMinimaTiroAlien2;
        CadenciaMaximaTiroAlien = CadenciaMaximaTiroAlien2;
    }

    public IEnumerator TocarZurroAlien()
    {
        while (true)
        {
            if (!SomAnterior)
            {
                Debug.Log("teste1");
                GestorDeSons.Instance.PlayOneShot(GestorDeSons.Instance.ZoarAlien1);
                SomAnterior = true;
            }
            else
            {
                Debug.Log("teste2");
                GestorDeSons.Instance.PlayOneShot(GestorDeSons.Instance.ZoarAlien2);
                SomAnterior = false;
            }
            yield return new WaitForSeconds(TimingDeSonsAliens);
        }
    }

    void Turn(int direction)
    {
        Vector2 novaVeloc = rigidBody.velocity;
        novaVeloc.x = veloc * direction;
        rigidBody.velocity = novaVeloc;
    }

    void MoveDown()
    {
        Vector2 posicao = transform.position;
        posicao.y -= 1;
        transform.position = posicao;
    }

    void OnCollisionEnter2D(Collision2D coli)
    {
        switch (coli.gameObject.name)
        {
            case "ParedeDireita":
                Turn(-1);
                MoveDown();
                break;
            case "ParedeEsquerda":
                Turn(1);
                MoveDown();
                break;
            default:
                break;
        }
        if (coli.gameObject.name == "Tiro")
        {
            GestorDeSons.Instance.PlayOneShot(GestorDeSons.Instance.MorteAlien);
            Destroy(gameObject);
        }
    }

    private float CalculoCadencia()
    {
        float Calculo = Random.Range(CadenciaMinimaTiroAlien, CadenciaMaximaTiroAlien);
        return Calculo;
    }

    void FixedUpdate()
    {
        if (Time.time > CadenciaBaseTiroAlien)
        {
            CadenciaBaseTiroAlien += CalculoCadencia();
            Instantiate(TiroAlien, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.tag == "Player")
        {
            GestorDeSons.Instance.PlayOneShot(GestorDeSons.Instance.ExplosaoNave);
            coli.GetComponent<SpriteRenderer>().sprite = ImagemExplosaoNave;

            Destroy(gameObject);

            Destroy(coli.gameObject, 0.5f);

        }
    }
}
