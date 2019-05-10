using System;
using System.Collections.Generic;
using System.Linq;
using SecretSantaApp.BusinessLogic.Services.Interfaces;
using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.BusinessLogic.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;
        private readonly IListItemRepository _listItemRepository;

        public ListService(
            IListRepository listRepository,
            IListItemRepository listItemRepository)
        {
            _listRepository = listRepository;
            _listItemRepository = listItemRepository;
        }

        public void Create(List list)
        {
            _listRepository.Create(list);
        }

        public List[] GetAllByOwner(long ownerId)
        {
            return _listRepository.GetAllByOwnerId(ownerId);
        }

        public List[] GetAllByGroup(long id)
        {
            return _listRepository.GetAllByGroupId(id);
        }

        public List GetOne(long id)
        {
            return _listRepository.Get(id);
        }

        public void Update(List list)
        {
            var entity = GetOne(list.Id);
            entity.Name = list.Name;
            entity.IsPrimary = list.IsPrimary;
            _listRepository.SaveChanges();

            var entityItemIds = entity.Items.Select(x => x.Id).ToArray();
            foreach (var entityItemId in entityItemIds)
            {
                if (!list.Items.Any(x => x.Id == entityItemId))
                {
                    var entityToDelete = _listItemRepository.First(x => x.Id == entityItemId);
                    _listItemRepository.Delete(entityToDelete);
                }
            }

            foreach (var listItem in list.Items)
            {
                var existingItem = _listItemRepository.First(x => x.Id == listItem.Id);
                if (existingItem == null)
                {
                    _listItemRepository.Create(listItem);
                    continue;
                }

                existingItem.Description = listItem.Description;
                existingItem.IsPurchased = listItem.IsPurchased;
                _listItemRepository.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var entity = GetOne(id);
            var listItemIds = entity.Items.Select(x => x.Id).ToArray();
            foreach (var itemId in listItemIds)
            {
                var entityToDelete = _listItemRepository.First(x => x.Id == itemId);
                _listItemRepository.Delete(entityToDelete);
            }
            _listRepository.Delete(entity);
        }

        public void AssignListsToSantas(long groupId)
        {
            var groupLists = GetAllByGroup(groupId).ToList();
            var finished = false;
            while (!finished)
            {
                foreach (var list in groupLists)
                {
                    var listPool = groupLists
                        .Where(x => x.Id != list.Id && x.OwnerId != list.OwnerId && x.SantaId == 0).ToArray();
                    if (listPool.Length == 0) break;
                    var random = new Random();
                    var index = random.Next(listPool.Length);
                    var randomList = listPool[index];
                    randomList.SantaId = list.Id;
                }

                finished = groupLists.All(x => x.SantaId != 0);
            }

            _listRepository.SaveChanges();
        }
    }
}