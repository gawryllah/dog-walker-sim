using TMPro;
using UnityEngine;

public class DogUIRenderer : MonoBehaviour
{

    public TMP_Text dogsNameText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dogsNameText.transform.rotation = Camera.main.transform.rotation;
    }

    public void setName(string name)
    {
        dogsNameText.text = name;
    }
}
