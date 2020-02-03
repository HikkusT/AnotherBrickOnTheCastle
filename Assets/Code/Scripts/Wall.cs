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
    public int wallHeight;

    public float baseHeight;

    private float brickWidth;
    private float brickHeight;
    private Queue<Vector2> holesPositions = new Queue<Vector2>();
    private Queue<Vector3> scales = new Queue<Vector3>();

    private List<GameObject> tiles = new List<GameObject>();
    private List<float> xPositions = new List<float>();
    private List<float> multipliers = new List<float>();
    private int rand;
    private float xPosition;
    private float multiplier;

    private float desiredBrickWidth;
    private float scaleMultiplier;

    private float lastHeight;

    public void StartGeneration()
    {
        holesPositions.Clear();
        scales.Clear();
        tiles.Clear();
        xPositions.Clear();
        multipliers.Clear();
        transform.position = Vector3.zero;

        brickWidth = brick.GetComponent<SpriteRenderer>().sprite.rect.width;
        GenerateWall();
        manager.CreateLari();
    }

    public void DestroyWall()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
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

        baseHeight = (brickHeight / 2) / 100 - Camera.main.orthographicSize;
        //for (int i = 0; i < 200 * Camera.main.orthographicSize / brickHeight; i++)
        for (int i =0; i <= wallHeight; i ++)
            GenerateRow((i * brickHeight) / 100 + baseHeight);

        lastHeight = (wallHeight * brickHeight) / 100 + baseHeight;
    }

    private void GenerateRow(float height)
    {
        Debug.Log("AQUI1");
        float startPos = (-wallWidth / 2) / 100;
        float currentLength = Random.Range(-desiredBrickWidth, 0);
        
        while (currentLength < wallWidth)
        {
            // Calcula o tamanho do tijolo
            float variation = Random.Range(-brickVariation, brickVariation);
            float currentBrickWidth = desiredBrickWidth * (1 + variation);

            currentLength += (currentBrickWidth / 2);
            float xPos = startPos + currentLength / 100;
            float scaleMultiplierX = currentBrickWidth / brickWidth;

            GameObject brickInstance = Instantiate(brick, new Vector3(xPos, height, 10), Quaternion.identity);
            brickInstance.transform.localScale = new Vector3(scaleMultiplierX, scaleMultiplier, 1);
            brickInstance.transform.SetParent(transform);

            // Se ele nao é o primeiro nem o último, adiciona na fila para possível buraco
            if ((currentLength - (currentBrickWidth / 2) > 0) && (currentLength + (currentBrickWidth / 2) < wallWidth))
            {
                tiles.Add(brickInstance);
                xPositions.Add(xPos);
                multipliers.Add(scaleMultiplierX);
            }

            currentLength += (currentBrickWidth / 2);
        }

        rand = Random.Range(0, tiles.Count);
        Debug.Log(tiles.Count);
        GameObject brickToDestroy = tiles[rand];
        xPosition = xPositions[rand];
        multiplier = multipliers[rand];
        Destroy(brickToDestroy);
      
        tiles.Clear();
        xPositions.Clear();
        multipliers.Clear();

        holesPositions.Enqueue(new Vector2(xPosition, height));
        scales.Enqueue(new Vector3(multiplier, scaleMultiplier, 1));
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

        GenerateRow(lastHeight);
        yield break;
    }

    void GenerateLaterals()
    {

    }
}
