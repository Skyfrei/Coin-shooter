using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool wonGame = false;
    private ObjectManager objectManager;

    [SerializeField]
    private float countdown = 120.0f;

    void Start()
    {
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.score >= 100)
        {
            wonGame = true;
            Debug.Log("Congratulations you won!");
        }
        if (countdown <= 0 && wonGame == false)
        {
            Lost();
            return;
        }
        countdown -= Time.deltaTime;
    }

    private void Lost()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
