using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private bool isTimerON = false;
    [SerializeField] private bool isSwitchON = false;
    [SerializeField] private int timer = 90;
    [SerializeField] private GameObject switchClone;

    [SerializeField] private bool isSwitchBtnActivate = false;

    public Material[] switchMats;
    private Renderer targetRenderer;


    // Start is called before the first frame update
    void Start()
    {
        targetRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    /*
    IEnumerator SwitchTimer()
    {
        while(true)
        {
            if (timer > 0)
            {
                timer--;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                timer = 90;
                targetRenderer.material = switchMats[1];
                isSwitchON = true;
                break;
            }
        }
    }
    */

    private void SwitchControll()
    {
        if (!isTimerON)
        {
            StartCoroutine("SwitchTimer");
            isTimerON = true;
        }
    }

    public void viewPreview()
    {
        //Debug.Log("!@!@!");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mousePos = hit.point;
            mousePos.y = 0;
            switchClone.transform.position = mousePos;
        }
    }


    public void CreateNewSwitch()
    {
        isSwitchBtnActivate = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (isSwitchBtnActivate)
        {
            //Debug.Log("@@@");
            viewPreview();
        }
    }
}