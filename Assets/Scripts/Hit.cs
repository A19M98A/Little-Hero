using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public Rigidbody point;

    public Rigidbody FF;

    public int temp = 0;

    public int ss = 0;

    public int State = 0;
    public int Y = 0;

    static int id;

    public Text choob;
    public Text ahan;

    public static int VideosNumber = 0;

    private void Start()
    {
    }

    void Update()
    {

        choob.text = Save.choob.person.ToString();
        

        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            State = 0;
            UI();
        }
        temp = (int) (FF.transform.rotation.eulerAngles.y + 45) / 90;
        if (State == 0 && Input.GetKeyUp(KeyCode.B))
        {
            State = 1;
            UIB();
        }
        else if (State == 1 && Input.GetKeyUp(KeyCode.R))
        {
            State = 2;
            UIR();
        }
        else if (State == 2)
        {
            if (Input.GetKeyUp(KeyCode.H) && haveWood(2))
            {
                Save.choob.person -= 2;
                Save.saveMasaleh(Save.choob, null, true);

                R1Q(1);
                State = 0;
            }
            else if (Input.GetKeyUp(KeyCode.J) && haveWood(2))
            {
                Save.choob.person -= 2;
                Save.saveMasaleh(Save.choob, null, true);

                R1Q(3);
                State = 0;
            }
            else if (Input.GetKeyUp(KeyCode.K) && haveWood(2))
            {
                Save.choob.person -= 2;
                Save.saveMasaleh(Save.choob, null, true);

                R1Q(4);
                State = 0;
            }
            else if (Input.GetKeyUp(KeyCode.L) && haveWood(2))
            {
                Save.choob.person -= 2;
                Save.saveMasaleh(Save.choob, null, true);

                R1Q(2);
                State = 0;
            }
        }
        else if (State == 1 && Input.GetKeyUp(KeyCode.Y))
        {
            State = 4;
            UIY();
        }
        else if (State == 4)
        {
            if (Input.GetKeyUp(KeyCode.H) && haveWood(2))
            {
                Save.choob.person -= 2;
                Save.saveMasaleh(Save.choob, null, true);

                R3Q(1);
                State = 0;
            }
            else if (Input.GetKeyUp(KeyCode.J) && haveWood(2))
            {
                Save.choob.person -= 2;
                Save.saveMasaleh(Save.choob, null, true);

                R3Q(3);
                State = 0;
            }
            else if (Input.GetKeyUp(KeyCode.K) && haveWood(2))
            {
                Save.choob.person -= 2;
                Save.saveMasaleh(Save.choob, null, true);

                R3Q(4);
                State = 0;
            }
            else if (Input.GetKeyUp(KeyCode.L) && haveWood(2))
            {
                Save.choob.person -= 2;
                Save.saveMasaleh(Save.choob, null, true);

                R3Q(2);
                State = 0;
            }
        }
    }

    private void R3Q(int v)
    {
        Y = 0;
        v = (v + temp) % 4;

        ss = v;
        switch (v)
        {
            case 0:
                createRigidbodyWithPosition(Shaips.R3_2);
                break;
            case 1:
                createRigidbodyWithPosition(Shaips.R3_1);
                break;
            case 2:
                createRigidbodyWithPosition(Shaips.R3_2);
                break;
            case 3:
                createRigidbodyWithPosition(Shaips.R3_1);
                break;
        }
    }


    public void createRigidbodyWithPosition(Rigidbody rigidbody)
    {
        Vector3 vector = point.position;
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);
        int x = Convert.ToInt16(vector.x / 3.5);
        int y = Convert.ToInt16((vector.y + Y) / 2);
        int z = Convert.ToInt16(vector.z / 3.5);
        vector.x = (float)(x * 3.5);
        vector.y = (float)(y * 2);
        vector.z = (float)(z * 3.5);

        Rigidbody inst = Instantiate(rigidbody, vector, quaternion);

        Save.SaveCreateObj(vector, quaternion,rigidbody.name.Substring(0, 4), Save.getUpId());
        UI();
    }

    private void R1Q(int v)
    {
        v = (v + temp) % 4;

        ss = v;
        switch (v)
        {
            case 0:
                Y = 1;
                createRigidbodyWithPosition(Shaips.R1_3);
                break;
            case 1:
                Y = 1;
                createRigidbodyWithPosition(Shaips.R1_4);
                break;
            case 2:
                Y = 1;
                createRigidbodyWithPosition(Shaips.R1_2);
                break;
            case 3:
                Y = 1;
                createRigidbodyWithPosition(Shaips.R1_1);
                break;
        }
    }

    public void UI()
    {
        for (int i = 4; i < 100; i++)
        {
            if (UiControler.UiImageT[i] != null)
                UiControler.UiImageT[i].enabled = false;
        }
    }

    public void UIB()
    {
        for (int i = 4; i < 10; i++)
        {
            if (UiControler.UiImageT[i] != null)
                UiControler.UiImageT[i].enabled = true;
        }
    }

    public void UIR()
    {
        for (int i = 7; i < 13; i++)
        {
            if (UiControler.UiImageT[i] != null)
                UiControler.UiImageT[i].enabled = false;
        }
        for (int i = 13; i < 25; i++)
        {
            if (UiControler.UiImageT[i] != null)
                UiControler.UiImageT[i].enabled = true;
        }
    }

    private void UIY()
    {
        for (int i = 4; i < 7; i++)
        {
            if (UiControler.UiImageT[i] != null)
                UiControler.UiImageT[i].enabled = false;
        }
        for (int i = 13; i < 25; i++)
        {
            if (UiControler.UiImageT[i] != null)
                UiControler.UiImageT[i].enabled = true;
        }
    }

    public bool haveWood(int wood)
    {
        if(Save.choob.person >= wood)
            return true;
        return false;
    }
}
