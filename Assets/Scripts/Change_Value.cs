using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Change_Value : MonoBehaviour
{
    private int count;
    private string oldVal;
    private void Start()
    {
        count = GetComponent<TextMeshProUGUI>().text.Length;
    }
    public async void Change(string value)
    {
        for (int i = 0; i < count; ++i)
        {
            oldVal = GetComponent<TextMeshProUGUI>().text;
            if (i < value.Length)
                ReplaceText(i, value[i]);
            else
                ReplaceText(i, '0');
            await Task.Delay(100);
        }
    }

    private void ReplaceText(int i, char ch)
    {
        oldVal = oldVal.Remove(i, 1);
        GetComponent<TextMeshProUGUI>().text = oldVal.Insert(i, ch.ToString());
    }
}
