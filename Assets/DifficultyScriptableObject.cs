using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName ="DifficultyScriptableObject")]
public class DifficultyScriptableObject : ScriptableObject
{
    ///<summary>
    ///Coin(0), Blue(1), Yellow(2), Red(3), Shield(4), Target(5)
    ///</summary>
    public float[] chanceToSpawn = new float[6];
    
    //Time between spawns 
    public float minTimeBetweenSpawns;
    public float maxTimeBetweenSpawns;

    //Amount of objects in the screen at the same time.
    public int minObjects;
    public int maxObjects;
}
