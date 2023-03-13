using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnResourcesFromThePlayer : MonoBehaviour
{
    public GameObject woodRes;
    public GameObject metalRes;

    public float shootForce = 5f;

    private float timeToNextSpawn;
    private float timeFromFirstTouch;

    public int woodInOneThrow = 1;
    public int metalInOneThrow = 1;

    private bool PlayerIn;
    private float spread;

    public SpotResourcesInfo spotInfo;

    //необходимая задержка между летящими ресурсами (сначала ресурсы будут перекидываться медленно (slowdelay), затем быстрее (fastdelay))
    private float SlowDelay;
    private float FastDelay;

    // Start is called before the first frame update
    void Start()
    {
        spread = spotInfo._spreadOfTheResources;
        SlowDelay = spotInfo._slowDelay;
        FastDelay = spotInfo._fastDelay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //обеспечиваем периодичность перекидывания ресурсов
        timeToNextSpawn -= 1f;

        if(PlayerIn == true)
        {
            timeFromFirstTouch += 1;
        }
        else
        {
            timeFromFirstTouch = 0f;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if((other.gameObject.name == "SpotWood" || other.gameObject.name == "SpotMetal") && other.gameObject.GetComponent<SpotScript>().isItReadyToStartCooking == false && timeToNextSpawn <= 0 && gameObject.GetComponent<PlayerController>().isItRunning == false)
        {
            //проверяем, прошло ли нужное время до скоростного режима
            if (timeFromFirstTouch < 200)
            {
                timeToNextSpawn = 50f * SlowDelay;
            }
            else if (timeFromFirstTouch >= 200)
            {
                timeToNextSpawn = 50f * FastDelay;
            }

            //расчитываем вектор до спота
            Vector3 directionWithoutSpread = other.gameObject.transform.position - gameObject.transform.position;

            //задаем рандомный разброс
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            //Calculate new direction with spread
            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);
            if(other.gameObject.name == "SpotWood" && gameObject.GetComponent<PlayerResourcesScript>().woodRes > 0)
            {
                //отнимаем выпущенный ресурс от общего числа ресов
                gameObject.GetComponent<PlayerResourcesScript>().WoodResMinus(woodInOneThrow);
                //создаем ресурс
                GameObject resourceExisted = Instantiate(woodRes, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
                //задаем импульс нашему ресурсу
                resourceExisted.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            }
            else if(other.gameObject.name == "SpotMetal" && gameObject.GetComponent<PlayerResourcesScript>().metalRes > 0)
            {
                //отнимаем выпущенный ресурс от общего числа ресов
                gameObject.GetComponent<PlayerResourcesScript>().MetalResMinus(metalInOneThrow);
                //создаем ресурс
                GameObject resourceExisted = Instantiate(metalRes, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
                //задаем импульс нашему ресурсу
                resourceExisted.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //начинаем отсчет до скоростного режима
        if(other.gameObject.name == "SpotWood" || other.gameObject.name == "SpotMetal")
        {
            PlayerIn = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        //сбрасываем отсчет до скоростного режима
        if (other.gameObject.name == "SpotWood" || other.gameObject.name == "SpotMetal")
        {
            PlayerIn = false;
        }

    }
}
