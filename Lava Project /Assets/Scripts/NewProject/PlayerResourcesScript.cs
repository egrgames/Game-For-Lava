using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerResourcesScript : MonoBehaviour
{
    public Animator anim;
    public List<GameObject> trees = new List<GameObject>();
    public List<GameObject> rocks = new List<GameObject>();
    public List<GameObject> crystals = new List<GameObject>();
    public List<GameObject> resources = new List<GameObject>();
    public float timeToHit;
    public float AxeDamage = 35f;

    public ParticleSystem woodDebris;
    public ParticleSystem rockDebris;
    public ParticleSystem crystalDebris;

    public ParticleSystem woodDebrisUI;
    public ParticleSystem rockDebrisUI;
    public ParticleSystem crystalDebrisUI;

    public int woodRes;
    public int metalRes;
    public int cristallRes;

    private int numberOfTrees;
    private int numberOfRocks;
    private int numberOfCrystals;
    private int numberOfActiveTrees;
    private int numberOfActiveRocks;
    private int numberOfActiveCrystals;

    public Text woodResText;
    public Text metalResText;
    public Text cristallResText;

    public int NumberOfResourcesAfterOneHitTree = 1;
    public int NumberOfResourcesAfterOneHitMetal = 1;
    public int NumberOfResourcesAfterOneHitCrystal = 1;

    private float RadiusToCollectResources;
    public PlayerInfo playerInfo;

    private void Start()
    {
        RadiusToCollectResources = playerInfo.RadiusForCllectingObjects;
        gameObject.GetComponent<SphereCollider>().radius = RadiusToCollectResources;
        LoadRes();
        woodResText.text = woodRes.ToString();
        metalResText.text = metalRes.ToString();
        cristallResText.text = cristallRes.ToString();
    }
    private void OnTriggerStay(Collider other)
    {
        //задаем периодичность ударов
        if(timeToHit <= 0f)
        {
            if (other.gameObject.name == "Tree" || other.gameObject.name == "MetalRock" || other.gameObject.name == "Crystal")
            {
                timeToHit = 50f;
                if(numberOfActiveRocks + numberOfActiveTrees + numberOfActiveCrystals > 0)
                {
                    anim.SetTrigger("attack");
                }
                
                if (numberOfTrees > 0)
                { 
                        Invoke("HitTree", 0.4f);
                }
                if(numberOfRocks > 0)
                {
                        Invoke("HitRock", 0.4f);
                }
                if(numberOfCrystals > 0)
                {
                        Invoke("HitCrystal", 0.4f);
                }

            }
        }
        
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Tree")
        {
            //делаем так, чтобы было объект понимал, можно ли восстанавливаться
            other.gameObject.GetComponent<TreeScript>().PlayerIn();
            if(!trees.Contains(other.gameObject))
            {
                trees.Add(other.gameObject);
            }
                numberOfActiveTrees += 1;
        }
        if (other.gameObject.name == "MetalRock")
        {
            //делаем так, чтобы было объект понимал, можно ли восстанавливаться
            other.gameObject.GetComponent<MetalRockScript>().PlayerIn();
            if (!rocks.Contains(other.gameObject))
            {
                rocks.Add(other.gameObject);
            }
                numberOfActiveRocks += 1;
        }
        if (other.gameObject.name == "Crystal")
        {
            //делаем так, чтобы было объект понимал, можно ли восстанавливаться
            other.gameObject.GetComponent<CrystalResourceScript>().PlayerIn();
            if (!crystals.Contains(other.gameObject))
            {
                crystals.Add(other.gameObject);
            }
                numberOfActiveCrystals += 1;
        }
        if (other.gameObject.name == "WoodPile(Clone)")
        {
            //проверяем, прошло ли достаточно времени, чтобы забрать выпавший ресурс
            if (other.gameObject.GetComponent<resourceScript>().isGrababble == true)
            {
                Destroy(other.gameObject);
                woodRes += 1;
                woodDebrisUI.Play();
                SaveRes();
            }
        }
        if (other.gameObject.name == "MetalResource(Clone)")
        {
            //проверяем, прошло ли достаточно времени, чтобы забрать выпавший ресурс
            if (other.gameObject.GetComponent<resourceScript>().isGrababble == true)
            {
                Destroy(other.gameObject);
                metalRes += 1;
                rockDebrisUI.Play();
                SaveRes();
            }
        }
        if (other.gameObject.name == "CrystalResource(Clone)")
        {
            //проверяем, прошло ли достаточно времени, чтобы забрать выпавший ресурс
            if (other.gameObject.GetComponent<resourceScript>().isGrababble == true)
            {
                Destroy(other.gameObject);
                cristallRes += 1;
                crystalDebrisUI.Play();
                SaveRes();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Tree")
        {
            //делаем так, чтобы было объект понимал, можно ли восстанавливаться
            other.gameObject.GetComponent<TreeScript>().PlayerOut();
            trees.Remove(other.gameObject);
        }
        if (other.gameObject.name == "MetalRock")
        {
            other.gameObject.GetComponent<MetalRockScript>().PlayerOut();
            rocks.Remove(other.gameObject);
        }
        if (other.gameObject.name == "Crystal")
        {
            other.gameObject.GetComponent<CrystalResourceScript>().PlayerOut();
            crystals.Remove(other.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if(timeToHit > 0f)
        {
            timeToHit -= 1;
        }
        //проверяем, находимся ли мы сейчас рядом с объектом, добывающем ресурсы
        numberOfTrees = trees.Count;
        numberOfRocks = rocks.Count;
        numberOfCrystals = crystals.Count;
        woodResText.text = woodRes.ToString();
        metalResText.text = metalRes.ToString();
        cristallResText.text = cristallRes.ToString();
    }
    public void HitTree()
    {

        numberOfActiveTrees = 0;

        foreach(GameObject ob in trees)
        {
            if(ob.gameObject.GetComponent<TreeScript>().isItOver == false)
            {
                woodDebris.Play();
                numberOfActiveTrees += 1;
                ob.gameObject.GetComponent<TreeScript>().HitTree();
                ob.gameObject.GetComponent<spawnResources>().SpawnResource();
            }
            
        }
    }
    public void HitRock()
    {

        numberOfActiveRocks = 0;

        foreach (GameObject ob in rocks)
        {
            if (ob.gameObject.GetComponent<MetalRockScript>().isItOver == false)
            {
                rockDebris.Play();
                numberOfActiveRocks += 1;
                ob.gameObject.GetComponent<MetalRockScript>().HitRock();
                ob.gameObject.GetComponent<spawnResources>().SpawnResource();
            }

        }
    }
    public void HitCrystal()
    {

        numberOfActiveCrystals = 0;

        foreach (GameObject ob in crystals)
        {
            if (ob.gameObject.GetComponent<CrystalResourceScript>().isItOver == false)
            {
                crystalDebris.Play();
                numberOfActiveCrystals += 1;
                ob.gameObject.GetComponent<CrystalResourceScript>().HitCrystal();
                ob.gameObject.GetComponent<spawnResources>().SpawnResource();
            }

        }
    }
    //отнимаем необходимое количество ресурсов
    public void WoodResMinus(int minus)
    {
        woodRes -= minus;
        SaveRes();
    }
    
    public void MetalResMinus(int minus)
    {
        metalRes -= minus;
        SaveRes();
    }

    public void AddResources()
    {
        woodRes += 100;
        SaveRes();
    }
    // сохраняем новые ресы
    public void SaveRes()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Resources.dat");
        SaveData data = new SaveData();
        data.woodRes = woodRes;
        data.metalRes = metalRes;
        data.cristallRes = cristallRes;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
    //показываем актуальные ресурсы
    public void LoadRes()
    {
        if (File.Exists(Application.persistentDataPath + "/Resources.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Resources.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            woodRes = data.woodRes;
            metalRes = data.metalRes;
            cristallRes = data.cristallRes;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}

[Serializable]
class SaveData
{
    public int woodRes;
    public int metalRes;
    public int cristallRes;
}