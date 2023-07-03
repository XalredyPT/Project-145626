using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{

    public TextMeshProUGUI t;

    private string text = "";
    // Start is called before the first frame update
    void Start()
    {
        text = "Long ago, out of nowhere and with no one knowing where they came from, evil slimes started to appear. Their sole purpose was to kill everything and everyone. In the face of despair, humans discovered a staff that would be their only hope against the forces of evil—a staff with the power to summon wizard towers capable of defending the territories from the slimes. It is now your duty, as the wielder of this staff, to defend the territory from the hordes of slimes.";
        StartCoroutine(AnimateText());
    
    }
    void Update()
    {
        if (t.text != text && Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            t.text = text;
        }
        else if (t.text == text && Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
        
    }

 IEnumerator AnimateText()
    {
        
        for (int i = 0; i < text.Length; i++)
        {
            if (t!=null)
            {
                t.text = text.Substring(0, i);
            }
            
            yield return new WaitForSeconds(0.01f);
        }
    }
}

