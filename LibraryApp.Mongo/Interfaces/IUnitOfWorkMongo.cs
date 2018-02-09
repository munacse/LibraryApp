namespace LibraryApp.Mongo.Interfaces
{
    public interface IUnitOfWorkMongo
    {
        IProductRepository ProductRepository { get; }

        INoteRepository NoteRepository { get; }

        IEmployeeRepository EmployeeRepository { get; }
    }
}
