using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartText : MonoBehaviour
{
    Text flashingText;
    void Start () 
    { 
        flashingText = GetComponent<Text> (); 
        StartCoroutine(BlinkText());
    } 
    public IEnumerator BlinkText()
    { 
        while (true) 
        { 
            flashingText.text = ""; 
            yield return new WaitForSeconds (.5f);
            flashingText.text = "PRESS TO START";
            yield return new WaitForSeconds (.5f); 
        } 
    }

}
