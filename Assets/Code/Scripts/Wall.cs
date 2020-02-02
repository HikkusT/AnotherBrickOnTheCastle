using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float wallWidth;
    public int numOfBricks;
    public GameObject brick;
    private float desiredBrickWidth;
    private float screenWidth;
    private float brickWidth;

    // Start is called before the first frame update
    void Start()
    {
        desiredBrickWidth = wallWidth / numOfBricks;
        brickWidth = brick.GetComponent<SpriteRenderer>().sprite.rect.width;
        float scaleMultiplier = desiredBrickWidth / brickWidth;

        for(int i = 0; i < numOfBricks; i ++)
        {
            GameObject brickInstance = Instantiate(brick, 
                                                  new Vector3((i * desiredBrickWidth + desiredBrickWidth / 2 - wallWidth/2)/100, 0, 0),
                                                  Quaternion.identity);
            brickInstance.transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
