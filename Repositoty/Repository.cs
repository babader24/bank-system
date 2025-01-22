using Bank_Web_Project.Repositoty.Base;

namespace Bank_Web_Project.Repositoty
{
	public class Repository<T> : IRepository<T> where T : class
	{
		public T Add(T entity)
		{
			throw new NotImplementedException();
		}

		public T Delete(int id)
		{
			throw new NotImplementedException();
		}

		public T FindByID(int id)
		{
			throw new NotImplementedException();
		}

		public T GetAll()
		{
			throw new NotImplementedException();
		}

		public T Update(int id)
		{
			throw new NotImplementedException();
		}
	}
}
