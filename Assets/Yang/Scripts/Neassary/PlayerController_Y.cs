using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Y : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5.0f;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Filp();
        Voice();
    }

    private void Move()
    {
        Vector2 movement = rb.velocity;
        movement.x = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = movement;
        //检测移动速度绝对值是否大于零 生成bool值
        bool isMove = Mathf.Abs(movement.x) > Mathf.Epsilon;
        anim.SetBool("isMove",isMove);
        
    }


    private void Voice()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            VoiceManager.Instance.walkVoice();
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            VoiceManager.Instance.StopWalk();
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.R))
        {
            VoiceManager.Instance.FVoice();
        }
        /*else if (Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.R))
        {
            VoiceManager.Instance.StopF();
        }*/

    }


    private void Filp()
    {
        bool Speed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;//
        if (rb.velocity.x > 0.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (rb.velocity.x < -0.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //返回一个旋转，它围绕 z 轴旋转 z 度、围绕 x 轴旋转 x 度、围绕 y 轴旋转 y 度（按该顺序应用)
        }

    }


}
