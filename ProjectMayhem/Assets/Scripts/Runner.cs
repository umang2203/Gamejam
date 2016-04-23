using UnityEngine;
using System.Collections;

enum RunnerState
{
    Running,
    Jumping,
    Dieing,
    Dead,
    Idel
}

public class Runner : MonoBehaviour {

    Animator            _animator;
    RunnerState         _state;
    private Vector3     _lastCamPos;

    public float        runningSpeed = 1f;
    public float        jumpDistance = 10f;
    Vector3     _direction;
    public float        jumpTime;

    public GameObject camera;
	
	void Start () 
    {
        _state = RunnerState.Idel;
        _animator = GetComponent<Animator>();
        _direction = new Vector3(1f,0,0);
        Run();
	}
	
    void Update()
    {
        if(_state == RunnerState.Running || _state == RunnerState.Jumping)
        {
            transform.Translate(_direction * runningSpeed);
//            camera.transform.Translate(_direction * runningSpeed);
        }
    }

    public void Jump()
    {
        if(_state == RunnerState.Running)
        {
         _animator.SetTrigger("Jump");
            StartCoroutine(JumpCoroutine());
        }
        
    }

    public void Run()
    {
        if(_state != RunnerState.Running)
            _animator.SetTrigger("Run");
    }

    public void Hit()
    { 
        _animator.SetTrigger("Die");
    }
        


    //Animation Trigger callbacks
    public void OnJump_Started()
    {
        Debug.Log("Jumping");
        _state = RunnerState.Jumping;
        _direction = new Vector3(2f, jumpDistance, 0f);
    }
    public void OnJump_Halfway()
    {
        _direction = new Vector3(2f, -jumpDistance, 0f);
    }
    public void OnRun_Started()
    {
        if(_state != RunnerState.Running)
        {
            Debug.Log("Running");
            _state = RunnerState.Running;
            _direction = new Vector3(1f,0f,0f);
//            transform.localPosition = new Vector3(transform.localPosition.x, 0f, 0f);
//            camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, 0f, -10f);
        }
    }
    public void OnDieing_Started()
    {
        if(_state == RunnerState.Running)
        {
            Debug.Log("Dieing");
            _state = RunnerState.Dieing;
        }
    }
  
    public void OnDead_Started()
    {
        if(_state == RunnerState.Dieing)
        {
            Debug.Log("Dead");
            _state = RunnerState.Dead;
        }
    }

    private IEnumerator JumpCoroutine()
    {
        float time = 0;

        float NormalizeTime;
        Vector3 startPos = this.transform.localPosition;
        Debug.Log(startPos);
        bool Jumping = true;
        while(Jumping)
        {
            time += Time.deltaTime;
            NormalizeTime = time/jumpTime;

            if(NormalizeTime < 0.5f)
            {
                
                transform.localPosition = Vector3.Lerp(startPos,startPos + new Vector3(5,jumpDistance,0),NormalizeTime*2);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(startPos + new Vector3(5f,jumpDistance,0),startPos + new Vector3(10f,0,0), ((NormalizeTime*2) -1));
                Debug.Log(transform.localPosition);
            }

            if(NormalizeTime >=  1)
                Jumping = false;

            yield return null;
//            Jumping = false;
        }

        _animator.SetTrigger("End");



    }

}
