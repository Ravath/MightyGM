using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWpf.UI
{
	public interface IFiche
	{
		object SelectedObject { get; set; }
	}
	/// <summary>
	/// Doit afficher un object de type T dans une fiche dans l'interface.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IFiche<T> : IFiche
	{
		new T SelectedObject { get; set; }
	}
	/// <summary>
	/// Fiche d'affichage d'une liste d'objets
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IFicheListe<T>
	{
		IEnumerable<T> Items { get; set; }
		IEnumerable<T> SelectedItems { get; }
	}
}
