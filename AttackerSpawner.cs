using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

    void Update()
    {
        foreach(GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn (thisAttacker);
            }
        }
    }
    
    bool isTimeToSpawn (GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float spawnDelay = attacker.appearRateSeconds;
        float spawnPerSecond = 1 / spawnDelay;

        if (Time.deltaTime > spawnDelay)
        {
            Debug.Log("Warning spawn rate capped");
        }

        float threshold = spawnPerSecond * Time.deltaTime / 5;

        return (Random.value < threshold); //If return true, else return false
    }

    void Spawn (GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;

        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

   

}
