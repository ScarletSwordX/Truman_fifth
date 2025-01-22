using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D PlayerRigidbody;
    public CapsuleCollider2D PlayerCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        PlayerRigidbody.velocity = new Vector2(MoveSpeed * horizontal, PlayerRigidbody.velocity.y);
    }

}
