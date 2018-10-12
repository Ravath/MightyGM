using Core.Data;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.UI
{
	/// <summary>
	/// An interface component used to display informations about a model object from the RPG data.
	/// </summary>
	/// <typeparam name="T">The type of object to display.</typeparam>
	public abstract class FicheModel<T> : Entity where T : DataModel
	{
		private T _model;
		public T DisplayedModel
		{
			get { return _model; }
		}

		public FicheModel(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
		}

		public void SetDisplayedModel(T model)
		{
			if (_model == model) { return; }
			else { _model = model; }

			if (model == null)
			{
				SetNoObject();
			}
			else
			{
				SetModel(model);
			}
		}

		protected abstract void SetModel(T model);

		protected abstract void SetNoObject();
	}

	public static class ListBuilder
	{
		public static void AddItem(this StringBuilder sb, string newItem)
		{
			sb.AppendFormat("\n - {0}", newItem);
		}
	}
}
