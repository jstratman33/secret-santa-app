using System;
using System.Collections.Generic;
using System.Text;
using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.BusinessLogic.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group group);
        Group[] GetAll();
        Group GetById(long id);
        Group[] GetAllByUser(long userId);
        void Update(Group group);
        void Delete(long id);
    }
}
