using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public GameObject mobileBrickPrefab;
    public Wall wall;
    public int initialLives;
    public float initialSpeed;
    public GameObject gameOverCanvas;
    public Text infos;
    public Fader fader;
    public float animationPersistence;
    public Sprite[] spritesheet;
    public SpriteRenderer mestreDeObras;

    [HideInInspector]
    public int highScore = 0;
    [HideInInspector]
    public int lives;

    private float speed = 1;
    private GameObject mobileBrickInstance;

    void Start()
    {
        StartLevel();
    }

    void StartLevel()
    {
        gameOverCanvas.SetActive(false);
        lives = initialLives;
        speed = initialSpeed;
        wall.StartGeneration();
    }

    void DestroyLevel()
    {
        wall.DestroyWall();
        Destroy(mobileBrickInstance);
    }

    public void RestartLevel()
    {
        StartCoroutine(fader.FadeOut(0.3f));
        DestroyLevel();
        StartLevel();
    }

    private void Update()
    {
        infos.text = "Lives: " + lives + "\nScore: " + highScore;
    }

    private IEnumerator NextRow()
    {
        if (mobileBrickInstance != null)
        {
            mobileBrickInstance.transform.SetParent(wall.transform);
            Destroy(mobileBrickInstance.GetComponent<Tijolo>());
        }
        yield return StartCoroutine(wall.AnimateNextRow());
        Debug.Log("FFFF");

        CreateLari();
        yield return null;
    }

    public void CreateLari()
    {
        speed = 1.1f * speed;
        Vector2 holePos = wall.GetHolePos();
        float height = wall.baseHeight;
        Vector3 scale = wall.GetScale();

        mobileBrickInstance = Instantiate(mobileBrickPrefab, new Vector3(0, height, 0), Quaternion.identity);
        mobileBrickInstance.transform.localScale = scale;
        mobileBrickInstance.GetComponent<Tijolo>().posX = holePos.x;
        mobileBrickInstance.GetComponent<Tijolo>().speed = speed;
        mobileBrickInstance.GetComponent<Tijolo>().manager = this.GetComponent<MiniGameManager>();
        mobileBrickInstance.GetComponent<BoxCollider2D>().size = mobileBrickInstance.GetComponent<SpriteRenderer>().sprite.bounds.size;
    }

    public void ApplyFail()
    {
        StartCoroutine(mestreDeObrasFail());
        StartCoroutine(Camera.main.GetComponent<CameraEffect>().ShakeScreen(0.2f));
        lives--;
        if (lives > 0)
            StartCoroutine(NextRow());
        else
            StartCoroutine(EndGame());
    }

    public void ApplySuccess()
    {
        StartCoroutine(mestreDeObrasSuccess());
        highScore++;
        StartCoroutine(NextRow());
    }

    private IEnumerator EndGame()
    {
        yield return fader.FadeIn(0.3f);
        gameOverCanvas.SetActive(true);
    }

    private IEnumerator mestreDeObrasFail()
    {
        mestreDeObras.sprite = spritesheet[1];

        yield return new WaitForSeconds(animationPersistence);

        mestreDeObras.sprite = spritesheet[0];
    }

    private IEnumerator mestreDeObrasSuccess()
    {
        mestreDeObras.sprite = spritesheet[2];

        yield return new WaitForSeconds(animationPersistence);

        mestreDeObras.sprite = spritesheet[0];
    }
}
