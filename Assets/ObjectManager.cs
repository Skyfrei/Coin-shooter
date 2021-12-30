using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public List<Objects> listOfObjects = new List<Objects>();
    //Work on this next
    private float spawnCooldown;
    private float tempCooldown;
    private float despawnCooldown;
    
    private int minspawnObjects;
    private int maxspawnObjects;
    [SerializeField]
    private float[] chanceToSpawn;

    public DifficultyScriptableObject diffScriptableObject;

    //Existing objects in the game as GameObjects.
    public CoinObject coin0;
    public CoinObject coin1;
    public CoinObject coin2;
    public CoinObject coin3;
    public CoinObject coin4;
    public CoinObject coin5;
    public CoinObject coin6;

    public BlueObject blue0;
    public BlueObject blue1;
    public BlueObject blue2;

    public YellowObject yellow0;
    public YellowObject yellow1;
    public YellowObject yellow2;

    public RedObject red0;
    public RedObject red1;
    public RedObject red2;

    public ShieldObject shield0;
    public ShieldObject shield1;
    public ShieldObject shield2;

    public TargetObject target0;
    public TargetObject target1;
    public TargetObject target2;

    //List that stores the GameObjects so you can use it to insert them randomly
    //In the Logic function.
    private List<Objects> coinList; 
    private List<Objects> blueList; 
    private List<Objects> yellowList; 
    private List<Objects> redList; 
    private List<Objects> shieldList; 
    private List<Objects> targetList; 

    public bool nextFiveAreCoin = false;
    public byte nextFiveAreCoinCount = 0;
    
    public void GetDifficultyStats()
    {
        //Getting info from the scriptable objects
        minspawnObjects = diffScriptableObject.minObjects;
        maxspawnObjects = diffScriptableObject.maxObjects;
        chanceToSpawn = diffScriptableObject.chanceToSpawn;
        tempCooldown = diffScriptableObject.minTimeBetweenSpawns;
        despawnCooldown = diffScriptableObject.maxTimeBetweenSpawns;

        spawnCooldown = tempCooldown;

        coinList = new List<Objects>{coin0, coin1, coin2, coin3, coin4, coin5, coin6};
        blueList = new List<Objects>{blue0, blue1, blue2};
        yellowList = new List<Objects>{yellow0, yellow1, yellow2};
        redList = new List<Objects>{red0, red1, red2};
        shieldList = new List<Objects>{shield0, shield1, shield2};
        targetList = new List<Objects>{target0, target1, target2};

        GiveDespawnCooldown(coinList);
        GiveDespawnCooldown(blueList);
        GiveDespawnCooldown(yellowList);
        GiveDespawnCooldown(redList);
        GiveDespawnCooldown(shieldList);
        GiveDespawnCooldown(targetList);

    }

    void Update()
    {
        if (diffScriptableObject == null)
        {
            return;
        }
        SpawnObject();
        tempCooldown -= Time.deltaTime;
        DecreaseCooldownObject();
    }

    private void SpawnObject()
    {
        if (tempCooldown <= 0 && listOfObjects.Count < maxspawnObjects)
        {
            ProbabilityLogic();
            tempCooldown = spawnCooldown;
        }
        //Spawn no matter what, because there isn't enough objects on the screen.
        if (listOfObjects.Count < minspawnObjects)
        {
            ProbabilityLogic();
        }
    }

    public void DespawnWhenHit(Objects obj)
    {
        obj.transform.localScale = new Vector3(0, 0, 0);
        listOfObjects.Remove(obj);
    }

    private void ProbabilityLogic()
    {
        //Spawning objects based on probability
            for (int i = listOfObjects.Count; i < maxspawnObjects; i++)
            {
                float randomRoll = Random.Range(0.0f, 1.0f);
                //Assume that the chanceTospawn array is a numerical meter with really small numbers 0.0f-1.0f.
                //We keep adding to the percentage until the rolled number is between index j and j - 1.
                //We then spawn the object that is in that index.
                float sumPercentage = 0.0f;
                if (listOfObjects.Count < maxspawnObjects)
                {
                    for (int j = 1; j < chanceToSpawn.Length; j++)
                    {
                        sumPercentage += chanceToSpawn[j-1];
                        if (randomRoll <= sumPercentage && randomRoll > sumPercentage - chanceToSpawn[j])
                        {
                            if(nextFiveAreCoin == true && nextFiveAreCoinCount > 0)
                            {
                                InsertInList(coinList);
                                nextFiveAreCoinCount--;
                                if(nextFiveAreCoinCount == 0)
                                {
                                    nextFiveAreCoin = false;
                                }
                                return;
                            }
                            //Based on where the randomRoll landed on, we spawn an object
                            //Coin(0), Blue(1), Yellow(2), Red(3), Shield(4), Target(5) for each difficulty
                            switch(j)
                            {
                                case 0:
                                    InsertInList(coinList);
                                    break;
                                case 1:
                                    InsertInList(blueList);
                                    break;
                                case 2:
                                    InsertInList(yellowList);
                                    break;
                                case 3:
                                    InsertInList(redList);
                                    break;
                                case 4:
                                    InsertInList(shieldList);
                                    break;
                                case 5:
                                    InsertInList(targetList);
                                    break;
                            }
                        }
                    }
                }
            }
    }
    ///<summary>
    ///Inserts new objects in the list so they get rendered on the screen.
    ///</summary>
    public void InsertInList(List<Objects> tempList)
    {
        foreach(Objects obj in tempList)
        {
            if(!listOfObjects.Contains(obj))
            {
                //If obj doesn't exist in the list it's given a timer and added in
                obj.Timer = despawnCooldown;
                obj.gameObject.transform.localScale = new Vector3(1, 1, 1);
                float randombObjectX = Random.Range(-16.0f, 16.0f);
                float randombObjectY = Random.Range(0.0f, 9.0f);
                float randomObjectZ = Random.Range(13.0f, 24.0f);
                obj.gameObject.transform.position = new Vector3(randombObjectX, randombObjectY, randomObjectZ);
                listOfObjects.Add(obj);
                return;
            }
        }         
    }

    ///<summary>
    ///Gives each object a timer before despawn.
    ///</summary>
    private void GiveDespawnCooldown(List<Objects> list)
    {
        foreach(Objects obj in list)
        {
            obj.Timer = despawnCooldown;
        }
    }
    ///<summary>
    ///Decreases the cooldown of all objects with delta time.
    ///</summary>
    private void DecreaseCooldownObject()
    {
        for(int i = listOfObjects.Count - 1; i >= 0; i--)
        {
            listOfObjects[i].Timer -= Time.deltaTime;
            if(listOfObjects[i].Timer <= 0)
            {
                listOfObjects.Remove(listOfObjects[i]);
            }
        }
    }
}
