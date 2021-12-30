using UnityEngine;

public class Player : MonoBehaviour
{
    public static int score = 0;
    private GameManager manager;
    private ObjectManager objectManager;
    

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    
    public void ScorePoint()
    {
        score++;
    }
}
