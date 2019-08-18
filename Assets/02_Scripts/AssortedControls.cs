using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script containing assorted controls not related to the overlay setup system
public class AssortedControls : MonoBehaviour
{
    public void ContinueButton()
    {
        //Used on the load screen to switch to the main application page
        //Load screen is for information on the application and assorted logos etc.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
