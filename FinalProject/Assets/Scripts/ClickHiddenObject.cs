using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickHiddenObject : MonoBehaviour
{

    public static string NameOfObject; // string that's the name of the object
    public Transform SuccessfulClick; // the position of the successfully clicked hidden object

    public GameObject ObjectNameText; // the UI text label object that is associated with this hidden object
    public Transform ObjectNameTextPos; // the position of the associated UI text label object

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // WHEN OBJECT IS CLICKED
    void OnMouseDown()
    {
        //DATA MANAGEMENT
        NameOfObject = gameObject.name; // set the name of the object
        //Debug.Log(NameOfObject);
        FindObjectOfType<GameManager>().FoundObject(NameOfObject); // call the FoundObject function from the GameManager, letting it know which object this was

        //FEEDBACK ON FOUND OBJECT
        Instantiate(SuccessfulClick, gameObject.GetComponent<Transform>().position, SuccessfulClick.rotation); // particle effect where the hidden object is
        // Instantiate(SuccessfulClick, ObjectNameTextPos.position, SuccessfulClick.rotation); // particle effect where the text label is
         // sound effect
        

        //REMOVE OBJECT / STRIKE FROM LIST
        //Destroy(gameObject); // destroy the object once clicked
        ObjectNameText.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough; // strikethrough the UI text label
        //Destroy(ObjectNameText); // destroy the associated UI object once clicked

    }
    



}

