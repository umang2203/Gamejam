using UnityEngine;
using System.Collections;

public class CharacterSpawner : MonoBehaviour {

    public GameObject Runner;
    public Camera mainCam;
    public GameObject world;
    GameObject runnerGO;

    void Start()
    {
        runnerGO = Instantiate(Runner);
        runnerGO.transform.SetParent(this.transform, false);
        runnerGO.name = "Runner";
        runnerGO.GetComponent<Runner>().OnRunnerDead += OnRunnerDead;
        mainCam.GetComponent<Camera2DFollow>().target = runnerGO.transform;
        world.GetComponent<World>()._runner = runnerGO.GetComponent<Runner>();

        runnerGO.SetActive(true);

    }

    void OnRunnerDead(GameObject go)
    {
        
        Vector3 pos = go.transform.localPosition - new Vector3(10,0,0);
        Destroy(go);

        runnerGO = Instantiate(Runner,pos,Runner.transform.localRotation) as GameObject;
        runnerGO.transform.SetParent(this.transform, false);
        runnerGO.name = "Runner";
        runnerGO.GetComponent<Runner>().OnRunnerDead += OnRunnerDead;
        mainCam.GetComponent<Camera2DFollow>().target = runnerGO.transform;
        world.GetComponent<World>()._runner = runnerGO.GetComponent<Runner>();
        runnerGO.SetActive(true);


    }


}
