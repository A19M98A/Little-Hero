using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;

public class Save : MonoBehaviour
{
    public static List<ClassObj> gameObjectArry = new List<ClassObj>();

    public static ClassAnbar choob;
    public static ClassAnbar ahan;


    public static string pathMap = "Assets/test.txt";
    public static string pathMasaleh = "Assets/test1.txt";

    public Rigidbody rahpele1;
    public Rigidbody rahpele2;
    public Rigidbody rahpele3;
    public Rigidbody rahpele4;

    public Rigidbody pol1;
    public Rigidbody pol2;


    public void Start()
    {
        getAllObject();
        getMasaleh();

        LoadGame();
    }


    public ClassObj getGameObject(int id)
    {
        for (int i = 0; i < gameObjectArry.Count; i++)
        {
            if (gameObjectArry[i].id == id)
            {
                return gameObjectArry[i];
            }
        }
        return null;
    }

    private void getAllObject()
    {
        StreamReader reader = new StreamReader(pathMap);

        for (; !reader.EndOfStream;)
        {
            GameObject gameObject = new GameObject();
            ClassObj obj = new ClassObj();

            string line = reader.ReadLine();
            string[] stringArry = line.Split(',');
            gameObject.transform.position = new Vector3(float.Parse(stringArry[0].Trim()), float.Parse(stringArry[1].Trim()), float.Parse(stringArry[2].Trim()));
            gameObject.transform.rotation = new Quaternion (float.Parse(stringArry[3].Trim()), float.Parse(stringArry[4].Trim()), float.Parse(stringArry[5].Trim()), float.Parse(stringArry[6].Trim()));

            obj.transform = gameObject.transform;
            obj.id = int.Parse(stringArry[7]);
            obj.name = stringArry[8].Trim();

            
            gameObjectArry.Add(obj);

        }
        reader.Close();
    }
    
    public static void SaveCreateObj(Vector3 vector, Quaternion quaternion, string name, int id)
    {
        StreamWriter writer = new StreamWriter(pathMap, true);
       

        writer.WriteLine(
              vector.x + " , "
            + vector.y + " , "
            + vector.z + " , "
            + quaternion.x + " , "
            + quaternion.y + " , "
            + quaternion.z + " , "
            + quaternion.w + " , "
            + id + " , "
            + name + " , "
            );

        ClassObj obj = new ClassObj();
        GameObject game = new GameObject();
        game.transform.position = vector;
        game.transform.rotation = quaternion;

        obj.transform = game.transform;
        obj.id = id;
        obj.name = name;
        gameObjectArry.Add(obj);

        writer.Close();
    }

    private void getMasaleh()
    {
        choob = new ClassAnbar();
        ahan = new ClassAnbar();
        StreamReader reader = new StreamReader(pathMasaleh);
        string line;
        string[] stringArry;

        line = reader.ReadLine();
        stringArry = line.Split(',');

        choob.person = int.Parse(stringArry[0]);
        choob.ghayegh = int.Parse(stringArry[1]);
        choob.anbar = int.Parse(stringArry[2]);

        line = reader.ReadLine();
        stringArry = line.Split(',');

        ahan.person = int.Parse(stringArry[0]);
        ahan.ghayegh = int.Parse(stringArry[1]);
        ahan.anbar = int.Parse(stringArry[2]);

        reader.Close();

    }

    public static void saveMasaleh(ClassAnbar choob, ClassAnbar ahan,bool flagChoob)
    {
        
        if ((choob != null) && (ahan != null))
        {
            StreamWriter writer = new StreamWriter(pathMasaleh);

            writer.WriteLine(
                  choob.person + " , "
                + choob.ghayegh + " , "
                + choob.anbar + " , "
                );
            writer.WriteLine(
                  ahan.person + " , "
                + ahan.ghayegh + " , "
                + ahan.anbar + " , "
                );

            writer.Close();
        }

        if (flagChoob)
        {
            Debug.Log("ok");
            Debug.Log(choob.person + " , " + choob.ghayegh + " , " + choob.anbar + " , ");
            editLine(choob.person + " , " + choob.ghayegh + " , " + choob.anbar + " , ", pathMasaleh, 1);
        }

        if (!flagChoob)
        {
            editLine(ahan.person + " , " + ahan.ghayegh + " , " + ahan.anbar + " , ", pathMasaleh, 2);
        }
        
    }

