namespace Core.Data {
	public interface IDataModel : IDataObject
	{
		string Name { get; set; }
		string Tag { get; set; }
		IDataDescription Description { get; }
	}
}