﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public GameObject mobileBrickPrefab;
    public Wall wall;

    private float speed = 1;
    //private static float healing = 1;
    //public static float nextHeight;
    //public static GameObject CastleManager;
    private GameObject mobileBrickInstance;

    //private  getHeight(GameObject Wall) {
    //    nextHeight = Wall.nextheight();
    //}

    //private float getMaxHealth(GameObject CastleManager) {
    //    return CastleManager.maxHealth;
    //}

    //private float getHealth(GameObject CastleManger) {
    //    return CastleManger.health;
    //}

    //public float getSpeed() {
    //    return speed;
    //}

    //public float getHealing() {
    //    return healing;
    //}

    //private void setHealing() {
    //    healing = healing + healing*1.5;
    //}

    //private void setSpeed() {
    //    speed = 1.1 * speed;
    //}

    // Start is called before the first frame update
    //void Start()
    //{

    //    speed = 1;
    //    healing = 1;
    //    this.nextHeight = getHeight();
    //    GameObject MobileBrickInstance = Instantiate(MobileBrick, new Vector3(0, this.nextHeight, 0), Quaternion.identity);
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if(MobileBrickInstance.sucess ==  True) {
    //        setHealing();
    //        Destroy(MobileBrickInstance);
    //        if(getHealth(CastleManager) + getHealing() >= getMaxHealth(CastleManager)){
    //           getHealth(CastleManager) = getMaxHealth(CastleManager);
    //        } else {
    //            getHealth(CastleManager) = getHealing() + getHealth(CastleManager);
    //            setSpeed();
    //            getHeight(Wall);
    //            GameObject MobileBrickInstance = Instantiate(MobileBrick, new Vector3(0, this.nextHeight, 0), Quaternion.identity);
    //        }
    //    } else {
    //        Destroy(MobileBrickInstance);
    //        Debug.Log("DEU RUIM");
    //    }
    //}

    public IEnumerator NextRow()
    {
        if (mobileBrickInstance != null)
        {
            //mobileBrickInstance.transform.SetParent(wall.transform);
            Destroy(mobileBrickInstance.GetComponent<Tijolo>());
        }
        yield return StartCoroutine(wall.AnimateNextRow());
        Debug.Log("FFFF");

        CreateLari();
    }

    public void CreateLari()
    {
        speed = 1.1f * speed;
        Vector2 holePos = wall.GetHolePos();
        Vector3 scale = wall.GetScale();

        mobileBrickInstance = Instantiate(mobileBrickPrefab, new Vector3(0, holePos.y, 0), Quaternion.identity);
        mobileBrickInstance.transform.localScale = scale;
        mobileBrickInstance.GetComponent<Tijolo>().posX = holePos.x;
        mobileBrickInstance.GetComponent<Tijolo>().speed = speed;
        mobileBrickInstance.GetComponent<Tijolo>().manager = this.GetComponent<MiniGameManager>();
        mobileBrickInstance.GetComponent<BoxCollider2D>().size = mobileBrickInstance.GetComponent<SpriteRenderer>().sprite.bounds.size;
    }

    public void EndGame()
    {
        Debug.Log("ACABOU");
    }
}
