using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text roomInfo;

    //����
    public Text roomDesc;

    //�� id
    int map_id;

    //Ŭ���� �Ǿ��� �� ȣ��Ǵ� �Լ��� �������ִ� ����
    public System.Action<string, int> onClickAction;

    void Start()
    {
        
    }
    
    public void SetInfo(string roomName, int currPlayer, byte maxPlayer)
    {
        //���ӿ�����Ʈ�� �̸��� roomName����!
        name = roomName;
        //���̸� (0/0)
        roomInfo.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")"; 
    }

    public void SetInfo(RoomInfo info)
    {
        SetInfo((string)info.CustomProperties["room_name"], info.PlayerCount, info.MaxPlayers);

        //desc ����
        roomDesc.text = (string)info.CustomProperties["desc"];

        //map id ����
        map_id = (int)info.CustomProperties["map_id"];
    }



    public void OnClick()
    {
        //���࿡ onClickAction �� null�� �ƴ϶��
        if(onClickAction != null)
        {
            //onClickAction ����
            onClickAction(name, map_id);
        }

        ////1. InputRoomName ���ӿ����� ã��
        //GameObject go = GameObject.Find("InputRoomName");
        ////2. InputField ������Ʈ ��������
        //InputField inputField = go.GetComponent<InputField>();
        ////3. text�� roomName ����.
        //inputField.text = name;
    }
}
