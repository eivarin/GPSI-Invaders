using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Nave : MonoBehaviour
{
    public float speed = 30;

    public GameObject oTiro;

    void FixedUpdate()
    {
        float horzMove = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horzMove * speed, 0);
    }
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horzMove = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horzMove * speed, 0);
        if (CrossPlatformInputManager.GetButtonDown("DispararBTN"))
        {
            Instantiate(oTiro, transform.position, Quaternion.identity);

            GestorDeSons.Instance.PlayOneShot(GestorDeSons.Instance.TiroDisparado);
        }
    }
}
