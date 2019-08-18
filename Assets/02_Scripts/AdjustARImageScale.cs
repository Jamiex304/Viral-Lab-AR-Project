using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustARImageScale : MonoBehaviour
{
    public OverlaySystemControls initialOverlaySystem;

    //Vector2 Relations For The Blind
    Vector2 adjustableScale;

    //Vector2 Relations For The Left and Right Curtims
    Vector2 movementPositionLeftCurtin;
    Vector2 movementPositionRightCurtin;

    //Use in the Adjustment Of The Curtins
    //float movementAdjustmentValue = 50f;
    //float scaleAdjustmentValue = 0.5f;

    //Test Values For AR Mid-Air & Ground Tests (Above Commented Out Values Are For Current Working Prototype)
    float movementAdjustmentValue = 0.05f;
    float scaleAdjustmentValue = 0.05f;

    void Start()
    {
        adjustableScale = new Vector2(initialOverlaySystem.imageTileRef_Blinds.transform.localScale.x, 
        initialOverlaySystem.imageTileRef_Blinds.transform.localScale.y);

        movementPositionLeftCurtin = new Vector2(initialOverlaySystem.imageTileRef_Curtins_Left.transform.localPosition.x,
        initialOverlaySystem.imageTileRef_Curtins_Left.transform.localPosition.y);

        movementPositionRightCurtin = new Vector2(initialOverlaySystem.imageTileRef_Curtins_Right.transform.localPosition.x,
        initialOverlaySystem.imageTileRef_Curtins_Right.transform.localPosition.y);

        if (initialOverlaySystem.isSettingUpCurtins == true) {

        }
    }

    //Curtain Space Settings
    public void IncreaseSpace() {
        if (initialOverlaySystem.isSettingUpCurtins == true)
        {
            movementPositionLeftCurtin.x = movementPositionLeftCurtin.x - movementAdjustmentValue;
            movementPositionRightCurtin.x = movementPositionRightCurtin.x + movementAdjustmentValue;
            initialOverlaySystem.imageTileRef_Curtins_Left.transform.localPosition = movementPositionLeftCurtin;
            initialOverlaySystem.imageTileRef_Curtins_Right.transform.localPosition = movementPositionRightCurtin;
        }
    }

    public void DecreaseSpace(){
        if (initialOverlaySystem.isSettingUpCurtins == true)
        {
            movementPositionLeftCurtin.x = movementPositionLeftCurtin.x + movementAdjustmentValue;
            movementPositionRightCurtin.x = movementPositionRightCurtin.x - movementAdjustmentValue;
            initialOverlaySystem.imageTileRef_Curtins_Left.transform.localPosition = movementPositionLeftCurtin;
            initialOverlaySystem.imageTileRef_Curtins_Right.transform.localPosition = movementPositionRightCurtin;
        }

    }

    //Start of code block system
    //Four button system for setting up the blinds and curtins
    public void IncreaseWidth() {
        if (initialOverlaySystem.isSettingUpBlinds == true) {
            Debug.Log("IncreaseWidth - Blinds");
            adjustableScale.x = adjustableScale.x + scaleAdjustmentValue;
            initialOverlaySystem.imageTileRef_Blinds.transform.localScale = adjustableScale;
        } else if (initialOverlaySystem.isSettingUpCurtins == true) {
            Debug.Log("IncreaseWidth - Curtins");
            adjustableScale.x = adjustableScale.x + scaleAdjustmentValue;
            initialOverlaySystem.imageTileRef_Curtins_Left.transform.localScale = adjustableScale;
            initialOverlaySystem.imageTileRef_Curtins_Right.transform.localScale = adjustableScale;
        }
    }

    public void IncreaseLength()
    {
        if (initialOverlaySystem.isSettingUpBlinds == true)
        {
            Debug.Log("IncreaseLength - Blinds");
            //adjustableScale.y++;
            adjustableScale.y = adjustableScale.y + scaleAdjustmentValue;
            initialOverlaySystem.imageTileRef_Blinds.transform.localScale = adjustableScale;
        }
        else if (initialOverlaySystem.isSettingUpCurtins == true)
        {
            Debug.Log("IncreaseWidth - Curtins");
            adjustableScale.y = adjustableScale.y + scaleAdjustmentValue;
            initialOverlaySystem.imageTileRef_Curtins_Left.transform.localScale = adjustableScale;
            initialOverlaySystem.imageTileRef_Curtins_Right.transform.localScale = adjustableScale;
        }
    }

    public void DecreaseLength()
    {
        if (adjustableScale.y >= 0.1)
        {
            if (initialOverlaySystem.isSettingUpBlinds == true)
            {
                Debug.Log("Decrease Length - Blinds");
                //adjustableScale.y--;
                adjustableScale.y = adjustableScale.y - scaleAdjustmentValue;
                initialOverlaySystem.imageTileRef_Blinds.transform.localScale = adjustableScale;
            }
            else if (initialOverlaySystem.isSettingUpCurtins == true)
            {
                Debug.Log("Decrease Length - Curtins");
                //adjustableScale.y--;
                adjustableScale.y = adjustableScale.y - scaleAdjustmentValue;
                initialOverlaySystem.imageTileRef_Curtins_Left.transform.localScale = adjustableScale;
                initialOverlaySystem.imageTileRef_Curtins_Right.transform.localScale = adjustableScale;
            }
            else
            {
                //Debug.Log("Cant Go Smaller");
            }
        }
    }

    public void DecreaseWidth()
    {
        if (adjustableScale.x >= 0.1)
        {
            if (initialOverlaySystem.isSettingUpBlinds == true)
            {
                Debug.Log("Decrease Width - Blinds");
                //adjustableScale.x--;
                adjustableScale.x = adjustableScale.x - scaleAdjustmentValue;
                initialOverlaySystem.imageTileRef_Blinds.transform.localScale = adjustableScale;
            }
            else if (initialOverlaySystem.isSettingUpCurtins == true)
            {
                Debug.Log("Decrease Length - Curtins");
                adjustableScale.x = adjustableScale.x - scaleAdjustmentValue;
                initialOverlaySystem.imageTileRef_Curtins_Left.transform.localScale = adjustableScale;
                initialOverlaySystem.imageTileRef_Curtins_Right.transform.localScale = adjustableScale;
            }
        }
        else {
            //Debug.Log("Cant Go Smaller");
        }
    }
    //End of code block system
}
