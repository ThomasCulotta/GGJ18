using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Lens;
    public Material   MatW;
    public Material   MatE;
    public Material   MatS;
    public Material   MatN;

    public GameObject EnvW;
    public GameObject EnvE;
    public GameObject EnvS;
    public GameObject EnvN;

    private Renderer _lensRenderer;
    private bool _portalAvailable;

    private void Awake()
    {
        _lensRenderer = Lens.GetComponent<Renderer>();
        _portalAvailable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_portalAvailable)
        {
            EnvW.SetActive(other.name.Equals("TriggerW") ? true : false);
            EnvE.SetActive(other.name.Equals("TriggerE") ? true : false);
            EnvS.SetActive(other.name.Equals("TriggerS") ? true : false);
            EnvN.SetActive(other.name.Equals("TriggerN") ? true : false);

            switch (other.name)
            {
                case "TriggerW":
                    _lensRenderer.material = MatW;
                    break;
                case "TriggerE":
                    _lensRenderer.material = MatE;
                    break;
                case "TriggerS":
                    _lensRenderer.material = MatS;
                    break;
                case "TriggerN":
                    _lensRenderer.material = MatN;
                    break;
            }

            StartCoroutine(PortalCooldown());
        }
    }

    private IEnumerator PortalCooldown()
    {
        _portalAvailable = false;
        yield return new WaitForSeconds(3f);
        _portalAvailable = true;
    }
}
