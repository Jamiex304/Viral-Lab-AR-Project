using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class ProductExamplesControls : MonoBehaviour
{
    //Reference to the initial overlay system script
    public OverlaySystemControls initialOverlaySystem;

    //Array of Images for Search Assign Option
    //Array should only ever have one Image assigned
    Image[] targetimage;

    void Start(){
        FindTargetImage();
    }
    //Should Only Return the Children Object Of The Button Which Is A Simple Image Plane
    void FindTargetImage() {
        targetimage = this.GetComponentsInChildren<Image>(true);
        for (int i = 0; i < targetimage.Length; i++)
        {
            if (!targetimage[i].CompareTag("ProductImageTag"))
            {
                //Removes any images found that are not tagged as "ProductImageTag"
                targetimage[i] = targetimage[targetimage.Length - 1];
                Array.Resize(ref targetimage, targetimage.Length - 1);
            }
        }
    }

    //Change The Image Once Pressed
    public void ChangeProductImage()
    {
        //Assign the Image and Sprite
        if (initialOverlaySystem.isSettingUpBlinds == true)
        {
            Image productImage = targetimage[0];
            Sprite productImageSprite = productImage.sprite;
            initialOverlaySystem.imageTileSpriteRef_Blinds.sprite = productImageSprite;
        }
        else if (initialOverlaySystem.isSettingUpCurtins == true)
        {
            Image productImage = targetimage[0];
            Sprite productImageSprite = productImage.sprite;
            initialOverlaySystem.imageTileSpriteRef_Curtins_Left.sprite = productImageSprite;
            initialOverlaySystem.imageTileSpriteRef_Curtins_Right.sprite = productImageSprite;
        }
    }
}
