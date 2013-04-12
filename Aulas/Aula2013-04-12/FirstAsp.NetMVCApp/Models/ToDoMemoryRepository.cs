namespace FirstAsp.NetMVCApp.Models
{
    using System.Collections.Generic;

    class ToDoMemoryRepository : IToDoRepository
    {
        private readonly IDictionary<int, ToDo> _repo = new Dictionary<int, ToDo>()
            {
                { 1, new ToDo { Id = 1, Description = "Todo 1" } },
                { 2, new ToDo { Id = 2, Description = "Todo 2" } },
                { 3, new ToDo { Id = 3, Description = "Todo 3" } }
            };
        private int _cid = 0;

        public IEnumerable<ToDo> GetAll()
        {
            return this._repo.Values;
        }

        public ToDo GetById(int id)
        {
            ToDo td = null;
            this._repo.TryGetValue(id, out td);
            return td;
        }

        public void Add(ToDo td)
        {
            td.Id = this._cid;
            this._repo.Add(this._cid++,td);
        }
    }
}