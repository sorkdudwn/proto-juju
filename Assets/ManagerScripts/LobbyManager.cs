using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    //방이름 InputField
    public InputField inputRoomName;
    //총인원 InputField
    public InputField inputMaxPlayer;
    
    //방 생성 Button
    public Button btnCreate;
    
    //방의 정보들   
    Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();
    //룸 리스트 Content
    public Transform trListContent;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        // 방이름(InputField)이 변경될때 호출되는 함수 등록
        inputRoomName.onValueChanged.AddListener(OnRoomNameValueChanged);
        // 총인원(InputField)이 변경될때 호출되는 함수 등록
        inputMaxPlayer.onValueChanged.AddListener(OnMaxPlayerValueChanged);

    }

    private void OnRoomNameValueChanged(string s)
    {
        //생성
        btnCreate.interactable = s.Length > 0 && inputMaxPlayer.text.Length > 0;
    }
    
    private void OnMaxPlayerValueChanged(string s)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
