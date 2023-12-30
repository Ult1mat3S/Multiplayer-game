#if UNITY_EDITOR
using ParrelSync;
using UnityEditor;
#endif
using UnityEngine;
using FishNet;
using FishNet.Transporting.Tugboat;
using FishNet.Transporting;

public class ConnectionStarter : MonoBehaviour
{
    private Tugboat _tugboat;
  
    private void OnEnable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState += OnClientConnectionState;
        Debug.Log("Subscribe to connection state");
    }

    private void OnDisable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState -= OnClientConnectionState;
        Debug.Log("Unsubscribe to connection state");
    }

    private void OnClientConnectionState(ClientConnectionStateArgs args)
    {
        if(args.ConnectionState == LocalConnectionState.Stopping)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    private void Start()
    {
        Debug.Log("Before TryGetComponent");
        if (TryGetComponent(out Tugboat _t))
        {
            _tugboat = _t;
            Debug.Log("Tugboat component found!");
        }
        else
        {
            Debug.LogError("Couldn't get tugboat!", this);
            return;
        }
        Debug.Log("After TryGetComponent");
#if UNITY_EDITOR
        if (ParrelSync.ClonesManager.IsClone())
        {
            _tugboat.StartConnection(false);
        }
        else
        {
            _tugboat.StartConnection(false);
            _tugboat.StartConnection(true);
        }
#endif
    }
}
