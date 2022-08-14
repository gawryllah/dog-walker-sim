using System.Collections;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "ClientSO", menuName = "ScriptableObjects/ClientSO")]
public class ClientSO : ScriptableObject
{
    [SerializeField] private string firstName, surname, address;

    [SerializeField] private bool canAssignTask;

    //[SerializeField] GameObject addressGO; to add later, address will be represented by emptyGO in certain place

   

    public void initClient(string firstName, string surname, string address)
    {
        this.firstName = firstName;
        this.surname = surname;
        this.address = address;
        canAssignTask = true;

        EditorUtility.SetDirty(this);
    }

    public string getAddress()
    {
        return address;
    }

    public string getClientInfo()
    {
        return $"fN: {firstName}, sN: {surname}, ad: {address}";
    }

    public bool getCanAssignTask()
    {
        return canAssignTask;
    }

    public void TaskAssigned()
    {
        canAssignTask = false;
       
    }

    public void setAssignTask(bool status)
    {
        canAssignTask = status;
    }

}
