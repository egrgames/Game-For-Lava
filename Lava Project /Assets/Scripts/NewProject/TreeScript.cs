using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public List<GameObject> treeParts = new List<GameObject>();
    public ParticleSystem woodDebris;
    private float TreeHealth = 150f;
    private int NumberOfHitToZeroHealth;
    private float TimeToRegenerateInSec;
    public bool IsPlayerIn = false;

    public bool isItOver;

    public SourceInfo sourceInfo;
    // Start is called before the first frame update
    void Start()
    {
        TimeToRegenerateInSec = sourceInfo.TimeToRegenerateInSec;
        NumberOfHitToZeroHealth = sourceInfo.NumberOfHitToZeroHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Проверяет, нужно ли ребилдить дерево и с какой скоростью это делать относительно введенных данных
        if(TreeHealth < 150f && IsPlayerIn == false)
        {
            TreeHealth += 3/TimeToRegenerateInSec;
        }

        // включаем то состояение дерева, сколько здоровья у него осталось
        if (TreeHealth < 150f && TreeHealth > 100f)
        {
            foreach (GameObject ob in treeParts)
            {
                ob.SetActive(false);
            }
            treeParts[0].SetActive(true);
            isItOver = false;
        }
        else if (TreeHealth <= 100f && TreeHealth > 50f)
        {

            foreach (GameObject ob in treeParts)
            {
                ob.SetActive(false);
            }
            treeParts[1].SetActive(true);
            isItOver = false;
        }
        else if (TreeHealth <= 50f && TreeHealth > 0)
        {

            foreach (GameObject ob in treeParts)
            {
                ob.SetActive(false);
            }
            treeParts[2].SetActive(true);
            isItOver = false;
        }
        else if (TreeHealth <= 0)
        {
            foreach (GameObject ob in treeParts)
            {
                ob.SetActive(false);
            }
            treeParts[3].SetActive(true);
            isItOver = true;
        }
    }
    //отнимаем от дерева здоровье при ударе
    public void HitTree()
    {
        if (TreeHealth > 0f)
        {
            TreeHealth -= (150/NumberOfHitToZeroHealth);
        }
        
    }
    //если игрок рядом с деревом, то отмечаем булом, что так и есть и наоборот
    public void PlayerIn()
    {
        IsPlayerIn = true;
    }
    public void PlayerOut()
    {
        IsPlayerIn = false;
    }
}
