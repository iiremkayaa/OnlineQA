using Project.OnlineQA.Business.Interface;
using Project.OnlineQA.DataAccess.Interface;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.Business.Concrete
{
    public class SelectionService :GenericService<Selection>,ISelectionService
    {
        private readonly ISelectionRepository _selectionRepository;
        public SelectionService(ISelectionRepository selectionRepository,IGenericRepository<Selection> genericRepository):base(genericRepository)
        {
            _selectionRepository = selectionRepository;

        }
    }
}
