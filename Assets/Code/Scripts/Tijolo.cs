using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tijolo : MonoBehaviour
{
    Vector3 direction;
    public float speed;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.right;
        velocity = speed * direction.normalized;
        this.transform.position = this.transform.position + velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        direction = -direction;
    }
}
