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
    public static GameObject number2;
    private bool selected;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Ok)
        {
            if (selected)
            {
                selected = false;
                if (numbers[0].activeSelf)
                {
                    numbers[0].SetActive(false);
                    DeactivateEmote(0);
                    if (number2 != null)
                    {
                        number2.GetComponentsInChildren<TextMeshProUGUI>(true)[0].gameObject.SetActive(true);
                        number2.GetComponentsInChildren<TextMeshProUGUI>(true)[1].gameObject.SetActive(false);
                        number2 = null;
                    }
                    else Ok = false;
                }
                else
                {
                    number2 = null;
                    numbers[1].SetActive(false);
                    DeactivateEmote(1);
                }
            }
            else if (number2 == null)
            {

                selected = true;
                numbers[1].SetActive(true);
                ActivateEmote(1);
                number2 = gameObject;
            }
        }
        else
        {
            Ok = true;
            selected = true;
            numbers[0].SetActive(true);
            ActivateEmote(0);
        }
    }

    private void DeactivateEmote(int number){
       emotes[number].DiactivateEmote(); 
       values[number].Change("000000000000");
    }
    private void ActivateEmote(int number)
    {
        values[number].Change(gameObject.name);
        emotes[number].gameObject.SetActive(true);
        emotes[number].ActivateEmote(transform.position, GetComponent<Image>().sprite);
    }

}
