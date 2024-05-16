using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Working_Handler : MonoBehaviour
{
    void Activate_Btn() => GetComponent<Button>().interactable = true;
}
