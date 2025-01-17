using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LobbyHandler : MonoBehaviourPunCallbacks
{
    //UI Elements
    [Header("UI Elements")]
    public InputField createInput;
    public InputField joinInput;
    public Text connectionStatus;
    public Button connectButton;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        connectionStatus.text = "Not Connected";
        connectButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //creates a random value for the lobby with 6 characters from {a-z,0-9,A-Z}
    public void randomizeLobby()
    {
        string values = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUWVXYZ0123456789";
        string resultString = "";
        for(int i = 0; i<6; i++)
        {
            resultString += values.Substring(Random.Range(0, values.Length), 1);
        }
        createInput.text = resultString;
    }

    public void clearCreateInputValue()
    {
        createInput.text = "";
    }

    public void clearJoinInputValue()
    {
        joinInput.text = "";
    }

    public void joinServer()
    {
        if(createInput.text == "" && joinInput.text == "")
        {
            Debug.Log("No server to connect");
            return;
        }
        else if(createInput.text != "" && joinInput.text == "")
        {
            Debug.Log("Creating server!");
            CreateRoom();
        }
        else if(createInput.text == "" && joinInput.text != "")
        {
            Debug.Log("Joining server!");
            JoinRoom();
        }
    }


    //PhotonNetwork
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("On Lobby");

        connectionStatus.text = "Server Connected";
        connectButton.interactable = true;
    }

    public void CreateRoom() 
    {
        PhotonNetwork.CreateRoom(createInput.text);

    }

    public void JoinRoom() 
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Main");
    }
}
