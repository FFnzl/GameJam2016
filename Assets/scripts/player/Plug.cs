using UnityEngine;
using System.Collections;

public class Plug : MonoBehaviour
{
	public Transform CablePosition { get; private set; }
	public DistanceJoint2D DistanceJoint { get; private set; }
	public HingeJoint2D HingeJoint { get; private set; }
	public Rigidbody2D Body { get; private set; }

	public bool IsConnected { get; private set; }

	[SerializeField]
	private GameObject _noEnergyIcon;

	private Socket _currentSocket;
	private bool _onSocket;
	private Socket _touchingSocket;
	private VacuumSounds _vacuumSounds;
	private PlugSounds _plugSounds;

	private void Start()
	{
		Body = GetComponent<Rigidbody2D>();

		DistanceJoint = GetComponent<DistanceJoint2D>();
		HingeJoint = GetComponent<HingeJoint2D>();

		_vacuumSounds = FindObjectOfType<VacuumSounds>();
		_plugSounds = FindObjectOfType<PlugSounds>();
	}


	public void PickUp()
	{
		if (IsConnected)
		{
			_currentSocket.Disconnect();
		}
		else
		{
			_plugSounds.PickUp();
		}
	}

	public void Drop()
	{
		if (_onSocket)
		{
			Connect();
		}
		else
		{
			_plugSounds.Drop();
		}
	}

	private void Connect()
	{
		_touchingSocket.ConnectPlug(this);
		_currentSocket = _touchingSocket;
		IsConnected = true;

		_vacuumSounds.ConnectedPlug();
		_plugSounds.Connect();

		if (_noEnergyIcon != null) _noEnergyIcon.SetActive(!IsConnected);
	}

	public void Disconnect()
	{
		_currentSocket = null;
		IsConnected = false;

		_vacuumSounds.DisconnectedPlug();
		_plugSounds.Disconnect();

		if (_noEnergyIcon != null) _noEnergyIcon.SetActive(!IsConnected);
	}

	private void OnTriggerEnter2D(Collider2D pOther)
	{
		if (pOther.tag == "Socket")
		{
			_onSocket = true;
			_touchingSocket = pOther.GetComponent<Socket>();
		}
	}

	private void OnTriggerExit2D(Collider2D pOther)
	{
		if (pOther.tag == "Socket")
		{
			_onSocket = false;
			_touchingSocket = null;
		}
	}
}
