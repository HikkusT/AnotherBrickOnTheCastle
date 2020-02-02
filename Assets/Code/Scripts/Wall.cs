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

    // Start is called before the first frame update
    void Start()
    {
        brickWidth = brick.GetComponent<SpriteRenderer>().sprite.rect.width;
        GenerateWall();
        manager.NextRow();
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
        float brickHeight = scaleMultiplier * brick.GetComponent<SpriteRenderer>().sprite.rect.height;

        for (int i = 0; i < 200 * Camera.main.orthographicSize / brickHeight; i++)
            GenerateRow((i * brickHeight + brickHeight / 2) / 100 - Camera.main.orthographicSize);
    }

    private void GenerateRow(float height)
    {

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

            GameObject brickInstance = Instantiate(brick, new Vector2(xPos, height), Quaternion.identity);
            brickInstance.transform.localScale = new Vector3(scaleMultiplierX, scaleMultiplier, 1);

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
        brick = tiles[rand];
        xPosition = xPositions[rand];
        multiplier = multipliers[rand];
        Destroy(brick);
      
        tiles.Clear();
        xPositions.Clear();
        multipliers.Clear();

        holesPositions.Enqueue(new Vector2(xPosition, height));
        scales.Enqueue(new Vector3(multiplier, scaleMultiplier, 1));
    }
}