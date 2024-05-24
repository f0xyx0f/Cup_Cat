using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Emote_Controller : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] numbers;
    public Change_Value[] values;
    public Add_Ingredient[] emotes;
    public Button Coffee_btn;
    public static bool Ok;
    public static Emote_Controller number2;
    public bool[] selected = new bool[2];
    public void OnPointerClick(PointerEventData eventData)=> Click();
    public void Click()
    {
        if (Ok)
        {
            if (selected[0])
            {
                DeactivateEmote(0);
                if (number2 != null)
                {
                    number2.DeactivateEmote(1);
                    number2.ActivateEmote(0);
                    number2 = null;
                }
                else Ok = false;
            }
            else if (selected[1])
            {
                number2 = null;
                DeactivateEmote(1);
                Coffee_btn.interactable = false;
            }
            else if (number2 == null)
            {
                ActivateEmote(1);
                Coffee_btn.interactable = true;
                number2 = GetComponent<Emote_Controller>();
            }
        }
        else
        {
            Ok = true;
            ActivateEmote(0);
        }
    }
    public void DeactivateEmote(int number)
    {
        selected[number] = false;
        numbers[number].SetActive(false);
        emotes[number].DiactivateEmote();
        values[number].Change("000000000000");
    }
    public void ActivateEmote(int number)
    {
        selected[number] = true;
        numbers[number].SetActive(true);
        values[number].Change(gameObject.name);
        emotes[number].gameObject.SetActive(true);
        emotes[number].ActivateEmote(transform.position, GetComponent<Image>().sprite);
    }
    public void Activate_Numbers(bool active)
    {
        if (selected[1])
        {
            numbers[1].SetActive(active);
        }
        else if (selected[0])
        {
            numbers[0].SetActive(active);
        }
    }
}
