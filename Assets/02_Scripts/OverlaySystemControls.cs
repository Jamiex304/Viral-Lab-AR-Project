using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverlaySystemControls : MonoBehaviour
{
    //Blind References for the Gameobject and the Image Component.
    public GameObject imageTileRef_Blinds;
    public Image imageTileSpriteRef_Blinds;

    //Curtin Referneces for the Gameobjects and the Image Components.
    public GameObject imageTileRef_Curtins_Left;
    public Image imageTileSpriteRef_Curtins_Left;
    public GameObject imageTileRef_Curtins_Right;
    public Image imageTileSpriteRef_Curtins_Right;

    //Trigger buttons for either setup
    public GameObject buttonsStartOverlayBlinds;
    public GameObject buttonsStartOverlayCurtins;

    //Scalable Area Controls (Currently Contains 4 button setup)
    public GameObject panelAdjustableScaleArrows;
    //Extra Step for the Curtains 
    public GameObject panelLocationArrows;

    //Assorted buttons for toggling the below named features
    //Visability toggle
    //Next Step
    //End overlay setup
    //Restart overlay setup
    public GameObject buttonVisabilityToggle;
    public GameObject buttonEndOverlaySetup;
    public GameObject buttonNextStepSetup;
    public GameObject buttonRestartEverything;

    //Product examples scrollable area setup
    //Contains product samples
    public GameObject panelProductsExample;

    //Visiabilty Control settings
    bool isUIVisable = true;
    public Image visabilityButtonSpriteRef;
    public Sprite[] visabiltyImages;

    //Trigger conditions to alert the system what type of setup to run
    public bool isSettingUpBlinds = false;
    public bool isSettingUpCurtins = false;

    //Trigger Condition (used by the ProductExample script)
    public bool isSetupComplete = false;

    public GameObject targetReticle;

    public void StartBlindsSetup() {
        //Spawn the blank image tile in the centre of screen
        //This gameObject has been preplaced in the scene
        imageTileRef_Blinds.SetActive(true);
        isSettingUpBlinds = true;
        targetReticle.SetActive(true);
        //After the image tile is spawned hide the initial start button from the user
        buttonsStartOverlayBlinds.SetActive(false);
        buttonsStartOverlayCurtins.SetActive(false);
        //Call in the scale arrows (see below method for more details)
        AdjustmentSystem();
    }

    public void StartCurtinsSetup()
    {
        //Spawn the blank image tile in the centre of screen
        //This gameObject has been preplaced in the scene
        //Debug.Log("StartInitialSetup Method Called");
        imageTileRef_Curtins_Left.SetActive(true);
        imageTileRef_Curtins_Right.SetActive(true);
        isSettingUpCurtins = true;
        targetReticle.SetActive(true);
        //After the image tile is spawned hide the initial start buttons from the user
        buttonsStartOverlayBlinds.SetActive(false);
        buttonsStartOverlayCurtins.SetActive(false);
        //Call in the scale arrows (see below method for more details)
        AdjustmentSystem();
    }

    void AdjustmentSystem() {
        //Spawn 4 arrows that will allow the user to adjust the scale of the image tile for there needed area
        //Debug.Log("SpawnScaleArrows Method Called");
        if (isSettingUpBlinds == true) {
            panelAdjustableScaleArrows.SetActive(true);
            //Spawn overlay end button
            buttonEndOverlaySetup.SetActive(true);
            buttonRestartEverything.SetActive(true);
        } else if (isSettingUpCurtins == true) {
            panelLocationArrows.SetActive(true);
            buttonNextStepSetup.SetActive(true);
            buttonRestartEverything.SetActive(true);
        }
    }

    public void NextStep() {
        //Curtains Only Function
        panelLocationArrows.SetActive(false);
        panelAdjustableScaleArrows.SetActive(true);
        buttonEndOverlaySetup.SetActive(true);
        buttonRestartEverything.SetActive(true);
    }

    public void EndInitialSetup() {
        //Function called once the user is happy with the layout
        //Overlay the choosen image tile sprite
        
        //Hide overlay setup controls
        panelAdjustableScaleArrows.SetActive(false);
        buttonEndOverlaySetup.SetActive(false);
        panelProductsExample.SetActive(true);
        buttonVisabilityToggle.SetActive(true);
        isSetupComplete = true;
        targetReticle.SetActive(false);
    }

    public void RestartSetup()
    {
        //Restart Setup If The User wants to try again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UIVisability() {
        //Show and Hide The UI
        //Uses bool for the toggle condition
        if (isUIVisable == true)
        {
            //If The UI is visable, hide it
            panelProductsExample.SetActive(false);
            visabilityButtonSpriteRef.sprite = visabiltyImages[0];//Hide Visabilty Icon - first position in the array
            isUIVisable = false;
        }
        else if (isUIVisable == false){
            //If The UI is not visable, show it
            panelProductsExample.SetActive(true);
            visabilityButtonSpriteRef.sprite = visabiltyImages[1];//Show Visabilty Icon - second position in the array
            isUIVisable = true;
        }
    }
}
