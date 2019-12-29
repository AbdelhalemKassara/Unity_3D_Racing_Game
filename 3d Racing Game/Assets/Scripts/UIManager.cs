using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI[] text;

    public virtual void ChangeText(float Num, string unit, int t)
    {
        if (t == 2 && Num == 0f)
        {
            text[t].text = "R " + unit;
        }
        else
        {

            text[t].text = Mathf.Round(Num) + unit;
        }
    }   

}
