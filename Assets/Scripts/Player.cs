using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float tankSpeed = 3;
    private Vector3 bulletRotatian;
    private float timeVal;
    private float attckCD = 0.5f;

    private SpriteRenderer srTank;
    public Sprite[] spTanks;//上，右，下，左
    public GameObject Bullet;
    

    private void Awake()
    {
        srTank = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (timeVal> attckCD)
        {
            Attack();
        }
        else
        {
            timeVal = Time.deltaTime;
        }
    }

    //固定物理帧
    private void FixedUpdate()
    {
        TankMove();
        Attack();
    }

    /// <summary>
    /// 控制坦克移动
    /// </summary>
    private void TankMove()
    {
        float h = Input.GetAxisRaw("Horizontal");//控制水平方向的移动，h<0向左，h>0向右
        transform.Translate(Vector3.right * h * tankSpeed * Time.fixedDeltaTime, Space.World);

        if (h < 0)
        {
            srTank.sprite = spTanks[3];
            bulletRotatian = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            srTank.sprite = spTanks[1];
            bulletRotatian = new Vector3(0, 0, -90);
        }

        if (!Mathf.Approximately(h,0)) return;

        float v = Input.GetAxisRaw("Vertical");//控制垂直方向的移动，v<0向下，v>0向右
        transform.Translate(Vector3.up * v * tankSpeed * Time.fixedDeltaTime, Space.World);

        if (v < 0)
        {
            bulletRotatian = new Vector3(0, 0, -180);
            srTank.sprite = spTanks[2];
        }
        else if (v > 0)
        {
            bulletRotatian = new Vector3(0, 0, 0);
            srTank.sprite = spTanks[0];
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position, Quaternion.Euler(transform.eulerAngles + bulletRotatian));
            timeVal = 0;
        }
    }
}
