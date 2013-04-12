namespace FirstAsp.NetMVCApp.Models
{
    class ToDoRepositoryLocator
    {
        private readonly static IToDoRepository Repo = new ToDoMemoryRepository();
        public static IToDoRepository Get()
        {
            return Repo;
        }
    }
}