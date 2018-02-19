using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Engine {

	public interface INamed {
		string Name { get; }
	}

	public interface ICapaciteActive<T> : ITargeting, INamed
			where T : ITargetable {
		void AffectSelf( T target );
		void AffectTarget( T caster, T target );
		void AffectTargets( T caster, IEnumerable<T> targets );
	}

	public interface ITrait<C> : INamed
			where C : IAgent {
		void AffectAgent( C a );
		void UnaffectAgent( C a );
	}

	/// <summary>
	/// classe de base de tous les objets, armes et autres du framework
	/// </summary>
	public interface IObject : INamed {

	}
	/// <summary>
	/// Objet pouvant être porté par un personnage.
	/// </summary>
	public interface IWearable : IObject {
		void Equiper( IAgent personnage );
		void Desequiper( IAgent personnage );
	}

	public delegate void SelectionChangedHandler( INamedCollection sender );

	public interface INamedCollection {
		IEnumerable<INamed> NamedCollection { get; }
        void RemoveNamed( INamed item );
        void AddNamed( INamed item );
		event SelectionChangedHandler SelectionChanged;
    }
}
