using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Introduction System Script (Optional System)
//User will have a choice when opening the app
public class IntroductionSystem : MonoBehaviour
{
    //Variables--
    bool userWantsIntroduction;

    public GameObject IntroductionPanel;

    //Setup Option
    public GameObject Setup;
    public GameObject AllAppControls;//All In-game app controls (Important Must Be Viewable for App to work)

    //Step One
    public GameObject firstIntroduction;
    //--

    public void HideIntroductonPanel() {
        //Hide Introduction Panel System
        IntroductionPanel.SetActive(false);
    }

    public void ShowIntroduction() {
        //Start The Introduction Walkthrough
        userWantsIntroduction = true;
        Setup.SetActive(false);
        firstIntroduction.SetActive(true);
        AllAppControls.SetActive(true);
    }

    public void SkipIntroduction() {
        //Skip The Introduction Walkthrough
        userWantsIntroduction = false;
        Setup.SetActive(false);
        AllAppControls.SetActive(true);
        HideIntroductonPanel();
    }
}
