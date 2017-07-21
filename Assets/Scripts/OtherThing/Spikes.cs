using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private Transform childTransfrom;
    private Constant spikesConstant;
    private Vector3 initPos;
    private Vector3 nextPos;
	void Start () {
        childTransfrom = transform.Find("spikes_b").GetComponent<Transform>();
        initPos = childTransfrom.position;
        if (transform.gameObject.tag == "SkySpikes")
        {
            nextPos = childTransfrom.position + new Vector3(0, 0.6f, 0);
        }
        if (transform.gameObject.tag == "Spikes")
        {
            nextPos = childTransfrom.position + new Vector3(0, 0.15f, 0);
        }
        spikesConstant = Constant.Instance();
        StartCoroutine("UpAndDown");
    }
	
	private IEnumerator UpAndDown()
    {
        while (true)
        {
            StopCoroutine("Down");
            StartCoroutine("Up");
            yield return new WaitForSeconds(spikesConstant.SPIKES_WAIT_TIME);
            StopCoroutine("Up");
            StartCoroutine("Down");
            yield return new WaitForSeconds(spikesConstant.SPIKES_WAIT_TIME);
        }
    }

    private IEnumerator Up()
    {
        while(true)
        {
            childTransfrom.position = Vector3.Lerp(childTransfrom.position, 
                nextPos,Time.deltaTime * spikesConstant.SPIKES_FALL_TIME);
            yield return null;
        }
    }
    private IEnumerator Down()
    {
        while (true)
        {
            childTransfrom.position = Vector3.Lerp(childTransfrom.position, 
                initPos, Time.deltaTime * spikesConstant.SPIKES_FALL_TIME);
            yield return null;
        }
    }
}
