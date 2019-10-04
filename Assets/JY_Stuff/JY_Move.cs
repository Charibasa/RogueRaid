using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Move : MonoBehaviour
{
    public bool CanMove;
    public int speedUp;
    public int speedBuff;
    public int guardUp;
    public bool hasSimple;
    public bool hasDesimple;
    public JY_TeleporterExit[] startPoints;
    bool IsMoving;
    Animator anim;
    Rigidbody2D Rb;
    Vector2 LastMovement;

    // Start is called before the first frame update
    void Start()
    {
        speedUp = 0;
        CanMove = true;
        hasSimple = false;
        hasDesimple = false;
        anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();

        int start = Random.Range(0, 3);
        gameObject.transform.position = startPoints[start].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Rb.velocity.magnitude > 0)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }

        if (CanMove)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                Rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * (5 + speedUp + (speedBuff / 2)), Rb.velocity.y);
                LastMovement = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            else
            {
                Rb.velocity = new Vector2(0f, Rb.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                Rb.velocity = new Vector2(Rb.velocity.x, Input.GetAxisRaw("Vertical") * (5 + speedUp + (speedBuff / 2)));
                LastMovement = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            else
            {
                Rb.velocity = new Vector2(Rb.velocity.x, 0f);
            }

            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetFloat("LastMoveX", LastMovement.x);
            anim.SetFloat("LastMoveY", LastMovement.y);
        }
        else
        {
            Rb.velocity = new Vector2(0f, 0f);
        }

        anim.SetBool("PlayerMoving", IsMoving);
    }
}
