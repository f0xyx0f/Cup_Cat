using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.WSA;

public class Emote_Controller : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] numbers;
    public Change_Value[] values;
    public Add_Ingredient[] emotes;
    public static bool Ok;
    public static Emote_Controller number2;
    private bool[] selected = new bool[2];
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Ok)
        {

            if (selected[0])
            {
                DeactivateEmote(0);
                if (number2 != null)
                {
                    number2.ActivateEmote(0);
                    number2.DeactivateEmote(1);
                    number2 = null;
                }
                else Ok = false;
            }
            else if (selected[1])
            {
                number2 = null;
                DeactivateEmote(1);
            }
            else if (number2 == null)
            {
                ActivateEmote(1);
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
