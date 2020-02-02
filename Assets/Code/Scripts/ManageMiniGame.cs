using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    private float speed;
    private float healing;
    public float nextHeight
    public GameObject MobileBrick;
    public GameObject Wall;
    public GameObject CastleManager;

    private  getHeight(GameObject Wall) {
        this.nextHeight = Wall.nextheight();
    }

    private float getMaxHealth(GameObject CastleManager) {
        return CastleManager.maxHealth;
    }

    private float getHealth(GameObject CastleManger) {
        return CastleManger.health
    }

    public float getSpeed() {
        return this.speed;
    }

    public float getHealing() {
        return this.healing;
    }

    private void setHealing() {
        this.healing = this.healing + this.healing*1.5;
    }

    private void setSpeed() {
        this.speed = 1.1*this.speed
    }

    // Start is called before the first frame update
    void Start()
    {

        speed = 1
        healing = 1
        this.nextHeight = getHeight();
        GameObject MobileBrickInstance = Instantiate(MobileBrick, new Vector3(0, this.nextHeight, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(MobileBrickInstance.sucess ==  True) {
            setHealing();
            Destroy(MobileBrickInstance);
            if(getHealth(CastleManager) + getHealing() >= getMaxHealth(CastleManager)){
               getHealth(CastleManager) = getMaxHealth(CastleManager);
            } else {
                getHealth(CastleManager) = getHealing() + getHealth(CastleManager);
                setSpeed();
                getHeight(Wall);
                GameObject MobileBrickInstance = Instantiate(MobileBrick, new Vector3(0, this.nextHeight, 0), Quaternion.identity);
            }
        } else {
            Destroy(MobileBrickInstance);
            Debug.Log('DEU RUIM')
        }
    }
}
