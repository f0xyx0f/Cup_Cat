using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Change_Value : MonoBehaviour
{
    private int count;
    private string oldVal;
    private void Start()=>
        count = GetComponent<TextMeshProUGUI>().text.Length;
    public async void Change(string value) => await ChangeValue(value);
    public async Task ChangeValue(string value)
    {
        for(int i = 0; i < count; ++i)
        {
            oldVal = GetComponent<TextMeshProUGUI>().text;
            if (i < value.Length)
                ReplaceText(i, value[i]);
            else
                ReplaceText(i, '0');
            await Task.Delay(50);
        }
    }
    private void ReplaceText(int i, char ch)
    {
        oldVal = oldVal.Remove(i, 1);
        GetComponent<TextMeshProUGUI>().text = oldVal.Insert(i, ch.ToString());
    }
}
