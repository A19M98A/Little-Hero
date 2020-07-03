using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shaips : MonoBehaviour
{

    public static Rigidbody R1_1;
    public static Rigidbody R1_2;
    public static Rigidbody R1_3;
    public static Rigidbody R1_4;

    public static Rigidbody R3_1;
    public static Rigidbody R3_2;

    public Rigidbody R1_1t;
    public Rigidbody R1_2t;
    public Rigidbody R1_3t;
    public Rigidbody R1_4t;

    public Rigidbody R3_1t;
    public Rigidbody R3_2t;

    public RawImage helpKey;
    public RawImage helpBackGround;
    public RawImage Ax;
    public RawImage CutTree;
    public RawImage Delete;

    public RawImage O1;
    public RawImage BO1;
    public RawImage O2;
    public RawImage BO2;
    public RawImage O3;
    public RawImage BO3;
    public RawImage O4;
    public RawImage BO4;

    public Texture[] H = new Texture[12];
    public static Texture[] HT;

    // Start is called before the first frame update
    void Start()
    {
        
        R1_1 = R1_1t;
        R1_2 = R1_2t;
        R1_3 = R1_3t;
        R1_4 = R1_4t;

        R3_1 = R3_1t;
        R3_2 = R3_2t;

        HT = H;

        O1.enabled = false;
        BO1.enabled = false;
        O2.enabled = false;
        BO2.enabled = false;
        O3.enabled = false;
        BO3.enabled = false;
        O4.enabled = false;
        BO4.enabled = false;
        Ax.enabled = false;
        CutTree.enabled = false;
        Delete.enabled = false;
        helpBackGround.enabled = false;
        helpKey.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
