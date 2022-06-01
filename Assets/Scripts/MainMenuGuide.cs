using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class MainMenuGuide : MonoBehaviour
{
    [SerializeField] private float dotSpeed = 0.05f;
    private const char DOT = '●';
    private int segmentsCount = 14;
    [SerializeField] private TextMeshProUGUI text;
    //<----------●--->
    void OnEnable()
    {
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        while (true)
        {
            
            StringBuilder strBuilder = new StringBuilder();
            for (int currentDotPosition = -segmentsCount; currentDotPosition < segmentsCount; currentDotPosition++)
            {
                strBuilder.Append('<');
                for (int i = 0; i <= segmentsCount; i++)
                {
                    if (i == Mathf.Abs(currentDotPosition))
                    {
                        strBuilder.Append(DOT);
                    }else
                    {
                        strBuilder.Append('-');
                    }
                }
                strBuilder.Append('>');
                text.text = strBuilder.ToString();
                yield return new WaitForSeconds(dotSpeed);
                strBuilder.Clear();
            }
        }
    }
}
