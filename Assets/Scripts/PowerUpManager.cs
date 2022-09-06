using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public List<GameObject> powerUpTemplateList;


    private List<GameObject> powerUpList;
    private float timer;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }
    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        //if (powerUpList.Count >= maxPowerUpAmount)
        //{
        //    return;
        //}

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);
        powerUpList.Add(powerUp);

        //Jika 'jumlah powerUpList' lebih besar dari 'maxPowerUpAmount', penghapusan power up dimulai
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            //Destroy(powerUp, spawnInterval);

            RemoveAllPowerUp();     //Method Penghapus
        }

        Debug.Log(powerUpList);
        Debug.Log(spawnArea);
        Debug.Log(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > maxPowerUpAmount)   //Jika 'jumlah powerUpList' diatas 2, 
        {                                              //maka menghapus powerUp pada index 0    
            RemovePowerUp(powerUpList[0]);
        }
    }
}
