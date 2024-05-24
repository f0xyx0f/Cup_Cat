using UnityEngine;

public class Working_Handler : MonoBehaviour
{
    public GameObject es;
    void Activate_Btn() => es.SetActive(true);
    void Delete() => Destroy(transform.GetChild(0).gameObject);
}