    private static void editLine(string newText, string fileName, int lineToEdit)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[lineToEdit - 1] = newText.ToString();
        File.WriteAllLines(fileName, arrLine);

    }

    public static int getUpId()
    {
        return Save.gameObjectArry[Save.gameObjectArry.Count - 1].id + 1;
    }

    private void LoadGame()
    {
        for (int i = 0; i < gameObjectArry.Count; i++)
        {
            if (gameObjectArry[i].name == "R1_1")
            {
                Rigidbody rigidbody = Instantiate(rahpele1, gameObjectArry[i].transform.position, gameObjectArry[i].transform.rotation);
                //rigidbody.GetComponent<HitFPS>().id = gameObjectArry[i].id;
                //rigidbody.GetComponent<HitFPS>().Name = gameObjectArry[i].name;
            }
            else if (gameObjectArry[i].name == "R1_2")
            {
                Rigidbody rigidbody = Instantiate(rahpele2, gameObjectArry[i].transform.position, gameObjectArry[i].transform.rotation);
                //rigidbody.GetComponent<HitFPS>().id = gameObjectArry[i].id;
                //rigidbody.GetComponent<HitFPS>().Name = gameObjectArry[i].name;
            }
            else if (gameObjectArry[i].name == "R1_3")
            {
                Rigidbody rigidbody = Instantiate(rahpele3, gameObjectArry[i].transform.position, gameObjectArry[i].transform.rotation);
                //rigidbody.GetComponent<HitFPS>().id = gameObjectArry[i].id;
                //rigidbody.GetComponent<HitFPS>().Name = gameObjectArry[i].name;
            }
            else if (gameObjectArry[i].name == "R1_4")
            {
                Rigidbody rigidbody = Instantiate(rahpele4, gameObjectArry[i].transform.position, gameObjectArry[i].transform.rotation);
                //rigidbody.GetComponent<HitFPS>().id = gameObjectArry[i].id;
                //rigidbody.GetComponent<HitFPS>().Name = gameObjectArry[i].name;
            }
            else if (gameObjectArry[i].name == "R3_1")
            {
            
                Rigidbody rigidbody = Instantiate(pol1, gameObjectArry[i].transform.position, gameObjectArry[i].transform.rotation);
                //int ii = gameObjectArry[i].id;
                //rigidbody.GetComponent<HitFPS>().id = ii;
                //rigidbody.GetComponent<HitFPS>().Name = gameObjectArry[i].name;

            }
            else if (gameObjectArry[i].name == "R3_2")
            {
                Rigidbody rigidbody = Instantiate(pol2, gameObjectArry[i].transform.position, gameObjectArry[i].transform.rotation);
                //rigidbody.GetComponent<HitFPS>().id = gameObjectArry[i].id;
                //rigidbody.GetComponent<HitFPS>().Name = gameObjectArry[i].name;
            }
        }
    }

    public static void removeGameObject(Transform transform)
    {
        for (int i = 0; i < gameObjectArry.Count; i++)
        {
            if (gameObjectArry[i].transform.position.x == transform.position.x && gameObjectArry[i].transform.position.y == transform.position.y && gameObjectArry[i].transform.position.z == transform.position.z)
            {
                gameObjectArry.Remove(gameObjectArry[i]);
                string[] arrLine = File.ReadAllLines(pathMap);
                RemoveAt(ref arrLine, i);
                File.WriteAllLines(pathMap, arrLine);
            }
        }
    }

    private static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++) arr[a] = arr[a + 1];
        Array.Resize(ref arr, arr.Length - 1);
    }
}

