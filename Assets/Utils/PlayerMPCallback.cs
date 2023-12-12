using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMPCallback : MonoBehaviour
{
    // Start is called before the first frame update

    private const string propertyName = "_GrayStrength";
    private const string propertyName2 = "_ShakeStrength";

    [SerializeField]
    private GameObject filter;


    private void Awake()
    {
        MP mp = gameObject.GetComponent<MP>();
        mp.OnChangeHandler += OnMPChange;
    }

    void OnMPChange(object target,int value)
    {
        float f = (float) value/((MP)target).GetMaxMP();
        var material = filter.GetComponent<Renderer>().material;
        if (material.HasProperty(propertyName))
        {
            material.SetFloat(propertyName, Mathf.Max(0, 1 - f - 0.2f));
            material.SetFloat(propertyName2, Mathf.Max(0, 1 - f - 0.2f));
        }
        else
        {
            Debug.Log(propertyName+" was not found in filter renderer");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
