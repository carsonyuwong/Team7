using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTextPerson : Collidable
{
    public string[] message;
    public int textSize;
    public float spaceAbove;
    private float coolDown = 4.0f;
    private float lastShout;

    protected override void Start()
    {
        base.Start();
        lastShout = -coolDown;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (Time.time - lastShout > coolDown)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[Random.Range(0, message.Length)], textSize, Color.red, transform.position + new Vector3(0, spaceAbove, 0), Vector3.zero, coolDown);
        }
    }
}