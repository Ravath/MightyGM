namespace StarWars.Data {
	public enum Faces{
		Triomphe, Succes, Avantage, Desastre, Echec, Menace, Neutre}

	public enum TypeObject{
		Communication, Detection, Medical, Survie, Outil, Explosif, Kit, Armure, Arme, Cybernetique, Substance, Divertissement, Securite, Divers}

	public enum TypeArme{
		Energetique, Percussion, Grenade, Missile, Pugilat, CaC, Jet, Autres}

	public enum Portee{
		Cac, Courte, Moyenne, Longue, Exteme}

	public enum CompetenceDeCombat{
		Pugilat, Cac, Legere, Lourde, Artillerie}

	public enum TypeCompetence{
		Generale, Connaissance, Combat}

	public enum Caracteristique{
		Vigueur, Agilite, Intelligence, Ruse, Volonte, Presence, Force}

	public enum TypeKit{
		Arme, Armure, Vehicule, ArmeVehicule}

	public enum Endomagement{
		Intact, Legers, Moderes, Graves, Detruit}

	public enum Action{
		Aucune, Broutille, Manoeuvre, Action}

	public enum ArcTir{
		Avant, Arriere, Cotes, Babord, Tribord, Tous, BabordAvant, BabordArriere, TribordAvant, TribordArriere}

	public enum TypeCapaciteForce{
		Base, Puissance, Amplitude, Duree, Portee, Controle}

	public enum DifficulteTest{
		Simple, Facile, Moyenne, Difficile, Intimidante, Exceptionelle}

	public enum RangAdversaire{
		Sbire, Rival, Nemesis}

	public enum Fortune{
		Neutre, Avantage, Succes, SuccesAvantage, DoubleSucces}

	public enum Desavantage{
		Neutre, Menace, Echec}

	public enum Aptitude{
		Neutre, Avantage, Succes, SuccesAvantage, DoubleSucces, DoubleAvantage}

	public enum Difficulte{
		Neutre, Menace, Echec, DoubleEchec, DoubleMenace, EchecMenace}

	public enum Maitrise{
		Neutre, Avantage, Su, DoubleSucces, DoubleAvantage, Triomphe}

	public enum Defi{
		Neutre, Menace, Echec, DoubleEchec, DoubleMenace, EchecMenace, Desastre}

	public enum TypeVehicule{
		Airspeeder, Landspeeder, VehiculeARoue, Marcheur, Chasseur, Cargo, Capital}

}
