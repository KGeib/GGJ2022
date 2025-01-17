using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnPlayers : MonoBehaviour
{

    public GameObject playerPrefab;

    public GameObject prefabBullets;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;



    void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }

    void Update()
    {
        
    }

    public void InstantiateBullet(Vector2 bulletPosition) 
    {
        PhotonNetwork.Instantiate(prefabBullets.name, bulletPosition, Quaternion.identity);
    }
}
