using DG.Tweening;

using UnityEngine;

using Zenject;

namespace BadRivals.MainMenuComponent.Animator
{
	public class WindowShowAnimator : MonoBehaviour, IWindowShowAnimator
	{
		[Header("References")]
		[SerializeField] private RectTransform _showTargetTransform = null;
		[SerializeField] private RectTransform _hideTargetTransform = null;

		[Header("Parameters")]
		[SerializeField] private float _moveDuration = 0f;

		[Inject] private readonly IMainMenuCameraController _mainMenuCameraController = null;

		private Sequence _showSequence = null;
		private Sequence _hideSequence = null;

		private void Start()
		{
			InitShowSequence();
			InitCloseSequence();
		}

		private void OnDestroy()
		{
			_showSequence.Kill();
			_showSequence = null;

			_hideSequence.Kill();
			_hideSequence = null;
		}

		public void Show()
		{
			_showSequence.Restart();
		}

		public void Close()
		{
			_hideSequence.Restart();
		}

		private void InitShowSequence()
		{
			var cameraTransform = _mainMenuCameraController.GetCameraTransform();

			var position = _showTargetTransform.position;
			var targetPosition = new Vector3(position.x, position.y, cameraTransform.position.z);

			_showSequence = DOTween.Sequence();
			_showSequence
				.Append(cameraTransform.DOMove(targetPosition, _moveDuration));
		}

		private void InitCloseSequence()
		{
			var cameraTransform = _mainMenuCameraController.GetCameraTransform();

			var position = _hideTargetTransform.position;
			var targetPosition = new Vector3(position.x, position.y, cameraTransform.position.z);

			_hideSequence = DOTween.Sequence();
			_hideSequence
				.Append(cameraTransform.DOMove(targetPosition, _moveDuration));
		}
	}
}