using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MiniGameManager
{
    private static float speed = 1;
    private static float healing = 1;
    public static float nextHeight;
    public static GameObject MobileBrick;
    public static GameObject Wall;
    public static GameObject CastleManager;

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

    public static void NextRow()
    {
        //setHealing();
        //Destroy(MobileBrickInstance);
        //if (getHealth(CastleManager) + getHealing() >= getMaxHealth(CastleManager))
        //{
        //    getHealth(CastleManager) = getMaxHealth(CastleManager);
        //}
        //else
        //{
        //    getHealth(CastleManager) = getHealing() + getHealth(CastleManager);
        //    setSpeed();
        //    getHeight(Wall);
        //    GameObject MobileBrickInstance = Instantiate(MobileBrick, new Vector3(0, nextHeight, 0), Quaternion.identity);
        //}
    }

    //public void EndGame()
    //{
    //    Debug.Log("ACABOU");
    //}
}
