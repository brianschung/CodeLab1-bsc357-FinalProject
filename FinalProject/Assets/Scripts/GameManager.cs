using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // holds the singleton

    private float timer = 0; // time variable
    private TextMeshProUGUI timeChangingText; // variable to hold component
    public GameObject timerText; // the timer ui GameObject

    private int NumberOfClicks; // variable for the number of clicks
    private TextMeshProUGUI clicksChangingText; // variable to hold the clicks text component
    public GameObject clickText; // the clicks ui GameObject

    //LIST OF ALL HIDDEN OBJECTS
    public List<string> foundObjects = new List<string>();
    private string[] hiddenObjects = { "Bug", "Mug", "PlantZZ", "TV" };


    private void Awake()
    {
        if (instance == null)
        { 
            instance = this; // set instance to be this object
            DontDestroyOnLoad(gameObject); // don't destroy this object when loading a new scene
        }
        else
        { 
            Destroy(gameObject); // if this object exists already, destroy (so that there's only 1 total)
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        timeChangingText = timerText.GetComponent<TextMeshProUGUI>();
        timer = 0;

        clicksChangingText = clickText.GetComponent<TextMeshProUGUI>();
        NumberOfClicks = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // TIMER
        timer += Time.deltaTime; // increase the timer by deltaTime every frame
        timeChangingText.text = "Time: " + (int)timer; // set text component with the time (rounded)

        // CLICKS
        if (Input.GetMouseButtonDown(0)) // if the player clicks
        {
            NumberOfClicks += 1; // increment the number of clicks
            clicksChangingText.text = "Clicks: " + NumberOfClicks; // function to set the text
            //Debug.Log("Clicks: " + NumberOfClicks);
        }

        // PRESS R TO RESTART
        if (Input.GetKeyDown(KeyCode.R))
        {
            print("game restarted!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        // IS THE GAME OVER?

        if (foundObjects.Count == hiddenObjects.Length)
        {
            Debug.Log("GAME OVER");
        }

    }


    // WHEN AN OBJECT IS FOUND
    public bool FoundObject(string key)
    {
        if (foundObjects.Contains(key)) return false;
        foundObjects.Add(key);
        IsGameOver();
        return true;
    }

    // WHETHER THE GAME IS OVER OR NOT
    public bool IsGameOver()
    {
        return foundObjects.Count == hiddenObjects.Length; // it's true when the number of found objects matches the total number of hidden objects in the list
    }


}
