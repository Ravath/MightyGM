using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreMono.TableTop.Graph.Shape;
using System.Reflection;
using GeonBit.UI.Entities.TextValidators;

namespace CoreMono.UI
{
	public class PropertyDisplay : Entity
	{
		public PropertyDisplay(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			
		}

		public void SetObject(Object o)
		{
			ClearChildren();

			AddObject(o);
		}

		public void AddObject(Object o)
		{
			if (o == null) { return; }

			foreach (var item in o.GetType().GetProperties())
			{
				AddProperty(item, o);
			}
		}

		public void AddProperty(PropertyInfo property, Object o)
		{
			// If can't read, nothing worth to do
			if (property.GetMethod == null) { return; }

			// If can't edit, just display value
			if (property.SetMethod == null)
			{
				AddChild(new Paragraph(property.Name));
				AddChild(new Label(property.GetValue(o).ToString()));
				return;
			}

			// Use of specific value editors

			if (property.PropertyType == typeof(string))
			{
				AddChild(new Paragraph(property.Name));
				AddChild(new TextInput(false)
				{
					Value = property.GetValue(o).ToString(),
					Validators = new List<ITextValidator>() { new SlugValidator() },
					OnValueChange = (e) =>
					{
						property.SetValue(o, ((TextInput)e).Value);
					}
				});
			}
			else if (property.PropertyType == typeof(int))
			{
				AddChild(new Paragraph(property.Name));
				AddChild(new TextInput(false) {
					Value = property.GetValue(o).ToString(),
					Validators = new List<ITextValidator>() { new TextValidatorNumbersOnly() },
					OnValueChange = (e) =>
					{
						if (int.TryParse(((TextInput)e).Value, out int value))
						{
							property.SetValue(o, value);
						}
					}
				});
			}
			else if (property.PropertyType.IsEnum)
			{
				AddChild(new Paragraph(property.Name));
				DropDown sl = new DropDown();
				sl.AddItem(Enum.GetNames(property.PropertyType));
				sl.SelectedIndex = (int)property.GetValue(o);
				sl.OnValueChange = (e) =>
				{
					if (sl.SelectedIndex == -1) { return; }
					property.SetValue(o, Enum.GetValues(property.PropertyType).GetValue(sl.SelectedIndex));
				};
				AddChild(sl);
			}
			else if (property.PropertyType == typeof(Color))
			{
				AddChild(new Paragraph(property.Name));
				ColorSelector cl = new ColorSelector((Color)property.GetValue(o), Color.Black, 0, new Vector2(40f))
				{
					OnValueChange = (e) =>
					{
						property.SetValue(o, ((ColorSelector)e).Value);
					}
				};
				AddChild(cl);
			}
			else if (property.PropertyType == typeof(bool))
			{
				bool initVal = (bool)property.GetValue(o);
				Button toogleButton = new Button(property.Name, ButtonSkin.Fancy, Anchor.AutoInline, new Vector2(220, 60))
				{
					ToggleMode = true,
					Checked = (bool)property.GetValue(o),
					OnClick = (e) =>
					{
						Button b = (Button)e;
						property.SetValue(o, b.Checked);
					}
				};
				AddChild(toogleButton);
			}
			else
			{
				AddChild(new Paragraph(property.Name));
			}
		}
	}
}
