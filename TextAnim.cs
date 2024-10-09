using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnim : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    [SerializeField]
    private float timeBtwnChars;
    [SerializeField]
    private float timeBtwnWords;

    // [SerializeField]
    // private string stringArray;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        EndCheck();
    }

    // Update is called once per frame
    public void EndCheck()
    {
        // textMeshPro.text = stringArray;
        StartCoroutine(TextVisible());
        // if (i <= stringArray.Length - 1)
        // {
        //     textMeshPro.text = stringArray[i];
        //     StartCoroutine(TextVisible());
        // }
    }

    private IEnumerator TextVisible()
    {
        textMeshPro.ForceMeshUpdate();
        int counter = 0;
        int totalVisibleCharacter = textMeshPro.textInfo.characterCount;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacter + 1);
            textMeshPro.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacter)
            {
                break;
            }

            counter += 1;
            yield return new WaitForSeconds(timeBtwnChars);
        }

        // textMeshPro.ForceMeshUpdate();
        // int totalVisibleCharacter = textMeshPro.textInfo.characterCount;
        // int counter = 0;

        // while (true)
        // {
        //     int visibleCount = counter % (totalVisibleCharacter + 1);
        //     textMeshPro.maxVisibleCharacters = visibleCount;

        //     if (visibleCount >= totalVisibleCharacter)
        //     {
        //         i += 1;
        //         Invoke("EndCheck", timeBtwnWords);
        //         break;
        //     }

        //     counter += 1;
        //     yield return new WaitForSeconds(timeBtwnChars);
        // }
    }
}
