using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_Handler : MonoBehaviour
{
    void Delete() => Destroy(transform.GetChild(0).gameObject);
}
