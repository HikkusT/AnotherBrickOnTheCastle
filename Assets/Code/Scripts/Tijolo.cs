﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tijolo : MonoBehaviour
{
    public MiniGameManager manager;
    Vector3 direction;
    public float speed;
    public float posX;
    private float width;
    Vector3 velocity;
    bool foi = false;

    void Start()
    {
        direction = Vector3.left;
        width = GetComponent<SpriteRenderer>().sprite.rect.width * transform.localScale.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !foi)
        {
            speed = 0;
            if ((Mathf.Abs(transform.position.x - posX) < (width / 1000)))
            {
                foi = true;
                this.transform.position = new Vector3(posX, this.transform.position.y, this.transform.position.z);
                manager.ApplySuccess();
            }
            else
            {
                manager.ApplyFail();
            }
        }

        velocity = speed * direction.normalized;
        this.transform.position = this.transform.position + velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        direction = -direction;
    }

}
