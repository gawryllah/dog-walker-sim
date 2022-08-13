using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "ClientSO", menuName = "ScriptableObjects/ClientSO")]
public class ClientSO : ScriptableObject
{
    [SerializeField] private string firstName, surname, address;

    //[SerializeField] GameObject addressGO; to add later, address will be represented by emptyGO in certain place

    public void initClient(string firstName, string surname, string address)
    {
        this.firstName = firstName;
        this.surname = surname;
        this.address = address;

        EditorUtility.SetDirty(this);
    }

    public string getClientInfo()
    {
        return $"fN: {firstName}, sN: {surname}, ad: {address}";
    }

}
