using TMPro;
using UnityEngine;

public class DogUIRenderer : MonoBehaviour
{

    public TMP_Text dogsNameText;
    public GameObject textHolder;

    public Transform cam;
    private void Start()    
    {
        cam = Camera.main.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(textHolder.transform.position + cam.forward);
    }

    public void SetName(string name)
    {
        dogsNameText.text = name;
    }
}
