using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public bool isTutorialNeeded;

    public GameObject TutorialSurrondings;
    public GameObject NormalSurrondings;

    public GameObject Player;

    private int woodResNumOld;
    private int woodResNumNew;
    private int metalResNumOld;
    private int metalResNumNew;

    public GameObject TreeCanvas;
    public GameObject SpotCanvas;
    public GameObject TutorialFinishImage;
    public GameObject TargetIndicator;

    public Transform SpotTarget;

    private bool checkIsItFirstTimeWoodNewBiggerOld;
    private bool checkMetalNewAndOld;

    // Start is called before the first frame update
    void Start()
    {
        
        if (isTutorialNeeded)
        {
            TargetIndicator.SetActive(true);
            TutorialSurrondings.SetActive(true);
            NormalSurrondings.SetActive(false);
        }
        else if (!isTutorialNeeded)
        {
            TutorialSurrondings.SetActive(false);
            NormalSurrondings.SetActive(true);
        }
        woodResNumOld = Player.gameObject.GetComponent<PlayerResourcesScript>().woodRes;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        woodResNumNew = Player.gameObject.GetComponent<PlayerResourcesScript>().woodRes;
        metalResNumNew = Player.gameObject.GetComponent<PlayerResourcesScript>().metalRes;
        if (woodResNumNew > woodResNumOld && checkIsItFirstTimeWoodNewBiggerOld == false)
        {
            woodResNumOld = woodResNumNew;
            checkIsItFirstTimeWoodNewBiggerOld = true;
        }
        else if(woodResNumNew > woodResNumOld && checkIsItFirstTimeWoodNewBiggerOld == true)
        {
            TreeCanvas.SetActive(false);
            SpotCanvas.SetActive(true);
            Player.GetComponent<PlayerController>().ChangeTarget(SpotTarget);
        }

        if (metalResNumNew > metalResNumOld && checkMetalNewAndOld == false)
        {
            metalResNumOld = metalResNumNew;
            checkMetalNewAndOld = true;
        }
        else if(metalResNumNew > metalResNumOld && checkMetalNewAndOld == true)
        {
            TutorialFinishImage.SetActive(true);
            Invoke("TutEnd", 4f);
        }
    }

    void TutEnd()
    {
        TargetIndicator.SetActive(false);
        TutorialFinishImage.SetActive(false);
        NormalSurrondings.SetActive(true);
        TutorialSurrondings.SetActive(false);

    }
}
