using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;

public class ImageRecognition : MonoBehaviour
{
    public GameObject person;
    public GameObject calibrationLocations;
    public bool searchingForMarker;
    // is used at start of application to set initial position
    public bool StartPosition(WebCamTexture wt)
    {
        bool succeeded = false;
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(wt.GetPixels32(), wt.width, wt.height);
            if (result != null)
            {
                Relocate(result.Text);
                succeeded = true;
            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }
        return succeeded;
    }
    // move to person indicator to the new spot
    private void Relocate(string text)
    {
        text = text.Trim(); //remove spaces
                            //find the correct location scanned and move the person to its position
        foreach (Transform child in calibrationLocations.transform)
        {
            if (child.name.Equals(text))
            {
                person.transform.position = child.position;
                break;
            }
        }
        searchingForMarker = false;
    }
}