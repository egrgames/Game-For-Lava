using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class PointerForTutorial : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Camera _camera;
    [SerializeField] Transform _pointerIconTransform;
    public GameObject _icon;
    private float dist0;
    private float dist1;
    private float dist1devidedist0;
    void Start(){
        dist0 = Vector3.Distance(gameObject.transform.position, _playerTransform.position);
    }
    // Update is called once per frame
    void Update()
    {
        dist1 = Vector3.Distance(gameObject.transform.position, _playerTransform.position);
        dist1devidedist0 = 1.5f - dist1/dist0;
        /*if(dist1devidedist0>=0.1f){
             _icon.transform.localScale = new Vector3(dist1devidedist0, dist1devidedist0, dist1devidedist0);
        }
        else{
            _icon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }*/
       
        Vector3 fromPlayerToEnemy = transform.position - _playerTransform.position;
        Ray ray = new Ray(_playerTransform.position, fromPlayerToEnemy);
        Debug.DrawRay(_playerTransform.position, fromPlayerToEnemy);

        Vector3 toEnemy = gameObject.transform.position - _playerTransform.position;
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

        float rayMinDistance = Mathf.Infinity;

        float minDistance = Mathf.Infinity;
        int planeIndex = 0;

        for(int i = 0; i<4;i++)
        {
            if(planes[i].Raycast(ray, out float distance))
            {
                if(distance < minDistance)
                {
                    minDistance = distance;
                    rayMinDistance = distance;
                    planeIndex = i;
                }

            }
        }

        minDistance = Mathf.Clamp(minDistance, 0, fromPlayerToEnemy.magnitude);

        Vector3 worldPosition = ray.GetPoint(minDistance);

        _pointerIconTransform.position = _camera.WorldToScreenPoint(worldPosition);
        _pointerIconTransform.rotation = GetIconRotation(planeIndex);
        //Debug.Log(planeIndex);

        if(toEnemy.magnitude > rayMinDistance)
        {
            _icon.SetActive(true);
        }
        else{
            _icon.SetActive(false);
        }
    }

    Quaternion GetIconRotation(int planeIndex)
    {
        if(planeIndex == 0){
        return Quaternion.Euler(0f,0f,90f);
        }
        else if(planeIndex == 1){
        return Quaternion.Euler(0f,0f,-90f);
        }
        else if(planeIndex == 2){
        return Quaternion.Euler(0f,0f,180f);
        }
        else if(planeIndex == 3){
        return Quaternion.Euler(0f,0f,0f);
        }
        return Quaternion.identity;
    }
}
