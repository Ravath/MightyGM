namespace Pathfinder.Data {
	public enum Caracteristique{
		Force, Dexterite, Constitution, Intelligence, Sagesse, Charisme}

	public enum Sauvegarde{
		Reflexe, Vigueur, Volonte}

	public enum ProgessionSauvegarde{
		Faible, Forte}

	public enum ProgressionBBA{
		Faible, Moyenne, Elevee}

	public enum CategorieTaille{
		I, Min, TP, P, M, G, TG, Gig, Col}

	public enum AlignementLoi{
		Loyal, Neutre, Chaotique}

	public enum AlignementBien{
		Bon, Neutre, Mauvais}

	public enum TypeDon{
		General, Combat, Critique, Creation, Metamagie, Epique}

	public enum TypePouvoir{
		Magique, Surnaturel, Extraordinaire, Naturel}

	public enum TypeArme{
		Courante, Guerre, Exotique}

	public enum TypeDegatArme{
		Contondant, Perforant, Tranchant}

	public enum ManiementArme{
		MainsNues, Legere, UneMain, DeuxMains, Distance, TeteSecondaire}

	public enum CategorieArmure{
		Legere, Intermediaire, Lourde, Bouclier}

	public enum CategorieMateriel{
		Aventure, Substance, Competence, Vetement, Hebergement, Monture, Transport, Service}

	public enum EcoleMagie{
		Abjuration, Divination, Echantement, Evocation, Illusion, Invocation, Necromancie, Transmutation, Universelle}

	public enum BrancheMagie{
		Scrutation, Charme, Coercition, Chimere, Fantasme, Hallucination, Mirage, Ombre, Appel, Convocation, Creation, Guerison, Teleportation, Metamorphose}

	public enum Registre{
		Acide, Air, Bien, Chaos, Eau, Electricite, Feu, Force, Froid, Langage, Loi, Lumiere, Mal, Mental, Mort, Obscurite, Son, Terre, Terreur}

	public enum ComposanteSort{
		Verbale, Gestuelle, Materielle, Focalisateur, FocalisateurDivin, XP}

	public enum PorteeSort{
		Personelle, Contact, Courte, Moyenne, Longue, Illimitee, Metres, Special}

	public enum CibleSort{
		Creature, Objet, Conscentante}

	public enum EffetSauvegarde{
		Annule, Partiel, DemiDegats, Aucun, Devoile, Objet, Inoffensif, Special}

	public enum TempsIncantation{
		Rapide, Simple, Complexe, Round, Minute, Heure, Jour}

	public enum EffetKeyWord{
		Rayon, Emanation, Etendue, Cone, Cylindre, Ligne, Sphere, Creature, Objet, Cube3mCote, Autre}

	public enum DureeSort{
		Instantane, Permanente, Concentration, Utilisation, Round, Minute, Heure, Jour, Mois, Annee}

	public enum FrequencePouvoirMagique{
		UnParJour, DeuxParJour, TroisParJour, AVolonte, UnParSemaine, UnParMois, UnParAn}

	public enum UsageObjectMagique{
		FinIncantation, PotentielMagique, MotCommande, Usage}

	public enum EmplacementObjet{
		Armure, Tete, Front, Yeux, Cou, Epaules, Torse, Corps, Taille, Bras, Mains, Bouclier, Pied, Doigts}

	public enum PuissanceAura{
		Faible, Intermediaire, Forte, Surpuissante}

	public enum PuissanceObjet{
		Faible, Intermediaire, Puissant}

	public enum TypeObjetMagique{
		Courant, Maudit, Rare, Artefact}

	public enum TypePiege{
		Mecanique, MagObjet, MagSort}

	public enum DeclencheurPiege{
		Espace, Proximite, Sonore, Visuel, Contact, Minute, Sort}

	public enum RemisePiege{
		Aucune, Reparation, Manuelle, Automatique}

	public enum Desarmement{
		Rien, Verrou, Loquet, Autre}

	public enum TypeAffliction{
		Malediction, Maladie, Poison}

	public enum MilieuNaturel{
		Aquatique, Ciel, Collines, Desert, Foret, Marais, Montagnes, Plaines, Ruines, Souterrain, Ville}

	public enum Climat{
		Froid, Extraplanaire, Tempere, Tropical}

	public enum FrequenceAlignement{
		Toujours, Generalement, Souvent}

	public enum TypeParticularite{
		Aura, Sens, Deplacement, ParticulariteAttaque, AttaqueSpeciale, CapaciteSpeciale, Resistance, Immunite}

	public enum TypeTrait{
		Combat, Magie, Social, Racial, Regional, Religieux, Handicap}

	public enum TypeCode{
		General, Chevalerie, Criminel, Politique, Samourai, Tribal}

	public enum EditJourFerie{
		Aucun, Un, Six, Douze, VingtQuatre}

	public enum EditPublicitaire{
		Aucun, Discret, Normale, Agressif, Expansionniste}

	public enum EditTaxation{
		Aucun, Leger, Normal, Lourd, Ecrasant}

}
