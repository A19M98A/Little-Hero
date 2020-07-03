using System;
using UnityEngine;
using UnityEngine.UI;

public class HitFPS : MonoBehaviour
{
    private bool hitFPS = false;

    public Rigidbody parent;

    public RawImage helpKey;
    public RawImage helpBackGround;
    public RawImage helpIMG;

    public RawImage IMG;
    public RawImage IMG_BackGround;

    public RawImage Help;
    public RawImage Enter;

    public int NomberH;

    public int test;

    public RawImage[] rawImages;

    public string Name;

    public int id = 0;

    bool f = true;

    public int state = 0;


    public Transform tt;

    private void Start()
    {
        
    }

    private void Update()
    {

        if (state == 1 && Input.GetKeyUp(KeyCode.I))
        {
            Application.LoadLevel(2);
            state = 0;
        }
        if (state == 1 && Input.GetKeyUp(KeyCode.O))
        {
            Application.LoadLevel(3);
            state = 0;
        }
        if (state == 1 && Input.GetKeyUp(KeyCode.U))
        {
            Application.LoadLevel(1);
            state = 0;
        }
        if (hitFPS)
        {
            if (Input.GetKeyUp(KeyCode.F) && Name != "Bow" && Name != "Tree")
            {
                if (Name == "RahCh")
                {
                    Save.choob.person += 1;
                    Save.saveMasaleh(Save.choob, null, true);
                }
                pickingUp();
                
            }
            if (Input.GetKeyUp(KeyCode.M) && Name == "Bow")
            {
                state = 1;
                Mapp();
            }
            if (Input.GetKeyUp(KeyCode.F) && Name == "Tree")
            {
                Save.choob.person += 3;
                Save.saveMasaleh(Save.choob, null,true);
                cutTree();
            }
        }
        if (f)
        {
            rawImages = UiControler.rawImagesT;



            if (Name == "Axe")
            {
                helpBackGround = rawImages[0];
                helpKey = rawImages[1];
                helpIMG = rawImages[2];

                IMG_BackGround = rawImages[3];
                IMG = rawImages[4];
            }

            if (Name == "RahCh")
            {
                helpBackGround = rawImages[0];
                helpKey = rawImages[5];
                helpIMG = rawImages[6];

                IMG_BackGround = rawImages[7];
                IMG = rawImages[8];
            }

            if (Name == "Tree")
            {
                helpBackGround = rawImages[0];
                helpKey = rawImages[5];
                helpIMG = rawImages[10];

                IMG_BackGround = rawImages[7];
                IMG = rawImages[8];
            }

            if (Name == "Bow")
            {
                //helpKey = UiControler.MKT;
                //helpIMG = UiControler.MT;
                //helpBackGround = UiControler.MBT;
                
            }
            
            if (Name == "Help")
            {
                helpBackGround = rawImages[13];
                helpBackGround.texture = Shaips.HT[NomberH];
                helpIMG = helpBackGround;
                IMG_BackGround = helpBackGround;
                IMG = helpBackGround;
                helpKey = rawImages[14];
                test = NomberH;
            }

            //IMG.enabled = false;
            //IMG_BackGround.enabled = false;
            //helpIMG.enabled = false;
            //helpBackGround.enabled = false;
            //helpKey.enabled = false;
            f = false;
        }
    }

    private void Mapp()
    {
        UiControler.MapT.enabled = true;
        UiControler.I1T.enabled = true;
        UiControler.I2T.enabled = true;
        UiControler.I3T.enabled = true;
    }

    public void pickingUp()
    {
        if (parent != null)
            Destroy(parent.gameObject, 0);

        if (Name != "Help" && Name != "Tree" && Name != "Axe")
            Save.removeGameObject(parent.gameObject.transform);

        hideHelp();
        showIMG();
        Destroy(this.gameObject, 0);
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            hitFPS = true;
            showHelp();
        }
    }



    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hitFPS = false;
            hideHelp();
        }
        UiControler.MapT.enabled = false;
        UiControler.I1T.enabled = false;
        UiControler.I2T.enabled = false;
        UiControler.I3T.enabled = false;
        state = 0;
    }

    public void showIMG()
    {
        IMG.enabled = true;
        IMG_BackGround.enabled = true;
    }

    public void showHelp()
    {
        if (Name == "Help")
        {

            helpBackGround = rawImages[13];
            helpBackGround.texture = Shaips.HT[NomberH -1];
            helpIMG = helpBackGround;
            IMG_BackGround = helpBackGround;
            IMG = helpBackGround;
            helpKey = rawImages[14];
        }
        helpKey.enabled = true;
        helpBackGround.enabled = true;
        helpIMG.enabled = true;
    }

    public void hideIMG()
    {
        IMG.enabled = false;
        IMG_BackGround.enabled = false;
    }

    public void hideHelp()
    {
        helpKey.enabled = false;
        helpBackGround.enabled = false;
        helpIMG.enabled = false;
    }

    public bool OnHit()
    {
        return hitFPS;
    }
    
    public void cutTree()
    {
        Destroy(gameObject, 0);
        if (parent != null)
            Destroy(parent.gameObject, 0); 
    }

}
