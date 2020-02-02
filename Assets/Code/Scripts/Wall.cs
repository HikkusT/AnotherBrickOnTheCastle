using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public MiniGameManager manager;
    public float wallWidth;
    public int numOfBricks;
    public GameObject brick;
    public float brickVariation;

    private float brickWidth;
    private float brickHeight;
    private Queue<Vector2> holesPositions = new Queue<Vector2>();
    private Queue<Vector3> scales = new Queue<Vector3>();
    private float desiredBrickWidth;
    private float scaleMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;

        brickWidth = brick.GetComponent<SpriteRenderer>().sprite.rect.width;
        GenerateWall();
        manager.CreateLari();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetHolePos()
    {
        return holesPositions.Dequeue();
    }

    public Vector3 GetScale()
    {
        return scales.Dequeue();
    }

    private void GenerateWall()
    {
        desiredBrickWidth = wallWidth / numOfBricks;
        scaleMultiplier = desiredBrickWidth / brickWidth;
        brickHeight = scaleMultiplier * brick.GetComponent<SpriteRenderer>().sprite.rect.height;

        for (int i = 0; i < 200 * Camera.main.orthographicSize / brickHeight; i++)
            GenerateRow((i * brickHeight + brickHeight / 2) / 100 - Camera.main.orthographicSize);
    }

    private void GenerateRow(float height)
    {
        float startPos = (-wallWidth / 2) / 100;
        float currentLength = 0;
        int chosenTile = Random.Range(0, numOfBricks);
        
        for (int i = 0; i < numOfBricks; i++)
        {
            float variation = Random.Range(-brickVariation, brickVariation);
            float currentBrickWidth = desiredBrickWidth * (1 + variation);

            if (i == numOfBricks - 1)
                currentBrickWidth = wallWidth - currentLength;

            currentLength += (currentBrickWidth / 2);
            float xPos = startPos + currentLength / 100;
            float scaleMultiplierX = currentBrickWidth / brickWidth;
            if (i != chosenTile)
            {
                GameObject brickInstance = Instantiate(brick, new Vector3(xPos, height, 10), Quaternion.identity);
                brickInstance.transform.SetParent(transform);

                brickInstance.transform.localScale = new Vector3(scaleMultiplierX, scaleMultiplier, 1);
            }
            else
            {
                holesPositions.Enqueue(new Vector2(xPos, height));
                scales.Enqueue(new Vector3(scaleMultiplierX, scaleMultiplier, 1));
            }
            currentLength += (currentBrickWidth / 2);
        }
    }

    public float EaseInBack(float start, float end, float value)
    {
        end -= start;
        value /= 1;
        float s = 1.70158f;
        return end * (value) * value * ((s + 1) * value - s) + start;
    }

    public float EaseOutBack(float start, float end, float value)
    {
        float s = 1.70158f;
        end -= start;
        value = (value) - 1;
        return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
    }

    public float EaseInOutBack(float start, float end, float value)
    {
        float s = 1.70158f;
        end -= start;
        value /= .5f;
        if ((value) < 1)
        {
            s *= (1.525f);
            return end * 0.5f * (value * value * (((s) + 1) * value - s)) + start;
        }
        value -= 2;
        s *= (1.525f);
        return end * 0.5f * ((value) * value * (((s) + 1) * value + s) + 2) + start;
    }

    public IEnumerator AnimateNextRow()
    {
        float elapsedTime = 0;
        float startingPos = transform.position.y;
        float endPos = startingPos - brickHeight / 100;

        while (elapsedTime < 0.75f)
        {
            transform.position = new Vector3(transform.position.x, EaseInOutBack(startingPos, endPos, elapsedTime / 0.75f), transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Debug.Log("EEE");
        yield break;
    }
}
