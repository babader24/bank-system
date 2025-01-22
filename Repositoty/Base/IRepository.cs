namespace Bank_Web_Project.Repositoty.Base
{
	public interface IRepository<T> where T : class
	{
		T FindByID(int id);

		T GetAll();

		T Add(T entity);

		T Update(int id);

		T Delete(int id);
	}
}
