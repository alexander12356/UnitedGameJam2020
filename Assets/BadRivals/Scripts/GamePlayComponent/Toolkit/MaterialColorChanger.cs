using UnityEngine;

namespace BadRivals.Gameplay.Toolkit
{
	[ExecuteInEditMode]
	public class MaterialColorChanger : MonoBehaviour
	{
		private static readonly int ColorId = Shader.PropertyToID("_Color");

		private Material _material = null;
		private Color _prevColor = Color.black;

		[SerializeField] private Color _color = Color.black;

		private Material Material
		{
			get
			{
				if (_material == null)
				{
					_material = GetComponent<SpriteRenderer>().sharedMaterial;
				}

				return _material;
			}
		}

		public void Start()
		{
			_prevColor = _color;
		}

		private void Update()
		{
			if (_prevColor == _color)
			{
				return;
			}

			Material.SetColor(ColorId, _color);

			_prevColor = _color;
		}
	}
}
